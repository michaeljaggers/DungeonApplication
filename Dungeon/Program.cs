using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DungeonLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeon of Secrets";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("][ ][ DUNGEON OF SECRETS ][ ][\n\n");
            Console.ResetColor();
            Console.WriteLine("Your journey begins...\n\n");
            int score = 0;

            //Weapons
            Weapon sword = new  Weapon(2, 8, "Broad Sword", 8, true);
            Weapon axe = new Weapon(3, 6, "Battle Axe", 10, true);
            Weapon mace = new Weapon(1, 10, "Bludgeoning Mace", 15, false);

            //Choose Weapon
            Console.WriteLine("As you make your way into the dark dungeon ahead, a glistening catches your eye.\n\n");
            System.Threading.Thread.Sleep(4000);
            
            bool chosen = false;
            Weapon userWeapon = new Weapon();

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("### Choose Your Weapon ###\n");
                Console.ResetColor();
                Console.WriteLine(
                    "[S] Sword  - It still looks sharp, but might require both hands to wield.\n" +
                    "[A] Axe    - This might do some damage, it will definitely require both hands to swing.\n" +
                    "[M] Mace   - A bit lighter, this could be used with one hand. Something just feels right about it.\n");

                ConsoleKey weaponChoice = Console.ReadKey(true).Key;
                Console.Clear();

                switch (weaponChoice)
                {
                    case ConsoleKey.S:
                        Console.WriteLine("It is heavy, but you're confident as you head further into the dungeon with your Broadsword...\n\n");
                        userWeapon = sword;
                        chosen = true;
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine("After lifting the Battle Axe, a surge of courage flows through you as you turn towards the darkness...\n\n");
                        userWeapon = axe;
                        chosen = true;
                        break;
                    case ConsoleKey.M:
                        Console.WriteLine("Snatching up the bludgeoning Mace, you make your way deeper into the looming pit...\n\n");
                        userWeapon = mace;
                        chosen = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid weapon choice.\n");
                        Console.ResetColor();
                        break;
                }
            } while (!chosen);

            //Player
            Player player = new Player("Hero", 70, 2, 50, 50, Race.Human, userWeapon);

            System.Threading.Thread.Sleep(7000);
            Console.Clear();

            bool exit = false;
            do
            {
                //Room
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(GetRoom());
                Console.ResetColor();
                Console.WriteLine("Press any key to continue.\n");
                Console.ReadKey();
                Console.Clear();

                //Monsters
                Skeleton skeleton = new Skeleton();
                Vampire vampire = new Vampire("Vampire", 20, 20, 25, 10, 1, 10, "It's pale skin almost glows in the darkness.  It moves silently.");
                Monster orc = new Monster("Orc", 10, 10, 20, 20, 1, 7, "A pig-like disgusting creature that smells of rotting flesh.");
                Monster rat = new Monster("Rat", 8, 8, 15, 10, 1, 5, "More than your average rat.  It looks rabbid to say the least...");

                Monster[] monsters = { skeleton, vampire, orc, rat };

                Random random = new Random();
                int randomMonster = random.Next(monsters.Length);
                Monster monster = monsters[randomMonster];
                Console.WriteLine("A MONSTER APPEARS! : " + monster.Name + "\n");

                bool reload = false;
                do
                {
                    //User Menu
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("### Please Choose an Action ###\n\n");
                    Console.ResetColor();
                    Console.Write(
                        "[A] Atack\n" +
                        "[R] Run Away\n" +
                        "[P] Player Info\n" +
                        "[M] Monster Info\n" +
                        "[X] Exit \n\n" +
                        "Monsters Defeated: {0}\n\n",
                        score);

                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    //Action
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                        case ConsoleKey.Enter://ease of use
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("### Attack ###\n");
                            Console.ResetColor();
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //find health potion chance +10 life
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You defeated {0}!!\n\n", monster.Name);
                                Console.ResetColor();

                                //FF7 Fanfare
                                Console.Beep(987, 53);
                                Thread.Sleep(53);
                                Console.Beep(987, 53);
                                Thread.Sleep(53);
                                Console.Beep(987, 53);
                                Thread.Sleep(53);
                                Console.Beep(987, 428);
                                Console.Beep(784, 428);
                                Console.Beep(880, 428);
                                Console.Beep(987, 107);
                                Thread.Sleep(214);
                                Console.Beep(880, 107);
                                Console.Beep(987, 857);

                                reload = true;
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("### Run Away ###\n");
                            Console.ResetColor();
                            Console.WriteLine($"{monster.Name} attacks you as you run away!\n");
                            System.Threading.Thread.Sleep(500);
                            Combat.DoAttack(monster, player);
                            System.Threading.Thread.Sleep(2500);
                            reload = true;
                            break;
                        case ConsoleKey.P:
                        case ConsoleKey.H://hero
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("### Player Information ###\n");
                            Console.ResetColor();
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("### Monster Information ###\n");
                            Console.ResetColor();
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.Q://quit
                        case ConsoleKey.E://exit
                        case ConsoleKey.Escape://ease of use
                            Console.WriteLine($"TOTAL MONSTERS DEFATED: {score}\n");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("Thanks for playing!\n");
                            Console.ResetColor();
                            exit = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Unrecognized selection.  Please try again.\n");
                            Console.ResetColor();
                            break;
                    }

                    //Player Life
                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("YOU HAVE DIED.\n");
                        Console.ResetColor();
                        //console beep sad sound
                        exit = true;
                    }

                } while (!reload && !exit);
            } while (!exit);
        }//end Main

        //Room Generation
        private static string GetRoom()
        {
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
            Random random = new Random();
            int index = random.Next(rooms.Length);
            string room = "You enter a new room...\n\n" + rooms[index] + "\n";

            return room;
        }//end GetRoom

    }//end class
}//end namespace
