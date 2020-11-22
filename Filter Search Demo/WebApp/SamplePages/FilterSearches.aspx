<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilterSearches.aspx.cs" Inherits="WebApp.NorthwindPages.FilterSearches" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-header">
        <h1>Product: Filter MultiRecord Queries</h1>
    </div>

    <div class="row col-md-12">
        <div class="alert alert-warning">
            <blockquote style="font-style: italic; font-size:x-large" >
                This illustrates how to obtain multiple records from a database
                based on a search value. These techniques can be used to create
                Filter searches. Output controls can be any control that will display
                multiple records: DropDownList, GridView, RadioButtonList, CheckboxList,
                DataList, ListView.
            </blockquote>
        </div>
    </div>
    <br />
    <%-- <aps:Label id="MessageLabel" runat="server"></asp:Label> --%>
    <asp:DataList ID="Message" runat="server" Enabled="False">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"
        StaticMenuItemStyle-CssClass="tab"
        Font-Size="Large" StaticSelectedStyle-CssClass="selectedTab"
        StaticMenuItemStyle-HorizontalPadding="50px"
        StaticSelectedStyle-BackColor="lightblue"
        CssClass="tabs"
        OnMenuItemClick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem Text="DropDownList" Selected="true" Value="0"></asp:MenuItem>
            <asp:MenuItem Text="Textbox" Value="1"></asp:MenuItem>
            <asp:MenuItem Text="MultiParameter"  Value="2"></asp:MenuItem>
            <asp:MenuItem Text="DrillDown" Value="3"></asp:MenuItem>
            <asp:MenuItem Text="Exercise" Value="4"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <div class="tabContents">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <fieldset class="form-horizontal">
                    <legend>Filter Queries: Dropdown List</legend>
                    <asp:Label ID="Label1" runat="server" Text="Categories:"></asp:Label>
                    <asp:DropDownList ID="CategoryList" runat="server"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="CategoryList_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:GridView ID="ProductGridViewV1" runat="server">
                    </asp:GridView>
                </fieldset>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <fieldset class="form-horizontal">
                    <legend>Filter Queries: Partial String</legend>
                    <asp:Label ID="label2" runat="server" Text="Enter a product name:">
                    </asp:Label>
                    <asp:TextBox ID="PartialProductNameV2" runat="server"></asp:TextBox>

                    <asp:Button ID="SearchProductsPartial" runat="server" Text="Search Products"
                        OnClick="SearchProductsPartial_Click" />
                    <br />
                    <br />
                    <asp:GridView ID="ProductGridViewV2" runat="server">
                    </asp:GridView>
                </fieldset>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <fieldset class="form-horizontal">
                    <legend>Filter Queries: Dropdown/TextBox List</legend>
                    <asp:Label ID="Label4" runat="server" Text="Suppliers:"></asp:Label>

                    <asp:DropDownList ID="SupplierList" runat="server"></asp:DropDownList>
                    <br />
                    <asp:Label ID="label5" runat="server" Text="Enter a product name:">
                    </asp:Label>
                    <asp:TextBox ID="PartialProductNameV3" runat="server"></asp:TextBox>

                    <asp:Button ID="SearchSupplierProductsPartial" runat="server"
                        Text="Search Products" OnClick="SearchSupplierProductsPartial_Click" />
                    <br />
                    <br />
                    <asp:GridView ID="ProductGridViewV3" runat="server">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <fieldset class="form-horizontal">
                    <legend>Filter Queries: DrillDown with View</legend>
                    <asp:Label ID="Label3" runat="server" Text="Region:"></asp:Label>
                    <asp:DropDownList ID="RegionList" runat="server"></asp:DropDownList>
                    <asp:Button ID="FindTerritories" runat="server" Text="Territories?" OnClick="FindTerritories_Click" />
                    <asp:Label ID="label6" runat="server" Text="Territories:"></asp:Label>
                    <asp:DropDownList ID="TerritoryList" runat="server"></asp:DropDownList>
                    <asp:Button ID="FindEmployees" runat="server" Text="Employees?" OnClick="FindEmployees_Click" />
                    <br />
                    <br />
                    <asp:GridView ID="EmployeesGridViewV4" runat="server">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </asp:View>
             <asp:View ID="View5" runat="server">
                <fieldset class="form-horizontal">
                    <legend>Filter Queries: Exercise</legend>
                    <blockquote style="font-size:x-large">
                        For this exercise (not for marks) you are to retrieve the products
                        from a supplier's category and display the product(s) records. You need to 
                        create the necessary controller methods, design your form, and implement
                        the necessary code-behind. The following resources are available for this exercise:
                        <ul>
                            <li>Sql procedure <strong> Suppliers_GetCategories</strong>: returns the supplier's categories</li>
                            <li>Sql procedure <strong>Products_GetForSupplierCategory</strong>: returns products for a supplier category</li>
                            <li>Entities and Views: <strong>Product, Supplier, SupplierCategories</strong></li>
                        </ul>
                    </blockquote>
                    <asp:Label ID="Label7" runat="server" Text="Supplier:"></asp:Label>
                    <asp:DropDownList ID="SupplierListV5" runat="server"></asp:DropDownList>
                    <asp:Button ID="FindCategories" runat="server" Text="Categories?"  />
                    <asp:Label ID="label8" runat="server" Text="Categories:"></asp:Label>
                    <asp:DropDownList ID="CategoryListV5" runat="server"></asp:DropDownList>
                    <asp:Button ID="FindSupplierCategoryProducts" runat="server" Text="Products?" 
                          Enabled="false" />
                     <asp:Button ID="Reset" runat="server" Text="Reset"  />
                    <br />
                    <br />
                    <asp:GridView ID="ProductsGridViewV5" runat="server">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </asp:View>
        </asp:MultiView>

    </div>
</asp:Content>
