// Program 1B
// CIS 200-50
// Fall 2021
// Due: 10/8/2021
// By: 5342897

//File: Package.cs
//This absract class is a derived class of the Parcel class and adds Length, Width, Height, and Weight properties.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Package : Parcel
{
    private double _length; //The length of the package in inches
    private double _width; //The width of the package in inches
    private double _height; //The height of the package in inches
    private double _weight; //The weight of the package in pounds

    //Constructor
    //Precondition: length, width, height, and weight must be > 0
    //Postcondition: package object created and passed argument values
    public Package(Address originAddress, Address destAddress, double length, double width, double height, double weight)
        : base(originAddress, destAddress)
    {
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;
    }

    //Length Property
    public double Length
    {
        get //Precondition: None. Postcondition: length is returned from backing field.
        {
            return _length;
        }
        set //Precondition: passed value > 0. Postcondition: length is set to passed value. 
        {
            if (value > 0)
                _length = value;
            else
                throw new ArgumentOutOfRangeException($"{nameof(Length)}", value,
                    $"{nameof(Length)} must be > 0");
        }
    }

    //Width Property
    public double Width
    {
        get //Precondition: None. Postcondition: width is returned from backing field.
        {
            return _width;
        }
        set //Precondition: passed value > 0. Postcondition: width is set to passed value. 
        {
            if (value > 0)
                _width = value;
            else
                throw new ArgumentOutOfRangeException($"{nameof(Width)}", value,
                    $"{nameof(Width)} must be > 0");
        }
    }
    //Height Property
    public double Height
    {
        get //Precondition: None. Postcondition: height is returned from backing field.
        {
            return _height;
        }
        set //Precondition: passed value > 0. Postcondition: height is set to passed value. 
        {
            if (value > 0)
                _height = value;
            else
                throw new ArgumentOutOfRangeException($"{nameof(Height)}", value,
                    $"{nameof(Height)} must be > 0");
        }
    }
    //Weight Property
    public double Weight
    {
        get //Precondition: None. Postcondition: weight is returned from backing field.
        {
            return _weight;
        }
        set //Precondition: passed value > 0. Postcondition: weight is set to passed value. 
        {
            if (value > 0)
                _weight = value;
            else
                throw new ArgumentOutOfRangeException($"{nameof(Weight)}", value,
                    $"{nameof(Weight)} must be > 0");
        }
    }
    //ToString Method
    //Precondition: None
    //Postcondition: A formatted string displaying all properties is returned
    public override string ToString()
    {
        return base.ToString() + $"\nLength: {Length} inches\nWidth: {Width} inches\nHeight: " +
            $"{Height} inches\nWeight: {Weight} pounds";
    }
}
