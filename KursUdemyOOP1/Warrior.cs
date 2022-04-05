using WarriorWars.Enum;
using WarriorWars.Equipment;
using System;

namespace WarriorWars

{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 20;    //const so they start from the "same" value(specific value)
        private const int BAD_GUY_STARTING_HEALTH = 20;     //

        private readonly Faction FACTION;             //bcz we are defining it in the constructor (as a parameter)

        private int health;
        private string name;
        private bool isAlive;

        public bool IsAlive //IsAlive in PascalCase bcz is Property not a Field 
        {                   //We only have a get method bcz we should only get the status of the wariror if he is dead or alive, we should not be able to change it
            get
            {
                return isAlive;
            }
        }

        public Weapon weapon;
        public Armor armor;

        public Warrior(string name, Faction faction)    //constructor--> we give the user as little as possible parameters
        {
            this.name = name;
            FACTION = faction;
            isAlive = true;                             //the worrior is alive at the start


            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);   //the argument from the constructor(Ln29) goes to the constructor in this line...needed to do this since in the Weapon/Armor classes we gave this parameter to the constructor
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;

                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;
            }
        }

        public void Attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;
            enemy.health = enemy.health - damage;

            AttackResult(enemy, damage);
        }

        private void AttackResult(Warrior enemy, int damage)
        {
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Console.WriteLine($"{enemy.name} is dead!");
                Console.WriteLine($"The winner is { name } !");
            }
            else                        //if enemy is not dead
            {
                Console.WriteLine($"{name} attacked {enemy.name}. {damage} damage has been done and {enemy.name} has {enemy.health} health remaining");         //who attacked who
            }
        }
    }
}
