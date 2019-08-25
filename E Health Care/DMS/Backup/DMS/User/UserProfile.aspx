<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="DMS.User.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table width="100%">
<tr><th colspan="2" align="center" style="background-color:Silver">:: User Profile ::</th></tr>
<tr><td colspan="2">
<ul style="color:Red">
<li>Name should be same as college register or known by all</li>
<li>University Roll number should be correct.It will check by Admin.</li>
<li>Enter your Stream/Department correctly.</li>
</ul>
</td></tr>
<tr><td>
<fieldset class="register">
                            <legend>User Information</legend>
                            <table>
                            <tr><td> <asp:Label ID="lbl1" runat="server" >Your Name:</asp:Label></td>
                            <td> <asp:TextBox  CssClass="textEntry" ID="txtUserName" runat="server"></asp:TextBox></td></tr>
                            <tr><td> <asp:Label ID="Label1" runat="server" >Your Stream/Department :</asp:Label></td>
                            <td> 
                                <asp:DropDownList ID="drpDept" runat="server">
                                    <asp:ListItem>IT</asp:ListItem>
                                    <asp:ListItem>ECE</asp:ListItem>
                                    <asp:ListItem>Comp. Sc.</asp:ListItem>
                                    <asp:ListItem>EE</asp:ListItem>
                                    <asp:ListItem>EI</asp:ListItem>
                                    <asp:ListItem>Mech. Sc.</asp:ListItem>
                                </asp:DropDownList>
                                </td></tr>
                                <tr>
                                <td><asp:Label ID="Label2" runat="server" >Your University Roll :</asp:Label></td>
                                <td>
                                    <asp:TextBox  CssClass="textEntry" ID="txtUniRoll" runat="server"></asp:TextBox>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                    <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                                        Text="Update" />
                                    </td><td>
                                        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                                            Text="Submit" />
                                    </td>
                                </tr>
                            </table>

</fieldset>
</td>
<td></td>
</tr>
</table>
</asp:Content>
