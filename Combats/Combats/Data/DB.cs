using System.Collections.Generic;
using System;

namespace MyGame
{
    [Serializable]
    internal class DB : IPlayerRepository
    {
        public List<Player> players = new List<Player>();
        public Shop shop = new Shop();
        public Bot bot = new Bot();
        
        public Player GetPlayerByName(string name)
        {
            foreach (var item in players)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
        public void SetCharacter(Player player)
        {
            foreach (var item in players)
            {
                if (item.Name == player.Name && item.Password == player.Password)
                {
                    item.Character = player.Character;
                    break;
                }
            }
        }
        public void SetHP(Player player)
        {
            foreach (var item in players)
            {
                if (item.Name == player.Name && item.Password == player.Password)
                {
                    item.HP = player.HP;
                    break;
                }
            }
        }
        public bool SearchPlayer(string name, string password)
        {
            foreach (var item in players)
            {
                if (item.Name == name && item.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool SearchPlayerByName(string name)
        {
            foreach (var item in players)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IfSomeInPlayer()
        {
            return players.Count == 0;
        }
    }
}