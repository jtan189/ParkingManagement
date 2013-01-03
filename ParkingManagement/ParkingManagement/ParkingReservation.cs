using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingManagement.Accounts;
using System.ComponentModel;

namespace ParkingManagement
{
    // A parking spot reservation.
    // Implements INotifyPropertyChanged in order to notify its container BindingList, when used
    // with a combobox.
    // source: http://stackoverflow.com/questions/504551/updating-a-databound-combobox
    public class ParkingReservation : INotifyPropertyChanged
    {
        private int _reservationID;
        private CustomerAccount _customer;
        private Accounts.Vehicle _reservationVehicle;
        private DateTime _date;
        private int _durationMinutes;
        private int _parkingSpotID;
        private int _ticketKey;
        private bool _isCheckedIn;

        // event for notify a container of this that a property has changed
        public event PropertyChangedEventHandler PropertyChanged;

        // properties
        public int ReservationID
        {
            get { return _reservationID; }
            set
            {
                _reservationID = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("ReservationID"));
                }
            }
        }

        public CustomerAccount Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Customer"));
                }
            }
        }

        public Accounts.Vehicle ReservationVehicle
        {
            get { return _reservationVehicle; }
            set
            {
                _reservationVehicle = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("ReservationVehicle"));
                }
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Date"));
                }
            }
        }

        public int DurationMinutes
        {
            get { return _durationMinutes; }
            set
            {
                _durationMinutes = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("DurationMinutes"));
                }
            }
        }

        public int ParkingSpotID
        {
            get { return _parkingSpotID; }
            set
            {
                _parkingSpotID = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("ParkingSpotID"));
                }
            }
        }

        public int TicketKey
        {
            get { return _ticketKey; }
            set
            {
                _ticketKey = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("TicketKey"));
                }
            }
        }

        public bool IsCheckedIn
        {
            get { return _isCheckedIn; }
            set
            {
                _isCheckedIn = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("IsCheckedIn"));
                }
            }
        }

        // get the date and time that the reservation ends
        public DateTime ReservationEndTime
        {
            get { return Date.AddMinutes(DurationMinutes); }
        }

        // constructors
        public ParkingReservation()
        {
            ReservationID = -1;
            Customer = null;
            ReservationVehicle = null;
            Date = new DateTime();
            DurationMinutes = -1;
            ParkingSpotID = -1;
            TicketKey = -1;
            IsCheckedIn = false;
        }

        public ParkingReservation(CustomerAccount cust, Accounts.Vehicle veh, DateTime date,
            int durationMinutes)
        {
            Customer = cust;
            ReservationVehicle = veh;
            Date = date;
            DurationMinutes = durationMinutes;
            IsCheckedIn = false;
        }

        public ParkingReservation(int resID, CustomerAccount cust, Accounts.Vehicle veh, DateTime date,
            int durationMinutes, int spotID, int ticketKey, bool isCheckedIn)
        {
            ReservationID = resID;
            Customer = cust;
            ReservationVehicle = veh;
            Date = date;
            DurationMinutes = durationMinutes;
            ParkingSpotID = spotID;
            TicketKey = ticketKey;
            IsCheckedIn = isCheckedIn;
        }
    }
}
