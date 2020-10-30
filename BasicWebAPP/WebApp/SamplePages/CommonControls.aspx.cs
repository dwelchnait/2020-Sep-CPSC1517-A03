using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class CommonControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this method executes BEFORE any event method on
            //      EACH processing of this web page

            //this is a great place to do common code that is
            //      required on EACH process of the page
            //Example: empty out old messages
            MessageLabel.Text = "";

            //this is an excellent place to do page initialization
            //  of controls on the 1st pass
            //checking the 1st time for this page uses the post back flag
            //Page.IsPostBack; this is a boolean value(true or false)
            if(!Page.IsPostBack)        //if(!false) => true
            {
                //if the page is not PostBack, it means that this
                //  is the 1st time the page has been displayed

                //simulate the loading of the dropdownlist via a
                //  dataset from a database call

                //create a collection of instances (class objects)
                //  that will be used to load the dropdownlist
                //each instance will represent a record on the
                //  database dataset
                //to accomplish is simulation, we will create a
                //  class and use it with a List<T>
                //the <T> in this example is the class DDLData
                List<DDLData> DDLCollection = new List<DDLData>();
                DDLData aninstance = new DDLData();
                aninstance.ValueId = 1;
                aninstance.DisplayText = "COMP1008";
                DDLCollection.Add(aninstance);
                aninstance = new DDLData(3, "DMIT1508");
                DDLCollection.Add(aninstance);
                DDLCollection.Add(new DDLData(4, "DMIT2018"));
                DDLCollection.Add(new DDLData(2, "CPSC1517"));

                //sorting of a List<T
                // (x,y) are placeholders representing any 2 records at any
                //      given time during the sort
                // => (lamda symbol) is part of the delegate syntax, I suggest
                //          that you read this symbol as "do the following"
                // comparing x to y is ascending
                // comparing y to x is descending
                DDLCollection.Sort((x,y) => x.DisplayText.CompareTo(y.DisplayText));

                //place the data collection set into the dropdownlist control
                //3 step to this process

                //a) assign the data collection set to the control
                CollectionList.DataSource = DDLCollection;

                //b) in this step you will assign the value that will
                //      be diplayed to the user and the value that will
                //      be associated and return from the control wher
                //      the user picks a particular selection
                //in the <select> control, this data was step using the <option>
                //  <option value="xxxx">display string</option>
                //this information is assigned to the DDL control by use
                //   of the property name in your collection

                //2 styles
                //  a) physical string of the field name
                CollectionList.DataValueField = "ValueId";
                //  b) OOP style coding
                CollectionList.DataTextField = nameof(DDLData.DisplayText);

                //c) bind your data source to your control
                CollectionList.DataBind();

                //d) optionally
                //  add a prompt line to your dropdownlist
                CollectionList.Items.Insert(0, new ListItem("select ...", "0"));
            }
        }

        protected void SubmitNumberChoice_Click(object sender, EventArgs e)
        {
            int numberchoice = 0;
            //validation checking that I have good data for my choice
            if (string.IsNullOrEmpty(NumberChoice.Text))
            {
                MessageLabel.Text = "Enter a number from 1 to 4";
            }
            else if (!int.TryParse(NumberChoice.Text, out numberchoice)) 
            {
                MessageLabel.Text = "Invalid number. Enter a number from 1 to 4";
            }
            else if (numberchoice < 1 || numberchoice > 4)
            {
                MessageLabel.Text = "Number is out of range. Enter a number from 1 to 4";
            }
            else
            {
                //good input data

                //RadioButtonlist
                //assign a value to the RadioButtonlist in indicate the item choice
                //   is based on the input data value
                //this can be done using either; .SelectedValue or .SelectedIndex
                //.SelectedValue will match the control item value to the
                //      argument value (BEST TO USE)
                //.SelectedIndex selects the control item to show based on the
                //      numerical index value (for PHYSICAL POSITIONING ONLY)
                //RadioButtonListChoice.SelectedValue = numberchoice.ToString();
                RadioButtonListChoice.SelectedValue = NumberChoice.Text;

                //set the checkbox
                //checbox is a boolean set
                if (numberchoice == 2 || numberchoice == 4)
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                //position in CollectionList on the selected item row
                //this can be done using either; .SelectedValue or .SelectedIndex
                //.SelectedValue will match the control item value to the
                //      argument value (BEST TO USE)
                //.SelectedIndex selects the control item to show based on the
                //      numerical index value (for PHYSICAL POSITIONING ONLY)
                CollectionList.SelectedValue = numberchoice.ToString();

                //create a message to display in the read only label control
                //ACCESS the data from the dropdownlist/radiobuttonlist
                //this can be done using either; .SelectedValue or .SelectedIndex
                //      or .SelectedItem.Text
                //.SelectedValue will return the value associated with the
                //      selected item from the dropdownlist (value of the row)
                //.SelectedIndex will return the index of the rows selected in the
                //      dropdownlist (is the phyiscal index position of the row)
                //.SelecetedItem.Text will return the display text associated with
                //      the selected item from the dropdownlist (is the display text)
                DisplayReadOnly.Text = CollectionList.SelectedItem.Text +
                    " at index " + CollectionList.SelectedIndex +
                    " having a value of " + CollectionList.SelectedValue +
                    ". This matches the radio button choice item value " +
                    RadioButtonListChoice.SelectedValue +
                    " located at radiobuttonlist index " +
                    RadioButtonListChoice.SelectedIndex;

            }
        }
    }
}