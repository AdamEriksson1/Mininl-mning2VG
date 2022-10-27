using System.Diagnostics.SymbolStore;
using System.Security.Cryptography;

namespace spel_läxa
{
      class Program
    {

        public static Player currentPlayer = new Player();
        public static bool mainloop = true;

        static void Main(string[] args)
        {
            Start();
             while (mainloop)
             {
                MainMenu();
                
             }

        }

        static void MainMenu()
        {
            bool MenuLoop = true;

            while (MenuLoop)
            {
                Console.Clear();
                Console.WriteLine("1. Gå och äventyra");
                Console.WriteLine("2. Karaktärsinfo");
                Console.WriteLine("3. Gå till affären");
                Console.WriteLine("4. Avsluta spel");


                int svar;
                if(int.TryParse(Console.ReadLine(), out svar))
                    
                 
                        if (svar == 1)
                        {
                            Encounters.RandomEncounter();
                        }

                        if (svar == 2)
                        {
                            stats();
                            Console.ReadLine();
                        }
                        if (svar == 3)
                        {
                            SHOP.LoadShop(currentPlayer);
                        }
                        if (svar == 4)
                        {
                            Console.WriteLine("stick då om du vill, bryr mig inte");
                            System.Environment.Exit(0);

                        }
                  
                
            }
        }

         public static void stats()
        {
            Console.WriteLine(currentPlayer.name + "´s STATS");
            Console.WriteLine();
            Console.WriteLine("HP                 " + currentPlayer.health);
            Console.WriteLine("Para:              " + currentPlayer.coins);
            Console.WriteLine("Vapen Amulett      " + currentPlayer.weaponValue);
            Console.WriteLine("Försvars Amulett   " + currentPlayer.armorValue);
            Console.WriteLine("Elixir             " + currentPlayer.potion);
            Console.WriteLine("KÖRV               " + currentPlayer.korv);
           // Console.WriteLine("Difficulty mods    " + currentPlayer.mods); extra grej
            Console.WriteLine("Xp:");
            Console.Write("[");
            Program.ProgressBar("+", " ", ((decimal)currentPlayer.xp / (decimal)currentPlayer.GetlevelupValue()), 25);
            Console.WriteLine("]");
            Console.WriteLine("Level: " + currentPlayer.level);
            Console.WriteLine("--------------");

        }

        static void Start()
        {
            Console.WriteLine("Välkommen till ÄventyrsDagzzz");
            Console.WriteLine("Namn: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Du vaknar upp bland blöt mossa och har knappt något minne kvar");
            if (currentPlayer.name == "")
                Console.WriteLine("Du kan inte ditt egna namn?");
            else
            Console.WriteLine("Du vet att du heter " + currentPlayer.name + " och att du vill härifrån");
            
            Console.ReadKey();
            Console.Clear();
            

        }
        


        public static void ProgressBar(string filerChar,string backgroundChar, decimal value, int size)
        {
            int dif = (int)(value * size);
            for(int i = 0; i < size; i++)
            {
                if (i < dif)
                    Console.Write(filerChar);
                else
                    Console.Write(backgroundChar);
            }

        }

        
            


    }
}