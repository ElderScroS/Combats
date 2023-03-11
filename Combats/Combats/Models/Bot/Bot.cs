using System;
using System.Collections.Generic;

namespace MyGame
{
    [Serializable]
    internal class Bot
    {
        public Bot()
        {
            Health = 0;
            Level = 1;
            Character = "None";
        }

        public List<Weapon> weaponsBot = new List<Weapon>();
        public List<Armor> armorsBot = new List<Armor>();

        public Weapon weapon { get; set; }
        public Armor armor { get; set; }

        public int Health { get; set; }
        public int Level { get; set; }
        public string Character { get; set; }


        public void SetBotDefault()
        {
            Ax ax = new Ax();
            Sword sword = new Sword();
            Mace mace = new Mace();
            Staff staff = new Staff();
            Bow bow = new Bow();

            weaponsBot.Add(ax);
            weaponsBot.Add(sword);
            weaponsBot.Add(mace);
            weaponsBot.Add(staff);
            weaponsBot.Add(bow);

            Armor a1 = new Armor(80, 3, 100);
            Armor a2 = new Armor(100, 1, 60);
            Armor a3 = new Armor(80, 1, 50);
            Armor a4 = new Armor(80, 2, 80);

            armorsBot.Add(a1);
            armorsBot.Add(a2);
            armorsBot.Add(a3);
            armorsBot.Add(a4);
        }

        public void SetBot()
        {
            Random rnd = new Random(); int charac = rnd.Next(1, 5);
            int weap = rnd.Next(0, 4); int arm = rnd.Next(0, 3);

            switch (charac)
            {
                case 1:
                    Character = "Orc";
                    Health = 180;

                    weapon = weaponsBot[weap];
                    armor = armorsBot[arm];

                    weapon.Damage += 10; armor.HP += 80;

                    break;

                case 2:
                    Character = "Dark Elf";
                    Health = 130;

                    weapon = weaponsBot[weap];
                    armor = armorsBot[arm];

                    weapon.Damage += 20; armor.HP += 50;

                    break;

                case 3:
                    Character = "High Elf";
                    Health = 140;

                    weapon = weaponsBot[weap];
                    armor = armorsBot[arm];

                    weapon.Damage += 15; armor.HP += 60;

                    break;

                case 4:
                    Character = "Imperial";
                    Health = 150;

                    weapon = weaponsBot[weap];
                    armor = armorsBot[arm];

                    weapon.Damage += 10;
                    armor.HP += 90;

                    break;

                case 5:
                    Character = "Khajiit";
                    Health = 120;

                    weapon = weaponsBot[weap];
                    armor = armorsBot[arm];

                    weapon.Damage += 20; armor.HP += 70;

                    break;

            }
        }
    }
}