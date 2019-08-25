<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UploadDoc.aspx.cs" Inherits="DMS.UploadDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .textEntry
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr>
            <th colspan="2" align="center" style="background-color: Silver">
                :: Document Upload Panel ::
            </th>
        </tr>
        <tr>
            <td>
                <table style="background-color: ThreeDLighShadow">
                    <tr>
                        <td>
                            <asp:Label ID="lbl1" runat="server">Document Name:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="textEntry" ID="txtDocName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server">Document Type :</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpDocType" runat="server">
                                <asp:ListItem>Document</asp:ListItem>
                                <asp:ListItem>Media</asp:ListItem>
                                <asp:ListItem>Text</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server">Document Details :</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="textEntry" ID="txtDocDetails" runat="server" Height="51px"
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server">File upload :</asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload Width="100%" ID="DocFileUpload" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server">Share with :</asp:Label>
                        </td>
                        <td>
                            <asp:ListBox ID="lstUser" runat="server" Width="110px" SelectionMode="Multiple">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        
                        <td colspan="2">
                            <table>
                                <tr>
                                    <td>
                                        <fieldset class="register">
                                            <legend>User Information</legend>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server">Your Name:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="textEntry" ID="txtUserName" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server">Your Stream/Department :</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpDept" runat="server">
                                                            <asp:ListItem>IT</asp:ListItem>
                                                            <asp:ListItem>ECE</asp:ListItem>
                                                            <asp:ListItem>Comp. Sc.</asp:ListItem>
                                                            <asp:ListItem>EE</asp:ListItem>
                                                            <asp:ListItem>EI</asp:ListItem>
                                                            <asp:ListItem>Mech. Sc.</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server">Your University Roll :</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="textEntry" ID="txtUniRoll" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <p class="submitButton">
                                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" /></p>
                        </td>
                        <td>
                            <p class="submitButton">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click1" /></p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:HiddenField ID="hidContentId" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <img src="Images/DocEntry.jpg" width="200px" height="200px" />
            </td>
        </tr>
    </table>
</asp:Content>
