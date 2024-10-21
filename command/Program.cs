using System;
using System.Collections.Generic;

class Ambulance
{
    public string LicensePlate { get; set; }
    public string DriverName { get; set; }
    public bool IsAvailable { get; set; }

    public Ambulance(string licensePlate, string driverName, bool isAvailable)
    {
        LicensePlate = licensePlate;
        DriverName = driverName;
        IsAvailable = isAvailable;
    }

    public void DisplayInfo()
    {
        string availability = IsAvailable ? "Available" : "Not Available";
        Console.WriteLine($"License Plate: {LicensePlate}, Driver: {DriverName}, Status: {availability}");
    }
}

class Hospital
{
    private List<Ambulance> ambulances = new List<Ambulance>();

    // Method to register a new ambulance
    public void RegisterAmbulance()
    {
        Console.Write("Enter License Plate: ");
        string licensePlate = Console.ReadLine();

        Console.Write("Enter Driver Name: ");
        string driverName = Console.ReadLine();

        Console.Write("Is the ambulance available (yes/no)? ");
        string availableInput = Console.ReadLine().ToLower();
        bool isAvailable = availableInput == "yes";

        Ambulance newAmbulance = new Ambulance(licensePlate, driverName, isAvailable);
        ambulances.Add(newAmbulance);

        Console.WriteLine("Ambulance registered successfully!\n");
    }

    // Method to view available ambulances
    public void ViewAvailableAmbulances()
    {
        Console.WriteLine("\nAvailable Ambulances:");
        foreach (var ambulance in ambulances)
        {
            if (ambulance.IsAvailable)
            {
                ambulance.DisplayInfo();
            }
        }
    }

    // Method to view unavailable ambulances
    public void ViewUnavailableAmbulances()
    {
        Console.WriteLine("\nUnavailable Ambulances:");
        foreach (var ambulance in ambulances)
        {
            if (!ambulance.IsAvailable)
            {
                ambulance.DisplayInfo();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Hospital hospital = new Hospital();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Hospital Ambulance Management System ---");
            Console.WriteLine("1. Register Ambulance");
            Console.WriteLine("2. View Available Ambulances");
            Console.WriteLine("3. View Unavailable Ambulances");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    hospital.RegisterAmbulance();
                    break;
                case "2":
                    hospital.ViewAvailableAmbulances();
                    break;
                case "3":
                    hospital.ViewUnavailableAmbulances();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }

        Console.WriteLine("Exiting the system. Goodbye!");
    }
}
