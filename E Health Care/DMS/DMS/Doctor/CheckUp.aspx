<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckUp.aspx.cs" Inherits="DMS.Doctor.CheckUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .auto-style1 {
        height: 56px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>
            Treatment Details
        </legend>
        <table>
            <tr>
                <td>
                    Patient Full Name :
                </td>
                <td>
                    <asp:TextBox ID="txtPatName" runat="server" Width="198px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Patient Age :
                </td>
                <td>
                    <asp:TextBox ID="txtPatAge" runat="server" Width="194px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Patient Gender :
                </td>
                <td>
                    <asp:TextBox ID="txtPatGender" runat="server" Width="193px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Patient Details :
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPatDetails" TextMode="MultiLine" runat="server" Height="46px" Width="211px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Patient History :
                </td>
                <td>
                    <asp:TextBox ID="txtPatHistory" TextMode="MultiLine" runat="server" Height="46px" Width="213px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Report Upload :
                </td>
                <td>
                    <asp:FileUpload ID="ReportUpload" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Doctor's Prescription :
                </td>
                <td>
                    <asp:TextBox ID="txtPrescription" TextMode="MultiLine" runat="server" Height="143px" Width="229px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnReset" runat="server" Text="Reset" />
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit Prescription" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </fieldset>

</asp:Content>
