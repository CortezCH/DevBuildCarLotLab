using System;
using System.Collections.Generic;
using System.Text;

namespace DevBuildCarLotLab
{
    class CarLot
    {

        public List<Car> inventory { get; set; } = new List<Car>()
        {
            new Car("Chrystler", "T&C", 2005, 15000),
            new Car("Ford", "F-150", 2005, 15000),
            new Car("Chevy", "Equinox", 2005, 15000),
            new UsedCar("Rocket","TPO PRO SHIP", 2021, 60000, 150000),
            new UsedCar("Chevy","Taho", 2021, 60000, 150000),
            new UsedCar("Tesla","Model 3", 2021, 60000, 150000)
        };

        

        //Display a menu printing all cars currently in inventory to buy and the option to quit and or add a car
        //List all cars
        //  PrintInventory()
        //Add car
        //Ask if it is a used car or a new car
        //switch on "used" or "new"
        //  Get information for:
        //      - Make
        //      - Model
        //      - Year
        //          -Need to validate the year and return the valid int to here GetYear
        //      - Price
        //          - Need to validate the price and return the valid double here GetPrice

        public bool CarLotMenu()
        {
            
            Console.WriteLine("WELCOME TO THE GC USED CAR EMPORIUM!");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("[1] Add a car");
            Console.WriteLine("[2] Buy a car");
            Console.WriteLine("[3] List all availabe cars");
            Console.WriteLine("[4] Quit");
            string userMenuChoice = GetUserInput("Selection: ");
            Console.WriteLine();

            switch (userMenuChoice)
            {
                case "1":
                    //Call add car method
                    AddCar();
                    Console.WriteLine();
                    return true;

                case "2":
                    //Call Buy car method
                    BuyCar();
                    Console.WriteLine();
                    return true;

                case "3":
                    //Call List  all cars
                    Printinvetory();
                    Console.WriteLine();
                    return true;

                case "4":
                    return false;

                default:
                    Console.WriteLine("That selection was invalid. Please try again.");
                    return CarLotMenu();
            }
            
        }

        public void AddCar()
        {
            string newOrUsed = GetUserInput("New or Used: ");

            switch (newOrUsed.Trim().ToLower())
            {
                case "new":
                    NewCar();
                    break;
                case "used":
                    UsedCar();
                    break;
                default:
                    Console.WriteLine("Please enter either \"New\" or \"Used\"");
                    AddCar();
                    break;
            }
        }

        public void NewCar()
        {
            string make = GetUserInput("Make: ");
            string model = GetUserInput("Model: ");
            int year = GetYear();
            double price = GetPrice();
            inventory.Add(new Car(make, model, year, price));
        }

        public void UsedCar()
        {
            string make = GetUserInput("Make: ");
            string model = GetUserInput("Model: ");
            int year = GetYear();
            double price = GetPrice();
            double mileage = GetMileage();
            inventory.Add(new UsedCar(make, model, year, price, mileage));
        }

        public int GetMileage()
        {
            string userMileage = GetUserInput("Miles: ");

            try
            {
                return int.Parse(userMileage);
            }
            catch
            {
                Console.WriteLine("That mileage was invalid. Please try again.");
                return GetYear();
            }
        }

        public int GetYear()
        {
            string userYear = GetUserInput("Year: ");

            try
            {
                return int.Parse(userYear);
            }
            catch
            {
                Console.WriteLine("That year was invalid. Please try again.");
                return GetYear();
            }
        }

        public double GetPrice()
        {
            string userPrice = GetUserInput("Price: ");

            try
            {
                return double.Parse(userPrice);
            }
            catch
            {
                Console.WriteLine("That price was invalid. Please try again.");
                return GetPrice();
            }
        }

        public void BuyCar()
        {
            Printinvetory();
            int carChoice = int.Parse(GetUserInput("Which car would you like to buy: "));
            Console.WriteLine(inventory[carChoice-1]);

            if (BuyCarConfimration())
            {
                inventory.Remove(inventory[carChoice - 1]);
                Console.WriteLine("Excellent! Our Sales team will be in touch with you soon.");
            }
        }

        public bool BuyCarConfimration()
        {
            string buyCarAnswer = GetUserInput("Would you like to buy this car? (y/n): ");

            switch (buyCarAnswer)
            {
                case "y":
                    return true;

                case "n":
                    return false;
                default:
                    Console.WriteLine("That selecion was invalid. Please only enter Y or N.");
                    return BuyCarConfimration();
            }
        }

        public void Printinvetory()
        {

            Console.WriteLine("    {0, -10}| {1, -15}| {2, -5}| {3, -15:C2}| {4, -15:n0}", "Make", "Model", "Year", "Price", "Mileage");
            Console.WriteLine("------------------------------------------------------------------------------");
            foreach (Car car in inventory)
            {
                Console.WriteLine($"[{inventory.IndexOf(car) + 1}] {car}");
            }
        }

        public string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            string output = Console.ReadLine().Trim().ToLower();
            Console.WriteLine();


            return output;
        }
    }
}
