<%@ Page Title="" Language="C#" MasterPageFile="~/account/barcode.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="barcodetemplate.aspx.cs" Inherits="BarcodeIdentity.home.barcodetemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>QrId - Personal ID Suite - ID Template</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- main content -->
        <div class="main-content right-chat-active">
            
            <div class="middle-sidebar-bottom">

                <div class="middle-sidebar-left">
                      <!-- ALERT -->
                              <div class="alert alert-danger" role="alert" id="exceptiondiv" runat="server" visible="false">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"></button><span id="exceptiontxt" runat="server"></span>
                                </div>
             
                    <div class="row">
                      
                        <div class="col-xl-12 col-xxl-12 col-lg-12 pe-0">
                          
                            <div class="card w-100 shadow-xss rounded-xxl border-0 mb-3 mt-3">
                                <div class="card-body d-block p-4">
                                    <h4 class="fw-700 mb-3 font-xsss text-grey-900">QR Template</h4>
                                    <p class="fw-500 text-grey-500 lh-24 font-xssss mb-0">Edit template from the toolbox available</p>
                                </div>
                                <div class="row card-body border-top-xs d-flex">
                                    <div class="row">
                                        <div class="col-xl-10 ">
                                            <div class="row">
                                                 <div class="col-lg-6 pe-2 ps-2 " id="">
                                                    <span style="font-weight: 400; margin-left: 5px"><b>FRONT</b></span>
                                                    <div class="card w-100 border-0 shadow-none p-4 rounded-xxl mb-3" id="frontid" style="background-color: #e2f6e9; height: 200px">
                                                        <div class="card-body d-flex p-0" style="margin-top: 20px">
                                                            <img id="Img2" runat="server" src="/images/logobig.jpeg" style="height: 100px; width: 100px" alt="image"><br />
                                                            <p>
                                                                <h4 class="text-success font-lg fw-500" style="margin-left: 20px">Keep Fit Club <span class="fw-500 mt-0 d-block font-xssss" style="color:dimgray">Member</span></h4>
                                                            </p>
                                                        </div>
                                                    </div>

                                                </div>
                           
                                                <div class="col-lg-6 pe-2 ps-2 ">
                                                    <span style="font-weight: 400; margin-left: 5px"><b>BACK</b></span>
                                                    <div class="card w-100 border-0 shadow-none p-4 rounded-xxl mb-3" id="backid" style="background-color: #e2f6e9; height: 200px">
                                                        <div class="card-body d-flex p-0" style="margin-top: 20px">
                                                            <img id="image2" src="~/images/backgr.jpg" runat="server" style="height: 100px; width: 100px" alt="image"><br />
                                                            <p>
                                                                <h4 class="text-success font-lg fw-500" style="margin-left: 20px"><asp:Label ID="Label1" runat="server"></asp:Label> <span class="fw-500 mt-0 d-block font-xssss" style="color:dimgray">Scan QR-Code to view
                                                                <asp:Label ID="profilename" runat="server"></asp:Label>this member's detailed Profile</span></h4>
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                               
                             
                                
                            </div>
                           
                        </div>


                        <div class="col-xl-12 col-xxl-12 col-lg-12">
                            



                        </div>                             
                    </div>
        
                </div>
                 
            </div>            
        </div>
        <!-- main content -->
</asp:Content>
