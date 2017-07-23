using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    class Program
    {
        static void Main(string[] args)
        {

            Character PC = new Character();

            Console.WriteLine("What is your name?");
            PC.Name = Console.ReadLine();
            Console.WriteLine("Your name is {0}", PC.Name);


            Console.WriteLine("What is your alignment?");
            int AlignLoopNumber = 1;
            foreach(string align in Alignment.AlignmentType)
            {
                Console.WriteLine("{0} : {1}", AlignLoopNumber, align);
                AlignLoopNumber++;
            }
            int AlignInput = (Convert.ToInt32(Console.ReadLine())) - 1;
            PC.Alignment = Alignment.AlignmentType[AlignInput];


            Console.WriteLine("Press any key to roll your stats");
            Console.ReadLine();
            RollStats Roll1 = new RollStats();
            Roll1.Main(PC);
            PrintStats Print1 = new PrintStats();
            Print1.Main(PC);
            Console.ReadLine();
           

        }
    }
    public class Character
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public string Alignment { get; set; }
        public string Bio { get; set; }
    }
    
    public class RollStats
    {
        public void Main(Character Char)
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
        public void Main(Character Char)
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

    public class Alignment
    {
        public static string[] AlignmentType =
{
            "Lawful Good",
            "Lawful Neutral",
            "Lawful Evil",
            "Neutral Good",
            "True Neutral",
            "Neutral Evil",
            "Chaotic Good",
            "Chaotic Neutral",
            "Chaotic Evil"
        };
    }
}