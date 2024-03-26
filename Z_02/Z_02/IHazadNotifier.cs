namespace Z_02;

public class IHazadNotifier
{
    private bool isInDanger;
    private PhoneNumber phoneNumber;
    private void sendMsg(SerialNumber serialNumber)
    {
        if (isInDanger == true)
        {
           Console.WriteLine(serialNumber + " " + "is in danger");
        }
        {
            ;
        }
    }
}

