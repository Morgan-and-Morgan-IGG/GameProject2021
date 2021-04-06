using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Game
    {
        Player player;
        Parser parser;
        bool playing;

        public Game()
        {
            playing = false;
            parser = new Parser(new CommandWords());
            player = new Player(CreateWorld());
        }

        public Room CreateWorld()
        {
            Room centralHallway = new Room("in the Central Hallway");
            Room lobby = new Room("in the Lobby");
            Room southWestHallway = new Room("in the Southwest Hallway");
            Room studyHall = new Room("in the Study Hall");
            Room library = new Room("in the Library");
            Room broomCloset = new Room("in the Broom Closet");
            Room hexLab = new Room("in the Hex Lab");
            Room observatory = new Room("in the Observatory");
            Room southEastHallway = new Room("in the Southeast Hallway");
            Room hauntedBathroom = new Room("in the Haunted Bathroom");
            Room teleportationStudio = new Room("in the Teleportation Studio");
            Room garden = new Room("in the Garden");
            Room northEastHallway = new Room("in the Northeast Hallway");
            Room cafeteria = new Room("in the Cafeteria");
            Room examHall = new Room("in the examHall");
            Room carpentryShop = new Room("in the Carpentry Shop");
            Room northWestHallway = new Room("in the Northwest Hallway");
            Room potionsHall = new Room("in the Potions Hall");
            Room teachersLounge = new Room("in the Teacher's Lounge");
            Room necromancyStudio = new Room("in the Necromancy Studio");
            Room gym = new Room("in the Gym");

            centralHallway.SetExit("Garden", garden);
            centralHallway.SetExit("Lobby", lobby);

            garden.SetExit("Northeast Hallway", northEastHallway);
            garden.SetExit("Northwest Hallway", northWestHallway);
            garden.SetExit("Central Hallway", centralHallway);
            
            northWestHallway.SetExit("Necromancy Studio", necromancyStudio);
            northWestHallway.SetExit("Gym", gym);
            northWestHallway.SetExit("Teacher's Lounge", teachersLounge);
            northWestHallway.SetExit("Potions Hall", potionsHall);
            
            northEasHallway.SetExit("Carpentry Shop", carpentryShop);
            northEastHallway.SetExit("Cafeteria", cafeteria);
            northEastHallway.SetExit("Exam Hall", examHall);
            
            lobby.SetExit("Southeast Hallway", southEastHallway);
            lobby.SetExit("Southwest Hallway", southWestHallway);
            lobby.SetExit("Central Hallway", centralHallway);
            
            southWestHallway.SetExit("Broom Closet", broomCloset);
            southWestHallway.SetExit("Library", library);
            southWestHallway.SetExit("Hex Lab", hexLab);
            southWestHallway.SetExit("Observatory", observatory);
            southWestHallway.SetExit("Study Hall", studyHall);
            
            southEastHallway.SetExit("Haunted Bathroom", hauntedBathroom);
            southEastHallway.SetExit("Teleportation Studio", teleportationStudio);
            
            necromancyStudio.SetExit("Northwest Hallway", northWestHallway);
            gym.SetExit("Northwest Hallway", northWestHallway);
            teachersLounge.SetExit("Northwest Hallway", northWestHallway);
            potionsHall.SetExit("Northwest Hallway", northWestHallway);
            
            cafeteria.SetExit("Northeast Hallway", northEastHallway);
            examHall.SetExit("Northeast Hallway", northEastHallway);
            carpentryShop.SetExit("Northeast Hallway", northEastHallway);
            
            broomCloset.SetExit("Southwest Hallway", southWestHallway);
            library.SetExit("Southwest Hallway", southWestHallway);
            hexLab.SetExit("Southwest Hallway", southWestHallway);
            observatory.SetExit("Southwest Hallway", southWestHallway);
            studyHall.SetExit("Southwest Hallway", southWestHallway);
            
            hauntedBathroom.SetExit("Southeast Hallway", southEastHallway);
            teleportationStudio.SetExit("Southeast Hallway", southEastHallway);
            

            return studyHall;
        }

        /**
     *  Main play routine.  Loops until end of play.
     */
        public void Play()
        {

            // Enter the main command loop.  Here we repeatedly read commands and
            // execute them until the game is over.

            bool finished = false;
            while (!finished)
            {
                Console.Write("\n>");
                Command command = parser.ParseCommand(Console.ReadLine());
                if (command == null)
                {
                    Console.WriteLine("I didn't understand that command");
                }
                else
                {
                    finished = command.Execute(player);
                }
            }
        }


        public void Start()
        {
            playing = true;
            player.OutputMessage(Welcome());
        }

        public void End()
        {
            playing = false;
            player.OutputMessage(Goodbye());
        }

        public string Welcome()
        {
            return "Your sorcery exams are today!\n\n You have to learn all five spells before you take the exam.\n\nType 'help' if you need help." + player.CurrentRoom.Description();
        }

        public string Goodbye()
        {
            return "\nThank you for playing! \n";
        }

    }
}
