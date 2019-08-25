<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicineMaster.aspx.cs" Inherits="DMS.Admin.MedicineMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Medicine Details</legend>
        <table>
            <tr>
                <td>
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="Med_Id"  OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added." BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Med_Name" HeaderText="Medicine Name" ItemStyle-Width="150" SortExpression="Med_Name" >
<ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField  ItemStyle-HorizontalAlign="Center" DataField="Med_Disease" HeaderText="Required For Disease" ItemStyle-Width="150" SortExpression="Med_Disease" >
<ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                            ItemStyle-Width="100" >
<ItemStyle Width="100px"></ItemStyle>
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                    <tr>
                        <td style="width: 150px">Medicine Name:<br />
                            <asp:TextBox ID="txtMed_Name" runat="server" Width="140" />
                        </td>
                        <td style="width: 150px">Required For :<br />
                            <asp:TextBox ID="txtMed_Disease" runat="server" Width="140" />
                        </td>
                        <td style="width: 100px">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />
                        </td>
                    </tr>
                </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EHealthCareConnectionString %>"
                    SelectCommand="SELECT Med_Name, Med_Disease,Med_Id FROM MedicineDetails"
                    InsertCommand="INSERT INTO MedicineDetails( Med_Name, Med_Disease) VALUES (@Med_Name, @Med_Disease)"
                    UpdateCommand="UPDATE MedicineDetails SET Med_Name = @Med_Name, Med_Disease = @Med_Disease WHERE Med_Id = @Med_Id"
                    DeleteCommand="DELETE FROM MedicineDetails WHERE Med_Id = @Med_Id">
                    <InsertParameters>
                        <asp:ControlParameter Name="Med_Name" ControlID="txtMed_Name" Type="String" />
                        <asp:ControlParameter Name="Med_Disease" ControlID="txtMed_Disease" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Med_Id" Type="Int32" />
                        <asp:Parameter Name="Med_Name" Type="String" />
                        <asp:Parameter Name="Med_Disease" Type="String" />
                    </UpdateParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="Med_Id" Type="Int32" />
                    </DeleteParameters>
                </asp:SqlDataSource>

                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
