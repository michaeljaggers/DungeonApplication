using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Lair of Secrets";
            Console.WriteLine("Your journey begins...\n");
            int score = 0;

            //TODO 1. Create the player - need to create a class for this, as well as an instance of a weapon

            //TODO 2. Create a loop for the room and monster
            bool exit = false;
            do
            {
                //Enter a room
                //TODO 3. Call GetRoom()
                Console.WriteLine(GetRoom());

                //TODO 4. Create a monster for the room - learn about creating objects and then randomly selecting one

                //TODO 5. Create the loop for the room
                bool reload = false;
                do
                {
                    //TODO 6. Create the menu
                    #region User Menu
                    Console.Write("\n\nPlease Choose an Action:\n" +
                        "A) Atack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit \n\n" +
                        "Current Score: {0}\n\n", score);
                    #endregion

                    //TODO 7. Catch the user choice
                    #region User Choice
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    //Above will execute upon input without having to hit enter
                    #endregion

                    //TODO 8. Clear the console and build the switch based on userChoice
                    Console.Clear();
                    #region Switch that runs functionality based on user choice
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Attack\n");
                            //TODO 9. Build attack logic
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away\n");
                            //TODO 10. Build run away logic
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Information\n");
                            //TODO 11. Need to add player info
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Information\n");
                            //TODO 12. Need to add monster info
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("No one likes a quitter!\n");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("I thought you could read the menu and make a choice...maybe you should lose some XP for this!\n");
                            break;
                    }//end switch

                    //TODO 13. Handle Player Life

                    #endregion

                } while (!reload && !exit);
            } while (!exit);//exit == false
        }//end Main()

        //TODO 14. Create GetRoom() & plug it in to the todo above
        private static string GetRoom()
        {
            //create an array of room descriptions - string datatype
            string[] rooms =
            {
                //place a variety of room descriptions here
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
            Random rand = new Random();
            //since the maxValue in the Next() is exclusive, we can just use the Length property to include all indexes from our array.
            int indexNbr = rand.Next(rooms.Length);
            string room = "***** NEW ROOM *****\n" + rooms[indexNbr] + "\n";
            //return room
            return room;
        }//end Main()
    }//end class
}//end namespace
