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
            Window myDefaultInstance = new Window();

            myDefaultInstance.Height = 2.75m;
            myDefaultInstance.Width = 1.9m;
            myDefaultInstance.NumberofPanes = 3;
            myDefaultInstance.Manufacturer = "See Thru Holes";

            //Greedy constructor
            Window myGreedyInstance = new Window(2.75m, 1.9m, 3, "See thru Holes");

        }
    }
}
