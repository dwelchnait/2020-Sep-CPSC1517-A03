using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //a class represents the defined characteristics of an item
    //an item can be a phyiscal thing (cellphone), concept (student),
    //  represent a collection of data or/and methods
    //Visual Studio creates your classes withour a specific access type
    //the default type for a class is private
    //code outside of a private class cannot use the contents of the private class
    //for the class to be used by an outside user (program) it must be publlic

    public class Window
    {
        //the class can have data that is open to theuser by
        //   defining it as a public datatype
        //the class can have data (local variables) that is restricted from the user
        //   by defining it as a private datatype
        //the class can create a Property that can be used to
        //   interface between the user and the private data member
        //this interface is a public Property

        //private data member
        private string _Manufacturer;
        private decimal _Height;
        
        //Properties
        //optional
        //properties can be implemented in two ways
        //a) Fully Implemented Property
        //  used because there is additional code/logic use
        //  in processing the data
        //b) Auto Implemented Property
        //  used when there is no need for additional code/logic,
        //  when the data is simply saved (stored)

        //Fully Implemented Property
        public string Manufacturer
        {
            //assume the Manufacturer is a nullable string
            //3 possibilities
            //  a)there are characters in the string
            //  b)string has no data (null)
            //  c)there is a physical string BUT NO characters other than the
            //      end of string character
            //there will be additional code/logic to ensure ONLY case a and b
            //  exists for the data
            //this requires a private data member to hold the data
            //  and a property to manage the data content

            //imagine an assignment statement   recieving variable(left side) = sending data (right side)
            get
            {
                //returns data via the property to the outside user of that property
                // right side of an asignment statement
                //the data that is being return will normally come from a private
                //  data member
                return _Manufacturer;
            }
            private set
            {
                //stores data via the property from the outside user of that property
                // left side of an asignment statement
                //stores the data into your private data member
                //internal to the property is a common variable that will hold
                //   the incoming data, this variable is called value
                //a property is associated with a SINGLE data member
                //a property has NO parameter list
                if (string.IsNullOrEmpty(value))
                {
                    //case b and c
                    _Manufacturer = null;
                }
                else
                {
                    //case a
                    _Manufacturer = value; //value hold the into coming data
                }

                //alternate way of coding set
                //ternary operator
                //syntax:    condition(s) ? true value : false value
                //_Manufacturer = string.IsNullOrEmpty(value) ? null : value;

            }
        }

        //Auto Implemeted Properties
        //auto implemented properties can be used when there is NO NEED
        //  for additional processing against the incoming data
        //NO internal private data member is required for this property
        //the system will intenally generate a data area for the data
        //accessing this stored data (getting or setting) CAN ONLY be done
        //   via the property

        public decimal Width { get; set; }

        //one can still code an auto implement property as a
        //  fully implemented property
        //private decimal _Width;
        //public decimal Width
        //{
        //    get { return _Width; }
        //    set { _Width = value; }
        //}
        
        //what if, the data coming in is invalid?
        //Will there be additional logic/code need? YES
        //What property implementation is needed? 
        public decimal Height
        {
            get { return _Height; }
            set
            {
                //the m on the literal indicates the value is a decimal
                if (value <= 0.0m)
                {
                    throw new Exception("Height can not be 0 or less than 0");
                }
                else
                {
                    _Height = value;
                }
            }
        }

        //Nullable numerics
        //Why do we NOT need to fully implement a nullable numeric?
        //Numerics have a default of zero
        //Numerics can only store a numeric value (unless nullable)
        //Numerics can be null if declared as nullable
        //the only 2 possibilites for a nullable numeric is a number or null
        //IF the numeric has additional criteria THEN you can code
        //    the property as a Fully Implemented property
        public int? NumberofPanes { get; set; }

        //Constructors

        //Behaviours (methods)
    }
}
