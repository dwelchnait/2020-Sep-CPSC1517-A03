using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.BLL;
#endregion

namespace WebApp.NorthwindPages
{
    public partial class FilterSearches : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                BindCategoryList();
                BindSupplierList();
                BindRegionList();
            }
        }

        protected void BindCategoryList()
        {
            try
            {
                CategoryController sysmgr = new CategoryController();
                List<Category> info = sysmgr.Category_List();
                info.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                CategoryList.DataSource = info;
                CategoryList.DataTextField = nameof(Category.CategoryName);
                CategoryList.DataValueField = nameof(Category.CategoryID);
                CategoryList.DataBind();
                CategoryList.Items.Insert(0, "select...");
            }
            catch(Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindSupplierList()
        {
            try
            {
                SupplierController sysmgr = new SupplierController();
                List<Supplier> info = sysmgr.Supplier_List();
                info.Sort((x, y) => x.CompanyName.CompareTo(y.CompanyName));
                SupplierList.DataSource = info;
                SupplierList.DataTextField = nameof(Supplier.CompanyName);
                SupplierList.DataValueField = nameof(Supplier.SupplierID);
                SupplierList.DataBind();
                SupplierList.Items.Insert(0, "select...");
                SupplierListV5.DataSource = info;
                SupplierListV5.DataTextField = nameof(Supplier.CompanyName);
                SupplierListV5.DataValueField = nameof(Supplier.SupplierID);
                SupplierListV5.DataBind();
                SupplierListV5.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindRegionList()
        {
            try
            {
                RegionController sysmgr = new RegionController();
                List<Region> info = sysmgr.Region_List();
                info.Sort((x, y) => x.RegionDescription.CompareTo(y.RegionDescription));
                RegionList.DataSource = info;
                RegionList.DataTextField = nameof(Region.RegionDescription);
                RegionList.DataValueField = nameof(Region.RegionID);
                RegionList.DataBind();
                RegionList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
       
        //use this method to discover the inner most error message.
        //this routine has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in
        //   a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        //use this method to switch between views.
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }

        protected void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a category to view the category products.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                ProductGridViewV1.DataSource = null;
                ProductGridViewV1.DataBind();
            }
            else
            {
                try
                {
                    ProductController sysmgr = new ProductController();
                    List<Product> info = sysmgr.Products_GetByCategories(int.Parse(CategoryList.SelectedValue));
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the partial product name search");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                       
                        //GridView
                        ProductGridViewV1.DataSource = info;
                        ProductGridViewV1.DataBind();

                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void SearchProductsPartial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PartialProductNameV2.Text))
            {
                errormsgs.Add("Please enter a partial product name for the search");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                ProductGridViewV2.DataSource = null;
                ProductGridViewV2.DataBind();
            }
            else
            {
                try
                {
                    ProductController sysmgr = new ProductController();
                    List<Product> info = sysmgr.Products_GetByPartialProductName(PartialProductNameV2.Text);
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the partial product name search");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                        //load the multiple record control

                        //GridView
                        ProductGridViewV2.DataSource = info;
                        ProductGridViewV2.DataBind();

                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void SearchSupplierProductsPartial_Click(object sender, EventArgs e)
        {
            if (SupplierList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a supplier to view the supplier products.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                ProductGridViewV3.DataSource = null;
                ProductGridViewV3.DataBind();
            }
            else if(string.IsNullOrEmpty(PartialProductNameV3.Text))
            {
                errormsgs.Add("Enter a product (partial) name.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                ProductGridViewV3.DataSource = null;
                ProductGridViewV3.DataBind();
            }
            else
            {
                try
                {
                    ProductController sysmgr = new ProductController();
                    List<Product> info = sysmgr.Products_GetBySupplierPartialProductName(
                        int.Parse(SupplierList.SelectedValue),
                        PartialProductNameV3.Text);
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the partial product name of supplier search");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));

                        //GridView
                        ProductGridViewV3.DataSource = info;
                        ProductGridViewV3.DataBind();

                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void FindTerritories_Click(object sender, EventArgs e)
        {
            if (RegionList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a region to obtain territories.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                TerritoryList.DataSource = null;
                TerritoryList.DataBind();
                EmployeesGridViewV4.DataSource = null;
                EmployeesGridViewV4.DataBind();
            }
            else
            {
                try
                {
                    TerritoryController sysmgr = new TerritoryController();
                    List<Territory> info = sysmgr.Territory_GetByRegion(int.Parse(RegionList.SelectedValue));
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the region");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.TerritoryDescription.CompareTo(y.TerritoryDescription));
                        //Second Dropdown list drill down
                        TerritoryList.DataSource = info;
                        TerritoryList.DataTextField = nameof(Territory.TerritoryDescription);
                        TerritoryList.DataValueField = nameof(Territory.TerritoryID);
                        TerritoryList.DataBind();
                        TerritoryList.Items.Insert(0, "select....");
                        //GridView
                        EmployeesGridViewV4.DataSource = null;
                        EmployeesGridViewV4.DataBind();

                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void FindEmployees_Click(object sender, EventArgs e)
        {
            if (TerritoryList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a territory to view the territory employees.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                EmployeesGridViewV4.DataSource = null;
                EmployeesGridViewV4.DataBind();
            }
            else
            {
                try
                {
                    EmployeeController sysmgr = new EmployeeController();
                    List<EmployeeOfTerritory> info = sysmgr.Employee_GetByTerritory(TerritoryList.SelectedValue);
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the territory");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.FirstName.CompareTo(y.FullName));
                       
                        //GridView
                        EmployeesGridViewV4.DataSource = info;
                        EmployeesGridViewV4.DataBind();

                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

    }
}