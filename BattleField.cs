using System;

namespace leadsquared
{
    public class BattleField
    {
        private BattleUnit battleUnitContender1;
        private BattleUnit battleUnitContender2;

        private static APIAdapter _apiService = new APIAdapter();

        private string getBattleResult(BattleUnit contenderA, BattleUnit contenderB)
        {
            string battleResult = "";

            try
            {
                double killTimeA = (double)contenderA.hitPoints / (double)contenderB.attack;
                double killTimeB = (double)contenderB.hitPoints / (double)contenderA.attack;

                if ((killTimeA == killTimeB) || (killTimeA < 0 && killTimeB < 0))
                    battleResult = contenderA.name + " and " + contenderB.name + " are equally worthy!! The battle ended in a draw.";
                else if (killTimeA > killTimeB)
                    battleResult = contenderA.name + " won the battle against " + contenderB.name;
                else if (killTimeA < killTimeB)
                    battleResult = contenderB.name + " won the battle against " + contenderA.name;
            }
            catch (System.Exception exception)
            {
                Console.WriteLine("The battle could not be held ", exception);
            }

            return battleResult;
        }

        private BattleUnit getContender()
        {
            Random r = new Random();
            int id = r.Next(1, 100);

            BattleUnit contender;
            do
            {
                contender = _apiService.getBattleUnit(id);
            } while (contender == null);

            return contender;

        }

        private void chooseContenders()
        {
            battleUnitContender1 = getContender();

            do
            {
                battleUnitContender2 = getContender();
            } while (battleUnitContender1.isSame(battleUnitContender2));

        }

        public void startBattle()
        {

            Console.WriteLine("Choosing units for the battle..........");

            try
            {

                chooseContenders();

                Console.WriteLine(battleUnitContender1.name + " v/s " + battleUnitContender2.name);
                Console.WriteLine("Let the battle begin......");

                string battleResult = getBattleResult(battleUnitContender1, battleUnitContender2);

                Console.WriteLine(battleResult);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}