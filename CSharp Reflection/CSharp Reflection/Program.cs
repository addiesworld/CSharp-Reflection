using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Reflection
{
    class Car //Store user input: Make, model, registation, year of init. registration and current value.
    { 
        public string carMake { get; set; }
        public string carModel { get; set; }
        public string carReg { get; set; }
        public int carRegYear { get; set; }
        public int carValue { get; set; }

        public void carStats(string make, string model, string reg, int regyear, int value)
        {
            carMake = make;
            carModel = model;
            carReg = reg;
            carRegYear = regyear;
            carValue = value;
        }

    }
    class Program //Main panel -> Direct to each section (Add new car, value/year of selected car, current car list
    {
        static void Main(string[] args)
        {
            List<string> menuList = new List<string>() { "Add a car to database", "Exit" };
            int carValuePlacement = 1;
            string carValueString = "View selected car's value";
            int carRegPlacement = 2;
            string carRegString = "View selected car's registration number";
            int carYearPlacement = 3;
            string carYearString = "View selected car's year of registration";
            int carStatsPlacement = 4;
            string carStatsString = "Summary of car entry";

            List<Car> carStorage = new List<Car>();

            bool exitStatus = false;
            bool addOptions = true;

            int currentYear = DateTime.Now.Year;
            Console.WriteLine(currentYear);
            do
            {
                if (carStorage.Count > 0 && addOptions)
                {
                    menuList.Insert(carValuePlacement, carValueString);
                    menuList.Insert(carRegPlacement, carRegString);
                    menuList.Insert(carYearPlacement, carYearString);
                    menuList.Insert(carStatsPlacement, carStatsString);
                    addOptions = false;
                }
                Console.Clear();

                    Console.WriteLine("Welcome to the car storage database. \nPlease enter a value from the list below to proceed.");
                    for (int x = 1; x <= menuList.Count; x++)
                        Console.Write("[" + x + "] " + menuList[x - 1] + "\n");

                int userInput;
                if (!Int32.TryParse(Console.ReadLine(), out userInput))
                    Console.Clear();
                if (userInput != 0)
                    switch (userInput)
                    {
                        case 1: 
                            Console.Clear();
                            CreateACar();
                            break;
                        case 2: 
                            if (carStorage.Count > 0) 
                                ViewValue();
                            else 
                                exitStatus = true;
                            break;
                        case 3: 
                            ViewRegistration();
                            break;
                        case 4: 
                            ViewRegYear();
                            break;
                        case 5:
                            ViewDetails();
                            break;
                        case 6:
                            if (carStorage.Count > 0) 
                                exitStatus = true;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
            } while (exitStatus == false);

            Environment.Exit(0);

            void CreateACar()
            {
                int entryTracker = 0;
                string make = "";
                string model = "";
                string registration = "";
                int year = 0;
                int value = 0;
                Console.Clear();
                do
                {

                    switch (entryTracker)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("What is the car's make?");
                            do
                            {
                                string input = Console.ReadLine();
                                    make = input;
                            } while (make.Length == 0);
                            entryTracker++;
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("What is the car's model?");
                            do
                            {
                                string input = Console.ReadLine();
                                    model = input;
                            } while (model.Length == 0);
                            entryTracker++;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("What is the car's registration number?");
                            Console.WriteLine("This should read as any combination of 7 numeric and/or alphabetical characters.\nPlease remember to use capital letters.");
                            do
                            {
                                string input = Console.ReadLine();
                                //if (Regex.IsMatch(input, @"^[A-Z0-9]+$")) -- Commented out, should make it so that no special characters can be entered, but it blocks the value entered from being saved?
                                    registration = input;
                            } while (registration.Length < 7);
                            entryTracker++;
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("What year was the car registered? (Numeric values ONLY.)");
                            do
                            {
                                string temp = Console.ReadLine();
                                    year = Int32.Parse(temp);
                            } while (year == 0 && year <= currentYear);
                            entryTracker++;
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("What is the value of the car in GBP?");
                            do
                            {
                                string temp = Console.ReadLine();
                                    value = Int32.Parse(temp);
                            } while (value == 0 || value < 0);
                            entryTracker++;
                            break;
                        default:

                            break;
                    }
                } while (entryTracker < 5);

                Car newCar = new Car();
                newCar.carStats(make, model, registration, year, value);
                carStorage.Add(newCar);
                Console.Clear();
            }

            void ViewValue()
            {
                bool inputValid = false;
                int input;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please select a car to see its value.");
                    for (int i = 1; i <= carStorage.Count; i++)
                    {
                        Console.WriteLine("[" + i + "] " + carStorage[i - 1].carMake + " " + carStorage[i - 1].carModel);
                    }
                    bool valid = Int32.TryParse(Console.ReadLine(), out input);
                    if (input > 0 && input <= carStorage.Count && valid)
                        inputValid = true;
                } while (!inputValid);
                Console.WriteLine("The value of " + carStorage[input - 1].carMake + " " + carStorage[input - 1].carModel + " is: £" + carStorage[input - 1].carValue);
                Console.ReadLine();
            }

            void ViewRegistration()
            {
                bool inputValid = false;
                int input;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please select a car to see its registration.");
                    for (int i = 1; i <= carStorage.Count; i++)
                    {
                        Console.WriteLine("[" + i + "] " + carStorage[i - 1].carMake + " " + carStorage[i - 1].carModel);
                    }
                    bool valid = Int32.TryParse(Console.ReadLine(), out input);
                    if (input > 0 && input <= carStorage.Count && valid)
                        inputValid = true;
                } while (!inputValid);
                Console.WriteLine("The registration of " + carStorage[input - 1].carMake + " " + carStorage[input - 1].carModel + " is: " + carStorage[input - 1].carReg);
                Console.ReadLine();
                {
                    Console.Clear();
                    Console.WriteLine("Please select a car to see its registration.");
                    for (int i = 1; i <= carStorage.Count; i++)
                    {
                        Console.WriteLine("[" + i + "] " + carStorage[i - 1].carMake + " " + carStorage[i - 1].carModel);
                    }
                    do
                    {
                        input = Int32.Parse(Console.ReadLine());
                        if (input > 0 && input <= carStorage.Count)
                            inputValid = true;
                    } while (!inputValid);
                    Console.WriteLine("The registration of " + carStorage[input - 1].carMake + " " + carStorage[input - 1].carModel + " is: " + carStorage[input - 1].carReg);
                    Console.ReadLine();
                }
            }

            void ViewRegYear()
            {
                bool inputValid = false;
                int input;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please select a car to see its year of registration.");
                    for (int i = 1; i <= carStorage.Count; i++)
                    {
                        Console.WriteLine("[" + i + "] " + carStorage[i - 1].carMake + " " + carStorage[i - 1].carModel);
                    }
                    bool valid = Int32.TryParse(Console.ReadLine(), out input);
                    if (input > 0 && input <= carStorage.Count && valid)
                        inputValid = true;
                } while (!inputValid);
                Console.WriteLine("The year of registration of " + carStorage[input - 1].carMake + " " + carStorage[input - 1].carModel + " is: " + carStorage[input - 1].carRegYear);
                Console.ReadLine();
            }

            void ViewDetails()
            {
                bool inputValid = false;
                int input;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please select a car to view all entered details.");
                    for (int i = 1; i <= carStorage.Count; i++)
                    {
                        Console.WriteLine("[" + i + "] " + carStorage[i - 1].carMake + " " + carStorage[i - 1].carModel);
                    }
                    bool valid = Int32.TryParse(Console.ReadLine(), out input);
                    if (input > 0 && input <= carStorage.Count && valid)
                        inputValid = true;
                } while (!inputValid);
                input--;
                Console.WriteLine("\nCar Make: " + carStorage[input].carMake);
                Console.WriteLine("\nCar Model: " + carStorage[input].carModel);
                Console.WriteLine("\nCar Registration: " + carStorage[input].carReg);
                Console.WriteLine("\nCar Year of Registration: " + carStorage[input].carRegYear);
                Console.WriteLine("\nCar Value: £" + carStorage[input].carValue);
                Console.ReadLine();
            }
        }
    }
}

