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
    public partial class CRUDPage : System.Web.UI.Page
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

        protected void Clear_Click(object sender, EventArgs e)
        {
            ProductArg.Text = "";
            ProductID.Text = "";
            ProductName.Text = "";
            QuantityPerUnit.Text = "";
            UnitPrice.Text = "";
            UnitsInStock.Text = "";
            UnitsOnOrder.Text = "";
            ReorderLevel.Text = "";
            Discontinued.Checked = false;
            CategoryList.SelectedIndex = 0;
            SupplierList.SelectedIndex = 0;
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
                if (info == null)
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
                    CategoryList.SelectedValue = info.CategoryID.HasValue ? info.CategoryID.ToString() : "0";
                    SupplierList.SelectedValue = info.SupplierID.HasValue ? info.SupplierID.ToString() : "0";
                    QuantityPerUnit.Text = string.IsNullOrEmpty(info.QuantityPerUnit) ? "" : info.QuantityPerUnit;
                    UnitPrice.Text = string.Format("{0:0.00}", info.UnitPrice);
                    if (info.UnitsInStock == null)
                    {
                        UnitsInStock.Text = "0";
                    }
                    else
                    {
                        UnitsInStock.Text = info.UnitsInStock.ToString();
                    }
                    if (info.UnitsOnOrder == null)
                    {
                        UnitsOnOrder.Text = "0";
                    }
                    else
                    {
                        UnitsOnOrder.Text = info.UnitsOnOrder.ToString();
                    }
                    if (info.ReorderLevel == null)
                    {
                        ReorderLevel.Text = "0";
                    }
                    else
                    {
                        ReorderLevel.Text = info.ReorderLevel.ToString();
                    }
                    
                    Discontinued.Checked = info.Discontinued;
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = GetInnerException(ex).Message;
            }
        }

        protected void SearchProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductArg.Text))
            {
                MessageLabel.Text = "Enter a product name (or portion of) then press search";
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Product item = new Product();
                item.ProductName = ProductName.Text;
                if(CategoryList.SelectedValue == "0")
                {
                    item.CategoryID = null;
                }
                else
                {
                    item.CategoryID = int.Parse(CategoryList.SelectedValue);
                }
                if (SupplierList.SelectedValue == "0")
                {
                    item.SupplierID = null;
                }
                else
                {
                    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                }
                item.QuantityPerUnit = string.IsNullOrEmpty(QuantityPerUnit.Text) ?
                    null : QuantityPerUnit.Text;
                if (string.IsNullOrEmpty(UnitPrice.Text))
                {
                    item.UnitPrice = null;
                }
                else
                {
                    item.UnitPrice = decimal.Parse(UnitPrice.Text);
                }
                if (string.IsNullOrEmpty(UnitsInStock.Text))
                {
                    item.UnitsInStock = null;
                }
                else
                {
                    item.UnitsInStock = Int16.Parse(UnitsInStock.Text);
                }
                if (string.IsNullOrEmpty(UnitsOnOrder.Text))
                {
                    item.UnitsOnOrder = null;
                }
                else
                {
                    item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text);
                }
                if (string.IsNullOrEmpty(ReorderLevel.Text))
                {
                    item.ReorderLevel = null;
                }
                else
                {
                    item.ReorderLevel = Int16.Parse(ReorderLevel.Text);
                }
                item.Discontinued = false;
                try
                {
                    ProductController sysmgr = new ProductController();
                    int newproductid = sysmgr.Product_Add(item);
                    ProductID.Text = newproductid.ToString();
                    MessageLabel.Text = "Product has been added.";
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = GetInnerException(ex).Message;
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "TODO: code update event";
        }

        protected void Disc_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "TODO: code discontinued event";
        }
    }
}