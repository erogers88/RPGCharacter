using System;
using System.Data.SqlClient;
using Character;


namespace MainGame
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu MainMenu1 = new MainMenu();
            MainMenu1.PrintMainMenu();

            int NumResult = 0;
            //Error Handling on a Convert Function
            //          try
            //          {
            //              //Int32.TryParse(Console.ReadLine(), out NumResult);
            //              NumResult = Convert.ToInt32(Console.ReadLine());
            //               
            //          }
            //          catch
            //          {
            //              Console.WriteLine("Enter an integer you fucking asshole");
            //              Console.ReadLine();
            //          }
            while (NumResult == 0)
            {
                string UserNameInput = Console.ReadLine();
                Int32.TryParse(UserNameInput, out NumResult);
                if(NumResult == 0)
                {
                    Console.WriteLine("Enter a number in range");
                }
                else if(NumResult < 1 || NumResult > 6)
                {
                    Console.WriteLine("Enter a number in range");
                    NumResult = 0;
                }
            }
            int NumChoice = NumResult;
            if(NumChoice == 1)
            {
                NewGame NewGame1 = new NewGame();
                NewGame1.Main();
            }
        }
    }

    public class MainMenu
    {
        public void PrintMainMenu()
        {
            Console.WriteLine("##############################################################################");
            Console.WriteLine("###                                                                        ###");
            Console.WriteLine("###                   #####   #####    #####  #####                        ###");
            Console.WriteLine("###                     #     #         #       #                          ###");
            Console.WriteLine("###                     #     ####       #      #                          ###");
            Console.WriteLine("###                     #     #           #     #                          ###");
            Console.WriteLine("###                     #     #####   #####     #                          ###");
            Console.WriteLine("###                                                                        ###");
            Console.WriteLine("###                       ######   ######   ######                         ###");
            Console.WriteLine("###                       #   #    #   #    #                              ###");
            Console.WriteLine("###                       # ##     # ##     #   ###                        ###");
            Console.WriteLine("###                       #  #     #        #     #                        ###");
            Console.WriteLine("###                       #   #    #        #######                        ###");
            Console.WriteLine("###                                                                        ###");
            Console.WriteLine("##############################################################################");
            Console.WriteLine();
            Console.WriteLine("                      1. New Game");
            Console.WriteLine("                      2. Load Game");
            Console.WriteLine("                      3. Options");
            Console.WriteLine("                      4. How to Play");
            Console.WriteLine("                      5. Monster Encyclopedia");
            Console.WriteLine("                      6. Credits");
        }
    }

    public class NewGame
    {
        public void Main()
        {
            PC PC1 = new PC();

            Console.WriteLine("What is your name?");
            PC1.Name = Console.ReadLine();
            Console.WriteLine("Your name is {0}", PC1.Name);


            Console.WriteLine("What is your alignment?");
            int AlignLoopNumber = 1;
            foreach (int align in Alignment.AlignmentType)
            {
                Console.WriteLine("{0} : {1}", AlignLoopNumber, align);
                AlignLoopNumber++;
            }
            int AlignInput = (Convert.ToInt32(Console.ReadLine())) - 1;
            PC1.Alignment = Alignment.AlignmentType[AlignInput];

            Console.WriteLine("Press any key to roll your stats");
            Console.ReadLine();
            RollStats Roll1 = new RollStats();
            Roll1.Main(PC1);
            PrintStats Print1 = new PrintStats();
            Print1.Main(PC1);
            Console.ReadLine();

            bool IsCharacterExists = false;
            SaveCharacter Save1 = new SaveCharacter(IsCharacterExists);
            Save1.SaveFunction(PC1);

            Console.WriteLine("Awesome. You've made a new character");
            Console.ReadLine();
        }
    }

    public class SaveCharacter
    {
        //This is a constructor that sets a flag if the character exists already
        public SaveCharacter(bool exists)
        {
            IsExistingCharacter = exists;
        }
        //This function opens a database connection and calls one of two stored procedures to either create or update a character record
        public void SaveFunction(PC CharName)
        {
            string storedProcedure;
            if(IsExistingCharacter)
            {
                storedProcedure = "dbo.Update_Character";
            }
            else
            {
                storedProcedure = "dbo.Create_Character";
            }

            SqlConnection RPGDB = new SqlConnection(connectionString);
            SqlCommand TestCommand = new SqlCommand(storedProcedure, RPGDB);
            TestCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader TestReader;

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
        private bool IsExistingCharacter { get; set; }
        private string connectionString = @"Data Source = (local)\SQLTESTSERVER; Initial Catalog = RPG; Integrated Security = True";
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