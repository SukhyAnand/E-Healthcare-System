<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DMS.Admin.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset>
<legend>Global Document list</legend>
<table>
<tr><td>

    <asp:GridView ID="grdDashboard" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
        CellSpacing="1" GridLines="None" 
        onpageindexchanging="grdGlobalList_PageIndexChanging" PageSize="5">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="User Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="IsLockedOut" HeaderText="IsLocked" />
            <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
            <asp:TemplateField HeaderText="Delete User">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        CommandArgument='<%# Eval("UserName") %>' Height="30px" 
                        ImageUrl="~/Admin/Images/Deletedms.png" onclick="ImageButton1_Click" 
                        Width="30px" />
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
     <br />
            <div style="color: Gray; font-weight: bold" />
            <i>You are viewing page
                <%=grdDashboard.PageIndex + 1%>
                of
                <%=grdDashboard.PageCount%>
            </i>
</td></tr>
</table>
</fieldset>
<fieldset>
<legend>Uploaded Document Dashboard</legend>
    <asp:Chart ID="Chart1" runat="server" Palette="Chocolate">
        <Series>
            <asp:Series Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas >
            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</fieldset>
</asp:Content>
