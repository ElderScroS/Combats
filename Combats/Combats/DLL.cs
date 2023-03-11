using System;
using System.Collections.Generic;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace MyGame
{
    class DLL
    {
        #region Serializes

        static void SaveSerialize(string path, DB db)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, db);
            }
        }
        static DB LoadDeserialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (DB)formatter.Deserialize(fs);
            }
        }

        #endregion

        #region PrintFuncs

        public static void PrintFight(string name1, string name2, int hp1, int hp2, int lvl1, int lvl2, int a1, int a2)
        {
            Console.Clear();
            Console.WriteLine("======================================================== |FIGHT| =======================================================\n\n\n");
            Console.WriteLine("\t\t\t\t||====================================================||");
            Console.WriteLine($"\t\t\t\t   Player1: {name1}              Player2: {name2}   \n");
            Console.WriteLine($"\t\t\t\t   Health: {hp1}                 Health: {hp2}       ");
            Console.WriteLine($"\t\t\t\t   Level: {lvl1}               \tLevel: {lvl2}     ");
            Console.WriteLine($"\t\t\t\t   Armor: {a1}                   Armor: {a2}         ");
            Console.WriteLine("\t\t\t\t||====================================================||");

        }
        public static void PrintDropOrSell()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t||=======================||");
            Console.WriteLine("\t\t\t\t\t\t||      0 - Go back      ||");
            Console.WriteLine("\t\t\t\t\t\t||      1 - Drop         ||");
            Console.WriteLine("\t\t\t\t\t\t||      2 - Sell         ||");
            Console.Write("\t\t\t\t\t\t||=======================||\n\n\t\t\t\t\t\tChoose(go back [0]) - ");
        }
        public static void PrintWeaponOrArmor()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t||=======================||");
            Console.WriteLine("\t\t\t\t\t\t||      0 - Go back      ||");
            Console.WriteLine("\t\t\t\t\t\t||      1 - Weapons      ||");
            Console.WriteLine("\t\t\t\t\t\t||      2 - Armors       ||");
            Console.Write("\t\t\t\t\t\t||=======================||\n\n\t\t\t\t\t\tChoose - ");
        }
        public static void PrintAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("====================================================== |ADMIN MENU| ====================================================\n");
            Console.WriteLine("\t\t\t\t\t\t||===================================||");
            Console.WriteLine("\t\t\t\t\t\t||      0 - Go back tab              ||");
            Console.WriteLine("\t\t\t\t\t\t||      1 - Add weapon to shop       ||");
            Console.WriteLine("\t\t\t\t\t\t||      2 - Add armor to shop        ||");
            Console.WriteLine("\t\t\t\t\t\t||      3 - Ban player               ||");
            Console.WriteLine("\t\t\t\t\t\t||      4 - Unban player             ||");
            Console.Write("\t\t\t\t\t\t||===================================||\n\n\t\t\t\t\t\tChoose - ");
        }
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("====================================================== |MAIN MENU| =====================================================\n");
            Console.WriteLine("\t\t\t\t\t\t||======================||");
            Console.WriteLine("\t\t\t\t\t\t||   0 - Exit           ||");
            Console.WriteLine("\t\t\t\t\t\t||   1 - Registration   ||");
            Console.WriteLine("\t\t\t\t\t\t||   2 - Log in         ||");
            Console.Write("\t\t\t\t\t\t||======================||\n\n\t\t\t\t\t\tChoose - ");
        }
        public static void PrintPlayerMenu(Player player)
        {
            Console.Clear();
            Console.WriteLine("========================================================= |PLAYER MENU| ===============================================\n");
            Console.WriteLine($"\tName: {player.Name}");
            Console.WriteLine($"\tLevel: {player.Lvl}");
            Console.WriteLine($"\tCharacter: {player.Character}");
            Console.WriteLine($"\tHealth: {player.HP}");
            Console.WriteLine($"\tWins: {player.Wins}");
            Console.WriteLine($"\tLoses: {player.Loses}");
            Console.WriteLine($"\tCoins: {player.Coins}");

            Console.WriteLine("\t\t\t\t\t\t ||==============================||");
            Console.WriteLine("\t\t\t\t\t\t || 0 - Go back tab              ||");
            Console.WriteLine("\t\t\t\t\t\t || 1 - Inventory                ||");
            Console.WriteLine("\t\t\t\t\t\t || 2 - Shop                     ||");
            Console.WriteLine("\t\t\t\t\t\t || 3 - Player1 vs Player2       ||");
            Console.WriteLine("\t\t\t\t\t\t || 4 - Player1 vs Bot           ||");
            Console.WriteLine("\t\t\t\t\t\t || 5 - Jurnal of Fights         ||");
            Console.WriteLine("\t\t\t\t\t\t ||==============================||");
            Console.Write("\n\n\t\t\t\t\t\tChoose - ");


        }
        public static void PrintCharacters()
        {
            string eqs = "======================================================================";
            Console.WriteLine("\n\t\t\t\t\t\t\tGO BACK TAB - 0\n\n");
            Console.WriteLine("\t\t\t||    1. Orc      - [   +10 damage    || 180 HP ||    +80 Armor ]    ||");
            Console.WriteLine("\t\t\t||    2. Dark Elf - [   +25 damage    || 130 HP ||    +50 Armor ]    ||");
            Console.WriteLine("\t\t\t||    3. High Elf - [   +15 damage    || 140 HP ||    +60 Armor ]    ||");
            Console.WriteLine("\t\t\t||    4. Imperial - [   +10 damage    || 150 HP ||    +80 Armor ]    ||");
            Console.Write($"\t\t\t||    5. Khajiit  - [   +20 damage    || 120 HP ||    +70 Armor ]    ||\n\t\t\t{eqs}\n\n\t\t\t\t\t\t|| Choose - ");
        }

        #endregion

        #region PlayerFunc

        public static void InventoryFunc(Player player, DB database)
        {
            bool GoBackIsFalse = true;

            while (GoBackIsFalse)
            {
                PrintWeaponOrArmor();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        GoBackIsFalse = false;

                        break;

                    case 1:
                        {
                            if (player.weaponsPlayer.Count >= 1)
                            {
                                Console.Clear();

                                player.PrintWeapons();
                                Console.Write("\t\tChoose[go back - 0] - ");
                                int index = int.Parse(Console.ReadLine());

                                if (index == 0)
                                {
                                    GoBackIsFalse = false;
                                }
                                else if (index >= 1 && index <= player.weaponsPlayer.Count)
                                {
                                    PrintDropOrSell();
                                    int choose = int.Parse(Console.ReadLine());

                                    switch (choose)
                                    {
                                        case 0:
                                            GoBackIsFalse = false;

                                            break;

                                        case 1:
                                            player.RemoveWeapon(player.weaponsPlayer[index - 1]);

                                            break;

                                        case 2:
                                            player.increase_coins(player.weaponsPlayer[index - 1].Price / 2);
                                            database.shop.weaponList.Add(player.weaponsPlayer[index - 1]);
                                            player.RemoveWeapon(player.weaponsPlayer[index - 1]);

                                            break;

                                        default:
                                            Console.Clear();
                                            Console.WriteLine("\n\n\t\t\t!!! Wrong input !!!");
                                            Thread.Sleep(2000);

                                            break;

                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\n\t\t\t!!! Index out of list range Weapons !!!");
                                    Thread.Sleep(2000);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\n\n\t\t\t!!! There are no weapons in your inventory !!!");
                                Thread.Sleep(2000);
                            }

                            SaveSerialize("DB.dat", database);

                            break;

                        }
                    case 2:
                        {
                            if (player.armorsPlayer.Count >= 1)
                            {
                                Console.Clear();
                                player.PrintArmors();
                                Console.Write("\t\tChoose[go back - 0] - ");
                                int index = int.Parse(Console.ReadLine());

                                if (index == 0)
                                {
                                    GoBackIsFalse = false;
                                }
                                else if (index >= 1 && index <= player.armorsPlayer.Count)
                                {
                                    PrintDropOrSell();
                                    int choose = int.Parse(Console.ReadLine());
                                    switch (choose)
                                    {
                                        case 0:
                                            GoBackIsFalse = false;

                                            break;

                                        case 1:
                                            player.RemoveArmor(player.armorsPlayer[index - 1]);

                                            break;

                                        case 2:
                                            player.increase_coins(player.armorsPlayer[index - 1].Price / 2); database.shop.armorList.Add(player.armorsPlayer[index - 1]); player.RemoveArmor(player.armorsPlayer[index - 1]);

                                            break;

                                        default:
                                            Console.Clear();
                                            Console.WriteLine("\n\n\t\t\t!!! Wrong input !!!");
                                            Thread.Sleep(2000);

                                            break;

                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\n\t\t\t!!! Index out of list range Armors !!!");
                                    Thread.Sleep(2000);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\n\n\t\t\t!!! There are no armors in your inventory  !!!");
                                Thread.Sleep(2000);
                            }

                            SaveSerialize("DB.dat", database);
                        }

                        break;

                    default:
                        Console.WriteLine("\n\n\t\t\t\t\t\tWrong input!!!\n\n");
                        Thread.Sleep(3000);

                        break;

                }
            }
        }

        public static void ShopFunc(Player player, DB database)
        {
            bool IsGoBack = true;
            while (IsGoBack)
            {
                PrintWeaponOrArmor();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        IsGoBack = false;
                        break;


                    case 1:
                        {
                            Console.Clear();
                            database.shop.PrintWeapons(); Console.Write("\t\tChoose[go back - 0] - "); int index = int.Parse(Console.ReadLine());

                            if (index == 0) { IsGoBack = false; }
                            else if (index >= 1 && index <= database.shop.weaponList.Count && player.Lvl >= database.shop.weaponList[index - 1].Level)
                            {
                                if (player.Coins >= database.shop.weaponList[index - 1].Price)
                                {
                                    player.decrease_coins(database.shop.weaponList[index - 1].Price);
                                    player.AddWeapon(database.shop.weaponList[index - 1]);
                                    database.shop.weaponList.Remove(database.shop.weaponList[index - 1]);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\n\t\t\t!!! Not enough coins !!!");
                                    Thread.Sleep(2000);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\n\n\t\t\t!!! Index out of list range Weapons or your level does not match !!!");
                                Thread.Sleep(2000);
                            }
                            SaveSerialize("DB.dat", database);

                            break;

                        }
                    case 2:
                        {
                            Console.Clear();

                            database.shop.PrintArmors();
                            Console.Write("\t\tChoose[go back - 0] - "); int i = int.Parse(Console.ReadLine());

                            if (i == 0) { IsGoBack = false; }
                            else if (i >= 1 && i <= database.shop.armorList.Count && player.Lvl >= database.shop.armorList[i - 1].Lvl)
                            {
                                if (player.Coins >= database.shop.armorList[i - 1].Price)
                                {
                                    player.decrease_coins(database.shop.armorList[i - 1].Price);
                                    player.AddArmor(database.shop.armorList[i - 1]);
                                    database.shop.armorList.Remove(database.shop.armorList[i - 1]);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\n\t\t\t!!! Not enough coins !!!");
                                    Thread.Sleep(2000);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\n\n\t\t\t!!! Index out of list range Armors or your level does not match !!!");
                                Thread.Sleep(2000);
                            }
                            SaveSerialize("DB.dat", database);
                            break;
                        }
                    default:
                        Console.WriteLine("\n\n\t\t\t\t\t\tWrong input!!!\n\n");
                        Thread.Sleep(3000);
                        break;
                }
            }
        }

        public static void PlayerVsPlayer(Player PlayerOne, DB database)
        {
            Console.Clear();

            if (database.players.Count >= 2 && PlayerOne.weaponsPlayer.Count >= 1 && PlayerOne.armorsPlayer.Count >= 1)
            {
                SoundPlayer sound2 = new SoundPlayer("fight.wav");
                sound2.Play();

                bool f = true;
                Player PlayerTwo;

                int PlayerOneHP = PlayerOne.HP;
                int PlayerTwoHP;

                Weapon PlayerOneWeapon = new Weapon();
                Weapon PlayerTwoWeapon = new Weapon();

                Armor PlayerOneArmor = new Armor();
                Armor PlayerTwoArmor = new Armor();

                while (true)
                {
                    Console.Clear();
                    PlayerOne.PrintWeapons(); Console.Write("\t\t\tChoose a weapon for combat - "); int index = int.Parse(Console.ReadLine());
                    if (index >= 1 && index <= PlayerOne.weaponsPlayer.Count)
                    {
                        if (PlayerOne.Character == "Orc") { PlayerOneWeapon = PlayerOne.weaponsPlayer[index - 1]; PlayerOneWeapon.Damage += 10; }
                        else if (PlayerOne.Character == "Dark Elf") { PlayerOneWeapon = PlayerOne.weaponsPlayer[index - 1]; PlayerOneWeapon.Damage += 25; }
                        else if (PlayerOne.Character == "High Elf") { PlayerOneWeapon = PlayerOne.weaponsPlayer[index - 1]; PlayerOneWeapon.Damage += 15; }
                        else if (PlayerOne.Character == "Imperial") { PlayerOneWeapon = PlayerOne.weaponsPlayer[index - 1]; PlayerOneWeapon.Damage += 10; }
                        else if (PlayerOne.Character == "Khajiit") { PlayerOneWeapon = PlayerOne.weaponsPlayer[index - 1]; PlayerOneWeapon.Damage += 20; }
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\t\t\t!!! Index out of list range Weapons  !!!");
                        Thread.Sleep(2000);
                    }
                }
                while (true)
                {
                    Console.Clear();
                    PlayerOne.PrintArmors(); Console.Write("\t\t\tChoose a armor for combat - "); int index = int.Parse(Console.ReadLine());
                    if (index >= 1 && index <= PlayerOne.armorsPlayer.Count)
                    {
                        if (PlayerOne.Character == "Orc") { PlayerOneArmor = PlayerOne.armorsPlayer[index - 1]; PlayerOneArmor.HP += 80; }
                        else if (PlayerOne.Character == "Dark Elf") { PlayerOneArmor = PlayerOne.armorsPlayer[index - 1]; PlayerOneArmor.HP += 50; }
                        else if (PlayerOne.Character == "High Elf") { PlayerOneArmor = PlayerOne.armorsPlayer[index - 1]; PlayerOneArmor.HP += 60; }
                        else if (PlayerOne.Character == "Imperial") { PlayerOneArmor = PlayerOne.armorsPlayer[index - 1]; PlayerOneArmor.HP += 80; }
                        else if (PlayerOne.Character == "Khajiit") { PlayerOneArmor = PlayerOne.armorsPlayer[index - 1]; PlayerOneArmor.HP += 70; }
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\t\t\t!!! Index out of list range Armors  !!!");
                        Thread.Sleep(2000);
                    }
                }

                while (f)
                {
                    Console.Clear();

                    Console.WriteLine("\t\t\t\t\t\t PLAYER 2");
                    Console.Write("\n\n\n\t\t\t\t\t\t||Enter your username - ");
                    string username = Console.ReadLine();

                    Console.Write("\n\t\t\t\t\t\t||Enter your password - ");
                    string password = Console.ReadLine();

                    if (database.SearchPlayer(username, password))
                    {
                        PlayerTwo = database.GetPlayerByName(username);
                        PlayerTwoHP = PlayerTwo.HP;

                        if (PlayerTwo.weaponsPlayer.Count >= 1 && PlayerTwo.armorsPlayer.Count >= 1)
                        {
                            while (true)
                            {
                                Console.Clear();

                                PlayerTwo.PrintWeapons();
                                Console.Write("\t\t\tChoose a weapon for combat - ");
                                int index = int.Parse(Console.ReadLine());

                                if (index >= 1 && index <= PlayerTwo.weaponsPlayer.Count)
                                {
                                    if (PlayerTwo.Character == "Orc")
                                    {
                                        PlayerTwoWeapon = PlayerTwo.weaponsPlayer[index - 1];
                                        PlayerTwoWeapon.Damage += 10;
                                    }
                                    else if (PlayerTwo.Character == "Dark Elf")
                                    {
                                        PlayerTwoWeapon = PlayerTwo.weaponsPlayer[index - 1];
                                        PlayerTwoWeapon.Damage += 25;
                                    }
                                    else if (PlayerTwo.Character == "High Elf")
                                    {
                                        PlayerTwoWeapon = PlayerTwo.weaponsPlayer[index - 1];
                                        PlayerTwoWeapon.Damage += 15;
                                    }
                                    else if (PlayerTwo.Character == "Imperial")
                                    {
                                        PlayerTwoWeapon = PlayerTwo.weaponsPlayer[index - 1];
                                        PlayerTwoWeapon.Damage += 10;
                                    }
                                    else if (PlayerTwo.Character == "Khajiit")
                                    {
                                        PlayerTwoWeapon = PlayerTwo.weaponsPlayer[index - 1];
                                        PlayerTwoWeapon.Damage += 20;
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\n\t\t\t!!! Index out of list range Weapons  !!!");
                                    Thread.Sleep(2000);
                                }
                            }
                            while (true)
                            {
                                Console.Clear();
                                PlayerTwo.PrintArmors(); Console.Write("\t\t\tChoose a armor for combat - "); int index = int.Parse(Console.ReadLine());
                                if (index >= 1 && index <= PlayerTwo.armorsPlayer.Count)
                                {
                                    if (PlayerTwo.Character == "Orc") { PlayerTwoArmor = PlayerTwo.armorsPlayer[index - 1]; PlayerTwoArmor.HP += 80; }
                                    else if (PlayerTwo.Character == "Dark Elf") { PlayerTwoArmor = PlayerTwo.armorsPlayer[index - 1]; PlayerTwoArmor.HP += 50; }
                                    else if (PlayerTwo.Character == "High Elf") { PlayerTwoArmor = PlayerTwo.armorsPlayer[index - 1]; PlayerTwoArmor.HP += 60; }
                                    else if (PlayerTwo.Character == "Imperial") { PlayerTwoArmor = PlayerTwo.armorsPlayer[index - 1]; PlayerTwoArmor.HP += 80; }
                                    else if (PlayerTwo.Character == "Khajiit") { PlayerTwoArmor = PlayerTwo.armorsPlayer[index - 1]; PlayerTwoArmor.HP += 70; }
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\n\t\t\t!!! Index out of list range Armors  !!!");
                                    Thread.Sleep(2000);
                                }
                            }

                            #region fight

                            bool head1 = false; 
                            bool chest1 = false;

                            bool head2 = false;
                            bool chest2 = false;

                            Random rnd = new Random(); int n = rnd.Next(1, 3);
                            bool bool1 = n == 1;
                            while (PlayerOneHP > 0 && PlayerTwoHP > 0)
                            {
                                PrintFight(PlayerOne.Name, username, PlayerOneHP, PlayerTwoHP, PlayerOne.Lvl, PlayerTwo.Lvl, PlayerOneArmor.HP, PlayerTwoArmor.HP);
                                Thread.Sleep(5000);

                                if (bool1)
                                {
                                    bool s1 = true; bool s2 = true;
                                    if (PlayerTwoArmor.HP > 0)
                                    {
                                        while (s1)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"\t\t\t\t\t\tPlayer {PlayerTwo.Name}");
                                            Console.WriteLine("\n\t\t\t\t\t1 - Head");
                                            Console.Write("\n\t\t\t\t\t2 - Chest\n\n\t\t\t\t\tChoose for defend - "); int ch = int.Parse(Console.ReadLine());
                                            switch (ch)
                                            {
                                                case 1:
                                                    chest2 = false;
                                                    head2 = true;
                                                    s1 = false;
                                                    break;
                                                case 2:
                                                    head2 = false;
                                                    chest2 = true;
                                                    s1 = false;
                                                    break;
                                                default:
                                                    Console.Clear();
                                                    Console.WriteLine("\n\n\n\n\t\t\tWrong Input !!!");
                                                    Thread.Sleep(3000); Console.Clear();
                                                    break;
                                            }
                                        }
                                        while (s2)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"\t\t\t\t\t\tPlayer {PlayerOne.Name}");
                                            Console.WriteLine("\n\t\t\t\t\t1 - Head");
                                            Console.Write("\n\t\t\t\t\t2 - Chest\n\n\t\t\t\t\tChoose for attack - "); int ch = int.Parse(Console.ReadLine());
                                            switch (ch)
                                            {
                                                case 1:
                                                    if (head2) 
                                                    { 
                                                        PlayerTwoArmor.HP -= PlayerOneWeapon.Damage; 
                                                        if (PlayerTwoArmor.HP <= 0) 
                                                        {
                                                            PlayerTwoArmor.HP = 0; 
                                                        } 
                                                    }
                                                    else 
                                                    {
                                                        PlayerTwoHP -= PlayerOneWeapon.Damage; 
                                                    }
                                                    s2 = false;
                                                    break;
                                                case 2:
                                                    if (chest2) { PlayerTwoArmor.HP -= PlayerOneWeapon.Damage - 10; if (PlayerTwoArmor.HP <= 0) { PlayerTwoArmor.HP = 0; } }
                                                    else { PlayerTwoHP -= PlayerOneWeapon.Damage - 10; }
                                                    s2 = false;
                                                    break;
                                                default:
                                                    Console.Clear();
                                                    Console.WriteLine("\n\n\n\n\t\t\tWrong Input!!!");
                                                    Thread.Sleep(3000); Console.Clear();
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        PlayerTwoArmor.HP = 0;

                                        while (s2)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"\t\t\t\t\t\tPlayer {PlayerOne.Name}");
                                            Console.WriteLine("\n\t\t\t\t\t1 - Head");
                                            Console.Write("\n\t\t\t\t\t2 - Chest\n\n\t\t\t\t\tChoose for attack - "); int ch = int.Parse(Console.ReadLine());
                                            switch (ch)
                                            {
                                                case 1:
                                                    PlayerTwoHP -= PlayerOneWeapon.Damage;
                                                    s2 = false;
                                                    break;
                                                case 2:
                                                    PlayerTwoHP -= PlayerOneWeapon.Damage - 10;
                                                    s2 = false;
                                                    break;
                                                default:
                                                    Console.Clear();
                                                    Console.WriteLine("\n\n\n\n\t\t\tWrong Input!!!");
                                                    Thread.Sleep(3000); Console.Clear();
                                                    break;
                                            }
                                        }
                                    }
                                    
                                    bool1 = false;
                                }
                                else
                                {
                                    bool s1 = true; bool s2 = true;
                                    if (PlayerOneArmor.HP > 0)
                                    {
                                        while (s1)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"\t\t\t\t\t\tPlayer {PlayerOne.Name}");
                                            Console.WriteLine("\n\t\t\t\t\t1 - Head");
                                            Console.Write("\n\t\t\t\t\t2 - Chest\n\n\t\t\t\t\tChoose for defend - "); int ch = int.Parse(Console.ReadLine());
                                            switch (ch)
                                            {
                                                case 1:
                                                    chest1 = false;
                                                    head1 = true;
                                                    s1 = false;
                                                    break;
                                                case 2:
                                                    head1 = false;
                                                    chest1 = true;
                                                    s1 = false;
                                                    break;
                                                default:
                                                    Console.Clear();
                                                    Console.WriteLine("\n\n\n\n\t\t\tWrong Input !!!");
                                                    Thread.Sleep(3000); Console.Clear();
                                                    break;
                                            }
                                        }
                                        while (s2)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"\t\t\t\t\t\tPlayer {PlayerTwo.Name}");
                                            Console.WriteLine("\n\t\t\t\t\t1 - Head");
                                            Console.Write("\n\t\t\t\t\t2 - Chest\n\n\t\t\t\t\tChoose for attack - "); int ch = int.Parse(Console.ReadLine());
                                            switch (ch)
                                            {
                                                case 1:
                                                    if (head1) 
                                                    { 
                                                        PlayerOneArmor.HP -= PlayerTwoWeapon.Damage; 
                                                        if (PlayerOneArmor.HP <= 0) 
                                                        {
                                                            PlayerOneArmor.HP = 0;
                                                        }
                                                    }
                                                    else
                                                    { 
                                                        PlayerOneHP -= PlayerTwoWeapon.Damage;
                                                    }
                                                    s2 = false;
                                                    break;
                                                case 2:
                                                    if (chest1) { PlayerOneArmor.HP -= PlayerTwoWeapon.Damage - 10; if (PlayerOneArmor.HP <= 0) { PlayerOneArmor.HP = 0; } }
                                                    else { PlayerOneHP -= PlayerTwoWeapon.Damage - 10; }
                                                    s2 = false;
                                                    break;
                                                default:
                                                    Console.Clear();
                                                    Console.WriteLine("\n\n\n\n\t\t\tWrong Input!!!");
                                                    Thread.Sleep(3000); Console.Clear();
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        PlayerOneArmor.HP = 0;
                                        while (s2)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"\t\t\t\t\t\tPlayer {PlayerTwo.Name}");
                                            Console.WriteLine("\n\t\t\t\t\t1 - Head");
                                            Console.Write("\n\t\t\t\t\t2 - Chest\n\n\t\t\t\t\tChoose for attack - "); int ch = int.Parse(Console.ReadLine());
                                            switch (ch)
                                            {
                                                case 1:
                                                    PlayerOneHP -= PlayerTwoWeapon.Damage;
                                                    s2 = false;
                                                    break;
                                                case 2:
                                                    PlayerOneHP -= PlayerTwoWeapon.Damage - 10;
                                                    s2 = false;
                                                    break;
                                                default:
                                                    Console.Clear();
                                                    Console.WriteLine("\n\n\n\n\t\t\tWrong Input!!!");
                                                    Thread.Sleep(3000); Console.Clear();
                                                    break;
                                            }
                                        }
                                    }
                                    
                                    bool1 = true;
                                }
                            }
                            if (PlayerOneHP <= 0)
                            {
                                PlayerOneWeapon.DecreaseHP();
                                PlayerTwoWeapon.DecreaseHP();

                                if (PlayerOneArmor.HP <= 0) 
                                { 
                                    PlayerOne.RemoveArmor(PlayerOneArmor);
                                }
                                if (PlayerTwoArmor.HP <= 0)
                                {
                                    PlayerTwo.RemoveArmor(PlayerTwoArmor);
                                }

                                PlayerOne.add_lose(); 
                                PlayerTwo.add_win(); 
                                PlayerTwo.increase_coins(100);

                                FightDate fd1 = new FightDate()
                                {
                                    Date = DateTime.Now,
                                    NameEnemy = PlayerTwo.Name,
                                    WinOrLose = false
                                };
                                FightDate fd2 = new FightDate()
                                {
                                    Date = DateTime.Now,
                                    NameEnemy = PlayerOne.Name,
                                    WinOrLose = true
                                };
                                
                                PlayerOne.fightList.Add(fd1);
                                PlayerTwo.fightList.Add(fd2);

                                SaveSerialize("DB.dat", database);

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\n\n\n\n\t\t\t\t\t\tPLAYER {PlayerTwo.Name} WIN!!!"); 
                                Thread.Sleep(5000);
 
                                f = false;
                            }
                            else if (PlayerTwoHP <= 0)
                            {
                                PlayerOneWeapon.DecreaseHP(); 
                                PlayerTwoWeapon.DecreaseHP();

                                if (PlayerOneArmor.HP <= 0) 
                                { 
                                    PlayerOne.RemoveArmor(PlayerOneArmor);
                                }
                                if (PlayerTwoArmor.HP <= 0) 
                                { 
                                    PlayerTwo.RemoveArmor(PlayerTwoArmor); 
                                }

                                PlayerTwo.add_lose();
                                PlayerOne.add_win();
                                PlayerOne.increase_coins(100);

                                FightDate fd1 = new FightDate()
                                {
                                    Date = DateTime.Now,
                                    NameEnemy = PlayerTwo.Name,
                                    WinOrLose = true
                                };
                                FightDate fd2 = new FightDate()
                                {
                                    Date = DateTime.Now,
                                    NameEnemy = PlayerOne.Name,
                                    WinOrLose = false
                                };
                                
                                PlayerOne.fightList.Add(fd1);
                                PlayerTwo.fightList.Add(fd2);
                                SaveSerialize("DB.dat", database);

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\tPLAYER {PlayerOne.Name} WIN!!!");
                                Thread.Sleep(5000);

                                f = false;
                            }

                            #endregion
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine($"\n\n\n\n\t\t!!! Player 2 doesn't have weapon or armor in inventory !!!");
                            Thread.Sleep(3000);
                            
                            Console.Clear();
                            f = false;
                        }
                    }
                    else 
                    { 
                        Console.WriteLine("\n\n\t\t\t\t\tTry again");
                        Thread.Sleep(3000); 
                    }
                }
            }
            else
            {
                Console.Clear();

                Console.WriteLine($"\n\n\n\t\t\t!!! There is no second player in the system/Player 1 doesn't have weapon or armor in inventory !!!");
                Thread.Sleep(3000);
                
                Console.Clear();
            }
        }

        public static void PlayerVsBot(Player playerOne, DB database, Bot bot)
        {
            Console.Clear();

            if (playerOne.weaponsPlayer.Count >= 1 && playerOne.armorsPlayer.Count >= 1)
            {
                SoundPlayer sound2 = new SoundPlayer("fight.wav");
                sound2.Play();

                bot.SetBot();
                Weapon weaponBot = bot.weapon;
                Armor armorBot = bot.armor;
                int botHP = bot.Health;

                Weapon weaponPlayer = new Weapon();
                Armor armorPlayer = new Armor();
                int playerHP = playerOne.HP;

                while (true)
                {
                    Console.Clear();
                    playerOne.PrintWeapons(); Console.Write("\t\t\tChoose a weapon for combat - "); int index = int.Parse(Console.ReadLine());
                    if (index >= 1 && index <= playerOne.weaponsPlayer.Count)
                    {
                        if (playerOne.Character == "Orc") { weaponPlayer = playerOne.weaponsPlayer[index - 1]; weaponPlayer.Damage += 10; }
                        else if (playerOne.Character == "Dark Elf") { weaponPlayer = playerOne.weaponsPlayer[index - 1]; weaponPlayer.Damage += 25; }
                        else if (playerOne.Character == "High Elf") { weaponPlayer = playerOne.weaponsPlayer[index - 1]; weaponPlayer.Damage += 15; }
                        else if (playerOne.Character == "Imperial") { weaponPlayer = playerOne.weaponsPlayer[index - 1]; weaponPlayer.Damage += 10; }
                        else if (playerOne.Character == "Khajiit") { weaponPlayer = playerOne.weaponsPlayer[index - 1]; weaponPlayer.Damage += 20; }
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\t\t\t!!! Index out of list range Weapons  !!!");
                        Thread.Sleep(2000);
                    }
                }
                while (true)
                {
                    Console.Clear();
                    playerOne.PrintArmors(); Console.Write("\t\t\tChoose a armor for combat - "); int index = int.Parse(Console.ReadLine());
                    if (index >= 1 && index <= playerOne.armorsPlayer.Count)
                    {
                        if (playerOne.Character == "Orc") { armorPlayer = playerOne.armorsPlayer[index - 1]; armorPlayer.HP += 80; }
                        else if (playerOne.Character == "Dark Elf") { armorPlayer = playerOne.armorsPlayer[index - 1]; armorPlayer.HP += 50; }
                        else if (playerOne.Character == "High Elf") { armorPlayer = playerOne.armorsPlayer[index - 1]; armorPlayer.HP += 60; }
                        else if (playerOne.Character == "Imperial") { armorPlayer = playerOne.armorsPlayer[index - 1]; armorPlayer.HP += 80; }
                        else if (playerOne.Character == "Khajiit") { armorPlayer = playerOne.armorsPlayer[index - 1]; armorPlayer.HP += 70; }
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\t\t\t!!! Index out of list range Armors  !!!");
                        Thread.Sleep(2000);
                    }
                }

                #region fight

                bool headPlayer = false;
                bool chestPlayer = false;
                bool headBot = false;
                bool chestBot = false;

                Random rnd = new Random();

                int n = rnd.Next(1, 3);
                bool bool1 = n == 1;

                while (botHP > 0 && playerHP > 0)
                {
                    PrintFight(playerOne.Name, "Bot", playerHP, botHP, playerOne.Lvl, bot.Level, armorPlayer.HP, armorBot.HP);
                    Thread.Sleep(7000);

                    Random random = new Random();

                    if (bool1)
                    {
                        bool s1 = true;
                        bool s2 = true;

                        if (armorBot.HP > 0)
                        {
                            while (s1)
                            {
                                int choiceBot = random.Next(1, 3);
                                switch (choiceBot)
                                {
                                    case 1:
                                        chestBot = false;
                                        headBot = true;
                                        s1 = false;

                                        break;

                                    case 2:
                                        headBot = false;
                                        chestBot = true;
                                        s1 = false;

                                        break;

                                }
                                Console.Clear();

                                Console.WriteLine("\n\n\n\n\n\t\t\t\t\tThe bot chooses what to defend...");
                                Thread.Sleep(4000);
                            }
                            while (s2)
                            {
                                Console.Clear();

                                Console.WriteLine($"\t\t\t\t\t\tPlayer {playerOne.Name}");
                                Console.WriteLine("\n\t\t\t\t\t1 - Head");
                                Console.Write("\n\t\t\t\t\t2 - Chest\n\n\t\t\t\t\tChoose for attack - ");
                                int choice = int.Parse(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        if (headBot)
                                        {
                                            armorBot.HP -= weaponPlayer.Damage;
                                            if (armorBot.HP <= 0)
                                            {
                                                armorBot.HP = 0;
                                            }
                                        }
                                        else
                                        {
                                            botHP -= weaponPlayer.Damage;
                                        }
                                        s2 = false;

                                        break;

                                    case 2:
                                        if (chestBot)
                                        {
                                            armorBot.HP -= weaponPlayer.Damage - 10;
                                            if (armorBot.HP <= 0)
                                            {
                                                armorBot.HP = 0;
                                            }
                                        }
                                        else
                                        {
                                            botHP -= weaponPlayer.Damage - 10;
                                        }
                                        s2 = false;

                                        break;

                                    default:
                                        Console.Clear();

                                        Console.WriteLine("\n\n\n\n\t\t\tWrong Input!!!");
                                        Thread.Sleep(3000);

                                        Console.Clear();

                                        break;

                                }
                            }
                        }
                        else
                        {
                            armorBot.HP = 0;
                            while (s2)
                            {
                                Console.Clear();

                                Console.WriteLine($"\t\t\t\t\t\tPlayer {playerOne.Name}");
                                Console.WriteLine("\n\t\t\t\t\t1 - Head");
                                Console.Write("\n\t\t\t\t\t2 - Chest\n\n\t\t\t\t\tChoose for attack - ");
                                int choice = int.Parse(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        botHP -= weaponPlayer.Damage;
                                        s2 = false;

                                        break;

                                    case 2:
                                        botHP -= weaponPlayer.Damage - 10;
                                        s2 = false;

                                        break;

                                    default:
                                        Console.Clear();
                                        Console.WriteLine("\n\n\n\n\t\t\tWrong Input!!!");
                                        Thread.Sleep(3000);
                                        Console.Clear();

                                        break;

                                }
                            }
                        }

                        bool1 = false;

                    }
                    else
                    {
                        bool s1 = true;
                        bool s2 = true;

                        if (armorPlayer.HP > 0)
                        {
                            while (s1)
                            {
                                Console.Clear();

                                Console.WriteLine($"\t\t\t\t\t\tPlayer {playerOne.Name}");
                                Console.WriteLine("\n\t\t\t\t\t1 - Head");
                                Console.Write("\n\t\t\t\t\t2 - Chest\n\n\t\t\t\t\tChoose for defend - ");
                                int choice = int.Parse(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        chestPlayer = false;
                                        headPlayer = true;
                                        s1 = false;

                                        break;

                                    case 2:
                                        headPlayer = false;
                                        chestPlayer = true;
                                        s1 = false;

                                        break;

                                    default:
                                        Console.Clear();

                                        Console.WriteLine("\n\n\n\n\t\t\tWrong Input !!!");
                                        Thread.Sleep(3000); Console.Clear();

                                        break;

                                }
                            }
                            while (s2)
                            {
                                int choiceBot = random.Next(1, 3);
                                switch (choiceBot)
                                {
                                    case 1:
                                        if (headPlayer)
                                        {
                                            armorPlayer.HP -= weaponBot.Damage;
                                            if (armorPlayer.HP <= 0)
                                            {
                                                armorPlayer.HP = 0;
                                            }
                                        }
                                        else
                                        {
                                            playerHP -= weaponBot.Damage;
                                        }
                                        s2 = false;

                                        break;

                                    case 2:
                                        if (chestPlayer)
                                        {
                                            armorPlayer.HP -= weaponBot.Damage - 10;
                                            if (armorPlayer.HP <= 0)
                                            {
                                                armorPlayer.HP = 0;
                                            }
                                        }
                                        else
                                        {
                                            playerHP -= weaponBot.Damage - 10;
                                        }
                                        s2 = false;

                                        break;
                                }
                                Console.Clear();

                                Console.WriteLine("\n\n\n\n\n\t\t\t\t\tThe bot chooses what to attack...");
                                Thread.Sleep(4000);
                            }
                        }
                        else
                        {
                            armorPlayer.HP = 0;
                            while (s2)
                            {
                                int choiceBot = random.Next(1, 3);
                                switch (choiceBot)
                                {
                                    case 1:
                                        playerHP -= weaponBot.Damage;
                                        s2 = false;
                                        break;


                                    case 2:
                                        playerHP -= weaponBot.Damage - 10;
                                        s2 = false;

                                        break;

                                }
                            }
                            Console.Clear();

                            Console.WriteLine("\n\n\n\n\n\t\t\t\t\tThe bot chooses what to attack...");
                            Thread.Sleep(4000);
                        }

                        bool1 = true;
                    }

                }

                if (playerHP <= 0)
                {
                    weaponPlayer.DecreaseHP();
                    if (armorPlayer.HP <= 0)
                    {
                        playerOne.RemoveArmor(armorPlayer);
                    }
                    playerOne.add_lose();

                    FightDate fd1 = new FightDate()
                    {
                        Date = DateTime.Now,
                        NameEnemy = "Bot",
                        WinOrLose = false
                    };
                    playerOne.fightList.Add(fd1);

                    SaveSerialize("DB.dat", database);

                    Console.Clear();

                    Console.WriteLine($"\n\n\n\n\n\n\n\n\t\t\t\t\t\tBOT WIN!!!"); 
                    Thread.Sleep(5000);
                }
                else if (botHP <= 0)
                {
                    weaponPlayer.DecreaseHP();
                    if (armorPlayer.HP <= 0)
                    {
                        playerOne.RemoveArmor(armorPlayer);
                    }

                    playerOne.add_win();
                    playerOne.increase_coins(100);
                    FightDate fd1 = new FightDate()
                    {
                        Date = DateTime.Now,
                        NameEnemy = "Bot",
                        WinOrLose = true
                    };
                    playerOne.fightList.Add(fd1);

                    SaveSerialize("DB.dat", database);

                    Console.Clear();

                    Console.WriteLine($"\n\n\n\n\t\t\t\t\t\tPLAYER {playerOne.Name} WIN!!!");
                    Thread.Sleep(5000);
                }

                #endregion
            }
            else
            {
                Console.Clear();

                Console.WriteLine("\n\n\n\n\t\t\t\t\t\tYou must have at least 1 weapon and 1 armor in your inventory.");
                Thread.Sleep(4000);

                Console.Clear();
            }
        }

        #endregion

        #region reglog

        public static void reglog(string path, DB db, int choice, ref bool flag)
        {
            switch (choice)
            {
                case 0:
                    Console.WriteLine("\n\n\t\t\t\t\t\tGOOD LUCK:)\n\n");
                    flag = false;

                    break;

                case 1:
                    Registration(path, db);

                    break;

                case 2:
                    Login(path, db);

                    break;

                default:
                    Console.WriteLine("\n\n\t\t\t\t\t\tWrong input!!!\n\n");
                    Thread.Sleep(3000);

                    break;

            }
        }
        public static void Login(string path, DB db)
        {
            Console.Clear();

            Console.WriteLine("====================================================== |LOGIN MENU| ==================================================== ");

            Console.Write("\n\t\t\t\t\t\t||Enter your username - ");
            string username = Console.ReadLine();

            Console.Write("\n\t\t\t\t\t\t||Enter your password - ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "admin123")
            {
                AdminLoad(db);
            }
            else if (db.SearchPlayer(username, password))
            {
                Player player = db.GetPlayerByName(username);

                if (player.Active)
                {
                    if (player.Character == "None")
                    {
                        PrintCharacters();
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 0:

                                break;

                            case 1:
                                player.Character = "Orc";
                                player.HP = 180;
                                db.SetHP(player);
                                db.SetCharacter(player);
                                SaveSerialize("DB.dat", db);
                                LoadPlayer(db, player);

                                break;

                            case 2:
                                player.Character = "Dark Elf";
                                player.HP = 130;

                                db.SetHP(player);
                                db.SetCharacter(player);

                                SaveSerialize("DB.dat", db);
                                LoadPlayer(db, player);

                                break;

                            case 3:
                                player.Character = "High Elf";
                                player.HP = 140;

                                db.SetHP(player);
                                db.SetCharacter(player);

                                SaveSerialize("DB.dat", db);
                                LoadPlayer(db, player);

                                break;

                            case 4:
                                player.Character = "Imperial";
                                player.HP = 150;

                                db.SetHP(player);
                                db.SetCharacter(player);

                                SaveSerialize("DB.dat", db);
                                LoadPlayer(db, player);

                                break;

                            case 5:
                                player.Character = "Khajiit";
                                player.HP = 120;

                                db.SetHP(player);
                                db.SetCharacter(player);

                                SaveSerialize("DB.dat", db);
                                LoadPlayer(db, player);

                                break;

                            default:
                                Console.WriteLine("\n\n\t\t\t\t!!! Wrong input !!!\n");
                                Thread.Sleep(3000);

                                break;

                        }
                    }
                    else
                    {
                        LoadPlayer(db, player);
                    }
                }
                else
                {
                    Console.WriteLine("\n\n\n\n\nYou banned by Adminstration\t\t\t");
                    Thread.Sleep(5000);
                }
            }
            else
            {
                Console.WriteLine("\n\n\t\t\t\t\t\t!!! Wrong username or password !!!\n\n");
                Thread.Sleep(3000);
            }
        }
        public static void Registration(string path, DB db)
        {
            Console.Clear();

            Console.WriteLine("====================================================== |MAIN MENU| ===================================================== ");
            Console.Write("\n\t\t\t\t\t\t||Enter new username - ");
            string username = Console.ReadLine();

            Console.Write("\n\t\t\t\t\t\t||Enter new password(length > 5) - ");
            string password = Console.ReadLine();

            if (password.Length >= 5 && !db.SearchPlayer(username, password))
            {
                Player player = new Player()
                {
                    Name = username,
                    Password = password
                };

                db.players.Add(player);
                SaveSerialize(path, db);

                Console.WriteLine("\n\n\t\t\t\t\t\t!!! SUCCESFUL !!!\n\n");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("\n\n\t\t\t\t\t\tLength of password > 5 or such username/password has already!!!\n\n");
                Thread.Sleep(3000);
            }
        }

        #endregion

        #region Loaders

        public static void MainLoad()
        {
            SoundPlayer sound = new SoundPlayer("player.wav");
            sound.Play();

            DB db = new DB();
            string path = "DB.dat";

            //db.shop.weaponList.Clear();
            //db.shop.armorList.Clear();
            //db.players.Clear();
            //db.bot.SetBotDefault();
            //db.shop.SetShopToDefault();
            //SaveSerialize(path, db);

            db = LoadDeserialize(path);

            bool flag = true;
            while (flag)
            {
                PrintMenu();
                int ch = int.Parse(Console.ReadLine());

                reglog(path, db, ch, ref flag);
            }
        }

        public static void AdminLoad(DB db)
        {
            bool flag = true;

            while (flag)
            {
                PrintAdminMenu();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        SaveSerialize("DB.dat", db);
                        flag = false;

                        break;

                    case 1:
                        {
                            Console.Write("\n\n\n\n\n\t\t\t\t\tAx - 1, Sword - 2, Mace - 3, Staff - 4, Bow - 5: ");
                            int choose = int.Parse(Console.ReadLine());
                            switch (choose)
                            {
                                case 1:
                                    {
                                        Console.Write("\n\t\t\t\tDamage: ");
                                        int damage = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tPrice: ");
                                        int price = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tHeatlh: ");
                                        int health = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tLevel: ");
                                        int lvl = int.Parse(Console.ReadLine());

                                        Ax ax = new Ax() { Damage = damage, Price = price, HP = health, Level = lvl };
                                        db.shop.weaponList.Add(ax);
                                    }

                                    break;

                                case 2:
                                    {
                                        Console.Write("\n\t\t\t\tDamage: ");
                                        int damage = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tPrice: ");
                                        int price = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tHeatlh: ");
                                        int health = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tLevel: ");
                                        int lvl = int.Parse(Console.ReadLine());

                                        Sword sword = new Sword() { Damage = damage, Price = price, HP = health, Level = lvl };
                                        db.shop.weaponList.Add(sword);
                                    }

                                    break;

                                case 3:
                                    {
                                        Console.Write("\n\t\t\t\tDamage: ");
                                        int damage = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tPrice: ");
                                        int price = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tHeatlh: ");
                                        int health = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tLevel: ");
                                        int lvl = int.Parse(Console.ReadLine());

                                        Mace mace = new Mace() { Damage = damage, Price = price, HP = health, Level = lvl };
                                        db.shop.weaponList.Add(mace);
                                    }

                                    break;

                                case 4:
                                    {
                                        Console.Write("\n\t\t\t\tDamage: ");
                                        int damage = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tPrice: ");
                                        int price = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tHeatlh: ");
                                        int health = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tLevel: ");
                                        int lvl = int.Parse(Console.ReadLine());

                                        Staff s = new Staff() { Damage = damage, Price = price, HP = health, Level = lvl };
                                        db.shop.weaponList.Add(s);
                                    }

                                    break;

                                case 5:
                                    {
                                        Console.Write("\n\t\t\t\tDamage: ");
                                        int damage = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tPrice: ");
                                        int price = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tHeatlh: ");
                                        int health = int.Parse(Console.ReadLine());

                                        Console.Write("\n\t\t\t\tLevel: ");
                                        int lvl = int.Parse(Console.ReadLine());

                                        Bow bow = new Bow() { Damage = damage, Price = price, HP = health, Level = lvl };
                                        db.shop.weaponList.Add(bow);
                                    }

                                    break;

                                default:
                                    Console.WriteLine("Wrong input");

                                    break;

                            }
                        }

                        break;

                    case 2:
                        {
                            Console.Write("\n\t\t\t\tPrice: ");
                            int price = int.Parse(Console.ReadLine());

                            Console.Write("\n\t\t\t\tHeatlh: ");
                            int hp = int.Parse(Console.ReadLine());

                            Console.Write("\n\t\t\t\tLevel: ");
                            int lvl = int.Parse(Console.ReadLine());

                            Armor a = new Armor() { Price = price, HP = hp, Lvl = lvl };
                            db.shop.armorList.Add(a);
                        }

                        break;

                    case 3:
                        {
                            Console.Write("\n\t\t\t\tEnter name of player: ");
                            string name = Console.ReadLine();
                            if (db.SearchPlayerByName(name))
                            {
                                Player p = db.GetPlayerByName(name);
                                p.Active = false;
                            }
                            else
                            {
                                Console.WriteLine("Such player does not exist");
                                Thread.Sleep(2000);
                            }
                        }

                        break;

                    case 4:
                        {
                            Console.Write("Enter name of player: ");
                            string name = Console.ReadLine();
                            if (db.SearchPlayerByName(name))
                            {
                                Player p = db.GetPlayerByName(name);
                                p.Active = true;
                            }
                            else
                            {
                                Console.WriteLine("Such player does not exist");
                                Thread.Sleep(2000);
                            }
                        }

                        break;

                    default:
                        Console.WriteLine("\n\n\t\t\t\t\t\tWrong input!!!\n\n");
                        Thread.Sleep(3000);

                        break;
                }
                SaveSerialize("DB.dat", db);
            }
        }

        public static void LoadPlayer(DB db, Player player)
        {
            bool flag = true;

            while (flag)
            {
                PrintPlayerMenu(player);
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        SaveSerialize("DB.dat", db);
                        flag = false;

                        break;

                    case 1:
                        InventoryFunc(player, db);
                        SaveSerialize("DB.dat", db);

                        break;

                    case 2:
                        ShopFunc(player, db);
                        SaveSerialize("DB.dat", db);

                        break;

                    case 3:
                        PlayerVsPlayer(player, db);
                        SaveSerialize("DB.dat", db);

                        break;

                    case 4:
                        PlayerVsBot(player, db, db.bot);
                        SaveSerialize("DB.dat", db);

                        break;

                    case 5:
                        if (player.fightList == null)
                        {
                            Console.Clear();

                            Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\tYou didn't fight previously");
                            Thread.Sleep(4000);
                        }
                        else
                        {
                            bool end = true;

                            while (end)
                            {
                                Console.Clear();


                                player.PrintFightDates();
                                Console.WriteLine("\n\n\t\t\t\t\t\tGo back - 0");
                                int choose = int.Parse(Console.ReadLine());
                                if (choose == 0)
                                {
                                    end = false;
                                }
                                else
                                {
                                    Console.Clear();

                                    Console.WriteLine("\n\n\t\t\t\tWrong input !!!");
                                    Thread.Sleep(5000);
                                }
                            }
                        }

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\t\t!!! Wrong input !!!");
                        Thread.Sleep(2000);
                        Console.Clear();

                        break;

                }
            }
        }

        #endregion
    }
}