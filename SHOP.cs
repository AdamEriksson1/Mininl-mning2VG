using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spel_läxa
{
    public class SHOP
    {
 
        public static void LoadShop(Player p)
        {
            
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionPr;
            int armorPr ;
            int weaponPr;
            int diffPr;
            int korv;
            while (true)
            {
                potionPr = 20 + 10 * p.mods;
                armorPr = 100 * (p.armorValue + 1);
                weaponPr = 100 * (p.weaponValue);
                diffPr = 300 + 100 * p.mods;
                korv = 40+10*p.mods;

                Console.Clear();
                Console.WriteLine("===========================");
                Console.WriteLine("=====Kött och Elixir AB====");
                Console.WriteLine("===========================");
                Console.WriteLine("|(E)lixir            |$" + potionPr );
                Console.WriteLine("|(V)apen Amulett     |$" + weaponPr);
                Console.WriteLine("|(A)Mulett Försvar   |$" + armorPr);
                Console.WriteLine("|(K)orv me elixir i  |$" + korv);
               // Console.WriteLine("|(D)iff Mod          |$" + diffPr);
                Console.WriteLine("Coins:           " + p.coins);
                Console.WriteLine("=============");
                Console.WriteLine("(Q)uit");
               




                string input = Console.ReadLine().ToLower();

                if (input == "e" || input == "elixir")
                    TryBuy("elixir", potionPr, p);

                else if (input == "v" || input == "Vapen")
                    TryBuy("vapen", weaponPr, p);
                else if (input == "k" || input == "korv")
                    TryBuy("korv", korv, p);
                else if (input == "a" || input == "armor")
                    TryBuy("armor", armorPr, p);
                
                else if (input == "d" || input == "difficulty mod")
                    TryBuy("dif", diffPr, p);
                
                else if (input == "q" || input == "quit")
                    break;
            }

        }
        static void TryBuy(string item, int cost, Player p) 
        {
            if (p.coins >= cost)
            {
                if (item == "elixir")
                    p.potion++;
                else if (item == "vapen")
                    p.weaponValue++;
                else if (item =="korv")
                    p.korv++;
                else if (item == "armor")
                    p.armorValue++;
                if(item == "dif")
                    p.mods++;

                p.coins -= cost;

            }
            else
            {
                Console.WriteLine("Du är för fattig :( ");
                Console.ReadKey();
            }
        }


    }
}
