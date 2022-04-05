using WarriorWars.Enum;
using WarriorWars.Equipment;

namespace WarriorWars
{
    class War
    {
        static Random rng = new Random();
        static void Main()
        {
            Warrior goodGuy = new Warrior("Pero", Faction.GoodGuy);

            Warrior badGuy = new Warrior("Riste", Faction.BadGuy);

            while (goodGuy.IsAlive && badGuy.IsAlive)         //for how long to attack each other bcz we have no access to the health parameter
            {
                if (rng.Next(0, 10) < 5)
                {
                    goodGuy.Attack(badGuy);
                }
                else
                {
                    badGuy.Attack(goodGuy);
                }

                Thread.Sleep(250);              //delay od 500ms 
            }

        }
    }
}