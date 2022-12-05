<%@ Page Title="" Language="C#" MasterPageFile="~/account/barcode.Master" AutoEventWireup="true" CodeBehind="password.aspx.cs" Inherits="BarcodeIdentity.account.password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>QrId - Personal ID Suite - Rest Password</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- main content -->
        <div class="main-content right-chat-active">        
            <div class="middle-sidebar-bottom">
                <div class="middle-sidebar-left">
                   
                    <div class="middle-wrap">
                        <div class="card w-100 border-0 bg-white shadow-xs p-0 mb-4">
                            <div class="card-body p-4 w-100 bg-current border-0 d-flex rounded-3">
                                <a href="settings" class="d-inline-block mt-2"><i class="ti-arrow-left font-sm text-white"></i></a>
                                <h4 class="font-xs text-white fw-600 ms-4 mb-0 mt-2">Change Password</h4>
                            </div>
                            <div class="card-body p-lg-5 p-4 w-100 border-0 ">
                           

                            <div action="#">
                                <div class="row">
                                    <div class="col-lg-12 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">Current Password</label>
                                            <input type="password" id="currentpwtxt" required="required" runat="server" class="form-control">
                                        </div>        
                                    </div>

                                     <div class="col-lg-12 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">New Password</label>
                                            <input type="password" id="newpasswordtxt" required="required" runat="server" class="form-control">
                                        </div>        
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">Confirm Password</label>
                                            <input type="password" id="confirmpasswordtxt" required="required" runat="server" class="form-control">
                                        </div>        
                                    </div>

                                   
                                </div>

                                    <div class="col-lg-12">
                                        <asp:Button ID="Button1" OnClick="Reset_Password" class="bg-current text-center text-white font-xsss fw-600 p-3 w175 rounded-3 d-inline-block" runat="server" Text="Save" />
                                    </div>
                                 
                                </div>
                              
                            </div>
                        </div>
                    <!-- ALERT -->
                        <div class="alert alert-danger" role="alert" id="exceptiondiv" runat="server" visible="false">
                            <span id="exceptiontxt" runat="server"></span>
                        </div>
                    </div>
                </div>
                 
            </div>            
        </div>
        <!-- main content -->
</asp:Content>
