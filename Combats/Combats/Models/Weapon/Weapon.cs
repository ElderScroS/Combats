using System;

namespace MyGame
{
    [Serializable]
    class Weapon
    {
        public int Damage { get; set; }
        public int Price { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }

        public void DecreaseHP() { HP--; }
        public virtual void PrintWeapon() { }
    }
}