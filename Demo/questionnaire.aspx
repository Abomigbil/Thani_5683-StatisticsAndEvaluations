<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="questionnaire.aspx.cs" Inherits="Thani_5683.Demo.questionnaire" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
        User Name:<br />
        <asp:DropDownList ID="ddlVisitor" runat="server"></asp:DropDownList><br />
     
    </div>

    <h3>Travel by:</h3>
    <asp:CheckBoxList ID="chkTravelBy" runat="server" >
        <asp:ListItem Value="Car">Car</asp:ListItem>
        <asp:ListItem Value="Plane">Plane</asp:ListItem>
        <asp:ListItem Value="Train">Train</asp:ListItem>
    </asp:CheckBoxList>
    <h3>Travel with:</h3>
    <asp:CheckBoxList ID="chkTravelWith" runat="server">
        <asp:ListItem Value="Alone">Alone</asp:ListItem>
        <asp:ListItem Value="With Family">With Family</asp:ListItem>
        <asp:ListItem Value="With Frinde">With Frinde</asp:ListItem>
    </asp:CheckBoxList>
    <h3>Travel when:</h3>
    <asp:CheckBoxList ID="chkTravelWhen" runat="server">
        <asp:ListItem Value="Morning">Morning</asp:ListItem>
        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
        <asp:ListItem Value="Evening">Evening</asp:ListItem>
    </asp:CheckBoxList>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
    <asp:GridView ID="gvQuestionnaire" runat="server" Width="577px" ></asp:GridView>
</asp:Content>
