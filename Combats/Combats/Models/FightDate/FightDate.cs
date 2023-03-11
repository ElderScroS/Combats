using System;

namespace MyGame
{
    [Serializable]
    internal class FightDate
    {
        public DateTime Date { get; set; }
        public bool WinOrLose { get; set; }
        public string NameEnemy { get; set; }

        public void PrintFightDate()
        {
            Console.WriteLine($"\t\t\t\tFight date - {Date}");    
            Console.WriteLine($"\t\t\t\tYou vs {NameEnemy}");

            if (WinOrLose == true) 
            {
                Console.WriteLine($"\t\t\t\tYou win");
            }
            else 
            {
                Console.WriteLine($"\t\t\t\tYou lose"); 
            }
        }
    }
}
