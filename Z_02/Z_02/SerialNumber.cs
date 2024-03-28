namespace Z_02;

public class SerialNumber
{
    private static List<string> usedSerialNumbers = [];
    private static readonly Random random = new();
    private const string prefix = "KON";

    public static string GenerateSerialNumber(string containerType)
    {
        string serialNumber;
        do
        {
            var randomNumber = random.Next(1, 1000); 
            serialNumber = $"{prefix}-{containerType}-{randomNumber}";
        } while (usedSerialNumbers.Contains(serialNumber));

        usedSerialNumbers.Add(serialNumber);
        return serialNumber;
    }
}