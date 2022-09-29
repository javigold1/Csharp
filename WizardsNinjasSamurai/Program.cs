
// Test Samurai Attack method:
Samurai SamuraiOne = new Samurai("Chuck Norris");
Samurai SamuraiTwo = new Samurai("Darth Vader");

Console.WriteLine($"{SamuraiOne.Name} {SamuraiOne.Health}");
Console.WriteLine($"{SamuraiTwo.Name} {SamuraiTwo.Health}");
SamuraiOne.Attack(SamuraiTwo);
Console.WriteLine($"{SamuraiTwo.Name} {SamuraiTwo.Health}");
SamuraiTwo.Meditate();
Console.WriteLine($"{SamuraiTwo.Name} {SamuraiTwo.Health}");





public class Human
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Health { get; set; }

    public Human(string name)
    {
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Name = name;
        Health = 100;
    }

    public Human(string name, int str, int intel, int dex, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        Health = hp;
    }

    // Build Attack method
    public virtual int Attack(Human target)
    {
        int dmg = Strength * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
}

public class Samurai : Human
{
    public Samurai(string name) : base(name)
    {
        // Samurai should have a default health of 200
        Health = 200;
    }
    // Provide an override Attack method to Samurai, which calls the base Attack and reduces the target to 0 if it has less than 50 remaining health points.
    public override int Attack(Human target)
    {
        int TargetHealth = base.Attack(target);
        if (TargetHealth < 50)
        {
            target.Health = 0;
        }
        return target.Health
        ;
    }
    // Samurai should have a method called Meditate, which when invoked, heals the Samurai back to full health
    public void Meditate()
    {
        this.Health += 200;
    }
}

public class Wizard : Human
{
    public Wizard(string name) : base(name)
    {
        Health = 50;
        Intelligence = 25;
    }
    public override int Attack(Human target)
    {
        return base.Attack(target);

    }
}





