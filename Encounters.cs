using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spel_läxa
{
    public class Encounters
    {
        static Random rand = new Random();
       
        public static void Ingethänder()
        {
            Console.Clear();
            Console.WriteLine("Du får en dålig känsla i kroppen och tar de lugnt ett tag");
            Console.ReadLine();
        }

        public static void FirstEncounter()
        {
            Console.Clear();
            Console.WriteLine(" Du går förbi några träd och blir nedbrottat av ett monster som luktar fisk");
            Console.ReadKey();
     
            Combat(true, "", 1, 4); 
        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("Du kollar upp bland träden och ser ett monster som vill slåss ");
            Console.ReadKey();
            Combat(true, "", 2, 5);
        }


        public static void WizardEncounter() 
        {
            Console.Clear();
            Console.WriteLine("hips vips teleporterar en trollkarl fram sig");
            Console.WriteLine("långt skägg svarta ögon och mord i sinne");
            Console.ReadKey();
            Combat(false, "  Stor farlig Trollkarl", 4,3); 
        }


        public static void RandomEncounter()
        {
            switch (rand.Next(0, 9))
            {
                case 0:
                    FirstEncounter();
                    break;
                case 1:
                    BasicFightEncounter();
                    break;
                case 2:
                    WizardEncounter();
                    break;
                case 3:
                    BasicFightEncounter();
                    break;
                case 4:
                    WizardEncounter();
                    break;
                case 5:BasicFightEncounter();
                    break;
                case 6:BasicFightEncounter();
                    break;
                case 7: FirstEncounter();
                    break;
                case 8: FirstEncounter(); 
                    break;  
                case 9:
                    Ingethänder();
                    break;
            }
        }

        public static void Combat(bool random, string name, int power, int health )
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("=============");
                Console.WriteLine("|(A)ttack (D)ucka slag |");
                Console.WriteLine("|(K)orv      (E)lixir  |");
                Console.WriteLine("=============");
                Console.WriteLine("Elixir: " + Program.currentPlayer.potion + " Health:" + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    // attack
                    Console.WriteLine("Du attackerar " +n+ " med en rejäl höger krok! "  +n+ " Slår tillbaka ");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1,4);
                    Console.WriteLine("Du tar " + damage + " skada, och ger " + attack + " skada");
                    Program.currentPlayer.health-= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "Defend")
                {
                    //Defend
                   
                    Console.WriteLine("När " + n + " försöker slå dig så parerar du");
                    int damage =  (p/4) - Program.currentPlayer.armorValue; 
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue)/2;  //delar skada med 2
                    Console.WriteLine("Du tar " + damage + " skada, och ger " + attack + " skada");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "o" || input.ToLower() == "spring")
                {
                    // run
                   if (rand.Next(0,2) == 0)
                    {
                        Console.WriteLine("Du försöker springa från " + n + ", men ett slag får dig att ramla");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        
                        Console.WriteLine("Du tar " + damage + " skada och kan ej fly");
                        Console.ReadKey();
                        Program.currentPlayer.health -= damage;

                    }
                    else
                    {
                        Console.WriteLine("Du undviker " + n + " som en balettdansös tills du ser en affär med ljuset tänt");
                        Console.ReadKey();
                        
                        SHOP.LoadShop(Program.currentPlayer);
                        
                       
                    }
                }
                //korv
                else if (input.ToLower() == "k" || input.ToLower() == "Korv")
                {
                    Console.WriteLine("Du Tar fram en korv ur bröstfickan ");
                    int korvV = 8; 
                    Console.WriteLine("Du får " + korvV + " HP");
                    Program.currentPlayer.health += korvV;
                    Program.currentPlayer.korv = Program.currentPlayer.korv - 1;

                    if (Program.currentPlayer.korv < 0)
                        Console.WriteLine("Du har slut på KÖRV");
                }
           
                  
                                     

                else if (input.ToLower() == "e" || input.ToLower() == "Elixir")
                {
                    // heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("Du letar i fickorna efter elixir men hittar inget");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage =0;
                        Console.WriteLine(n + " slår dig med en kvist och du tar " + damage + "skada");

                    }

                    else
                    {
                        
                        Console.WriteLine("Du letar i fickan och hittar Elixir");
                        int potionV = 5; 
                        Console.WriteLine("Du får " + potionV + " HP");
                        Program.currentPlayer.health+= potionV;
                        Program.currentPlayer.potion = Program.currentPlayer.potion - 1;

                        if (Program.currentPlayer.potion < 0)
                            Console.WriteLine("Du har slut på Elixir");
                                                                       
                        Console.WriteLine("Medans du är upptagen slår, " + n + " dig");     
                        int damage = (p / 2)-Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Du tar " + damage + " skada");
                    }
                    Console.ReadKey();
                }

                if (Program.currentPlayer.level >= 9)
                {
                    Console.WriteLine("========================================================");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("============DU BESEGRADE ALLA VARELSER!! ===============");
                    Console.WriteLine("============LVL: 10 ye ye ye============================");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("========================================================");


                    System.Environment.Exit(0);
                }


                if (Program.currentPlayer.health <= 0)
                {
                    //döds kod
                    Console.WriteLine("Du tog för mkt skada och DOG av " + n + " =(");
                    Console.ReadKey();
                    System.Environment.Exit(0);

                }
                Console.ReadKey();

            } // COins
            int c = Program.currentPlayer.GetCoins();
            int x = Program.currentPlayer.Getxp();
            Console.WriteLine("Du vann över"+"" + n +"" + ", och får " + c + " Guld mynt! Du har fått " +x+" XP!"); 
            Program.currentPlayer.coins += c;
            Program.currentPlayer.xp += x;

            if (Program.currentPlayer.CanLevelup())
                Program.currentPlayer.LevelUp();

            Console.ReadKey();
        }
        public static string GetName()
        {
            switch(rand.Next(0, 5))
            {
                case 0:
                    return "MördarGöran";
                case 1: 
                    return "Zombie";
                    case 2:
                    return "Vampyr";
                case 3:
                    return "Träsktroll";
                case 4:
                    return "Clown med kniv";
                case 5:
                    return "Spöket Laban";

            }
            return "Cloudutvecklare";



                
        }


    }
}
