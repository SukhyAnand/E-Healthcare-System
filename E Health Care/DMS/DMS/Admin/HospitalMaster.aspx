<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HospitalMaster.aspx.cs" Inherits="DMS.Admin.Images.HospitalMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Hospitals Details</legend>
        <table>
            <tr>
                <td colspan="3" align="center">
                    <asp:GridView ID="gvHospitals" DataKeyNames="hosid" runat="server" AutoGenerateColumns="False" OnRowEditing="EditCustomer" OnRowDataBound="RowDataBound" OnRowUpdating="UpdateCustomer" OnRowDeleting="OnRowDeleting" OnRowCancelingEdit="CancelEdit" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <%--<asp:BoundField DataField = "hosname" HeaderText = "Hospital Name" />--%>
                <asp:TemplateField HeaderText="Hospital Name">
                    <ItemTemplate>
                        <asp:Label ID="lblHospitalName" runat="server" Text='<%# Eval("hosname")%>'></asp:Label>
                          <asp:Label ID="lblId" runat="server" Text='<%# Eval("hosid")%>' Visible="false"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("hosname")%>' Visible="false"></asp:Label>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hospital State">
                    <ItemTemplate>
                        <asp:Label ID="lblHospital" runat="server" Text='<%# Eval("hosstate")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text='<%# Eval("hosstate")%>' Visible="false"></asp:Label>
                        <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            <asp:ListItem>WB</asp:ListItem>
                            <asp:ListItem>CHENNAI</asp:ListItem>
                            <asp:ListItem>UP</asp:ListItem>
                            <asp:ListItem>MAHARASTHRA</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="hoscountry" HeaderText="Country" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
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
            <tr>
                <td>
                     <div style="vertical-align:middle">
                    <asp:Label ID="lbl1" runat="server" Text="Name :"></asp:Label>
                         </div>
                    <asp:TextBox ID="txtHosName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <div style="vertical-align:middle">
                    <asp:Label ID="lbl2" runat="server" Text="State :"></asp:Label>
                        </div>
                    <asp:DropDownList ID="ddlHosState" runat="server" >
                        <asp:ListItem>WB</asp:ListItem>
                        <asp:ListItem>CHENNAI</asp:ListItem>
                        <asp:ListItem>UP</asp:ListItem>
                        <asp:ListItem>MAHARASTHRA</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                     <div style="vertical-align:middle">
                    <asp:Label ID="lbl3" runat="server" Text="Country :"></asp:Label>
                    </div>
                    <asp:DropDownList ID="ddlCountry" runat="server" Enabled="false" >
                        <asp:ListItem Selected="True">INDIA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="Add Hospital" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>
        
    </fieldset>
</asp:Content>
