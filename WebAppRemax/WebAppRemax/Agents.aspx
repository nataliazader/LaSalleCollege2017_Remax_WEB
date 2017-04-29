<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agents.aspx.cs" Inherits="WebAppRemax.Agents" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content">
        <table style="width: 80%;">
        <tr>
            <td colspan="2"><h3 class="text-center">Find an Agent</h3></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="radGender" runat="server">
                    <asp:ListItem Value="f">Female</asp:ListItem>
                    <asp:ListItem Value="m">Male</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLanguages" runat="server" OnClick="btnLanguages_Click" Text="Languages" />
            </td>
            <td>
                <asp:CheckBoxList ID="cboLanguages" runat="server" RepeatColumns="6">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="text-right">
                <asp:Button ID="btnFind" runat="server" Text="Find" Width="100px" OnClick="btnFind_Click" />
            </td>
        </tr>
    </table>
        <asp:GridView ID="grvResult" runat="server"></asp:GridView>
        <asp:Label ID="lblWhere" runat="server" Text="Label"></asp:Label>
        <br />
</div>
</asp:Content>
