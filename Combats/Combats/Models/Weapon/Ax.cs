using System;

namespace MyGame
{
    [Serializable]
    internal class Ax : Weapon
    {
        public Ax()
        {
            Damage = 10;
            Price = 100;
            Level = 1;
            HP = 120;
        }

        public override void PrintWeapon()
        {
            Console.WriteLine($"\n\t\t============================================\n\t\tType of weapon - Ax: HP - {HP}, Damage - {Damage}\n\t\tLevel: {Level}\n\t\tPrice - {Price} coins\n\t\t============================================\n");
        }
    }
}