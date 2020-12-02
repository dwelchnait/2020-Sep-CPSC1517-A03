<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDPage.aspx.cs" Inherits="WebApp.SamplePages.CRUDPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="jumbotron">
            <h1>Filter Search using GridView</h1>
            <blockquote class="col-md-12 alert alert-info">
                This web page uses only code behind techniques. This page uses a drill down
                filter search involving a TextBox and GridView. The GridView demonstrates:
                customization, paging and selection.
            </blockquote>
        </div>
    </div>
    <div class="row">
        <asp:RequiredFieldValidator ID="RequiredProductName" runat="server" 
            ErrorMessage="Product Name is required"
            Display="None" SetFocusOnError="true" ForeColor="Firebrick"
             ControlToValidate="ProductName">
        </asp:RequiredFieldValidator>

        <asp:CompareValidator ID="CompareUnitPrice" runat="server" 
            ErrorMessage="Dollar price must be greater or equal to 0.00"
             Display="None" SetFocusOnError="true" ForeColor="Firebrick"
             ControlToValidate="UnitPrice" Type="Double" Operator="GreaterThanEqual"
             ValueToCompare="0.00">
        </asp:CompareValidator>
         <asp:CompareValidator ID="CompareUnitsInStock" runat="server" 
            ErrorMessage="Quanity on Hand must be greater or equal to 0"
             Display="None" SetFocusOnError="true" ForeColor="Firebrick"
             ControlToValidate="UnitsInStock" Type="Integer" Operator="GreaterThanEqual"
             ValueToCompare="0">
        </asp:CompareValidator>
        <asp:RangeValidator ID="RangeUnitsOnOrder" runat="server" 
             ErrorMessage="Quanity on Order must be greater or equal to 0"
             Display="None" SetFocusOnError="true" ForeColor="Firebrick"
              ControlToValidate="UnitsOnOrder" Type="Integer" MinimumValue="0"
             MaximumValue="32767">
        </asp:RangeValidator>
          <asp:CompareValidator ID="CompareReorderLevel" runat="server" 
            ErrorMessage="Reorder level must be greater or equal to 0"
             Display="None" SetFocusOnError="true" ForeColor="Firebrick"
             ControlToValidate="ReorderLevel" Type="Integer" Operator="GreaterThanEqual"
             ValueToCompare="0">
        </asp:CompareValidator>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="row">
        <div class="col-md-7">
            <asp:Label ID="Label1" runat="server" Text="Enter a product name:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="ProductArg" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:LinkButton ID="SearchProduct" runat="server" OnClick="SearchProduct_Click"
                 CausesValidation="false">
                <i class="fa fa-search"></i>Search Product?</asp:LinkButton>
            &nbsp;&nbsp;
            <asp:LinkButton ID="Clear" runat="server" OnClick="Clear_Click"
                 CausesValidation="false">
                <i class="fa fa-trash"></i>Clear</asp:LinkButton>
            <br />
            <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
            <br />
            <asp:GridView ID="ProductList" runat="server"
                CssClass="table table-striped" GridLines="Horizontal"
                BorderStyle="None" AutoGenerateColumns="False"
                OnSelectedIndexChanged="ProductList_SelectedIndexChanged" 
                DataSourceID="ProductListODS" AllowPaging="True" PageSize="4">

                <Columns>
                    <asp:CommandField CausesValidation="False" SelectText="View" 
                        ShowSelectButton="True" ButtonType="Button"></asp:CommandField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:HiddenField ID="ProductID" runat="server" 
                                 Value='<%# Eval("ProductID") %>'/>
                            <asp:Label ID="Label2" runat="server" 
                                Text='<%# Eval("ProductName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cat.">
                        <ItemTemplate>
                            <asp:DropDownList ID="CategoryGVList" runat="server" 
                                DataSourceID="CategoryListODS" 
                                DataTextField="CategoryName" 
                                DataValueField="CategoryID"
                                selectedvalue='<%# Eval("CategoryID") %>' >
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price ($)">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" 
                                Text='<%# string.Format("{0:0.00}",Eval("UnitPrice")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QoH">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" 
                                Text='<%# Eval("UnitsInStock") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" NextPageText="..." PageButtonCount="5" PreviousPageText="..." />
              
            </asp:GridView>
        </div>
        <div class="col-md-5">
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Product ID:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="ProductID" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label5" runat="server" Text="Name:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="ProductName" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label8" runat="server" Text="Category:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="CategoryList" runat="server">

                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label10" runat="server" Text="Supplier:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="SupplierList" runat="server">

                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label11" runat="server" Text="Qty/Unit:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="QuantityPerUnit" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label7" runat="server" Text="Price ($):"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="UnitPrice" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label12" runat="server" Text="QoH:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="UnitsInStock" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                               <tr>
                    <td align="right">
                        <asp:Label ID="Label13" runat="server" Text="QoO:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="UnitsOnOrder" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                               <tr>
                    <td align="right">
                        <asp:Label ID="Label14" runat="server" Text="ROL:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="ReorderLevel" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label9" runat="server" Text="Disc.:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="Discontinued" runat="server"
                            Text="&nbsp;(discontinued if checked)"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Add" runat="server" Text="Add" height="33px" width="74px" OnClick="Add_Click" />&nbsp;&nbsp;
                        <asp:Button ID="Update" runat="server" Text="Update" height="33px" width="74px" OnClick="Update_Click"/>&nbsp;&nbsp;
                        <asp:Button ID="Disc" runat="server" Text="Disc." height="33px" width="74px" 
                             CausesValidation="false" OnClick="Disc_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <%--ObjectDataSources--%>
    <asp:ObjectDataSource ID="ProductListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Product_GetByPartialProductName" 
        TypeName="NorthwindSystem.BLL.ProductController">

        <SelectParameters>
            <asp:ControlParameter ControlID="ProductArg" 
                PropertyName="Text" DefaultValue="dfgdgff" 
                Name="productname" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CategoryListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Category_ListAll" 
        TypeName="NorthwindSystem.BLL.CategoryController">

    </asp:ObjectDataSource>
</asp:Content>
