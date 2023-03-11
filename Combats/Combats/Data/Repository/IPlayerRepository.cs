namespace MyGame
{
    interface IPlayerRepository
    {
        Player GetPlayerByName(string name);

        bool SearchPlayer(string name, string password);
        bool SearchPlayerByName(string name);
        bool IfSomeInPlayer();
        void SetCharacter(Player player);
        void SetHP(Player player);
    }
}
