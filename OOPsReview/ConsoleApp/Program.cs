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
            room.Name = "Master Bedroom";
            room.Walls = walls;
            room.Windows = windows;
            room.Doors = doors;

            //calculate the number of cans of paint needed for the room
            //assume a can of paint covers 27.87 sq m

            //determine the area of wall surface to paint
            //total area of walls
            //total area of windows
            //total area of doors
            //paintable surface = wallarea  (windowarea + doorarea)
            //cans = paintable surface / 27.87

            //calculate the total area of the walls
            //traverse the List<T> one at a time, start to end
            decimal wallarea = 0.0m;
            foreach(Wall item in room.Walls)
            {
                //to reference something in an instance
                //     instancename.instanceitem
                //     instancename.property
                //     instancename.method()
                // the . (dot) is called the dot operator
                wallarea += item.WallArea();
            }

            //calculate the area of the windows
            //review the for(init; condition(s); increment){....}
            decimal windowarea = 0.0m;
            for(int i =0; i < room.Windows.Count; i++)
            {
                //individual instances in a collection (List<T>) can
                //   be referenced using an index
                windowarea += room.Windows[i].WindowArea();
                //windowarea += windows[i].WindowArea();
            }

            //calculate the area of the doors
            decimal doorarea = 0.0m;
            //var is a datatype
            //var is resolved at execution time --> Door
            //the resolved datatype remains as the resolved datatype unitl
            //  the variable is terminated.
            foreach (var item in room.Doors)
            {
                doorarea += item.DoorArea();
            }

            //paintable surface area
            decimal netWallArea = wallarea - (windowarea + doorarea);

            //calculate the number of cans required
            decimal cansOfPaint = netWallArea / 27.87m;

            //output results
            Console.WriteLine($"Wall area is:\t\t\t\t{wallarea:0.00}");
            //Console.WriteLine("Wall area is:\t\t{0:0.00}",wallarea);
            Console.WriteLine($"Window area is:\t\t\t\t{windowarea:0.00}");
            Console.WriteLine($"Door area is:\t\t\t\t{doorarea:0.00}");
            Console.WriteLine($"Net wall area is:\t\t\t{netWallArea:0.00}");
            Console.WriteLine($"Required number of paint cans is:\t{cansOfPaint:0.00}");
        }
    }
}
