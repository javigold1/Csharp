// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
/* IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions."); */

// Execute Assignment Tasks here!
// nb .Where() == "get me all the data where this condition is true"

// first eruption in Chile
Eruption chErup = eruptions.FirstOrDefault(c => c.Location == "Chile");
Console.WriteLine(chErup);

// first "Hawaii Is" eruption; if none, print "No Hawaiian Is eruption found"
Eruption hwErup = eruptions.FirstOrDefault(h => h.Location == "Hawaiian Is");
if (hwErup == null)
{
    Console.WriteLine("No Hawaiian Is eruption found");
}
else
{
    Console.WriteLine(hwErup);
}

// first eruption after 1900 AND in "New Zealand"
Eruption nzErup = eruptions.FirstOrDefault(nz => nz.Location == "New Zealand" && nz.Year > 1900);
// Console.WriteLine(nzErup);

// all eruptions where volcano's elevation is > 2000m
IEnumerable<Eruption> twoThou = eruptions.Where(t => t.ElevationInMeters > 2000).ToList();
PrintEach(twoThou);

// all eruptions where volcano's name starts with Z, and total number of eruptions
IEnumerable<Eruption> zeta = eruptions.Where(z => z.Volcano.StartsWith("Z")).ToList();
PrintEach(zeta);
Console.WriteLine(zeta.Count());

// find highest elevation and print that integer
// use highest elevation variable to find and print name of volcano with that name
var highest = eruptions.Max(h => h.ElevationInMeters);
Console.WriteLine(highest);
foreach (var h in eruptions)
{
    if (h.ElevationInMeters == highest)
    {
        Console.WriteLine(h.Volcano);
    }
}
// Eruption highestEl = eruptions.Where(h => h.ElevationInMeters == "3320");


// print all volcano names alphabetically
IEnumerable<Eruption> alpha = eruptions.OrderBy(a => a.Volcano);
int x = 1;
foreach (var a in alpha)
{
    Console.WriteLine($"{a.Volcano}");
    x++;
}

// print all eruptions that happened before the year 1000 CE alphabetically by volcano name
IEnumerable<Eruption> alphaThou = eruptions.OrderBy(a => a.Volcano).Where(a => a.Year < 1000);
// PrintEach(alphaThou);

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}