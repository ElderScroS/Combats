using System;

namespace MyGame
{
    [Serializable]
    internal class Mace : Weapon
    {
        public Mace()
        {
            Damage = 8;
            Price = 110;
            Level = 1;
            HP = 20;
        }

        public override void PrintWeapon()
        {
            Console.WriteLine($"\n\t\t=============================================\n\t\tType of weapon - Mace: HP - {HP}, Damage - {Damage}\n\t\tLevel: {Level}\n\t\tPrice - {Price} coins\n\t\t=============================================\n");
        }
    }
}