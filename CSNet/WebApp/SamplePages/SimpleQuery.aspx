<%@ Page Title="Simple Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SimpleQuery.aspx.cs" Inherits="WebApp.SamplePages.SimpleQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class ="jumbotron">
            <h1>Simple Query</h1>
            <blockquote class="alert alert-info">This page will input a region number and display
                the record record matching the input value.
            </blockquote>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:Label ID="Label1" runat="server" 
                Text="Enter a region id:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="RegionArg" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="RegionSearch" runat="server" Text="Region ?" OnClick="RegionSearch_Click" />
        </div>
        <div class="col-6">
            <asp:Label ID="Label2" runat="server" 
                Text="Region:"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="RegionId" runat="server" ></asp:Label>
            <br /><br />
             <asp:Label ID="Label4" runat="server" 
                 Text="Description"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="RegionDescription" runat="server" ></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-12 text-center">
            <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        </div>
    </div>
</asp:Content>
