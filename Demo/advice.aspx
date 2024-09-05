<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="advice.aspx.cs" Inherits="Thani_5683.Demo.advice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <span style="color: #0000CC"><strong><span style="font-size: large; background-color: #CCCCCC">Here, write your tips, comments, review, 
        or anything about the city you visited</span><br />
    </strong></span>
    <br />
    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    <strong><br />City</strong>  
    <asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList><br />
    <asp:TextBox ID="txtadvice" runat="server" TextMode="MultiLine"></asp:TextBox><br />
    
    <asp:Button ID="btnSave" runat="server" Text="Publish" OnClick="btnSave_Click" 
        OnClientClick ="return confirm ('Are you sure To publish') "/>
    <asp:Button ID="btnShowReview" runat="server" Text="Show Review" OnClick="btnShowReview_Click" />

    <br />
    <asp:GridView ID="gvadvice" runat="server" AutoGenerateColumns="False" DataKeyNames="adviceID">
        <Columns>
            <asp:BoundField DataField="adviceID" HeaderText="Advice ID" ReadOnly="True" SortExpression="adviceID" />
            <asp:TemplateField HeaderText="Advice" SortExpression="advice">
                <EditItemTemplate>
                    <asp:TextBox ID="txtadviceOr" runat="server" Text='<%# Bind("adviceOrNots") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbladvice" runat="server" Text='<%# Bind("adviceOrNots") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="city" HeaderText="City" ReadOnly="True" SortExpression="date" />
        </Columns>
    </asp:GridView>
    
</asp:Content>