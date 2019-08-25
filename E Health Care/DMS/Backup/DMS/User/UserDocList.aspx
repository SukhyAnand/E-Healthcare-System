<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDocList.aspx.cs" Inherits="DMS.User.UserDocList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table width="100%">
<tr><th colspan="2" align="center" style="background-color:Silver">:: My Document List ::</th></tr>
<tr><td align="center">
        
        <asp:GridView ID="grdUserList" runat="server" 
       AutoGenerateColumns="False" BorderStyle="None" 
            CellPadding="3" CellSpacing="1" GridLines="None"  AllowPaging="True" 
                AllowSorting="True" PageSize="5"
            onpageindexchanging="grdGlobalList_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="ContentName" HeaderText="Content Name" />
                <asp:BoundField DataField="ContentType" HeaderText="Content Type" />
                <asp:BoundField DataField="FullName" HeaderText="User Name" />
                <asp:BoundField DataField="UploadTimeStamp" HeaderText="Uploaded Date" />
                <asp:BoundField DataField="UserDept" HeaderText="Department" />
                <asp:BoundField DataField="UserUniRoll" HeaderText="University Roll" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("ContentId") %>' Height="30px" 
                            ImageUrl="~/User/Images/edit-dms.png" OnClick="ImageButton1_Click" 
                            Width="30px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            CommandArgument='<%# Eval("ContentId") %>' Height="30px" 
                            ImageUrl="~/User/Images/Deletedms.png" OnClick="ImageButton2_Click" 
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
            <div style="color: Gray; font-weight: bold">
            <i>You are viewing page
                <%=grdUserList.PageIndex + 1%>
                of
                <%=grdUserList.PageCount%>
            </i>
</div>

</td></tr>
</table>
</asp:Content>
