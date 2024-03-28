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

    
    // public override void LoadContainer (double weight)
    // {
    //     double maxAllowedWeight = isDangerous ? maxCapacity * 0.5 : maxCapacity * 0.9;
    //     if (weight > maxAllowedWeight)
    //     {
    //         string error = isDangerous ? 
    //             "Próba załadowania niebezpiecznego ładunku przekraczającego 50% maksymalnej pojemności kontenera." : 
    //             "Próba załadowania ładunku przekraczającego 90% maksymalnej pojemności kontenera.";
    //         NotifyHazard(error);
    //         throw new Exception("OverfillException: " + error);
    //     }
    //     this.weight = weight;
    // }
    //
    // public override void ClearContainer()
    // {
    //     weight = 0;
    // }
    

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard notification for {serialNumber}: {message}");
    }
}


