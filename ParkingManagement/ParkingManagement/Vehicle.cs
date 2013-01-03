using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Accounts
{
    // A vehicle in the parking garage.
    public class Vehicle
    {
        public int CarID { get; set; }
        public string CarModel { get; set; }
        public string LicensePlateID { get; set; }

        // property for returning a vehicles as a string (used for combobox binding)
        public string AsString
        {
            get
            {
                return string.Format("Model: {0}, License Plate: {1}", CarModel, LicensePlateID);
            }
        }

        // constructors
        public Vehicle()
        {
            CarModel = string.Empty;
            LicensePlateID = string.Empty;
        }

        public Vehicle(string model, string plateID)
        {
            CarModel = model;
            LicensePlateID = plateID;
        }

        public Vehicle(int id, string model, string plateID)
        {
            CarID = id;
            CarModel = model;
            LicensePlateID = plateID;
        }

        // method for displaying a string representation of a vehicle
        public override string ToString()
        {
            return string.Format("Model: {0}, License Plate: {1}", CarModel, LicensePlateID);
        }
    }
}
