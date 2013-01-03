using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingManagement.Accounts;
using ParkingManagement;
using System.Data.Linq;
using System.Windows.Forms;
using ParkingManagement.Exceptions;
using ParkingManagement.ParkingManagementDataSetTableAdapters;
using System.Data;
using ParkingManagement.External;

namespace ParkingManagement.Database
{
    // Database for the Parking Management system
    public class ParkingDatabase
    {
        public const decimal HOURLY_RATE = 10m;
        public const int NUM_PARKING_SPOTS = 100;
        public IClock DatabaseClock { get; set; }
        public IMailer Mailer { get; set; }
        Random rand = new Random();

        public decimal HourlyRate
        {
            get { return HOURLY_RATE; }
        }

        // table adapaters to be used in the database
        CustomerTableAdapter customerTableAdapater;
        VehicleTableAdapter vehicleTableAdapater;
        CustomerVehicleTableAdapter customerVehicleTableAdapter;
        ReservationTableAdapter reservationTableAdapter;
        CreditCardTableAdapter cardTableAdapter;
        CustomerCreditCardTableAdapter customerCardTableAdapter;
        TransactionTableAdapter transactionTableAdapater;
        ParkingSpotTableAdapter parkingSpotTableAdapter;

        // constructor
        public ParkingDatabase(IClock clock, IMailer mailer)
        {
            customerTableAdapater = new CustomerTableAdapter();
            vehicleTableAdapater = new VehicleTableAdapter();
            customerVehicleTableAdapter = new CustomerVehicleTableAdapter();
            reservationTableAdapter = new ReservationTableAdapter();
            cardTableAdapter = new CreditCardTableAdapter();
            customerCardTableAdapter = new CustomerCreditCardTableAdapter();
            transactionTableAdapater = new TransactionTableAdapter();
            parkingSpotTableAdapter = new ParkingSpotTableAdapter();
            DatabaseClock = clock;
            Mailer = mailer;
        }

        // add an customer account to the database
        public void AddAccount(CustomerAccount account)
        {
            try
            {
                // insert customer into table
                int custID = Convert.ToInt32(customerTableAdapater.InsertAndGetID(account.LastName, account.FirstName, account.PhoneNumber,
                     account.EmailAddress, account.Password));

                // set customer ID that was retrieved from the database
                account.CustomerID = custID;
            }
            catch (Exception)
            {
                throw new CreateAccountException("Could not add customer data to database.");
            }
        }

        // attempt to login an admin account (verifies credentials)
        public bool LoginAdmin(Account accountSent)
        {
            bool loginSuccess = false;
            try
            {
                // Query for customers with given email
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Admin> Admins = db.GetTable<Admin>();
                var query =
                    from admin in Admins
                    where admin.Email.Equals(accountSent.EmailAddress) && admin.Password.Equals(accountSent.Password)
                    select admin;

                // check if any results were found
                if (query.Any())
                {
                    loginSuccess = true;
                }

            }
            catch (Exception)
            {
                // login failed
            }

            return loginSuccess;
        }

        // attempt to login a customer account (verifies credentials)
        public Customer LoginCustomer(Account account)
        {
            Customer custToGet = null;
            try
            {
                // Query for customers with given email
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Customer> Customers = db.GetTable<Customer>();
                var query =
                    from cust in Customers
                    where cust.Email.Equals(account.EmailAddress) && cust.Password.Equals(account.Password)
                    select cust;

                // check if any results were found
                if (query.Any())
                {
                    custToGet = query.First();
                }
                else
                {
                    throw new AccountException("Account with given email and password could not be found.");
                }
            }
            catch (Exception)
            {
                throw new AccountException("Attempt to retrieve customer using database failed.");
            }

            return custToGet;
        }

        // add a vehicle to the database and map it to a customer
        public void AddVehicle(Accounts.Vehicle auto, int custID)
        {
            try
            {
                // insert vehicle into table
                int vehicleID = Convert.ToInt32(vehicleTableAdapater.InsertAndGetID(auto.CarModel,
                    auto.LicensePlateID.ToString()));

                // set vehicle ID
                auto.CarID = vehicleID;

                // inster customer-vehicle mapping
                customerVehicleTableAdapter.Insert(custID, vehicleID);
            }
            catch (Exception)
            {
                throw new VehicleException("Could not add vehicle to database.");
            }
        }

        // Get a list of vehicles for a customer from the database
        // source: http://stackoverflow.com/questions/1094931/linq-to-sql-how-to-select-specific-columns-and-return-strongly-typed-list
        // source: http://stackoverflow.com/questions/4115321/linq-to-sql-join
        public List<Accounts.Vehicle> GetVehicles(int customerID)
        {
            List<Accounts.Vehicle> vehicleList = null;
            try
            {
                // Query for relevant vehicles
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<CustomerVehicle> CustomerVehicles = db.GetTable<CustomerVehicle>();
                Table<Vehicle> Vehicles = db.GetTable<Vehicle>();
                var result =
                    from vehicle in Vehicles
                    join custVehicle in CustomerVehicles on vehicle.VehicleID equals custVehicle.VehicleID
                    where custVehicle.CustomerID == customerID
                    select new { vehicle.CarModel, vehicle.LicensePlateID, vehicle.VehicleID };

                // if no registered vehicles, throw an exception
                if (!result.Any())
                {
                    throw new VehicleException("No registered vehicles.");
                }

                // convert LINQ-to-SQL result list to a vehicle list
                vehicleList = result.AsEnumerable()
                    .Select(o => new Accounts.Vehicle
                    {
                        CarModel = o.CarModel,
                        LicensePlateID = o.LicensePlateID,
                        CarID = o.VehicleID
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw new VehicleException(ex.Message);
            }

            return vehicleList;
        }

        // Get a list of available parking spots for the given reservation period
        public List<Garage.ParkingSpot> GetAvailableParkingSpots(ParkingReservation desiredReservation)
        {
            List<Garage.ParkingSpot> spotList = null;
            try
            {
                // Query for spots that are not reserved during given time
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Reservation> Reservations = db.GetTable<Reservation>();
                Table<ParkingSpot> ParkingSpots = db.GetTable<ParkingSpot>();

                var unavailableSpots =
                    from spot in ParkingSpots
                    join res in Reservations on spot.ParkingSpotID equals res.ParkingSpotID
                    // if res start < desred start && res end >= desired start, then no
                    where ((res.DateTime < desiredReservation.Date) &&
                        res.DateTime.AddMinutes(res.DurationMinutes) >= desiredReservation.Date) ||
                        // if res start = des start, then no
                   (res.DateTime == desiredReservation.Date) ||
                        // res start > des start && res start <= des end, then no
                    ((res.DateTime > desiredReservation.Date) &&
                        res.DateTime <= desiredReservation.ReservationEndTime) ||
                        // must be available
                    res.ParkingSpot.AvailabilityStatus != 0
                    select spot;

                // get those spots not found in the above list
                var result =
                    from spot in ParkingSpots
                    where !unavailableSpots.Contains(spot)
                    select new { spot.ParkingSpotID, spot.AvailabilityStatus };

                // if none available, throw an exception
                if (!result.Any())
                {
                    throw new ParkingSpotException("No available parking spots during the specified time period.");
                }

                // convert LINQ-to-SQL result list to a parking spot list
                spotList = result.AsEnumerable()
                    .Select(o => new Garage.ParkingSpot
                    {
                        ParkingSpotID = o.ParkingSpotID,
                        AvailabilityStatus = (Garage.ParkingSpot.Availibility)o.AvailabilityStatus
                    }).ToList();

            }
            catch (Exception)
            {
                throw new ParkingSpotException("Attempt to get available parking spots failed.");
            }

            return spotList;
        }

        // get a list of all parking spots in the database
        public List<Garage.ParkingSpot> GetParkingSpots()
        {
            List<Garage.ParkingSpot> spotList = null;
            try
            {
                // retrieve reservation and parking spot tables
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Reservation> Reservations = db.GetTable<Reservation>();
                Table<ParkingSpot> ParkingSpots = db.GetTable<ParkingSpot>();

                // convert to LINQ-to-SQL class to a parking spot object
                var result =
                    from spot in ParkingSpots
                    select new { spot.ParkingSpotID, spot.AvailabilityStatus };

                spotList = result.AsEnumerable()
                    .Select(o => new Garage.ParkingSpot
                    {
                        ParkingSpotID = o.ParkingSpotID,
                        AvailabilityStatus = (Garage.ParkingSpot.Availibility)o.AvailabilityStatus
                    }).ToList();
            }
            catch (Exception)
            {
                throw new ParkingSpotException("Attempt to get parking spots failed.");
            }

            return spotList;
        }

        // return true if there are other available parking spots for the given reservation period
        public bool IsOtherParkingSpots(ParkingReservation desiredReservation)
        {
            // retrieve the reservation and parking spot tables
            ParkingManagementDataContext db = new ParkingManagementDataContext();
            Table<Reservation> Reservations = db.GetTable<Reservation>();
            Table<ParkingSpot> ParkingSpots = db.GetTable<ParkingSpot>();

            // find unavailable spots
            var unavailableSpots =
                from spot in ParkingSpots
                join res in Reservations on spot.ParkingSpotID equals res.ParkingSpotID
                // if res start < des start && res end >= des start, then no
                where ((res.DateTime < desiredReservation.Date) &&
                    res.DateTime.AddMinutes(res.DurationMinutes) >= desiredReservation.Date) ||
                    // if res start = des start, then no
               (res.DateTime == desiredReservation.Date) ||
                    // res start > des start && res start <= des end, then no
                ((res.DateTime > desiredReservation.Date) &&
                    res.DateTime <= desiredReservation.ReservationEndTime) ||
                    // must be available
                res.ParkingSpot.AvailabilityStatus != 0
                select spot;

            // find those spots that not unavailable (i.e. are available)
            var result =
                from spot in ParkingSpots
                where !unavailableSpots.Contains(spot)
                select new { spot.ParkingSpotID, spot.AvailabilityStatus };

            // if there is at list one other spot, return true
            if (!result.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // return true if the reservation modification from oldRes to newRes is valid.
        // this is the case if it doesn't conflict with other existing reservations
        public bool ReservationModificationValid(ParkingReservation oldRes, ParkingReservation newRes)
        {
            // Query for available spots during given time
            ParkingManagementDataContext db = new ParkingManagementDataContext();
            Table<Reservation> Reservations = db.GetTable<Reservation>();

            // find possible conflicts
            var conflicts =
                from res in Reservations
                where ((res.DateTime < newRes.ReservationEndTime) &&
                    (res.DateTime >= newRes.Date)) ||
                    ((res.DateTime < newRes.Date) && (res.DateTime.Add(new TimeSpan(0, res.DurationMinutes, 0)) > newRes.Date))
                where res.ParkingSpot.ParkingSpotID == newRes.ParkingSpotID
                where res.CustomerID != oldRes.Customer.CustomerID
                select res;

            // if there any conflicts, then return true; else, false
            if (!conflicts.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // record a fine in the database (for overstaying a reservation)
        public void RecordFine(decimal amount, int customerID, int reservationID, int cardID)
        {
            transactionTableAdapater.Insert(customerID, amount, reservationID, 1, cardID, DatabaseClock.Now);
        }

        // get the default credit card ID for a customer (first one in the list)
        public int GetDefaultCreditCardID(int customerID)
        {
            return GetCreditCards(customerID)[0].CardID;
        }

        // add a reservation to the database
        public ParkingReservation AddReservation(ParkingReservation res, int cardID, int spotID,
            DateTime transactionDate)
        {
            try
            {
                res.ParkingSpotID = spotID;

                // generate random key
                int key = GenerateTicketKey();
                res.TicketKey = key;

                // insert reservation into table
                int resID = Convert.ToInt32(reservationTableAdapter.InsertAndGetID(
                    res.Customer.CustomerID, res.ReservationVehicle.CarID, res.Date,
                    res.DurationMinutes, spotID, key, false));

                // set reservation ID
                res.ReservationID = resID;

                // add transaction for reservation
                decimal cost = res.DurationMinutes * (HOURLY_RATE / 60);
                transactionTableAdapater.Insert(res.Customer.CustomerID, Decimal.Round(cost, 2), resID, 0, cardID,
                    transactionDate);
            }
            catch (Exception)
            {
                throw new ReservationException("Could not add reservation to database.");
            }

            // mail receipt of the reservation to the customer
            Mailer.MailReservationReceipt(res);

            return res;
        }

        // add a reservation to the database (specifices spotID)
        public ParkingReservation AddReservation(ParkingReservation res, int cardID, int spotID)
        {
            return AddReservation(res, cardID, spotID, DatabaseClock.Now);
        }

        // add a reservation to the database (random spotID)
        public ParkingReservation AddReservation(ParkingReservation res, int cardID)
        {
            int spotID = 1;
            try
            {
                // find random open spot
                List<Garage.ParkingSpot> availableSpots = GetAvailableParkingSpots(res);
                int spotIndex = rand.Next(0, availableSpots.Count);
                spotID = availableSpots[spotIndex].ParkingSpotID;
                res.ParkingSpotID = spotID;
            }
            catch (Exception)
            {
                throw new ReservationException("Could not add reservation to database.");
            }

            return AddReservation(res, cardID, spotID);
        }

        // add a reservation to the database (does not specifiy spotID, but specifies the transaction date)
        public ParkingReservation AddReservation(ParkingReservation res, int cardID, DateTime transactionDate)
        {
            int spotID = 1;
            try
            {
                // find random open spot
                List<Garage.ParkingSpot> availableSpots = GetAvailableParkingSpots(res);
                int spotIndex = rand.Next(0, availableSpots.Count);
                spotID = availableSpots[spotIndex].ParkingSpotID;
                res.ParkingSpotID = spotID;
            }
            catch (Exception)
            {
                throw new ReservationException("Could not add reservation to database.");
            }

            return AddReservation(res, cardID, spotID, transactionDate);

        }

        // add a credit card for a customer to the database
        public void AddCreditCard(Billing.CreditCard card, int custID)
        {
            try
            {
                // insert customer into table
                int cardID = Convert.ToInt32(cardTableAdapter.InsertAndGetID((int)card.CardType,
                    card.CreditCardNumber));

                // set card ID
                card.CardID = cardID;

                // inster customer-card mapping
                customerCardTableAdapter.Insert(custID, cardID);
            }
            catch (Exception)
            {
                throw new CreditCardException("Could not add credit card to database.");
            }
        }

        // Get a list of customer credit cards
        public List<Billing.CreditCard> GetCreditCards(int customerID)
        {
            List<Billing.CreditCard> cardList = null;
            try
            {
                // Query for customers with given email
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<CustomerCreditCard> CustomerCards = db.GetTable<CustomerCreditCard>();
                Table<CreditCard> Cards = db.GetTable<CreditCard>();
                var result =
                    from card in Cards
                    join custCard in CustomerCards on card.CardID equals custCard.CreditCardID
                    where custCard.CustomerID == customerID
                    select new { card.CardID, card.CardNumber, card.CardType };

                // if none, throw an exception
                if (!result.Any())
                {
                    throw new CreditCardException("No credit cards added.");
                }

                // convert LINQ-to-SQL class list to a credit card list
                cardList = result.AsEnumerable()
                    .Select(o => new Billing.CreditCard
                    {
                        CardID = o.CardID,
                        CreditCardNumber = (long)o.CardNumber,
                        CardType = (Billing.CreditCard.CreditCardType)o.CardType
                    }).ToList();

            }
            catch (Exception)
            {
                throw new CreditCardException("Problem accessing the database.");
            }

            return cardList;
        }

        // get a reservation object for the given reservation number
        public ParkingReservation GetReservation(int reservationNumber)
        {
            ParkingReservation reservation = null;
            try
            {
                // Query for customers with given email
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Reservation> Reservations = db.GetTable<Reservation>();
                var query =
                    from res in Reservations
                    where res.ReservationID == reservationNumber
                    select res;

                // check if any results were found
                if (query.Any())
                {
                    Reservation dbRes = query.First();

                    // create a new reservation, based on the database information
                    reservation = new ParkingReservation(dbRes.ReservationID, GetCustomerFromID(dbRes.CustomerID),
                        GetVehicleFromID(dbRes.VehicleID), dbRes.DateTime, dbRes.DurationMinutes, dbRes.ParkingSpotID,
                        dbRes.TicketKey, dbRes.IsCheckedIn);
                }
                else
                {
                    throw new ReservationException("Reservation number could not be found.");
                }

            }
            catch (Exception e)
            {
                throw new ReservationException(e.Message);
            }

            return reservation;
        }



        /**
         * Get the relevant reservation for a parking spot.
         * Relevant is defined as:
         * 
         * if occupied, show reservation for person occcupying.
         * if not occupied, show reservation any current reservation
         * otherwise, show nothing
         * 
         */
        public ParkingReservation GetRelevantReservation(int parkingSpot)
        {
            ParkingReservation resToReturn = null;
            Reservation dbResToReturn = null;
            try
            {
                // Query for spots that are not reserved during given time
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Reservation> Reservations = db.GetTable<Reservation>();
                Table<ParkingSpot> ParkingSpots = db.GetTable<ParkingSpot>();

                // get parking spot from ID
                var reservationsStillCheckedIn =
                    from spot in ParkingSpots
                    join res in Reservations on spot.ParkingSpotID equals res.ParkingSpotID
                    where spot.ParkingSpotID == parkingSpot
                    where res.IsCheckedIn == true
                    select res;

                // check if customer has overstaid
                bool customerOverstaid = false;
                if (reservationsStillCheckedIn.Any())
                {
                    var resCheckedIn = reservationsStillCheckedIn.First();
                    TimeSpan resDuration = new TimeSpan(0, resCheckedIn.DurationMinutes, 0);
                    DateTime resEnd = resCheckedIn.DateTime.Add(resDuration);
                    if (resEnd < DatabaseClock.Now)
                    {
                        customerOverstaid = true;
                        dbResToReturn = resCheckedIn;
                    }
                }

                // if customer has not overstaid, find current reservation in effect
                if (!customerOverstaid)
                {
                    var reservationsInEffect =
                        from res in Reservations
                        where ((res.DateTime <= DatabaseClock.Now) &&
                            res.DateTime.AddMinutes(res.DurationMinutes) > DatabaseClock.Now)
                        where res.ParkingSpot.ParkingSpotID == parkingSpot
                        select res;

                    if (reservationsInEffect.Any())
                    {
                        dbResToReturn = reservationsInEffect.First();
                    }
                }

                // create a ParkingReservation from the LINQ-to-SQL Reservation class
                if (dbResToReturn != null)
                {
                    resToReturn = new ParkingReservation(dbResToReturn.ReservationID,
                        GetCustomerFromID(dbResToReturn.CustomerID),
                        GetVehicleFromID(dbResToReturn.VehicleID),
                        dbResToReturn.DateTime, dbResToReturn.DurationMinutes, dbResToReturn.ParkingSpotID,
                        dbResToReturn.TicketKey, dbResToReturn.IsCheckedIn);
                }
            }
            catch (Exception)
            {
                throw new ParkingSpotException("Attempt to get reservation failed.");
            }

            return resToReturn;
        }

        // get a list of current and future reservations for a customer ID.
        // this includes all reservations that have not ended
        public List<ParkingReservation> GetCurrentAndFutureReservations(int customerID)
        {
            List<ParkingReservation> reservationList = null;
            try
            {
                // Query for customers with given email
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Reservation> Reservations = db.GetTable<Reservation>();
                var result =
                    from res in Reservations
                    where res.CustomerID == customerID
                    where DatabaseClock.Now <= res.DateTime.Add(new TimeSpan(0, res.DurationMinutes, 0))
                    select new
                    {
                        res.ReservationID,
                        res.Customer,
                        res.Vehicle,
                        res.DateTime,
                        res.DurationMinutes,
                        res.ParkingSpotID,
                        res.TicketKey,
                        res.IsCheckedIn
                    };

                // if there are none, create an empty list
                if (!result.Any())
                {
                    reservationList = new List<ParkingReservation>();
                }
                else
                {
                    // otherwise, create the list from the LINQ-to-SQL class list
                    reservationList = result.AsEnumerable()
                        .Select(o => new ParkingReservation
                        {
                            ReservationID = o.ReservationID,
                            Customer = GetCustomerFromID(o.Customer.CustomerID),
                            ReservationVehicle = GetVehicleFromID(o.Vehicle.VehicleID),
                            Date = o.DateTime,
                            DurationMinutes = o.DurationMinutes,
                            ParkingSpotID = o.ParkingSpotID,
                            TicketKey = o.TicketKey,
                            IsCheckedIn = o.IsCheckedIn
                        }).ToList();
                }

            }
            catch (Exception)
            {
                throw new CreditCardException("Problem accessing the database.");
            }

            return reservationList;
        }

        // get the current load percentage for the parkign garage
        public double GetLoadPercentage()
        {
            // retrieve the reservation and parking spot tables
            ParkingManagementDataContext db = new ParkingManagementDataContext();
            Table<Reservation> Reservations = db.GetTable<Reservation>();
            Table<ParkingSpot> ParkingSpots = db.GetTable<ParkingSpot>();

            // find unavailable spots
            var unavailableSpots =
                from spot in ParkingSpots
                join res in Reservations on spot.ParkingSpotID equals res.ParkingSpotID
                where ((res.DateTime <= DatabaseClock.Now) &&
                    (res.DateTime.AddMinutes(res.DurationMinutes) > DatabaseClock.Now) &&
               (res.IsCheckedIn == true))
                select spot;

            // calculate the percentage full
            double percentageFull = ((double)unavailableSpots.Count()) / NUM_PARKING_SPOTS;
            return percentageFull;

        }

        // get a customer account from a customer ID
        public CustomerAccount GetCustomerFromID(int custID)
        {
            CustomerAccount custToGet = null;
            try
            {
                // get customer table
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Customer> Customers = db.GetTable<Customer>();

                // Query for customers with given ID
                var query =
                    from cust in Customers
                    where cust.CustomerID == custID
                    select cust;

                // check if any results were found
                if (query.Any())
                {
                    // if so, create a new customer object from the LINQ-to-SQL class object
                    Customer dbCust = query.First();
                    custToGet = new CustomerAccount(dbCust.CustomerID, dbCust.FirstName, dbCust.LastName, dbCust.Password,
                        dbCust.Email, dbCust.Password);
                }
                else
                {
                    throw new AccountException("Customer ID could not be found.");
                }

            }
            catch (Exception)
            {
                throw new AccountException("Attempt to retrieve customer using database failed.");
            }

            return custToGet;
        }

        // get a vehicles from the vehicle ID
        public Accounts.Vehicle GetVehicleFromID(int vehicleID)
        {
            Accounts.Vehicle vehToGet = null;
            try
            {
                // Query for vehicle with given ID
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Vehicle> Vehicles = db.GetTable<Vehicle>();
                var query =
                    from veh in Vehicles
                    where veh.VehicleID == vehicleID
                    select veh;

                // check if any results were found
                if (query.Any())
                {
                    // create a vehicle from the LINQ-to-SQL vehicle object
                    Vehicle dbVehicle = query.First();
                    vehToGet = new Accounts.Vehicle(dbVehicle.VehicleID, dbVehicle.CarModel, dbVehicle.LicensePlateID);
                }
                else
                {
                    throw new VehicleException("Vehicle ID could not be found.");
                }

            }
            catch (Exception)
            {
                throw new AccountException("Attempt to retrieve vehicle using database failed.");
            }

            return vehToGet;
        }

        // return true if the parking spot with the given ID is occupied
        public bool IsOccupied(int spotIDToCheck)
        {
            bool isOccupied = false;
            try
            {
                // retrieve the parking spots table
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<ParkingSpot> ParkingSpots = db.GetTable<ParkingSpot>();

                // Query for parking spots for given ID
                var query =
                    from spot in ParkingSpots
                    where spot.ParkingSpotID == spotIDToCheck
                    select spot;

                // check if any results were found
                if (query.Any())
                {
                    ParkingSpot dbSpot = query.First();
                    if (dbSpot.AvailabilityStatus == 1)
                    {
                        isOccupied = true;
                    }
                }
                else
                {
                    throw new ParkingSpotException("Spot ID could not be found.");
                }

            }
            catch (Exception)
            {
                throw new ParkingSpotException("Attempt to retrieve parking spot using database failed.");
            }

            return isOccupied;
        }

        // modify a reservation with the given information
        public void ModifyReservation(ParkingReservation oldReservation, int newParkingSpot,
            DateTime newDateTime, int newDuration, bool newStatus, int newVehicleID)
        {
            // update the reservation in the database table
            reservationTableAdapter.UpdateReservation(newVehicleID, newDateTime,
                newDuration, newParkingSpot, newStatus, oldReservation.ReservationID);
        }

        // set the occupancy status of a parking spot
        public void SetParkingSpotStatus(int parkingSpot, int newStatus)
        {
            // update the availablility status in the database
            parkingSpotTableAdapter.UpdateAvailability(newStatus, parkingSpot);
        }

        // cancel and delete a reservation
        public void CancelReservation(ParkingReservation reservation)
        {
            // deletion in the reservation table should also cascade to transaction
            reservationTableAdapter.DeleteReservation(reservation.ReservationID); 
        }

        // generate a random ticket key
        public int GenerateTicketKey()
        {
            return rand.Next(10000, 100000);
        }

        // get a list of all transactactions in the database
        public IEnumerable<Transaction> GetTransactionList()
        {
            try
            {
                // retrieve the transactions table
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Transaction> Transactions = db.GetTable<Transaction>();

                // select all transactions and return as an enumerable list
                var result =
                    from trans in Transactions
                    select trans;

                return result.AsEnumerable();

            }
            catch (Exception)
            {
                throw new TransactionException("Attempt to get transactions failed.");
            }
        }

        // get a list of all reservations in the database
        public IEnumerable<Reservation> getReservationList()
        {
            try
            {
                // retrieve the reservations table
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Reservation> Reservations = db.GetTable<Reservation>();

                // select all reservations and return as an enumerable list
                var result =
                    from res in Reservations
                    select res;

                return result.AsEnumerable();

            }
            catch (Exception)
            {
                throw new ReservationException("Attempt to get reservations failed.");
            }
        }

        // get a list of all customers in the database
        public IEnumerable<Customer> GetCustomerList()
        {
            try
            {
                // retrieve the customers table
                ParkingManagementDataContext db = new ParkingManagementDataContext();
                Table<Customer> Customers = db.GetTable<Customer>();

                // select all customers and return as an enumerable list
                var result =
                    from cust in Customers
                    select cust;

                return result.AsEnumerable();

            }
            catch (Exception)
            {
                throw new ReservationException("Attempt to get customers failed.");
            }
        }
    }

}
