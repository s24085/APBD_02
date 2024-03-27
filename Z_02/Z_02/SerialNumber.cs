namespace Z_02;

public class SerialNumber
{
    private static List<string> usedSerialNumbers = new List<string>();
    private static readonly Random random = new Random();
    private const string prefix = "KON";

    public static string GenerateSerialNumber(string containerType)
    {
        string serialNumber;
        do
        {
            int randomNumber = random.Next(1, 1000); 
            serialNumber = $"{prefix}-{containerType}-{randomNumber}";
        } while (usedSerialNumbers.Contains(serialNumber));

        usedSerialNumbers.Add(serialNumber);
        return serialNumber;
    }
}