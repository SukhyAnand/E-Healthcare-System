<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorMaster.aspx.cs" Inherits="DMS.Admin.DoctorMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend> Doctor's Details </legend>
        <table>
             <tr>
                <td>Choose UserName :</td>
                <td>
                    <asp:DropDownList ID="ddlDocUser" runat="server"></asp:DropDownList>
                    <asp:HiddenField ID="HidDocId" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Doctors Name:</td>
                <td>
                  <asp:TextBox ID="txtDocname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Doctors License:</td>
                <td>
                  <asp:TextBox ID="txtLicense" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Doctors License Expiration Date (dd/MM/yyyy):</td>
                <td>
                  <asp:TextBox ID="txtExpdate" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>Doctor's OnSite Fees (In Indian Rupees) :</td>
                <td>
                  <asp:TextBox ID="txtOnSiteFee" runat="server"></asp:TextBox>/ Visit
                </td>
            </tr>
             <tr>
                <td>Doctor's Home Visit Fees (In Indian Rupees) :</td>
                <td>
                  <asp:TextBox ID="txtHomeFee" runat="server"></asp:TextBox>/ Visit
                </td>
            </tr>
            <tr>
               <td>Doctor's Specialization:</td>
                <td>
                    <asp:DropDownList ID="ddlSpecial" runat="server">
                        <asp:ListItem>E.N.T</asp:ListItem>
                        <asp:ListItem>Medicine</asp:ListItem>
                        <asp:ListItem>Surgen</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Doctor's More Info:</td>
                <td>
                  <asp:TextBox ID="txtDocDetails" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Country:</td>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" Enabled="false">
                        <asp:ListItem>INDIA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Country:</td>
                <td>
                   <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" >
                            <asp:ListItem Selected="True">-- Select State --</asp:ListItem>
                            <asp:ListItem>WB</asp:ListItem>
                            <asp:ListItem>CHENNAI</asp:ListItem>
                            <asp:ListItem>UP</asp:ListItem>
                            <asp:ListItem>MAHARASTHRA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>Choose Hospitals:</td>
                <td>
                    <asp:ListBox ID="lstHospital" SelectionMode="Multiple" runat="server">
                        <asp:ListItem>-- Select Hospital --</asp:ListItem>
                    </asp:ListBox>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" /></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Doctors List</legend>
       <table>
           <tr>
               <td>
                   <asp:GridView ID="gvDoctors" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                       <Columns>
                           <asp:BoundField DataField="Doc_NameM" HeaderText="Doctor Name" />
                           <asp:BoundField DataField="Doc_CountryM" HeaderText="Country" />
                           <asp:BoundField DataField="Doc_StateM" HeaderText="State" />
                           <asp:BoundField DataField="Doc_HospitalM" HeaderText="Hospitals" />
                           <asp:BoundField DataField="Doc_SpecialistM" HeaderText="Specialization" />
                           <asp:BoundField DataField="Doc_RegIdM" HeaderText="Registration No." />
                           <asp:BoundField DataField="Doc_ExpM" HeaderText="Reg. Expiration date" />
                           <asp:TemplateField HeaderText="Edit Profile">
                               <ItemTemplate>
                                   <asp:Button ID="btnEdit" runat="server" CommandArgument='<%# Eval("Doc_IdM") %>' OnClick="btnEdit_Click" Text="Edit" />
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Delete Profile">
                               <ItemTemplate>
                                   <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("Doc_IdM") %>' OnClick="btnDelete_Click" Text="Delete" />
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
