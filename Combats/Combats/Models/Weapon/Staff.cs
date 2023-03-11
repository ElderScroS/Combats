using System;

namespace MyGame
{
    [Serializable]
    internal class Staff : Weapon
    {
        public Staff()
        {
            Damage = 15;
            Price = 130;
            Level = 1;
            HP = 25;
        }

        public override void PrintWeapon()
        {
            Console.WriteLine($"\n\t\t============================================\n\t\tType of weapon - Staff: HP - {HP}, Damage - {Damage}\n\t\tLevel: {Level}\n\t\tPrice - {Price} coins\n\t\t============================================\n");
        }
    }
}