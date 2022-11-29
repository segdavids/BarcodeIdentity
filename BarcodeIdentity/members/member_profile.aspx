<%@ Page Title="" Language="C#" MasterPageFile="~/account/barcode.Master" AutoEventWireup="true" CodeBehind="member_profile.aspx.cs" Inherits="BarcodeIdentity.members.view_profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <title>BarcodID - Personal ID Suite - Member Profile</title>
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
                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card w-100 border-0 p-0 bg-white shadow-xss rounded-xxl">
                                <div class="card-body h250 p-0 rounded-xxl overflow-hidden m-3"><img src="/images/u-bg.jpg" alt="image"></div>
                                <div class="card-body p-0 position-relative">
                                    <figure class="avatar position-absolute w100 z-index-1" style="top:-40px; left: 30px;"><img src="/images/rounddefault.jpg" alt="image" class="float-right p-1 bg-white rounded-circle w-100"></figure>
                                    <h4 class="fw-700 font-sm mt-2 mb-lg-5 mb-4 pl-15"><%# Eval("FirstName") %> <%# Eval("LastName") %> <span class="fw-500 font-xssss text-grey-500 mt-1 mb-3 d-block"><%# Eval("Email") %></span></h4>
                                    <div class="d-flex align-items-center justify-content-center position-absolute-md right-15 top-0 me-2">
                                        <a href="#" class="d-none d-lg-block bg-success p-3 z-index-1 rounded-3 text-white font-xsssss text-uppercase fw-700 ls-3">Download ID</a>
                                        <a href="edit_profile?mid=<%# Eval("MemberId") %>" class="d-none d-lg-block bg-greylight btn-round-lg ms-2 rounded-3 text-grey-700"><i class="feather-edit font-md"></i></a>

                                    </div>
                                </div>

                                <div class="card-body d-block w-100 shadow-none mb-0 p-0 border-top-xs">
                                    <ul class="nav nav-tabs h55 d-flex product-info-tab border-bottom-0 ps-4" id="pills-tab" role="tablist">
                                        <li class="active list-inline-item me-5"><a class="fw-700 font-xssss text-grey-500 pt-3 pb-3 ls-1 d-inline-block active" href="#navtabs1" data-toggle="tab">About</a></li>
                                        <li class="list-inline-item me-5"><a class="fw-700 font-xssss text-grey-500 pt-3 pb-3 ls-1 d-inline-block" href="#navtabs2" data-toggle="tab">Membership</a></li>
                                        <li class="list-inline-item me-5"><a class="fw-700 font-xssss text-grey-500 pt-3 pb-3 ls-1 d-inline-block" href="#navtabs3" data-toggle="tab">Discussion</a></li>
                                     
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-12 col-xxl-12 col-lg-12 pe-0">
                          
                            <div class="card w-100 shadow-xss rounded-xxl border-0 mb-3 mt-3">
                                <div class="card-body d-block p-4">
                                    <h4 class="fw-700 mb-3 font-xsss text-grey-900">About</h4>
                                    <p class="fw-500 text-grey-500 lh-24 font-xssss mb-0"><%# Eval("About") %></p>
                                </div>
                                <div class="card-body border-top-xs d-flex">
                                    <i class="feather-lock text-grey-500 me-3 font-lg"></i>
                                    <h4 class="fw-700 text-grey-900 font-xssss mt-0">Private <span class="d-block font-xssss fw-500 mt-1 lh-3 text-grey-500">What's up, how are you?</span></h4>
                                </div>

                                <div class="card-body d-flex pt-0">
                                    <i class="feather-map-pin text-grey-500 me-3 font-lg"></i>
                                    <h4 class="fw-700 text-grey-900 font-xssss mt-1"><%# Eval("StateName") %>, <%# Eval("LocationName") %> </h4>
                                </div>
                                  <div class="card-body d-flex pt-0">
                                    <i class="feather-web text-grey-500 me-3 font-lg"></i>
                                    <h4 class="fw-700 text-grey-900 font-xssss mt-1"><%# Eval("URL") %> </h4>
                                </div>
                                <div class="card-body d-flex pt-0">
                                    <i class="feather-users text-grey-500 me-3 font-lg"></i>
                                    <h4 class="fw-700 text-grey-900 font-xssss mt-1"><%# Eval("Role") %></h4>
                                </div>
                            </div>
                           
                        </div>


                        <div class="col-xl-12 col-xxl-12 col-lg-12">
                            



                        </div>                             
                    </div>
                                            </ItemTemplate>
                        </asp:Repeater>
                </div>
                 
            </div>            
        </div>
        <!-- main content -->
</asp:Content>
