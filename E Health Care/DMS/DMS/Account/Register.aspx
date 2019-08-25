<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeBehind="Register.aspx.cs" Inherits="DMS.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .textEntry {}
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
        
                    <h2>
                        Create a New / UPdate Account
                    </h2>
                    <p>
                        Use the form below to create a new / update account.
                    </p>
                   
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                    <div class="accountInfo">
                        <fieldset class="register">
                           
                            <legend>Account Information</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <br />
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" ></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                     CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                  <asp:Label ID="Mobile" runat="server" AssociatedControlID="MobilePIN">Mobile No:</asp:Label>
                            <asp:TextBox ID="MobilePIN" runat="server" CssClass="textEntry" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="MobilePIN" 
                                 CssClass="failureNotification" ErrorMessage="Mobile is required." ToolTip="Mobile is required." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                          
                             <p>
                                  <asp:Label ID="Gender" runat="server" AssociatedControlID="drpGender">Gender:</asp:Label>
                                  <asp:DropDownList ID="drpGender" runat="server" CssClass="textEntry" Width="323px" >
                                      <asp:ListItem>Male</asp:ListItem>
                                      <asp:ListItem>Female</asp:ListItem>
                                  </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpGender" 
                                 CssClass="failureNotification" ErrorMessage="Select proper gender." ToolTip="Gender is required." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                  <asp:Label ID="Country" runat="server" AssociatedControlID="drpGender">Country:</asp:Label>
                                  <asp:DropDownList ID="drpCountry" CssClass="textEntry" runat="server" Width="323px" >
                                      <asp:ListItem>India</asp:ListItem>
                                      <asp:ListItem>Pakistan</asp:ListItem>
                                      <asp:ListItem>Bangladesh</asp:ListItem>
                                      <asp:ListItem>Srilanka</asp:ListItem>
                                  </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpCountry" 
                                 CssClass="failureNotification" ErrorMessage="Country is required." ToolTip="Country is required." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                  <asp:Label ID="Role" runat="server" AssociatedControlID="drpGender">User Role :</asp:Label>
                                  <asp:DropDownList ID="drpRole" CssClass="textEntry" runat="server" Width="323px" DataSourceID="SqlDataSource1" DataTextField="Role" DataValueField="Role_Id" >
                                  </asp:DropDownList>
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EHealthCareConnectionString %>" SelectCommand="SELECT [Role_Id], [Role] FROM [RoleDetails]"></asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpCountry" 
                                 CssClass="failureNotification" ErrorMessage="Country is required." ToolTip="Country is required." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                &nbsp;<asp:Panel ID="UpdPanel" runat="server">
                                    <div style="vertical-align:top">
                                  <asp:Label ID="Label1" runat="server" AssociatedControlID="drpGender">Current Uploaded Photo:</asp:Label>
                                        </div>
                                  <asp:Image ID="imgPhotoView" runat="server" Height="97px" Width="100px" />
                                </asp:Panel>
                            
                            </p>
                             <p>
                                  <asp:Label ID="Photo" runat="server" AssociatedControlID="drpGender">Upload Photo:</asp:Label>
                                  <asp:FileUpload ID="FilePhoto" runat="server" Width="323px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="FilePhoto" 
                                 CssClass="failureNotification" ErrorMessage="Select proper Photo." ToolTip="Photo is required." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" OnTextChanged="Password_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                            </p>
                        </fieldset>
                        <p class="submitButton">
                            <%--<asp:Button ID="UpdateUserButton" runat="server" Text="Update User" 
                                 ValidationGroup="RegisterUserValidationGroup" OnClick="UpdateUserButton_Click" />--%>
                            <asp:Button ID="CreateUserButton" runat="server"  Text="Create User" 
                                 ValidationGroup="RegisterUserValidationGroup" OnClick="CreateUserButton_Click"/>
                          
                        </p>
                          <asp:Button ID="UpdateUserButton" runat="server"    Text="Update User" OnClick="UpdateUserButton_Click" />
                    </div>
               
       
  
</asp:Content>
