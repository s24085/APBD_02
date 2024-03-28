namespace Z_02;

public class ColdContainer : ContainerGeneral, IHazardNotifier
{
    public string productType { get; private set; }
    private double containerTemp { get; set; }

    public static Dictionary<string, double> productTypeMap = new Dictionary<string, double>
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
        { "Jajka", 19 },
        { "Inne", 0 }
    };

    public ColdContainer(double weight, double height, double netWeight, double depth,
        double maxCapacity, string productType, double containerTemp) : base(weight, height, netWeight, depth,
        SerialNumber.GenerateSerialNumber("C"), maxCapacity)
    {
        this.productType = productType;
        this.containerTemp = containerTemp;

        ValidateProductTypeAndTemperature();
    }

    private void ValidateProductTypeAndTemperature()
    {
        if (!productTypeMap.ContainsKey(productType))
        {
            throw new ArgumentException($"Nieobsługiwany typ produktu: {productType}.", nameof(productType));
        }

        if (containerTemp < productTypeMap[productType] - 2)
        {
            throw new InvalidOperationException(
                $"Temperatura kontenera {containerTemp}°C jest za niska dla produktu {productType}, optymalna temperatura to {productTypeMap[productType]}°C.");
        }

        if (containerTemp > productTypeMap[productType] + 2)
        {
            throw new InvalidOperationException(
                $"Temperatura kontenera {containerTemp}°C jest za wysoka dla produktu {productType}, optymalna temperatura to {productTypeMap[productType]}°C.");
        }
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard notification for {serialNumber}: {message}");
    }
}