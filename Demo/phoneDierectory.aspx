<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="phoneDierectory.aspx.cs" Inherits="Thani_5683.Demo.phoneDierectory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div>
          <br />
        <br />
          </div>
    welcom to my phone Dirctory <br />
    <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="False" DataKeyNames="contactID,Expr1" Width="918px" 
        >
        <Columns>
            <asp:BoundField DataField="contactID" HeaderText="contactID" ReadOnly="True" SortExpression="contactID" />
            <asp:BoundField DataField="fName" HeaderText="fName" SortExpression="fName" />
            <asp:BoundField DataField="lName" HeaderText="lName" SortExpression="lName" />
            <asp:BoundField DataField="cell" HeaderText="cell" SortExpression="cell" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
            
        </Columns>
</asp:GridView>
</asp:Content>
