using System.Text.Json;

public class Individual
{
    public int Id { get; set; }
    public bool? IsHumanoid { get; set; }
    public string Planet { get; set; }
    public int? Age { get; set; }
    public List<string> Traits { get; set; }

    public Individual() {}

    public void PrintDetails()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Is Humanoid: {IsHumanoid}");
        Console.WriteLine($"Planet: {Planet}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine("Traits: " + (Traits != null ? string.Join(", ", Traits) : "None"));
        Console.WriteLine();
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
        Console.WriteLine("Details of individuals with even Ids:");
        foreach (var individual in individuals)
        {
            if (individual.Id % 2 == 0)
            {
                individual.PrintDetails();
            }
        }
        Console.WriteLine("Details of individuals with odd Ids:");
        foreach (var individual in individuals)
        {
            if (individual.Id % 2 != 0)
            {
                individual.PrintDetails();
            }
        }
    }
}
