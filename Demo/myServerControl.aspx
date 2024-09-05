<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="myServerControl.aspx.cs"
    Inherits="Thani_5683.Demo.myServerControl" EnableEventValidation="false" ValidateRequest="false"
%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <table class="nav-justified">
            <tr>
                <td colspan="2" style="height: 20px">
                    <asp:Label ID="lblOutput" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-right" style="color: #FF0000"><strong>Contact ID</strong></td>
                <td>
                    <asp:TextBox ID="txtContactID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-right" style="color: #FF0000"><strong>First Name</strong></td>
                <td>
                    <asp:TextBox ID="txtfName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-right" style="font-weight: bold; color: #FF0000">Last Name</td>
                <td>
                    <asp:TextBox ID="txtlName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-right" style="font-weight: bold; color: #FF0000">Cell Phone</td>
                <td>
                    <asp:TextBox ID="txtCell" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-right" style="font-weight: bold; color: #FF0000">Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-right" style="font-weight: bold; color: #FF0000">Country ID</td>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                    <asp:Button ID="btnShowContactInf" runat="server" OnClick="btnShowContactInf_Click" Text="ShowContactInf" />
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update"
                         OnClientClick ="return confirm ('Are you sure To update')"/>
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete"
                        OnClientClick ="return confirm ('Are you sure To delete') "/>
                    <asp:Button ID="btnExportExcel" runat="server" OnClick="btnExportExcel_Click" 
                        Text="Export TO Excel" />
                    <%--<asp:Button ID="btnExportGoogleDrive" runat="server" OnClick="btnExportGoogleDrive_Click" 
                        Text="Export TO Google drive" />--%>
                </td>
            </tr>
        </table>
        <br />
    </p>
    <div>
        <asp:GridView ID="gvContact" runat="server" Width="1000px"></asp:GridView>
    </div>

    
</asp:Content>

