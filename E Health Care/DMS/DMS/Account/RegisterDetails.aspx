<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterDetails.aspx.cs" Inherits="DMS.Account.RegisterDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
                    <h2>
                        Your Account details
                    </h2>
                    <p>
                        Use the form below to create a new account.
                    </p>
                   
                  
                    <div class="accountInfo">
                        <fieldset class="register">
                           
                            <legend>Account Information</legend>
                            <p>
                                <asp:Label ID="ProfileView" runat="server" >Profile Image:</asp:Label>
                                <asp:Image ID="imgPhotoView" runat="server" Height="97px" Width="100px" />
                                
                            </p>
                            <p>
                                <asp:Label ID="UserNameLabelView" runat="server" >User Name:</asp:Label>
                                <asp:TextBox Enabled="false" ID="UserNameView" runat="server" CssClass="textEntry"></asp:TextBox>
                                
                            </p>
                            <p>
                                <asp:Label ID="EmailLabelView" runat="server" >E-mail:</asp:Label>
                                <asp:TextBox Enabled="false" ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                               
                            </p>
                            <p>
                                  <asp:Label ID="MobileView" runat="server" >Mobile No:</asp:Label>
                            <asp:TextBox Enabled="false" ID="MobilePINView" runat="server" CssClass="textEntry" ></asp:TextBox>
                            
                            </p>
                          
                             <p>
                                  <asp:Label ID="GenderView" runat="server">Gender:</asp:Label>
                                  <asp:DropDownList Enabled="false" ID="drpGenderView" runat="server" CssClass="textEntry" Width="323px" >
                                      <asp:ListItem>Male</asp:ListItem>
                                      <asp:ListItem>Female</asp:ListItem>
                                  </asp:DropDownList>
                            
                            </p>
                            <p>
                                  <asp:Label ID="CountryView" runat="server" >Country:</asp:Label>
                                  <asp:DropDownList Enabled="false" ID="drpCountryView" CssClass="textEntry" runat="server" Width="323px" >
                                      <asp:ListItem>India</asp:ListItem>
                                      <asp:ListItem>Pakistan</asp:ListItem>
                                      <asp:ListItem>Bangladesh</asp:ListItem>
                                      <asp:ListItem>Srilanka</asp:ListItem>
                                  </asp:DropDownList>
                           
                            </p>
                            <p>
                                  <asp:Label ID="RoleView" runat="server">User Role :</asp:Label>
                                  <asp:DropDownList Enabled="false" ID="drpRoleView" CssClass="textEntry" runat="server" Width="323px" DataSourceID="SqlDataSource1" DataTextField="Role" DataValueField="Role_Id" >
                                  </asp:DropDownList>
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EHealthCareConnectionString %>" SelectCommand="SELECT [Role_Id], [Role] FROM [RoleDetails]"></asp:SqlDataSource>
                          
                            </p>
                             
                            
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="UpdateButton" runat="server"  Text="Update User" OnClick="UpdateButton_Click" />
                        </p>
                    </div>
</asp:Content>
