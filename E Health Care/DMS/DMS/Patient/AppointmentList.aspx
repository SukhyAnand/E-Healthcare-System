<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppointmentList.aspx.cs" Inherits="DMS.Patient.AppointmentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset style="width:150px">
        <legend>Appointment Listing</legend>
        <div style="width:95%;overflow-x:scroll">
            <asp:GridView  ID="gvAppoList" Visible="true" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Patient_NameM" HeaderText="Patient Name" />
                    <asp:BoundField DataField="Patient_GenderM" HeaderText="Gender" />
                    <asp:BoundField DataField="Patient_AgeM" HeaderText="Age" />
                    <asp:BoundField DataField="Patient_CountryM" HeaderText="Country" />
                    <asp:BoundField DataField="Patient_StateM" HeaderText="State" />
                    <asp:BoundField DataField="Patient_HospitalM" HeaderText="Hospitals" />
                    <asp:BoundField DataField="Doc_NameM" HeaderText="Doctors's Name" />
                    <asp:BoundField DataField="Appo_DateM" HeaderText="Appointment Date" />
                    <asp:TemplateField HeaderText="Disease Details">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" TextMode="MultiLine" Enabled="false" runat="server" Text='<%# Eval("Patient_DiseaseM") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Medical History">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox2" TextMode="MultiLine" Enabled="false" runat="server" Text='<%# Eval("Patient_ReportM") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IsConfirmM" HeaderText="Is Confirm By Doctor" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("Patient_IdM") %>' OnClick="btnDelete_Click" Text="Delete" />
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
        </div>
    </fieldset>

</asp:Content>
