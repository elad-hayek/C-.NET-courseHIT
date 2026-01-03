using Ex03.GarageLogic;
using Ex03.GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class UIManager
    {
        private readonly StringBuilder r_StringBuilder = new StringBuilder();
        private readonly GarageManager r_GarageManager = new GarageManager();

        private string getMenuOptions()
        {
            r_StringBuilder.Clear();
            r_StringBuilder.AppendLine("Welcome to the Garage Management System!");
            r_StringBuilder.AppendLine("Choose your action:");
            r_StringBuilder.AppendLine("1. Load vehicles from file");
            r_StringBuilder.AppendLine("2. Add a new vehicle to the garage");
            r_StringBuilder.AppendLine("3. Display all license IDs in the garage");
            r_StringBuilder.AppendLine("4. Change vehicle status");
            r_StringBuilder.AppendLine("5. Inflate vehicle tires to maximum");
            r_StringBuilder.AppendLine("6. Refuel a vehicle");
            r_StringBuilder.AppendLine("7. Recharge an electric vehicle");
            r_StringBuilder.AppendLine("8. Display vehicle details");
            r_StringBuilder.AppendLine("9. Exit");

            return r_StringBuilder.ToString();
        }

        private eMenuOption parseMenuOption(string i_UserInput)
        {
            if (!int.TryParse(i_UserInput, out int menuOptionNumber) || menuOptionNumber < 1 || menuOptionNumber > 9)
            {
                throw new FormatException("Invalid menu option. Please enter a number between 1 and 9.");
            }

            return (eMenuOption)menuOptionNumber;
        }

        public void ShowMenu()
        {
            bool isInputInvalid = true;
            string menuOptions = getMenuOptions();
            eMenuOption? menuOption = null;

            do
            {
                Console.WriteLine(menuOptions);
                Console.Write("Enter your choice: ");
                string userInput = Console.ReadLine();
                try
                {
                    menuOption = parseMenuOption(userInput);
                    activateMenuOption(menuOption.Value);
                    isInputInvalid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                Console.WriteLine();

            } while (isInputInvalid || (menuOption.HasValue && menuOption.Value != eMenuOption.Exit));
        }

        private void activateMenuOption(eMenuOption i_MenuOption)
        {
            switch (i_MenuOption)
            {
                case eMenuOption.LoadSystemFromFile:
                    loadSystemFromFile();
                    break;
                case eMenuOption.EnterNewVehicle:
                    enterNewVehicle();
                    break;
                case eMenuOption.DisplayLicenseNumbers:
                    displayLicenseNumbers();
                    break;
                case eMenuOption.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case eMenuOption.InflateTiresToMax:
                    inflateTiresToMax();
                    break;
                case eMenuOption.RefuelVehicle:
                    refuelVehicle();
                    break;
                case eMenuOption.RechargeElectricVehicle:
                    rechargeVehicle();
                    break;
                case eMenuOption.DisplayVehicleDetails:
                    displayVehicleDetails();
                    break;
                case eMenuOption.Exit:
                    break;
                default:
                    throw new Exception("Invalid menu option.");
            }
        }

        private void displayVehicleDetails()
        {
            try
            {
                GarageVehicle garageVehicle = getGarageVehicleFromUser();
                Console.WriteLine(garageVehicle.ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }

        private void loadSystemFromFile()
        {
            try
            {
                r_GarageManager.LoadGarageVehiclesFromFile("VehiclesDB.txt");
                Console.WriteLine("Garage vehicles loaded successfully from file.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }

        private void enterNewVehicle()
        {
            try
            {
                GarageVehicle garageVehicle = getGarageVehicleFromUser();
                r_GarageManager.ChangeVehicleStatus(garageVehicle, eVehicleStatus.InRepair);
                Console.WriteLine("Vehicle already exists in the garage. Status updated to 'In Repair'.");
            }
            catch (VehicleNotFoundException vehicleNotFoundException)
            {
                try
                {
                    GarageVehicle garageVehicle = createGarageVehicleFromUserInput(vehicleNotFoundException.LicenseNumber);

                    foreach (KeyValuePair<eVehicleQuestion, string> question in garageVehicle.Vehicle.GetVehicleDataQuestions())
                    {
                        bool isValidAnswer = false;

                        do
                        {
                            try
                            {
                                string userAnswer = getUserQuestionAnswer(question.Value);
                                garageVehicle.Vehicle.SetVehicleDataFromQuestionAnswer(question.Key, userAnswer);
                                isValidAnswer = true;
                            }
                            catch (Exception answerQuestionException)
                            {
                                Console.WriteLine($"Error: {answerQuestionException.Message}");
                                Console.WriteLine("Please try again.");
                                Console.WriteLine();
                            }
                        }
                        while (!isValidAnswer);
                    }

                    r_GarageManager.AddVehicleToGarage(garageVehicle);
                    Console.WriteLine("Vehicle added successfully to the garage.");
                }
                catch (Exception addNewVehicleException)
                {
                    Console.WriteLine($"Error: {addNewVehicleException.Message}");
                }
            }
            catch (Exception generalException)
            {
                Console.WriteLine($"Error: {generalException.Message}");
            }
        }

        private GarageVehicle createGarageVehicleFromUserInput(string i_LicenseId)
        {
            string vehicleType = getVehicleTypeFromUser();
            string modelName = getUserQuestionAnswer("Enter the model name of the vehicle: ");
            string ownerName = getUserQuestionAnswer("Enter the owner's name: ");
            string ownerPhoneNumber = getUserQuestionAnswer("Enter the owner's phone number: ");
            Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, i_LicenseId, modelName);
            GarageVehicle garageVehicle = new GarageVehicle(vehicle, ownerName, ownerPhoneNumber);

            return garageVehicle;
        }

        private string getVehicleTypeFromUser()
        {
            List<string> vehicleTypes = VehicleCreator.SupportedTypes;
            r_StringBuilder.Clear();
            r_StringBuilder.AppendLine("Choose vehicle type:");

            for (int i = 0; i < vehicleTypes.Count; i++)
            {
                r_StringBuilder.AppendLine($"{i + 1}. {vehicleTypes[i]}");
            }

            Console.WriteLine(r_StringBuilder.ToString());
            string userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out int userChoice) || userChoice < 1 || userChoice > 5)
            {
                throw new FormatException("Invalid vehicle type choice.");
            }

            return vehicleTypes[userChoice - 1];
        }

        private string getUserQuestionAnswer(string i_Question)
        {
            Console.WriteLine(i_Question);
            string userInput = Console.ReadLine();

            return userInput;
        }

        private eVehicleStatus parseVehicleStatus(string i_UserInput)
        {
            if (!int.TryParse(i_UserInput, out int vehicleStatusNumber) || vehicleStatusNumber < 1 || vehicleStatusNumber > 3)
            {
                throw new FormatException("Invalid status number");
            }

            return (eVehicleStatus)vehicleStatusNumber;
        }

        private eFuelType parseFuelType(string i_UserInput)
        {
            if (!int.TryParse(i_UserInput, out int fuelTypeNumber) || fuelTypeNumber < 1 || fuelTypeNumber > 4)
            {
                throw new FormatException("Invalid fuel type number");
            }

            return (eFuelType)fuelTypeNumber;
        }

        private void displayLicenseNumbers()
        {
            r_StringBuilder.Clear();
            r_StringBuilder.AppendLine("Choose filter: ");
            r_StringBuilder.AppendLine("1. In repair");
            r_StringBuilder.AppendLine("2. Repaired ");
            r_StringBuilder.AppendLine("3. Paid ");
            r_StringBuilder.Append("For no filter press Enter: ");
            string filterMenu = r_StringBuilder.ToString();
            eVehicleStatus? filterStatus = null;
            bool isInputInvalid = true;
            string userInput = null;

            do
            {
                Console.WriteLine(filterMenu);
                userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    try
                    {
                        filterStatus = parseVehicleStatus(userInput);
                        isInputInvalid = false;
                    }
                    catch (FormatException formatException)
                    {
                        Console.WriteLine(formatException.Message);
                    }
                }
                else
                {
                    isInputInvalid = false;
                }
            }
            while (isInputInvalid);

            List<string> licenseNumbers = r_GarageManager.GetLicenseNumbers(filterStatus);
            r_StringBuilder.Clear();
            r_StringBuilder.AppendLine("License Numbers in the Garage:");

            foreach (string licenseNumber in licenseNumbers)
            {
                r_StringBuilder.AppendLine(licenseNumber);
            }

            Console.WriteLine(r_StringBuilder.ToString());
        }

        private GarageVehicle getGarageVehicleFromUser()
        {
            Console.WriteLine("Enter the license number of the vehicle: ");
            GarageVehicle garageVehicle = null;
            string licenseNumber = Console.ReadLine();
            garageVehicle = r_GarageManager.GetVehicleByLicenseNumber(licenseNumber);

            return garageVehicle;
        }

        private void changeVehicleStatus()
        {
            try
            {
                GarageVehicle garageVehicle = getGarageVehicleFromUser();
                r_StringBuilder.Clear();
                r_StringBuilder.AppendLine("Choose the new status of the vehicle:");
                r_StringBuilder.AppendLine("1. In repair");
                r_StringBuilder.AppendLine("2. Repaired ");
                r_StringBuilder.AppendLine("3. Paid ");
                Console.WriteLine(r_StringBuilder.ToString());
                string userInput = Console.ReadLine();
                eVehicleStatus newStatus = parseVehicleStatus(userInput);
                r_GarageManager.ChangeVehicleStatus(garageVehicle, newStatus);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }

        private string getFuelTypeMenu()
        {
            r_StringBuilder.Clear();
            r_StringBuilder.AppendLine("Choose fuel type:");
            r_StringBuilder.AppendLine("1. Soler");
            r_StringBuilder.AppendLine("2. Octan95");
            r_StringBuilder.AppendLine("3. Octan96");
            r_StringBuilder.AppendLine("4. Octan98");

            return r_StringBuilder.ToString();
        }

        private float getAmountOfEnergyFromUser(string i_EnergyUnit)
        {
            Console.WriteLine($"Enter amount of {i_EnergyUnit} to add: ");
            string amountOfEnergyInput = Console.ReadLine();

            if (!float.TryParse(amountOfEnergyInput, out float amountOfEnergyToAdd))
            {
                throw new FormatException($"Invalid amount of {i_EnergyUnit}.");
            }

            return amountOfEnergyToAdd;
        }

        private void refuelVehicle()
        {
            try
            {
                GarageVehicle garageVehicle = getGarageVehicleFromUser();
                Console.WriteLine(getFuelTypeMenu());
                string fuelTypeInput = Console.ReadLine();
                eFuelType fuelType = parseFuelType(fuelTypeInput);
                float amountOfFuelToAdd = getAmountOfEnergyFromUser("liters");
                r_GarageManager.RefuelVehicle(garageVehicle, fuelType, amountOfFuelToAdd);
                Console.WriteLine($"{amountOfFuelToAdd} liters were added to the car's fuel tank");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }

        private void rechargeVehicle()
        {
            try
            {
                GarageVehicle garageVehicle = getGarageVehicleFromUser();
                float amountOfMinutesToAdd = getAmountOfEnergyFromUser("minutes");
                r_GarageManager.RechargeVehicle(garageVehicle, amountOfMinutesToAdd);
                Console.WriteLine($"{amountOfMinutesToAdd} minutes were added to the car's battery");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }

        private void inflateTiresToMax()
        {
            try
            {
                GarageVehicle garageVehicle = getGarageVehicleFromUser();
                r_GarageManager.InflateTiresToMax(garageVehicle);
                Console.WriteLine("All tires were inflated to maximum pressure.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }
    }
}
