namespace Z_02;

public class ColdContainer : ContainerGeneral, IHazardNotifier
{
    public string productType { get; private set; }
    public double containerTemp { get; private set; }
    private Dictionary<string, double> productTypeMap;

    public ColdContainer(double weight, double height, double netWeight, double depth,
        double maxCapacity, string productType, double containerTemp) : base(weight, height, netWeight, depth, SerialNumber.GenerateSerialNumber("C"), maxCapacity)
    {
        this.productType = productType;
        this.containerTemp = containerTemp;
       
        InitializeProductTypeMap();
        ValidateProductTypeAndTemperature();
    }

    private void InitializeProductTypeMap()
    {
        productTypeMap = new Dictionary<string, double>
        {
            { "Banany", 13.3 },
            { "Czekolada", -18 },
            { "Ryby", -2 },
            { "Mięso", -15 },
            { "Lody", -18 },
            { "Mrożona pizza", -30 },
            { "Ser", 7.2 },
            { "Kiełbasa", 5 },
            { "Masło", 20.5 },
            { "Jajka", 19 }
        };
    }

    private void ValidateProductTypeAndTemperature()
    {
        if (!productTypeMap.ContainsKey(productType))
        {
            throw new ArgumentException($"Nieobsługiwany typ produktu: {productType}.", nameof(productType));
        }

        if (containerTemp < productTypeMap[productType])
        {
            throw new InvalidOperationException($"Temperatura kontenera {containerTemp}°C jest za niska dla produktu {productType}, wymagana temperatura to {productTypeMap[productType]}°C.");
        }
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
        weight = 0;
    }

    public override void AddContainer()
    {
        throw new NotImplementedException();
    }
    

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard notification for {serialNumber}: {message}");
    }
}
