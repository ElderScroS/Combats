using System;

namespace MyGame
{
    [Serializable]
    internal class Bow : Weapon
    {
        public Bow()
        {
            Damage = 5;
            Price = 50;
            Level = 1;
            HP = 15;
        }

        public override void PrintWeapon()
        {
            Console.WriteLine($"\n\t\t============================================\n\t\tType of weapon - Bow: HP - {HP}, Damage - {Damage}\n\t\tLevel: {Level}\n\t\tPrice - {Price} coins\n\t\t============================================\n");
        }
    }
}