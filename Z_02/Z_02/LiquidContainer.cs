using System.ComponentModel;
using System.Linq.Expressions;

namespace Z_02;

public class LiquidContainer(
    double weight,
    double height,
    double netWeight,
    double depth,
    double maxCapacity,
    bool isDangerous)
    : ContainerGeneral(weight, height, netWeight, depth, SerialNumber.GenerateSerialNumber("L"), maxCapacity),
        IHazardNotifier
{
    public bool isDangerous { get; private set; } = isDangerous;

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard notification for {serialNumber}: {message}");
    }
}