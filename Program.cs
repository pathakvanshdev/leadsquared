using System;

namespace leadsquared
{
    class BattleGround
    {
        static private BattleField _battleField = new BattleField();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ULTIMATE BATTLE!");
            try
            {
                _battleField.startBattle();
            }
            catch (System.Exception exception)
            {
                Console.WriteLine("Could not start the game",exception);
            }
        }

    }
}
