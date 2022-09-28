// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// Create a function called RandomArray() that returns an integer array
static void RandomArray()
{
    Random rand = new Random();
    int[] randArray = new int[10];

    int Min = 26;
    int Max = 0;
    int Sum = 0;


    // Place 10 random integer values between 5 - 25 into the array
    for (int i = 0; i < randArray.Length; i++)
    {
        randArray[i] = rand.Next(5, 25);
        Sum += randArray[i];
        if (randArray[i] < Min) { Min = randArray[i]; }
        else if (randArray[i] > Max) { Max = randArray[i]; }
    }

    // Print the min and max values of the array
    Console.WriteLine($"Min: {Min}");
    Console.WriteLine($"Max: {Max}");

    // Print the sum of all the values
    Console.WriteLine($"Sum: {Sum}");

}

RandomArray();

static string TossCoin()
{
    Random rand = new Random();
    int coin = rand.Next(0, 2);
    string coinres = "";

    if (coin == 0)
    {
        coinres = "tails";
    }
    else
    {
        coinres = "heads";
    }

    return coinres;

}

for (int i = 0; i < 4; i++)
{
    Console.WriteLine(TossCoin());
}

static List<string> Names()
{
    List<string> names = new List<string>();
    names.Add("Todd");
    names.Add("Tiffany");
    names.Add("Charlie");
    names.Add("Geneva");
    names.Add("Sydney");

    List<string> namesFiltered = new List<string>();

    // Console.WriteLine(names.Count);
    int nameMax = 5;

    for (int i = 0; i < names.Count; i++)
    {
        // Console.WriteLine("Here:" + names[i] + " Length:" + names[i].Length);
        if (names[i].Length < nameMax)
        {
            namesFiltered.Add(names[i]);
        }
    }
    return namesFiltered;
}

List<string> nameslist = Names();
for (int i = 0; i < nameslist.Count; i++)
{
    Console.WriteLine(nameslist[i]);
}
