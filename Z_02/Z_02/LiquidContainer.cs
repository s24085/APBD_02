using System.ComponentModel;
using System.Linq.Expressions;

namespace Z_02;

public class LiquidContainer : ContainerGeneral, IHazardNotifier
{
    public bool isDangerous { get; private set; }
    public LiquidContainer(double weight, double height, double netWeight, double depth, double maxCapacity, bool isDangerous) 
        : base(weight, height, netWeight, depth, SerialNumber.GenerateSerialNumber("L"), maxCapacity)
    {
        this.isDangerous = isDangerous;
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard notification for {serialNumber}: {message}");
    }
}


