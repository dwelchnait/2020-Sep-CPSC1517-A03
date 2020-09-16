using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Door
    {
        // height, width, material (nullable), right or left swing door
        //height and width > 0.0
        //height has a defualt of 1.75, width is 1.2
        //right or left are indicated with an R or L
        //Area and Perimeter
        //throw exceptions for invalid data

        private string _Material;
        private decimal _Height;
        private string _RightOrLeft;
        private decimal _Width;

        public string Material
        {
            get
            {
                return _Material;
            }
            set
            {
                _Material = string.IsNullOrEmpty(value) ? null : value;
            }
        }

        public string RightOrLeft
        {
            get
            {
                return _RightOrLeft;
            }
            set
            {
                if (value.ToUpper().Equals("R") || value.ToUpper().Equals("L"))
                {
                    _RightOrLeft = value.ToUpper();
                }
                else
                {
                    throw new Exception("Door opening direction must be R (right) or L (left)");
                }
            }
        }

        public decimal Height
        {
            get
            {
                return _Height;
            }
            set
            {
                // the m indicates the value is a decimal
                if (value <= 0.0m)
                {
                    throw new Exception("Height can not be 0 or less than 0.");
                }
                else
                {
                    _Height = value;
                }
            }
        }

        public decimal Width
        {
            get
            {
                return _Width;
            }
            set
            {
                if (value <= 0.0m)
                {
                    throw new Exception("Width can not be 0 or less than 0.");
                }
                else
                {
                    _Width = value;
                }
            }
        }

        public Door()
        {
            //instead of using the system datatype defaults, we have supplied
            //  our own defaults
            Width = 1.2m;
            Height = 1.75m;
            RightOrLeft = "R"; //could have be "L"
        }

        public Door(decimal width, decimal height, string rightofleft, string material)
        {
            Width = width;
            Height = height;
            RightOrLeft = rightofleft;
            Material = material;
        }

        public decimal DoorArea()
        {
            return Width * Height;
        }

        public decimal DoorPerimeter()
        {
            return 2 * (Width + Height);
        }
    }
}
