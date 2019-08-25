<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GlobalDocList.aspx.cs" Inherits="DMS.User.GlobalDocList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table width="100%">
    <tr><th align="center" style="background-color:Silver">:: Global Document List ::</th></tr>
    <tr><td align="center">
    <asp:GridView ID="grdGlobalList" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" GridLines="None"  AllowPaging="True" AllowSorting="True" PageSize="5"
            onpageindexchanging="grdGlobalList_PageIndexChanging"  >
            <Columns>
                <asp:BoundField DataField="ContentName" HeaderText="Content Name"  />
                <asp:BoundField DataField="ContentType" HeaderText="Content Type"  />
                <asp:BoundField DataField="FullName" HeaderText="Upload User"  />
                <asp:BoundField DataField="UploadTimeStamp" HeaderText="Uploaded Date"   />
                <asp:BoundField DataField="UserDept" HeaderText="Department" />
                <asp:BoundField DataField="UserUniRoll" HeaderText="University Roll" />
                <asp:BoundField DataField="IsPermitted" HeaderText="IsPermitted" />
                <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgView" runat="server" 
                            CommandArgument='<%# Eval("ContentId") %>' Height="30px" 
                            ImageUrl="~/User/Images/view1.png" OnClick="imgView_Click" Width="30px" />
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DownLoad" ItemStyle-HorizontalAlign="Center" >
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDownload" runat="server" 
                            CommandArgument='<%# Eval("ContentId") %>' Height="30px" 
                            ImageUrl="~/User/Images/download3.png" Visible='<%# Eval("IsPermitted") %>' OnClick="imgDownload_Click" 
                            Width="30px" />
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
    <div style="color: Gray; font-weight: bold">
            <br />
            <i>You are viewing page
                <%=grdGlobalList.PageIndex + 1%>
                of
                <%=grdGlobalList.PageCount%>
            </i>
</div> 
    </td></tr>
    
    </table>
</asp:Content>
