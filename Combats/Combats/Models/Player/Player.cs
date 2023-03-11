using System;
using System.Collections.Generic;

namespace MyGame
{
    [Serializable]
    internal class Player
    {
        public Player()
        {
            Name = "None";
            Password = "None";
            Character = "None";
            HP = 0;
            Coins = 1000;
            Lvl = 1;
            Wins = 0;
            Loses = 0;
            Active = true;
        }

        public List<FightDate> fightList = new List<FightDate>();
        public List<Weapon> weaponsPlayer = new List<Weapon>();
        public List<Armor> armorsPlayer = new List<Armor>();

        public string Name { get; set; }
        public string Password { get; set; }
        public int HP { get; set; }
        public int Coins { get; set; }
        public int Lvl { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public bool Active { get; set; }
        public string Character { get; set; }

        public void PrintFightDates()
        {
            foreach (var item in fightList)
            {
                Console.WriteLine("\t\t\t\t====================================");
                item.PrintFightDate();
                Console.WriteLine("\t\t\t\t====================================\n");
            }
        }
        public void AddWeapon(Weapon weapon)
        {
            weaponsPlayer.Add(weapon);
        }
        public void RemoveWeapon(Weapon weapon)
        {
            weaponsPlayer.Remove(weapon);
        }
        public void AddArmor(Armor armor)
        {
            armorsPlayer.Add(armor);
        }
        public void RemoveArmor(Armor armor)
        {
            armorsPlayer.Remove(armor);
        }
        public void PrintWeapons()
        {
            int i = 1;

            foreach (var item in weaponsPlayer)
            {
                Console.Write($"\n\t\t\t\t{i++}\n\t\t\t\t");
                item.PrintWeapon();
            }

        }
        public void PrintArmors()
        {
            int i = 1;

            foreach (var item in armorsPlayer)
            {
                Console.Write($"\n\t\t\t\t{i++}\n\t\t\t\t");
                item.PrintArmor();
            }
        }

        public void add_lvl()
        {
            Lvl++;
            HP += 10;
        }

        public void add_win()
        {
            Wins++;

            if (Wins % 2 == 0)
            {
                add_lvl();
            }
        }

        public void add_lose()
        {
            Loses++;
        }

        public void increase_coins(int coins)
        {
            Coins += coins;
        }

        public void decrease_coins(int coins)
        {
            Coins -= coins;
        }

    }
}