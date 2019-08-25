<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="DMS.Admin.UserDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>User Dashboard</legend>
        <asp:GridView ID="grdUserDetails" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>
                <asp:BoundField HeaderText="User name" DataField="username" />
                <asp:BoundField DataField="role" HeaderText="Role" />
                <asp:BoundField HeaderText="Gender" DataField="gender" />
                <asp:BoundField HeaderText="Country" DataField="country" />
                <asp:BoundField HeaderText="Phone" DataField="mobile" />
                <asp:BoundField HeaderText="Email" DataField="email" />
                <asp:TemplateField HeaderText="Is Active">
                    <ItemTemplate>
                        <asp:Label ID="lblActive" runat="server" Text='<%# Convert.ToBoolean(Eval("IsActive"))==true?"Yes" : "No" %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Activator">
                    <ItemTemplate>
                       
                         <asp:Button ID="btnActivate"  runat="server" Text="Activate" CommandArgument='<%# Eval("username") %>' OnClick="btnActivate_Click" Visible='<%# Convert.ToBoolean(Eval("IsActive"))==true?false : true %>' />
                   
                         <asp:Button ID="btnDeactivate" runat="server" Text="De Activate"  CommandArgument='<%# Eval("username") %>' OnClick="btnDeactivate_Click" Visible='<%# Convert.ToBoolean(Eval("IsActive"))==true?true : false %>' />
                        
                       
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
    </fieldset>
</asp:Content>
