namespace Z_02;

public class GasContainer(
    double weight,
    double height,
    double netWeight,
    double depth,
    double maxCapacity,
    int pressure)
    : ContainerGeneral(weight, height, netWeight, depth, SerialNumber.GenerateSerialNumber("G"), maxCapacity),
        IHazardNotifier

{
    public double pressure { get; private set; } = pressure;


    public void NotifyHazard(string msg)
    {
        Console.WriteLine($"Hazard notification for {serialNumber}: {msg}");
    }
}