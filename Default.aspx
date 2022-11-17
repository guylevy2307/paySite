<%@ Page Title="Home Page" Language="C#"   MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="paySite._Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="main-content">
        <section class="jumbotron">
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div align="center">
                                <h1>Payment Page</h1>
                            </div>

                        </header>
                        <div class="panel-body">
                            <h4 align="center">Amount</h4>
                       
                        <div class="row">
                            <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                <table>
                                    <tr>
                                        <th>
                                          
                                                <div class="col-md-4 col-md-offset-1">
                                                    <div class="form-group">
                                                        <asp:Label runat="server" AssociatedControlID="amountTxt"><b>Amount:</b></asp:Label><br />
                                                        <asp:TextBox runat="server"  required="required" TextMode="Number"  Enabled="True" name="amountTxt" ID="amountTxt" class="form-control input-sm" placeholder="Amount" Width="259px"></asp:TextBox>
                                                    </div>
                                                </div>
                                     
                                        </th>
                                   
                                        <th>
                                          
                                            <div class="col-md-4 col-md-offset-1" style="left: 0px; top: 0px; width: 225px">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ><b>Currency:</b></asp:Label><br />
                                                    <asp:DropDownList ID="currencyTxt" CssClass="form-control input-sm" runat="server">

                                                        <asp:ListItem Text="ILS" />
                                                        <asp:ListItem Text="USD" />
                                                        <asp:ListItem Text="ERU" />

                                                    </asp:DropDownList>
                                                </div>
                                             
                                            </div>
                                        </th>
                                    </tr>
                                </table>
                                </div>
                            </div>
                        </div>
                        
                         </div>

                        <div class="panel-body">
                        <h4 align="center">Credit Card Info:</h4>
                        </div>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="cardNumber"><b>Card Number:</b></asp:Label><br />
                                        <asp:TextBox runat="server"   required="required" Enabled="True" TextMode="Number" name="cardNumber" ID="cardNumber" class="form-control input-sm" placeholder="Card Number"></asp:TextBox>

                                    </div>
                                </div>

                            <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                    <asp:Label runat="server"><b>Expiration Date:</b></asp:Label><br />
                                    <table>
                                        <tr >

                                        <th>
                                            <asp:Label runat="server" ><b>Month:</b></asp:Label><br />
                                            <asp:DropDownList ID="monthList" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Text="01" />
                                                <asp:ListItem Text="02" />
                                                <asp:ListItem Text="03" />
                                                <asp:ListItem Text="04" />
                                                <asp:ListItem Text="05" />
                                                <asp:ListItem Text="06" />
                                                <asp:ListItem Text="07" />
                                                <asp:ListItem Text="08" />
                                                <asp:ListItem Text="09" />
                                                <asp:ListItem Text="10" />
                                                <asp:ListItem Text="11" />
                                                <asp:ListItem Text="12" />

                                            </asp:DropDownList>
                                        </th>
                                            
                                        <th>
                                            <asp:Label runat="server" ><b>Year:</b></asp:Label><br />
                                            <asp:DropDownList ID="yearList" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Text="2023" />
                                                <asp:ListItem Text="2024" />
                                                <asp:ListItem Text="2025" />
                                                <asp:ListItem Text="2026" />
                                            </asp:DropDownList>
                                        </th>
                                        </tr>
                                    </table>
                                  
                                </div>
                               
                            </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="csvNum"><b>CSV:</b></asp:Label><br />
                                        <asp:TextBox runat="server"  required="required" TextMode="Number" Enabled="True" name="csvNum" ID="csvNum"  class="form-control input-sm" placeholder="CSV"></asp:TextBox>
                                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "csvNum" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{3,4}$" runat="server" ErrorMessage="Minimum 3 Digit Or Max 4 Digit"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                            <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="fullName"><b>Card Holder Name</b></asp:Label><br />
                                        <asp:TextBox runat="server" required="required" Enabled="True" name="fullName" ID="fullName" class="form-control input-sm" placeholder="Name"></asp:TextBox>

                                    </div>
                                </div>
                        
                            </div><!--end cc part-->
                          </div>
                            <div class="row"> 
                            <div class="panel-body">
                                <h4 align="center">Personal Info:</h4>
                            </div>
                            <div class="panel-body"> 
                            <div class="row">
                                <div class="form-group">
                                <table>
                                    <tr>
                                        <th>
                                          
                                                <div class="col-md-4 col-md-offset-1">
                                                    <div class="form-group">
                                                        <asp:Label runat="server" AssociatedControlID="addressTxt"><b>Address:</b></asp:Label><br />
                                                        <asp:TextBox runat="server"  Enabled="True" name="addressTxt" ID="addressTxt" class="form-control input-sm" placeholder="Address" Width="259px"></asp:TextBox>

                                                    </div>
                                                </div>
                                     
                                        </th>
                                        <th>
                                          
                                                <div class="col-md-4 col-md-offset-1" style="left: 0px; top: 0px; width: 172px">
                                                    <div class="form-group">
                                                        <asp:Label runat="server" AssociatedControlID="cityTxt"><b>City:</b></asp:Label><br />
                                                        <asp:TextBox runat="server"   Enabled="True"  name="cityTxt" ID="cityTxt" class="form-control input-sm" placeholder="City"></asp:TextBox>

                                                    </div>
                                             
                                            </div>
                                        </th>
                                        <th>
                                          
                                            <div class="col-md-4 col-md-offset-1" style="left: 0px; top: 0px; width: 225px">
                                                <div class="form-group">
                                                    <asp:Label runat="server" AssociatedControlID="zipTxt" Width="81px"><b>Zip Code:</b></asp:Label><br />
                                                    <asp:TextBox runat="server" Enabled="True"  name="zipTxt" ID="zipTxt" class="form-control input-sm" placeholder="Zip Code:"></asp:TextBox>

                                                </div>
                                             
                                            </div>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>
                                          
                                            <div class="col-md-4 col-md-offset-1" style="left: 0px; top: 0px; width: 225px">
                                                <div class="form-group">
                                                    <asp:Label runat="server" AssociatedControlID="emailTxt" Width="81px"><b>Email:</b></asp:Label><br />
                                                    <asp:TextBox runat="server"   required="required"  TextMode="Email"  Enabled="True"  name="emailTxt" ID="emailTxt" class="form-control input-sm" placeholder="Email:"></asp:TextBox>

                                                </div>
                                             
                                            </div>
                                        </th>
                                        <th>
                                          
                                            <div class="col-md-4 col-md-offset-1" style="left: 0px; top: 0px; width: 225px">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ><b>Country:</b></asp:Label><br />
                                                    <asp:DropDownList ID="countryList" CssClass="form-control input-sm" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                             
                                            </div>
                                        </th>
                                    </tr>
                                </table>
                                </div>
                            </div>
                            </div>
                            
                            

                            

                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group" align="center">
                                        <asp:Button Text="Pay" ID="btnsave" OnClick="alertBox" CssClass="btn btn-primary btn-lg" BackColor="green" Width="220px" runat="server" />
                                        
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                                           <p ID="detailsSent"  runat="server"></p>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server" Visible="false">
                                            <p ID="detailsBack"  runat="server"> </p>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>

                        </div>
                        </div>
                    </section>
                </div>
            </div>
   

        </section>
    </section>






</asp:Content>
