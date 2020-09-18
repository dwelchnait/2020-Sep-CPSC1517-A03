using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
   
    public class Room
    {
        //composite class
        //is a mixture of data members/properties
        //   of native datatypes and other classes

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = string.IsNullOrEmpty(value) ? "Unknown" : value; }
        }
    
        public List<Wall> Walls { get; set; }
        public List<Window> Windows { get; set; }
        public List<Door> Doors { get; set; }

        public Room()
        {
            Name = "Unknown";
        }
    }
    
}
