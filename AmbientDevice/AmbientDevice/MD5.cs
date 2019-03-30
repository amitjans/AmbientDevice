using System.Text;

public class MD5 {

    public static string CalculateMD5Hash(string input)
    {
        var md5 = System.Security.Cryptography.MD5.Create();
        var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        var hash = md5.ComputeHash(inputBytes);
        var sb = new StringBuilder();
        foreach (var t in hash)
        {
            sb.Append(t.ToString("X2"));
        }
        return sb.ToString();
    }
}
