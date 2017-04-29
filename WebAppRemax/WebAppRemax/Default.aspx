<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppRemax._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Image ID="imgHouse" runat="server" ImageUrl="~/Images/Site/real-estate.jpg" Width="100%" />
 <div class="container body-content">
    <div class="row">
        <asp:Label ID="lblHouses" runat="server"></asp:Label>
    </div>
</div>
</asp:Content>
