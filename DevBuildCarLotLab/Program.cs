using System;

namespace DevBuildCarLotLab
{
    class Program
    {
        static void Main(string[] args)
        {
            CarLot test = new CarLot();
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = test.CarLotMenu();
            }
        }
    }
}
