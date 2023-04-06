// Program 1B
// CIS 200-50
// Fall 2021
// Due: 10/8/2021
// By: 5342897

//File: AirPackage.cs
//This abstract class is derived from the Package class and adds methods to test if the package is heavy or large. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AirPackage : Package
{
    private const int HEAVY = 75; //used as benchmark for if weight is considered heavy or not
    private const int LARGE = 100; //used as benchmark for if dimensions are considered large or not

    //Constructor
    //Precondition: Length, Width, Height, and Weight are > 0
    //Postcondition: AirPackage object is created and arguments passed to base class.
    public AirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
        : base(originAddress, destAddress, length, width, height, weight) { }

    //IsHeavy Method
    //Precondition:  None
    //Postcondition: If Weight is at least 75lbs true is returned, if not false is returned
    public bool IsHeavy()
    {
        if (Weight >= HEAVY)
            return true;
        else
            return false;
    }

    //IsLarge Method
    //Precondition: None
    //Postcondition: If sum of dimensions is at least 100in true is returned, if not false if returned
    public bool IsLarge()
    {
        if (Length + Width + Height >= LARGE)
            return true;
        else
            return false;
    }

    //ToString Method
    //Precondition: None
    //Postcondition: Formatted string is returned, including heavy and large status
    public override string ToString()
    {
        return base.ToString() + $"\nHeavy: {IsHeavy()}\nLarge: {IsLarge()}";
    }
}
