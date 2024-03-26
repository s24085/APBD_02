namespace Z_02;

public class GasContainer :ContainerGeneral, IHazardNotifier
{
    public GasContainer(double weight, double height, double netWeight, double depth, SerialNumber serialNumber, double maxCapacity, int pressure) : base(weight, height, netWeight, depth, serialNumber, maxCapacity)
    {
        this.pressure = pressure;
    }

    private int pressure { get; private set; }
    
    if(getWeight()> ConatinerShip.weight){
        throw Exception("Overloaded");
    }
}