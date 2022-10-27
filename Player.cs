using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spel_läxa
{
    public class Player
    {
        Random rand = new Random();
        
        // det är mer ".net" rktigt att använda properties istället för variabler

      
        /*public string name {get;set;} 
        public int coins {get;set;}= 30000;
        public int health {get;set;}= 10;
        public int damage {get;set;}= 1;
        public int armorValue {get;set;}= 0;
        public int potion {get;set;}= 5;
        public int weaponValue {get;set;}= 1;*/
        public string name;
        public int coins = 50;
        public int level = 1;  
        public int xp = 0; 
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 3;
        public int weaponValue = 1;
        public int korv = 2;    
        public int mods = 0;


       
           

        public int GetHealth() // Snyggt!
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }

        public int GetPower()
        {
            int upper = (2 * mods + 3);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }

        public int GetCoins()
        {
            int upper = (10 * mods + 50);
            int lower = (10 * mods + 10);
            return rand.Next(lower, upper);


        }

        public int Getxp()
        {
            int upper = (20 * mods + 666);
            int lower = (15 * mods + 333);
            return rand.Next(lower, upper);
        }

        public int GetlevelupValue()
        {
            return 100 * level + 400;
        }


        public bool CanLevelup()
        {
            if (xp >= GetlevelupValue())
                return true;
            else
                return false;   
        }

        public void LevelUp()
        {
            while (CanLevelup())
            {
                xp-=GetlevelupValue();
                level++;
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Grattis! Du är nu level " + level + "!");
            Console.ResetColor();

        }

        public void MaxLevelzz() 
        {
            if (level == 10)  
            {
                Environment.Exit(0);
            }
        }
        
            

    }

}
