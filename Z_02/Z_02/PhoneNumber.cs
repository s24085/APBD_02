using System.Text.RegularExpressions;

namespace Z_02;

public class PhoneNumber
{
    public const string motif = @"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$";

    public static bool IsPhoneNbr(string number)
    {
        if (number != null) return Regex.IsMatch(number, motif);
        else return false;
    }
}