<%@ Page Title="Hello World" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" 
    Inherits="WebApp.HelloWorld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Hello World</h1>
    <div class="row">
        <div class="col-md-offset-1">
            <asp:Label ID="Label1" runat="server" 
                Text="Enter your name:" Font-Bold="True"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="NameArg" runat="server" 
                ></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="PressMe" runat="server" Text="Press Me" 
                CssClass="btn btn-primary" OnClick="PressMe_Click"  />

            <br /><br />
            <asp:Label ID="OutputArea" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
