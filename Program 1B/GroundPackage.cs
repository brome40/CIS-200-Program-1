// Program 1B
// CIS 200-50
// Fall 2021
// Due: 10/8/2021
// By: 5342897

//File: GroundPackage.cs
//This concrete class is a derived class of Package and includes a calculated Zone-Distance and calculates the cost. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GroundPackage : Package
{
    private readonly int _zoneDistance;     //positave difference of the first digit of the
                                            //zip code of the origin address and destination address
    
    private const double LWH_RATE = .15;    //used in calculation of cost
    private const double WEIGHT_RATE = .7;  //used in calculation of cost
    private const int ZONE_INCREASE = 1;    //used in calculation of cost

    //Constructor
    //Precondition:   Length, Width, Height, Weight are > 0
    //Postconditions: GroundPackage object created and arguments handled by base classes.
    //                Zone Distance calculated and assigned to readonly variable. 
    public GroundPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
        : base(originAddress, destAddress, length, width, height, weight)
    {
        int zip1First = Int32.Parse(originAddress.Zip.ToString().Substring(0,1)); //the first digit of the zip code of the originAddress
        int zip2First = Int32.Parse(destAddress.Zip.ToString().Substring(0, 1)); //the first digit of the zip code of the destAddress
        _zoneDistance = Math.Abs(zip1First - zip2First);
    }

    //Read-Only Zone Distance Property
    //Precondition:   None
    //Postcondition:  Zone Distance is returned.
    public int ZoneDistance
    {
        get
        {
            return _zoneDistance;
        }
    }

    //Override CalcCost Method
    //Precondition:  None
    //Postcondition: Cost is calculated and returned as a decimal.
    public override decimal CalcCost()
    {
        return (decimal)(LWH_RATE * (Length + Width + Height) + WEIGHT_RATE * (ZoneDistance + ZONE_INCREASE) * Weight);
    }

    //ToString Method
    //Precondition:  None
    //Postcondition: A formatted String is returned, adding the zone distance the base class string. 
    public override string ToString()
    {
        return base.ToString() + $"\nZone Distance: {ZoneDistance}";
    }
}
