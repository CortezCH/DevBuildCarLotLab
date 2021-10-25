using System;
using System.Collections.Generic;
using System.Text;

namespace DevBuildCarLotLab
{
    class UsedCar : Car
    {
        private double mileage;

        public double Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        public UsedCar()
        {
            Mileage = 0.0;
        }

        public UsedCar(string incomingMake, string incomingModel, int incomingYear, double incomingPrice, double incomingMilage )
            : base(incomingMake, incomingModel, incomingYear, incomingPrice)
        {
            Make = incomingMake;
            Model = incomingModel;
            Year = incomingYear;
            Price = incomingPrice;
            Mileage = incomingMilage;
        }

        public override string ToString()
        {
            
            return String.Format("{0, -10}| {1, -15}| {2, -5}| {3, -15:C2}| {4, -15:n0} (Used)", Make, Model, Year, Price, Mileage);
            
        }
    }
}
