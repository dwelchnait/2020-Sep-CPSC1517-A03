
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Entities;
#endregion

namespace WebApp.SamplePages
{
    public partial class GridViewCodeBehind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }

        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void SearchProduct_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ProductArg.Text))
            {
                MessageLabel.Text = "Enter a product name (pr portion of) then press search";
            }
            else
            {
                try
                {
                    //standard look up
                    ProductController sysmgr = new ProductController();
                    List<Product> info = sysmgr.Product_GetByPartialProductName(ProductArg.Text);
                    if (info.Count > 0)
                    {
                        //put the data on the custom gridview
                        //the data set has all the columns of the Product table
                        //the gridview will ONLY use the columns that are requested
                        ProductList.DataSource = info;
                        ProductList.DataBind();
                    }
                    else
                    {
                        MessageLabel.Text = "No products match your search value";
                        ProductList.DataSource = null;
                        ProductList.DataBind();
                    }
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = GetInnerException(ex).Message;
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ProductArg.Text = "";
            ProductID.Text = "";
            ProductName.Text = "";
            UnitPrice.Text = "";
            Discontinued.Checked = false;
            //emptying a gridview
            ProductList.DataSource = null;
            ProductList.DataBind();
        }

        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //determine the selected GridView Row
                //this obtains a pointer to the selected row
                GridViewRow agvrow = ProductList.Rows[ProductList.SelectedIndex];
                //obtaining a pointer to the control on the row
                //WARNING: if you can find the control on the gridview
                //         your error will be Object Reference set to null
                HiddenField aPointerToControl = agvrow.FindControl("ProductID") as HiddenField;
                //obtain the contents of the control on the gridview
                //most contents of controls are returned as a string
                string hiddenfieldvalue = aPointerToControl.Value;
                //convert the string value to a numeric
                int productid = int.Parse(hiddenfieldvalue);
                //the last 3 lines could be coded as one
                //int productid = int.Parse((agvrow.FindControl("ProductID") as HiddenField).Value);
                

                //standard lookup
                ProductController sysmgr = new ProductController();
                Product info = sysmgr.Product_FindByID(productid);
                //a single row test
                if(info == null)
                {
                    MessageLabel.Text = "Product not currently on file. Refresh your search";
                    //optionally clear your display
                    //reuse a method (event) in your program
                    Clear_Click(sender, e);
                }
                else
                {
                    ProductID.Text = info.ProductID.ToString();
                    ProductName.Text = info.ProductName;
                    UnitPrice.Text = string.Format("{0:0.00}", info.UnitPrice);
                    Discontinued.Checked = info.Discontinued;
                }
            }
            catch(Exception ex)
            {
                MessageLabel.Text = GetInnerException(ex).Message;
            }
        }

        protected void ProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //you must manually alter the current PageIndex on the gridview
            //the collection along with the PageSize will determine which
            //   rows of your dataset (colletion) to display
            //the required page (group of records) is indicated by the pageindex
            //the selected (new) pageindex is available to you via the
            //    GridViewPageEventArgs parameter e.NewPageIndex
            ProductList.PageIndex = e.NewPageIndex;

            //you MUST new refresh your data set (collection)
            SearchProduct_Click(sender, new EventArgs());
        }
    }
}