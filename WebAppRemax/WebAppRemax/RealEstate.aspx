<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RealEstate.aspx.cs" Inherits="WebAppRemax.RealEstate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content">
        <table style="width: 80%;">
                <tr>
                    <td colspan="4"><h3 class="text-center">Find a real estate</h3></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblBuilding" runat="server" Text="Building Type"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlBuilding" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblProperty" runat="server" Text="Property Type"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProperty" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblBedrooms" runat="server" Text="Number of Bedrooms"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlBedroom" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblParking" runat="server" Text="Number of parking"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlParking" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="cboPool" runat="server" Text="Pool" />
                    </td>
                    <td>
                        <asp:CheckBox ID="cboWaterFront" runat="server" Text="Waterfront" />
                    </td>
                    <td>
                        <asp:CheckBox ID="cboElevator" runat="server" Text="Elevator" />
                    </td>
                    <td>
                        <asp:CheckBox ID="cboMobility" runat="server" Text="Reduced Mobility" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLowerPrice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLowerPrice_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUpperPrice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUpperPrice_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNetArea" runat="server" Text="Net Area"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLowerNetArea" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlUpperNetArea" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                     
                        <asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>
                     
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLowerYear" runat="server" OnSelectedIndexChanged="ddlYearLower_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlUpperYear" runat="server" OnSelectedIndexChanged="ddlYearUpper_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                     
                        <asp:Label ID="lblKeyWords" runat="server" Text="Key words"></asp:Label>
                     
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeyWords" runat="server" Width="327px"></asp:TextBox>
                    </td>
                    <td colspan="2" class="text-right">
                        <asp:Button ID="btnFind" runat="server" Text="Find" Width="100px" OnClick="btnFind_Click" />
                    </td>
                </tr>
            </table>
                    <asp:GridView ID="grvResult" runat="server">
                    </asp:GridView>
        <div class="row">
            <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>

         </div>     
    </div>

</asp:Content>
