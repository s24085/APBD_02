namespace Z_02;

public class SerialNumber
{
    private string constans = "KON";
    private Random r = new Random();
    private string conatinerType;
    private int randomNumber;

    public string SetSerialNumber(ContainerGeneral container)
    {
        this.conatinerType = container.ToString();
        randomNumber = r.Next(1, 51);
        return constans + conatinerType + randomNumber;
    }
}