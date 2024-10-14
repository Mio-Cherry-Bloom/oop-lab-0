using System;
using System.Collections.Generic;

public class Individual
{
    public int Id { get; set; }
    public bool? IsHumanoid { get; set; }
    public string Planet { get; set; }
    public int? Age { get; set; }
    public List<string> Traits { get; set; }

    public Individual(int id, bool? isHumanoid, string planet, int? age, List<string> traits)
    {
        Id = id;
        IsHumanoid = isHumanoid;
        Planet = planet;
        Age = age;
        Traits = traits;
    }

    public void PrintDetails()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"IsHumanoid: {IsHumanoid}");
        Console.WriteLine($"Planet: {Planet}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine("Traits: " + string.Join(", ", Traits));
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        var traits = new List<string> { "BLONDE", "TALL" };
        Individual individual1 = new Individual(1, true, "Asgard", 2034, traits);
        individual1.PrintDetails();
        individual1.Traits.Add("STRONG");
        individual1.PrintDetails();
    }
}
