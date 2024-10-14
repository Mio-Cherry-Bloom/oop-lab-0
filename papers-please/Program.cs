using System.Text.Json;

public class Individual
{
    public int Id { get; set; }
    public bool? IsHumanoid { get; set; }
    public string Planet { get; set; }
    public int? Age { get; set; }
    public List<string> Traits { get; set; }

    public Individual() {}

    public void PrintId()
    {
        Console.WriteLine($"Id: {Id}");
    }
}

public class InputWrapper
{
    public List<Individual> Input { get; set; }
}

public class Program
{
    public static void Main()
    {
        string jsonFilePath = @"..\..\..\..\input.json";
        string jsonData = File.ReadAllText(jsonFilePath);
        InputWrapper inputWrapper = JsonSerializer.Deserialize<InputWrapper>(jsonData, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        List<Individual> individuals = inputWrapper.Input;
        Console.WriteLine("Even Ids:");
        foreach (var individual in individuals)
        {
            if (individual.Id % 2 == 0)
            {
                individual.PrintId();
            }
        }
        Console.WriteLine("\nOdd Ids:");
        foreach (var individual in individuals)
        {
            if (individual.Id % 2 != 0)
            {
                individual.PrintId();
            }
        }
    }
}
