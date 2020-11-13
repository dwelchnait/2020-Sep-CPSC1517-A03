<%@ Page Title="Test Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="WebApp.SamplePages.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Test Page</h1>
    <blockquote>Sample of how you could possible setup your project default page</blockquote>
    <div class="row">
        <div class="col-7">
            <%-- ERD diagram --%>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/EmployeeERD.png" />
        </div>
        <div class="col-5">
            <%-- Project description --%>
        </div>

    </div>
        <div class="row">
        <div class="col-7">
            <%-- class diagram --%>
        </div>
        <div class="col-5">
            <%-- Known Bugs  --%>
            <%-- Sql procedures --%>
            <h3>Sql Procedures</h3>
            <ul>
                <li>akdfkjadna;</li>
            </ul>
        </div>

    </div>
</asp:Content>
