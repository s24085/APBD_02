namespace Z_02;

public class ShipContainer
{
    public List<ContainerGeneral> Containers { get; private set; } = new List<ContainerGeneral>();
    private double maxSpeed;
    private int maxLoad;
    private double maxTotal;
    
}