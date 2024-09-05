<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Rating.aspx.cs" Inherits="Thani_5683.Demo.Raiting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
    </div>
        
    <br /><br />
    <div>
        <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    </div>
    <div>
        User Name:<br />
        <asp:DropDownList ID="ddlVisitor" runat="server"></asp:DropDownList><br />
        City Name:<br />
        <asp:DropDownList ID="ddlHotel" runat="server"></asp:DropDownList>
    </div>
    <div>
            <asp:Repeater ID="repeaterRating" runat="server">
    <HeaderTemplate>
        <table>
            <th style="width:200px; background-color:lightgray; text-align:center">City Rating Criteria</th>
            <th style="width:200px; background-color:lightgray; text-align:left">City Rating</th>
        </table>
    </HeaderTemplate>
    <ItemTemplate>
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdnCityRatingCID" runat="server" Value='<%# Eval("cityRatingCID") %>' />
                </td>
                <td style="width:200px; background-color:lightgray; text-align:center">  
                    <asp:Label ID="lblCityRatingC" runat="server" Text='<%# Eval("cityRatingC") %>' />
                </td>
                <td style="width:200px; background-color:lightgray; text-align:center">
                    <asp:RadioButtonList ID="rblcityRatingCriteriaPoint" runat="server" RepeatDirection="Horizontal" CellSpacing="2">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:Repeater>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnClearn" runat="server" OnClick="btnClearn_Click" Text="Clear" />
            <asp:Button ID="btnGetExistingRating" runat="server" Text="Get Existing Rating" OnClick="btnGetExistingRating_Click" /> 
            <br />
            <br />
    </div>
    <asp:GridView ID="gvRating" runat="server" AutoGenerateColumns="false" 
            OnSelectedIndexChanged="gvRating_SelectedIndexChanged" Height="174px" Width="770px">
    <Columns>
        <asp:BoundField DataField="visitorName" HeaderText="Visitor Name" />
        <asp:BoundField DataField="city" HeaderText="City" />
        <asp:BoundField DataField="cityRatingC" HeaderText="Rating Criteria" />
        <asp:BoundField DataField="cityRatingCriteriaPoint" HeaderText="Rating Point" />
    </Columns>
</asp:GridView>
</asp:Content>
