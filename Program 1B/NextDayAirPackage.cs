// Program 1B
// CIS 200-50
// Fall 2021
// Due: 10/8/2021
// By: 5342897

//File: NextDayAirPackage.cs
// This concrete class is derived from the Air Package Class. It accepts an additional argument for an express fee and calculates the cost. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NextDayAirPackage : AirPackage 
{
    private decimal _exFee; //the express cost backing fielf for the NextDayAirPackage 

    private const double LWH_RATE = .35; //used in calculation of cost
    private const double WEIGHT_RATE = .25; //used in calculation of cost
    private const double HEAVY_RATE = .2; //used in extra weight charge within calculation of cost
    private const double LARGE_RATE = .22; //used in extra size charge within calculation of cost

    //Constructor
    //Precondition: Length, Width, Height, and Weight are > 0. Express Fee is >= 0
    //Postcondition: NextDayAirPackage is created with values from argument.
    public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, decimal exFee)
        : base(originAddress,destAddress,length,width,height,weight)
    {
        ExFee = exFee;
    }

    //Express Fee Property
    public decimal ExFee
    {
        get
        //Precondition: None
        //Postcondition: Express Fee is returned.
        {
            return _exFee;
        }
        // Precondition:  value >= 0
        // Postcondition: The next day air package's express fee has been set to the
        //                specified value
        private set // Helper set property
        {
            if (value >= 0)
                _exFee = value;
            else
                throw new ArgumentOutOfRangeException(nameof(ExFee), value,
                    $"{nameof(ExFee)} must be >= 0");
        }
    }

    //CalcCost Method
    //Precondition: None
    //Postcondition: The package cost is returned, containing an extra cost if it is heavy or large. 

    public override decimal CalcCost()
    {
        double cost = LWH_RATE * (Length + Width + Height) + WEIGHT_RATE * Weight + (double)ExFee; //base cost
        if (IsHeavy() == true)
            cost += HEAVY_RATE * Weight; //added weight cost if it is heavy
        if (IsLarge() == true)
            cost += LARGE_RATE * (Length + Width + Height); //added size cost if it is large 
        return (decimal)cost; 
    }

    //ToString Method 
    //Precondition: None
    //Postcondition: A formatted string is returned which includes the express fee. 
    public override string ToString()
    {
        return base.ToString() + $"\nExpress Fee: {ExFee:C}";
    }
}
