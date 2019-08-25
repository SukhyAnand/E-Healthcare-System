<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReviewListing.aspx.cs" Inherits="DMS.ReviewListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>User's Review List</legend>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvReviewList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <Columns>
                            <asp:BoundField DataField="Raised_ByUsernameM" HeaderText="Review Raised By User" />
                            <asp:BoundField DataField="Raised_ByM" HeaderText="Reviewer User Id" />
                            <asp:BoundField DataField="Review_DateM" HeaderText="Posted Date" />
                            <asp:BoundField DataField="RatingM" HeaderText="Rating" />
                            <asp:TemplateField HeaderText="Review Comment">
                                <ItemTemplate>
                                    <asp:TextBox Enabled="false" ID="TextBox1" TextMode="MultiLine" runat="server" Text='<%# Eval("Review_TextM") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
