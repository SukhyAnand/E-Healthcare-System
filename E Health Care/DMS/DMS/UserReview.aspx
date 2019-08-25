<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserReview.aspx.cs" Inherits="DMS.Account.UserReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>User Review</legend>
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Provide Rating [ 1 <- Bad -(5)- Good -> 10] :</td>
                <td>
                    <asp:DropDownList ID="drpRating" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Comment :</td>
                <td>
                    <asp:TextBox ID="txtComment" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnreset" runat="server" Text="Reset" OnClick="btnreset_Click" /></td>
                <td>
                    <asp:Button ID="btnReview" runat="server" Text="Submit Review" OnClick="btnReview_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
