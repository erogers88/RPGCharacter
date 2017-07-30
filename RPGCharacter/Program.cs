using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Database;

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
            foreach (int align in Alignment.AlignmentType)
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

            SaveCharacter Save1 = new SaveCharacter();
            Save1.SaveFunction(PC);

            TestDB WriteAlignments = new TestDB();
            WriteAlignments.GetLine();

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
        public int Alignment { get; set; }
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

    public class SaveCharacter
    {
        public void SaveFunction(Character CharName)
        {

            string connectionString = @"Data Source = (local)\SQLTESTSERVER; Initial Catalog = RPG; Integrated Security = True";
            string storedProcedure = "dbo.Create_Character";
            SqlConnection RPGDB = new SqlConnection(connectionString);
            SqlCommand TestCommand = new SqlCommand(storedProcedure, RPGDB);
            SqlDataReader TestReader;
            TestCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter Name = new SqlParameter("@Name", CharName.Name);
            TestCommand.Parameters.Add(Name);
            SqlParameter Strength = new SqlParameter("@Strength", CharName.Strength);
            TestCommand.Parameters.Add(Strength);
            SqlParameter Dexterity = new SqlParameter("@Dexterity", CharName.Dexterity);
            TestCommand.Parameters.Add(Dexterity);
            SqlParameter Constitution = new SqlParameter("@Constitution", CharName.Constitution);
            TestCommand.Parameters.Add(Constitution);
            SqlParameter Wisdom = new SqlParameter("@Wisdom", CharName.Wisdom);
            TestCommand.Parameters.Add(Wisdom);
            SqlParameter Intelligence = new SqlParameter("@Intelligence", CharName.Intelligence);
            TestCommand.Parameters.Add(Intelligence);
            SqlParameter Charisma = new SqlParameter("@Charisma", CharName.Charisma);
            TestCommand.Parameters.Add(Charisma);
            SqlParameter Alignment = new SqlParameter("@Alignment", CharName.Alignment);
            TestCommand.Parameters.Add(Alignment);
            SqlParameter Bio = new SqlParameter("@Bio", CharName.Bio);
            TestCommand.Parameters.Add(Bio);

            RPGDB.Open();
            TestReader = TestCommand.ExecuteReader();
            RPGDB.Close();
        }
    }
    public class TestDB
    {
        public void GetLine()
        {
            string connectionString = @"Data Source = (local)\SQLTESTSERVER; Initial Catalog = RPG; Integrated Security = True";
            SqlConnection RPGDB = new SqlConnection(connectionString);
            SqlCommand TestCommand = new SqlCommand();
            SqlDataReader TestReader;
            TestCommand.CommandText = "Select * from alignments";
            TestCommand.CommandType = System.Data.CommandType.Text;
            TestCommand.Connection = RPGDB;

            RPGDB.Open();
            TestReader = TestCommand.ExecuteReader();

            while (TestReader.Read())
            {
                string AlignmentType = (string)TestReader[1];
                Console.WriteLine(AlignmentType);
            }

            RPGDB.Close();
        }
    }
}  