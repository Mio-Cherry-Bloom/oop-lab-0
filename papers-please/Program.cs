using System;
using System.Collections.Generic;
using System.IO;
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

public class Program
{
    public static void Main()
    {
        string jsonFilePath = @"..\..\..\..\input.json";
        string jsonData = File.ReadAllText(jsonFilePath);
        List<Individual> individuals = JsonSerializer.Deserialize<List<Individual>>(jsonData, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
