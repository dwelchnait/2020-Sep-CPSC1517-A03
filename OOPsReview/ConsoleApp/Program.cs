using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        { 
            //Default constructor
            //create an instance of the Window class using the default constructor
            //the system calls your class constructor via the "new" command
            //the "new" will use the indicated constructor
            //the "new" actually makes the call to the constructor and returns
            //  the instance of the class
            //your code NEVER calls the contructor directly
            Window myDefaultInstance = new Window();

            //results of the Default constructor
            Console.WriteLine($"Width {myDefaultInstance.Width}; Height {myDefaultInstance.Height};" +
                $"Panes {myDefaultInstance.NumberofPanes}; Manufacturer >{myDefaultInstance.Manufacturer}<");

            //change the contents of an instance by using the instance class properties
            //  and/or methods
            //to reference a property/method within an instance, use the dot operator
            myDefaultInstance.Height = 2.75m;
            myDefaultInstance.Width = 1.9m;
            myDefaultInstance.NumberofPanes = 3;
            myDefaultInstance.Manufacturer = "See Thru Holes";

            //results of the changes via class instance properties
            Console.WriteLine($"Width {myDefaultInstance.Width}; Height {myDefaultInstance.Height};" +
                $"Panes {myDefaultInstance.NumberofPanes}; Manufacturer >{myDefaultInstance.Manufacturer}<");

            //Greedy constructor
            Window myGreedyInstance = new Window(2.75m, 1.9m, 3, "See thru Holes");

            Console.WriteLine($"Width {myGreedyInstance.Width}; Height {myGreedyInstance.Height};" +
               $"Panes {myGreedyInstance.NumberofPanes}; Manufacturer >{myGreedyInstance.Manufacturer}<");

            Console.WriteLine("\n\n");

            UsingClasses();

            //when using your debugging
            Console.ReadKey();
        }
        static void UsingClasses()
        {
            //the purpose of this methid is to calculate the cost
            //  of painting a room
            //the room will have serval windows and walls with a single door
            //all data for windows, walls and doors will be collected and
            //   stored in an instance of Room

            //What does Room need
            //declare a set of List<T> for the components of the Room
            List<Wall> walls = new List<Wall>();
            List<Window> windows = new List<Window>();
            List<Door> doors = new List<Door>();
            Room room = new Room(); //Default constructor

            //read and collect the data for the room
            //create a reusable pointer variable to each of the components
            //   of a room (wall, window, door)
            //these pointers are created outside of my input loops
            Wall wall = null;
            Window window = null;
            Door door = null;

          

            //collect the data for all of the walls in the room
            //loop of prompt/input/validation for each wall

            //after validation of data, create an instance of the need class
            wall = new Wall();
            //load data into the instance
            wall.Width = 6.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //end of the wall collection loop

            //assume the loop collected and stored the following
            //pass 2
            wall = new Wall();
            //load data into the instance
            wall.Width = 6.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //pass 3
            wall = new Wall();
            //load data into the instance
            wall.Width = 5.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //pass 4
            wall = new Wall();
            //load data into the instance
            wall.Width = 5.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //door loop
            //collect the data for all of the doors in the room
            //loop of prompt/input/validation for each door
            //assume in this example that the literials were acually in variables
            //door = new Door(inputWidth, inputHeight, inputRL, inputMaterial);
            door = new Door(0.85m, 2.0m, "R", "Composite Pressed Wood");
            doors.Add(door);

            //end of door loop

            //Window loop
            //prompt/input/validate
            //store
            window = new Window(1.3m, 1.3m, 2, "Fancy Windows");
            windows.Add(window);
            window = new Window(1.3m, 1.3m, 2, "Fancy Windows");
            windows.Add(window);


            //store all of the room components into the instance of room.

        }
    }
}
