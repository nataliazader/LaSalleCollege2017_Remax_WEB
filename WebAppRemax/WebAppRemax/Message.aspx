<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="WebAppRemax.Message" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content" style='margin-top:20px'>
        <asp:Panel ID="PanelMessage" runat="server">
            <asp:Label ID="lblAgent" runat="server" Text="Label"></asp:Label>
            <table style="width:500px;margin:auto">
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtMessage" runat="server" Height="100px" Width="400px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="280px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" TextMode="Number" Width="280px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Width="280px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSend" runat="server" style="margin-top:20px" Text="Send" Width="100px" OnClick="btnSend_Click" />
                    </td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
