<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorsBooking.aspx.cs" Inherits="DMS.Patient.DoctorsBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type = "text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=gvDoctorDet.ClientID%>");
         var rbs = gv.getElementsByTagName("input");

         var row = rb.parentNode.parentNode;
         for (var i = 0; i < rbs.length; i++) {
             if (rbs[i].type == "radio") {
                 if (rbs[i].checked && rbs[i] != rb) {
                     rbs[i].checked = false;
                     break;
                 }
             }
         }
     }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Doctor Booking</legend>
        <table>
            <tr>
                <td>Patient's Full Name:</td>
                <td>
                    <asp:TextBox ID="txtPatFullName" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>Patient's Age:</td>
                <td>
                    <asp:TextBox ID="txtPatAge" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Patient's Gender:</td>
                <td>
                                  <asp:DropDownList ID="drpGender" runat="server" CssClass="textEntry" Width="323px" >
                                      <asp:ListItem>Male</asp:ListItem>
                                      <asp:ListItem>Female</asp:ListItem>
                                  </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Patient's Full Address:</td>
                <td>
                    <asp:TextBox ID="txtPatAdd" TextMode="MultiLine" runat="server"></asp:TextBox>
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
                <td>State:</td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
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
                    <asp:DropDownList ID="lstHospital" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstHospital_SelectedIndexChanged">
                        <asp:ListItem>-- Select Hospital --</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td>Choose Sprcialist for You :</td>
                <td>
                    <asp:DropDownList ID="ddlSpecial" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSpecial_SelectedIndexChanged">
                        <asp:ListItem>E.N.T</asp:ListItem>
                        <asp:ListItem>Medicine</asp:ListItem>
                        <asp:ListItem>Surgen</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td colspan="2" style="float: initial" align="center">

                    <asp:GridView ID="gvDoctorDet" ShowHeader="true" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButton1" runat="server"
                                        onclick="RadioCheck(this);" />
                                    <asp:HiddenField ID="HiddenField1" runat="server"
                                        Value='<%#Eval("Doc_IdM")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Doc_NameM" HeaderText="Dr. Name" />
                            <asp:BoundField DataField="Doc_SpecialistM" HeaderText="Specialist" />
                            <asp:BoundField DataField="Doc_OnSite_FeeM" HeaderText="OnSite Fees" />
                            <asp:BoundField DataField="Doc_Home_FeeM" HeaderText="AtHome Fees" />
                            
                            <asp:TemplateField HeaderText="Doctor's Info">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox1" Enabled="false" TextMode="MultiLine" runat="server" Text='<%# Eval("Doc_DetailsM") %>'></asp:TextBox>
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
                </td>
            </tr>
            <tr>
                <td>
                    Provide Your disease Details :
                </td>
                <td>
                    <asp:TextBox ID="txtDisease" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                   Select Appointment Date:
                </td>
                <td>
                    <asp:TextBox ID="txtAppDate" runat="server" TextMode="SingleLine"></asp:TextBox>
                    (dd/MM/yyyy)</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnReset" runat="server" Text="Cancel" />  
                </td>
                <td>
                    <asp:Button ID="btnAppointment" runat="server" Text="Get Appointment" OnClick="btnAppointment_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
