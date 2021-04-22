using System;
public static class Extensions
{
    public static int Length(this Person person)
    {
        return person.Name.Length;
    }
}
public class Person
{
    public string Name { get; set; }

    public char GetFirstChar()
    {
        return Name[1];
    }
}

internal class Program
{
    #region MyRegion
    //public static string HashPassword(string password)
    //{
    //    string first = GetHash(password).Result;
    //    return GetHash(first + first.Substring(0, first.Length / 2)).Result;
    //}

    //private static async Task<string> GetHash(string input)
    //{
    //    return await Task.Run(() =>
    //    {
    //        var bytes = System.Text.Encoding.UTF8.GetBytes(input);
    //        using (var hash = SHA512.Create())
    //        {
    //            var hashedInputBytes = hash.ComputeHash(bytes);
    //            var hashedInputStringBuilder = new System.Text.StringBuilder(128);
    //            foreach (var b in hashedInputBytes)
    //                hashedInputStringBuilder.Append(b.ToString("X2"));
    //            return hashedInputStringBuilder.ToString();
    //        }
    //    });
    //}

    //public static async Task<string> GenerateRefrashToken()
    //{
    //    var list = new List<string>();
    //    for (int i = 0; i < Random.Next(3, 7); i++)
    //    {
    //        list.Add(Guid.NewGuid().ToString());
    //    }

    //    return (await SummaTokens(list)).ToLower(); ;
    //}

    //private static readonly Random Random = new Random();
    //private static async Task<string> SummaTokens(IEnumerable<string> guids)
    //{
    //    var result = new StringBuilder();
    //    for (int i = 0; i < 36; i++)
    //    {
    //        foreach (var guid in guids)
    //        {
    //            result.Append(guid[Random.Next(0, 36)]);
    //        }
    //    }

    //    Console.WriteLine(result.ToString());

    //    return HashPassword(result.ToString().Replace("-", string.Empty));
    //} 
    #endregion


    private static void Main(string[] args)
    {
        Console.WriteLine(new Person() { Name = "Kirill" }.Length());
    }

}