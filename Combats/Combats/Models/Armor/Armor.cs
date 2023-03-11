using System;

namespace MyGame
{
    [Serializable]
    internal class Armor
    {
        public int Price { get; set; }
        public int HP { get; set; }
        public int Lvl { get; set; }

        public Armor()
        {
            Price = 0;
            Lvl = 1;
            HP = 30;
        }
        public Armor(int price, int lvl, int hp)
        {
            Price = price;
            Lvl = lvl;
            HP = hp;
        }

        public void PrintArmor()
        {
            Console.WriteLine($"\n\t\t============================================\n\t\tHP - {HP}, \n\t\tLevel: {Lvl}\n\t\tPrice - {Price} coins\n\t\t============================================\n");
        }
    }
}