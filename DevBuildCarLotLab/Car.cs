using System;
using System.Collections.Generic;
using System.Text;

namespace DevBuildCarLotLab
{
    class Car
    {

        private string make;
        private string model;
        private int year;
        private double price;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Car()
        {
            Make = string.Empty;
            Model = string.Empty;
            Year = 0;
            Price = 0.00;
        }

        public Car(string incomingMake, string incomingModel, int incomingYear, double incomingPrice)
        {
            Make = incomingMake;
            Model = incomingModel;
            Year = incomingYear;
            Price = incomingPrice;
        }

        public override string ToString()
        {
            return String.Format("{0, -10}| {1, -15}| {2, -5}| {3, -15:C2}|", Make, Model, Year, Price);
        }
    }
}
