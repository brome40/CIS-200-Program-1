// Program 1B
// CIS 200-50
// Fall 2021
// Due: 10/8/2021
// By: 5342897

// File: Program.cs
// Creates sample objects of concrete classes and displays the results of four LINQ queries.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program1A
{
    class Program
    {
        // Precondition:  None
        // Postcondition: Small list of Parcels is created and displayed
        static void Main(string[] args)
        {
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ", 
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", 
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321", 
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Jacob Green", "443 Verde Ave.",
                "Portland", "OR", 97035); // Test Address 5
            Address a6 = new Address("Peter Parker", "20 Ingram St.",
                "Flushing", "NY", 11375); // Test Address 6
            Address a7 = new Address("Tony Stark", "10880 Malibu Point",
                "Malibu", "CA", 90265); // Test Address 7
            Address a8 = new Address("Eric Adams", "602 5th St.", "Room 13",
                "Topeka", "KS", 66546); // Test Address 8


            Letter l1 = new Letter(a1, a3, 0.50M); // Test Letter 1
            Letter l2 = new Letter(a2, a4, 1.20M); // Test Letter 2
            Letter l3 = new Letter(a4, a1, 1.70M); // Test Letter 3

            GroundPackage gp1 = new GroundPackage(a1,a5,5,13,3,15); //Test GroundPackage 1
            GroundPackage gp2 = new GroundPackage(a2,a7,6,7,4,10);  //Test GroundPackage 2
            GroundPackage gp3 = new GroundPackage(a3,a4,7,4,5,20);  //Test GroundPackage 3

            NextDayAirPackage ndap1 = new NextDayAirPackage(a2,a8,15,10,15,77,3.50M); //Test NextDayAirPackage 1
            NextDayAirPackage ndap2 = new NextDayAirPackage(a7,a3,6,10,4,8,4.14M); //Test NextDayAirPackage 2
            NextDayAirPackage ndap3 = new NextDayAirPackage(a5,a1,9,3,5,12,5.00M); //Test NextDayAirPackage 3

            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a3,a2,5,5,4,11,TwoDayAirPackage.Delivery.Saver); //Test TwoDayAirPackage 1 
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a8,a7,6,3,5,100,TwoDayAirPackage.Delivery.Early); //Test TwoDayAirPackage 2 
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a6,a1,3,3,3,5,TwoDayAirPackage.Delivery.Saver);  //Test TwoDayAirPackage 3 

            List<Parcel> parcels = new List<Parcel> { l1, l2, l3, gp1, gp2, gp3, ndap1, ndap2, ndap3, tdap1, tdap2, tdap3 }; // Test list of parcels

            // Display All Parcels and order by destination zip descending
            var orderByDestZip =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            WriteLine("List of Parcels sorted descending by destination zip\n");
            foreach (Parcel element in orderByDestZip)
            {
                WriteLine(element);
                WriteLine("--------------------");
            }
            Pause();

            //Display all Parcels and order by cost ascending
            var orderByCost =
                from p in parcels
                orderby p.CalcCost()
                select p;

            WriteLine("List of Parcels sorted ascending by cost\n");
            foreach (Parcel element in orderByCost)
            {
                WriteLine(element);
                WriteLine("--------------------");
            }
            Pause();

            //Display all Parcels and order first by Type ascending, then by Cost descending
            var orderByTypeThenCost =
                from p in parcels
                orderby p.GetType().ToString(), p.CalcCost() descending
                select p;

            WriteLine("List of Parcels sorted by type then subsorted descending by cost\n");
            foreach (Parcel element in orderByTypeThenCost)
            {
                WriteLine($"Parcel Type: {element.GetType()}\n");
                WriteLine(element);
                WriteLine("--------------------");
            }
            Pause();

            //Display all AirPackages that are heavy and order by weight descending
            var orderHeavyAPByWeight =
                from p in parcels
                where p is AirPackage && (p as AirPackage).IsHeavy() == true
                orderby (p as AirPackage).Weight descending
                select p;

            WriteLine("List of heavy AirPackages sorted descending by weight\n");
            foreach (Parcel element in orderHeavyAPByWeight)
            {
                WriteLine(element);
                WriteLine("--------------------");
            }
            Pause();
        }
        
        // Pause Method
        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and then clears the screen
        public static void Pause()
        {
            WriteLine("Press Enter to Continue...");
            ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
