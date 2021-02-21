using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeon of Secrets";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("][ ][ DUNGEON OF SECRETS ][ ][\n");
            Console.ResetColor();
            Console.WriteLine("Your journey begins...\n");
            int score = 0;


            //Weapons
            Weapon sword = new  Weapon(2, 8, "Sword", 8, true);
            Weapon axe = new Weapon(3, 6, "Battle Axe", 10, true);
            Weapon mace = new Weapon(1, 10, "Mace", 15, false);

            //Choose Weapon
            Console.WriteLine("\nAs you make your way into the dark dungeon ahead, a glistening catches your eye...\n");
            System.Threading.Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("===== Choose Your Weapon =====\n");
            Console.ResetColor();

            bool chosen = false;
            Weapon userWeapon = new Weapon();

            do
            {
                Console.WriteLine("[S] Sword - It still looks sharp, but might require both hands to wield.\n" +
                    "[A] Axe - This might do some damage, it will definitely require both hands to swing.\n" +
                    "[M] Mace - A bit lighter this could be used with one hand, something just feels right about it.\n");

                ConsoleKey weaponChoice = Console.ReadKey(true).Key;

                Console.Clear();

                switch (weaponChoice)
                {
                    case ConsoleKey.S:
                        Console.WriteLine("It sure is heavy, but you're confident in your ability as you head further into the dungeon with your Broad Sword.");
                        userWeapon = sword;
                        chosen = true;
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine("After lifting the Battle Axe for the first time, a surge of courage flows through you as you turn towards the darkness.");
                        userWeapon = axe;
                        chosen = true;
                        break;
                    case ConsoleKey.M:
                        Console.WriteLine("Snatching up the Bludgeoning Mace, you make your way deeper into the looming pit.");
                        userWeapon = mace;
                        chosen = true;
                        break;
                    default:
                        Console.WriteLine("Invalid weapon choice.  Please choose again.");
                        break;
                }
            } while (!chosen);

            //Player
            Player player = new Player("Hero", 70, 2, 50, 50, Race.Human, userWeapon);

            bool exit = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(GetRoom());
                Console.ResetColor();

                //TODO 4. Create a monster for the room - learn about creating objects and then randomly selecting one
                //Monsters
                Skeleton skeleton = new Skeleton();


                bool reload = false;
                do
                {
                    #region User Menu
                    Console.Write("\n\n# Please Choose an Action #\n" +
                        "[A] Atack\n" +
                        "[R] Run Away\n" +
                        "[P] Player Info\n" +
                        "[M] Monster Info\n" +
                        "[X] Exit \n\n" +
                        "Monsters Defeated: {0}\n\n", score);
                    #endregion

                    #region User Choice
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    #endregion

                    Console.Clear();

                    #region Switch that runs functionality based on user choice
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("# Attack #\n");
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //Find health potion chance +10 life
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou defeated {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("# Run Away #\n");
                            Console.WriteLine($"{monster.Name} attacks you as you run away!\n");
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("# Player Information #\n");
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("# Monster Information #\n");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("Thanks for playing!\n");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Unrecognized selection.  Please try again.\n");
                            break;
                    }//end switch
                    #endregion

                    #region Player Life
                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("YOU HAVE DIED.\n");
                        Console.ResetColor();
                        //Console beep sad sound
                        exit = true;
                    }
                    #endregion

                } while (!reload && !exit);
            } while (!exit);
        }//end Main()

        //TODO 14. Create GetRoom() & plug it in to the todo above
        private static string GetRoom()
        {
            //create an array of room descriptions - string datatype
            string[] rooms =
            {
                "Rats inside the room shriek when they hear the door open, then they run in all directions from a putrid corpse lying in the center of the floor. As these creatures crowd around the edges of the room, seeking to crawl through a hole in one corner, they fight one another. The stinking corpse in the middle of the room looks human, but the damage both time and the rats have wrought are enough to make determining its race by appearance an extremely difficult task at best.",
                "When looking into this chamber, you're confronted by a thousand reflections of yourself looking back. Mirrored walls set at different angles fill the room. A path seems to wind through the mirrors, although you can't tell where it leads.",
                "You open the door and a gout of flame rushes at your face. A wave of heat strikes you at the same time and light fills the hall. The room beyond the door is ablaze! An inferno engulfs the place, clinging to bare rock and burning without fuel.",
                "Several exits lead from this room, but only one is within the mouth of a man. The door opposite you stands within an intricate stone carving of a man's wide-open mouth. The man's nose and eyes loom over the door while his sculpted hair splays out across the wall on either side.",
                "A huge stewpot hangs from a thick iron tripod over a crackling fire in the center of this chamber. A hole in the ceiling allows some of the smoke from the fire to escape, but much of it expands across the ceiling and rolls down to fill the room in a dark fog. Other details are difficult to make out, but some creature must be nearby, because it smells like a good soup is cooking.",
                "This tiny room holds a curious array of machinery. Winches and levers project from every wall, and chains with handles dangle from the ceiling. On a nearby wall, you note a pictogram of what looks like a scythe on a chain.",
                "Dozens of dead, winged beings lie scattered about the floor, each about the size of a cat. Their broken bodies are batlike and buglike at the same time. Each had two sets of bat wings, a long nose like a mosquito, and six legs, but many were split in half or had limbs or wings lopped off. Their forms are little more than dried husks now, and there's no sign of what killed them.",
                "A pungent, earthy odor greets you as you pull open the door and peer into this room. Mushrooms grow in clusters of hundreds all over the floor. Looking into the room is like looking down on a forest. Tall tangles of fungus resemble forested hills, the barren floor looks like a plain between the woods, and even a trickle of water and a puddle of water that pools in a low spot bears a resemblance to a river and lake, respectively."
            };
            //generate a Random object and get a random room description
            Random random = new Random();
            //since the maxValue in the Next() is exclusive, we can just use the Length property to include all indexes from our array.
            int indexNbr = random.Next(rooms.Length);
            string room = "***** YOU FIND A NEW ROOM *****\n" + rooms[indexNbr] + "\n";
            //return room
            return room;
        }//end Main()
    }//end class
}//end namespace
