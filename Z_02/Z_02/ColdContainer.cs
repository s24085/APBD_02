namespace Z_02;

public class ColdContainer : ContainerGeneral, IHazardContainer
{
    public string productType { get; private set; }
    private Dictionary<string, double> productTypeMap;
    public double ContainerTemp { get; private set; }

}