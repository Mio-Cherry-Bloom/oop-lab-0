using System.Text.Json;

public class Individual
{
    public int Id { get; set; }
    public bool? IsHumanoid { get; set; }
    public string Planet { get; set; }
    public int? Age { get; set; }
    public List<string> Traits { get; set; }

    public Individual() {}

    public string Classify()
    {
        var traitsList = Traits ?? new List<string>();
        var isHumanoidValue = IsHumanoid;
        var planetValue = Planet ?? string.Empty;
        var ageValue = Age;

        string classification = "Unknown Universe";

        if (isHumanoidValue == false)
        {
            if (planetValue == "Kashyyyk") classification = "Star Wars Universe (Wookie)";
            else if (planetValue == "Endor") classification = "Star Wars Universe (Ewok)";
            else if (planetValue == "Vogsphere") classification = "Hitchhiker's Universe (Vogons)";
            else if (ageValue > 200) classification = "Star Wars Universe (Wookie)";
            else if (ageValue > 60)
            {
                if (traitsList.Contains("HAIRY") || traitsList.Contains("TALL")) classification = "Star Wars Universe (Wookie)";
                else if (traitsList.Contains("BULKY") || traitsList.Contains("GREEN")) classification = "Hitchhiker's Universe (Vogons)";
            }
            else
            {
                if (traitsList.Contains("BULKY") || traitsList.Contains("GREEN")) classification = "Hitchhiker's Universe (Vogons)";
                else if (traitsList.Contains("TALL")) classification = "Star Wars Universe (Wookie)";
                else if (traitsList.Contains("SHORT")) classification = "Star Wars Universe (Ewok)";
            }
        }
        else if (isHumanoidValue == true)
        {
            if (planetValue == "Asgard") classification = "Marvel Universe (Asgardian)";
            else if (planetValue == "Betelgeuse") classification = "Hitchhiker's Universe (Betelgeusian)";
            else if (planetValue == "Earth")
            {
                if (ageValue > 200) classification = "Lord of the Rings Universe (Elf)";
                else if (traitsList.Contains("BLONDE") || traitsList.Contains("POINTY_EARS")) classification = "Lord of the Rings Universe (Elf)";
                else if (traitsList.Contains("SHORT") || traitsList.Contains("BULKY")) classification = "Lord of the Rings Universe (Dwarf)";
            }
            else
            {
                if (ageValue > 5000) classification = "Lord of the Rings Universe (Elf)";
                else if (ageValue > 200)
                {
                    if (traitsList.Contains("TALL")) classification = "Marvel Universe (Asgardian)";
                    else if (traitsList.Contains("POINTY_EARS")) classification = "Lord of the Rings Universe (Elf)";
                }
                else
                {
                    if (traitsList.Contains("EXTRA_ARMS") || traitsList.Contains("EXTRA_HEAD")) classification = "Hitchhiker's Universe (Betelgeusian)";
                    else if (traitsList.Contains("SHORT") || traitsList.Contains("BULKY")) classification = "Lord of the Rings Universe (Dwarf)";
                    else if (traitsList.Contains("TALL")) classification = "Marvel Universe (Asgardian)";
                    else if (traitsList.Contains("POINTY_EARS")) classification = "Lord of the Rings Universe (Elf)";
                }
            }
        }
        else
        {
            if (planetValue == "Kashyyyk") classification = "Star Wars Universe (Wookie)";
            else if (planetValue == "Endor") classification = "Star Wars Universe (Ewok)";
            else if (planetValue == "Asgard") classification = "Marvel Universe (Asgardian)";
            else if (planetValue == "Betelgeuse") classification = "Hitchhiker's Universe (Betelgeusian)";
            else if (planetValue == "Vogsphere") classification = "Hitchhiker's Universe (Vogons)";
            else if (planetValue == "Earth")
            {
                if (ageValue > 200) classification = "Lord of the Rings Universe (Elf)";
                else if (traitsList.Contains("BLONDE") || traitsList.Contains("POINTY_EARS")) classification = "Lord of the Rings Universe (Elf)";
                else if (traitsList.Contains("SHORT") || traitsList.Contains("BULKY")) classification = "Lord of the Rings Universe (Dwarf)";
            }
            else
            {
                if (ageValue > 5000) classification = "Lord of the Rings Universe (Elf)";
                else if (ageValue > 400)
                {
                    if (traitsList.Contains("TALL")) classification = "Marvel Universe (Asgardian)";
                    else if (traitsList.Contains("POINTY_EARS")) classification = "Lord of the Rings Universe (Elf)";
                }
                else if (ageValue > 60)
                {
                    if (traitsList.Contains("EXTRA_ARMS") || traitsList.Contains("EXTRA_HEAD")) classification = "Hitchhiker's Universe (Betelgeusian)";
                    else if (traitsList.Contains("GREEN")) classification = "Hitchhiker's Universe (Vogons)";
                    else if (traitsList.Contains("SHORT")) classification = "Lord of the Rings Universe (Dwarf)";
                    else if (traitsList.Contains("HAIRY")) classification = "Star Wars Universe (Wookie)";
                    else if (traitsList.Contains("POINTY_EARS")) classification = "Lord of the Rings Universe (Elf)";
                    else if (traitsList.Contains("BLONDE") && traitsList.Contains("TALL")) classification = "Marvel Universe (Asgardian)";
                }
                else
                {
                    if (traitsList.Contains("EXTRA_ARMS") || traitsList.Contains("EXTRA_HEAD")) classification = "Hitchhiker's Universe (Betelgeusian)";
                    else if (traitsList.Contains("GREEN")) classification = "Hitchhiker's Universe (Vogons)";
                    else if (traitsList.Contains("SHORT") && traitsList.Contains("BULKY")) classification = "Lord of the Rings Universe (Dwarf)";
                    else if (traitsList.Contains("HAIRY") && traitsList.Contains("TALL")) classification = "Star Wars Universe (Wookie)";
                    else if (traitsList.Contains("POINTY_EARS")) classification = "Lord of the Rings Universe (Elf)";
                    else if (traitsList.Contains("BLONDE") && traitsList.Contains("TALL")) classification = "Marvel Universe (Asgardian)";
                    else if (traitsList.Contains("SHORT") && traitsList.Contains("HAIRY")) classification = "Marvel Universe (Asgardian)";
                }
            }
        }

        return classification;
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

        foreach (var individual in individuals)
        {
            string classification = individual.Classify();
            Console.WriteLine($"Id: {individual.Id}, Classification: {classification}");
        }
    }
}
