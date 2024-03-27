namespace Z_02;

public class GasContainer :ContainerGeneral, IHazardNotifier
{
    public double pressure { get; private set; }
    public GasContainer(double weight, double height, double netWeight, double depth, double maxCapacity, int pressure) : base(weight, height, netWeight, depth, SerialNumber.GenerateSerialNumber("G"), maxCapacity)
    {
        this.pressure = pressure;
    }

    public override void LoadContainer(double weight)
    {
        if (weight > maxCapacity)
        {
            throw new Exception("OverfillException");
        }

        this.weight = weight;
    }

    public override void ClearContainer()
    {
       weight= weight*0.05;
    }

    public override void AddContainer()
    {
        throw new NotImplementedException();
    }
    

    public void NotifyHazard(string msg)
    {
        Console.WriteLine($"Hazard notification for {serialNumber}: {msg}");
    }
}