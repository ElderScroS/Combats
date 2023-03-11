using System.Collections.Generic;
using System;

namespace MyGame
{
    [Serializable]
    internal class Shop
    {
        public List<Weapon> weaponList = new List<Weapon>();
        public List<Armor> armorList = new List<Armor>();

        public void SetShopToDefault()
        {
            Ax ax = new Ax();
            Sword sword = new Sword();
            Mace mace = new Mace();
            Staff staff = new Staff();
            Bow bow = new Bow();
            weaponList.Add(ax);
            weaponList.Add(sword);
            weaponList.Add(mace);
            weaponList.Add(staff);
            weaponList.Add(bow);

            Armor a1 = new Armor(80, 3, 100);
            Armor a2 = new Armor(100, 1, 60);
            Armor a3 = new Armor(80, 1, 50);
            Armor a4 = new Armor(80, 2, 80);
            armorList.Add(a1);
            armorList.Add(a2);
            armorList.Add(a3);
            armorList.Add(a4);
        }

        public void PrintWeapons()
        {
            int i = 1;

            foreach (var item in weaponList)
            {
                Console.Write($"\n\t\t\t\t{i++}\n\t\t\t\t");
                item.PrintWeapon();
            }

        }
        public void PrintArmors()
        {
            int i = 1;

            foreach (var item in armorList)
            {
                Console.Write($"\n\t\t\t\t{i++}\n\t\t\t\t");
                item.PrintArmor();
            }
        }
    }
}