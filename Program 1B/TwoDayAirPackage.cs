// Program 1B
// CIS 200-50
// Fall 2021
// Due: 10/8/2021
// By: 5342897

//File: TwoDayAirPackage.cs
//This concrete class is derived from the AirPackage Class. It adds a Delivery Type property and Calculates Cost. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TwoDayAirPackage : AirPackage
{
    public enum Delivery {Early,Saver}; //deliveries can be either Early or Saver

    private Delivery _deliveryType; //backing field for DeliveryType property

    private const double LWH_RATE = .18; //used in calculation of cost
    private const double WEIGHT_RATE = .2; //used in calculation of cost
    private const double SAVER_DISCOUNT = .85; //15% off if type is Saver

    //Constructor
    //Precondition: Length, Width, Height, Weight are >= 0, Delivery Type value is defined within the Delivery enum.
    //Postcondition: TwoDayAirPackage object created and values passed to properties.
    public TwoDayAirPackage(Address originAddress,Address destAddress, double length, double width, double height, double weight, Delivery type)
        : base(originAddress, destAddress, length, width, height, weight)
    {
        DeliveryType = type;
    }

    //Delivery Type Property
    public Delivery DeliveryType
    {
        get //Precondition: None. Postcondition: Returns Delivery Type from backing field.
        {
            return _deliveryType;
        }
        set //Precondition: passed value is defined in Delivery Enum. Postcondition: value is assigned to backing field.
        {
            if (value >= Delivery.Early && value <= Delivery.Saver)
                _deliveryType = value;
            else
                throw new ArgumentOutOfRangeException($"{nameof(DeliveryType)}", value,
                    $"{nameof(DeliveryType)} must be defined within Delivery enum ('Early' or 'Saver')");
        }
    }

    //CalcCost Method
    //Precondition:  None
    //Postcondition: The package cost is returned, discounted if the type is 'Saver'
    public override decimal CalcCost()
    {
        double cost = LWH_RATE * (Length + Width + Height) + WEIGHT_RATE * Weight; //local variable cost is assigned to the base cost 
        if (DeliveryType == Delivery.Saver)
             cost *= SAVER_DISCOUNT; //discount applied if type is 'Saver'
        return (decimal)cost;
    }

    //ToString Method
    //Precondition:  None
    //Postcondition: A formatted string is returned which includes the Delivery Type.
    public override string ToString()
    {
        return base.ToString() + $"\nDelivery Type: {DeliveryType}";
    }
}
