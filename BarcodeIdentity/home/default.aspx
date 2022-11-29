<%@ Page Title="" Language="C#" MasterPageFile="~/account/barcode.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BarcodeIdentity.home.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>BarcodID - Personal ID Suite - Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- main content -->
        <div class="main-content bg-white right-chat-active">
            
            <div class="middle-sidebar-bottom">
                <div class="middle-sidebar-left">
                    <div class="row">
                        <div class="col-xl-12 ">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="card w-100 border-0 shadow-none p-5 rounded-xxl bg-lightblue2 mb-3">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <img src="/images/bg-2.png" alt="image" class="w-100">
                                            </div>
                                            <div class="col-lg-6 ps-lg-5">
                                                <h2 class="display1-size d-block mb-2 text-grey-900 fw-700">
                                                    <!-- <span class="font-xssss fw-600 text-grey-500 d-block mb-2 ms-1">Welcome back</span>  -->
                                                ID Card Made Easy with QRIdentity</h2>
                                                <p class="font-xssss fw-500 text-grey-500 lh-26">Our Solution provides the easiest way to Identify and categorize your friend by simply scanning their QRIdentity.</p>
                                                
                                                <a href="/members/add_member" class="btn w200 border-0 bg-primary-gradiant p-3 text-white fw-600 rounded-3 d-inline-block font-xssss">Create Member</a>
                                            </div>
                                        </div>
                                    </div>  
                                </div>
                                <div class="col-lg-3 pe-2">
                                    <div class="card w-100 border-0 shadow-none p-4 rounded-xxl mb-3" style="background-color: #e5f6ff;">
                                        <div class="card-body d-flex p-0">
                                            <i class="btn-round-lg d-inline-block me-3 bg-primary-gradiant feather-home font-md text-white"></i>
                                            <h4 class="text-primary font-xl fw-700">2.3M <span class="fw-500 mt-0 d-block text-grey-500 font-xssss">QRIDs</span></h4>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3 pe-2 ps-2">
                                    <div class="card w-100 border-0 shadow-none p-4 rounded-xxl mb-3" style="background-color: #f6f3ff;">
                                        <div class="card-body d-flex p-0">
                                            <i class="btn-round-lg d-inline-block me-3 bg-secondary feather-lock font-md text-white"></i>
                                            <h4 class="text-secondary font-xl fw-700">44.6K <span class="fw-500 mt-0 d-block text-grey-500 font-xssss">Total Members</span></h4>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3 pe-2 ps-2">
                                    <div class="card w-100 border-0 shadow-none p-4 rounded-xxl mb-3" style="background-color: #e2f6e9;">
                                        <div class="card-body d-flex p-0">
                                            <i class="btn-round-lg d-inline-block me-3 bg-success feather-command font-md text-white"></i>
                                            <h4 class="text-success font-xl fw-700">603 <span class="fw-500 mt-0 d-block text-grey-500 font-xssss">Active Members</span></h4>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3 ps-2">
                                    <div class="card w-100 border-0 shadow-none p-4 rounded-xxl mb-3" style="background-color: #fff0e9;">
                                        <div class="card-body d-flex p-0">
                                            <i class="btn-round-lg d-inline-block me-3 bg-warning feather-shopping-bag font-md text-white"></i>
                                            <h4 class="text-warning font-xl fw-700">3M <span class="fw-500 mt-0 d-block text-grey-500 font-xssss">Inactive Members</span></h4>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="card w-100 p-3 border-0 mb-3 rounded-xxl bg-lightblue2 shadow-none overflow-hidden">
                                        <div id="chart-usersMultiplee"></div>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="card w-100 p-5 border-0 mb-3 rounded-lg bg-lightblue2 shadow-xs overflow-hidden">
                                        <div id="chart-candlestick"></div>
                                    </div>
                                </div>

                            </div>

                        </div>               

                    </div>
                </div>
                 
            </div>            
        </div>
        <!-- main content -->

</asp:Content>
