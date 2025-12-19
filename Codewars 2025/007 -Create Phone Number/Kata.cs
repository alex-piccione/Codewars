public class Kata
{
    public static string CreatePhoneNumber(int[] numbers)
    {
        int[] v = [.. numbers];

        return $"({v[0]}{v[1]}{v[2]}) {v[3]}{v[4]}{v[5]}{v[6]}{v[7]}{v[8]}{v[9]}";
    }
}