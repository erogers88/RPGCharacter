using System;

namespace Character
{
    public class PC
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public int Alignment { get; set; }
        public string Bio { get; set; }
    }

    public static class Alignment
    {
        public static int[] AlignmentType =
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9
        };
    }

    public class RollStats
    {
        public void Main(PC Char)
        {
            Random rand = new Random();
            Char.Strength = rand.Next(60, 90);
            Char.Dexterity = rand.Next(60, 90);
            Char.Constitution = rand.Next(60, 90);
            Char.Wisdom = rand.Next(60, 90);
            Char.Intelligence = rand.Next(60, 90);
            Char.Charisma = rand.Next(60, 90);
        }
    }

    public class PrintStats
    {
        public void Main(PC Char)
        {
            Console.WriteLine("Name: {0}", Char.Name);
            Console.WriteLine("Strength: {0}", Char.Strength);
            Console.WriteLine("Dexterity: {0}", Char.Dexterity);
            Console.WriteLine("Constitution: {0}", Char.Constitution);
            Console.WriteLine("Wisdom: {0}", Char.Wisdom);
            Console.WriteLine("Intelligence: {0}", Char.Intelligence);
            Console.WriteLine("Charisma: {0}", Char.Charisma);
            Console.WriteLine("Alignment: {0}", Char.Alignment);
            Console.WriteLine("Bio: {0}", Char.Bio);
        }

    }
}