
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

        }
    }
}