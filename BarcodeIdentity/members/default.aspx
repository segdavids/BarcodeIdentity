<%@ Page Title="" Language="C#" MasterPageFile="~/account/barcode.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="default.aspx.cs" Inherits="BarcodeIdentity.users.members" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>QrId - Personal ID Suite</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- main content -->
     <div class="main-content right-chat-active">
            <div class="middle-sidebar-bottom">
                <div class="middle-sidebar-left pe-0">
                    <div class="row">
                        <div class="col-xl-12">
                            <div class="card shadow-xss w-100 d-block d-flex border-0 p-4 mb-3">
                                <div class="card-body d-flex align-items-center p-0">
                                    <h2 class="fw-700 mb-0 mt-0 font-md text-grey-900">Members</h2>
                                            <a href="add_member" class="mt-0 btn pt-2 pb-2 ps-3 pe-3 lh-24 ms-1 ls-3 d-inline-block rounded-xl bg-success font-xsssss fw-700 ls-lg text-white" <%--data-bs-toggle="modal" data-bs-target="#Modalregister"--%>>Add Member</a>
                                    <a href="#" class="mt-0 btn pt-2 pb-2 ps-3 pe-3 lh-24 ms-1 ls-3 d-inline-block rounded-xl bg-success font-xsssss fw-700 ls-lg text-white" data-bs-toggle="modal" data-bs-target="#uploadmodal">Upload</a>
                                    <div class="search-form-2 ms-auto">
                                        <i class="ti-search font-xss"></i>
                                        <input type="text" class="form-control text-grey-500 mb-0 bg-greylight theme-dark-bg border-0" placeholder="Search here.">
                                    </div>
                                    <a href="#" class="btn-round-md ms-2 bg-greylight theme-dark-bg rounded-3"><i class="feather-filter font-xss text-grey-500"></i></a>
                                </div>
                                <!--FILTER ROW-->
                                 <div class="row ps-2 pe-2">
                                     <div class="col-md-1 col-sm-1 pe-2 ps-2">
                                          <label class="mont-font fw-400 font-xsss">Active</label>
                                         <div class="card d-block border-0 shadow-xss rounded-3 overflow-hidden mb-3">
                                             <asp:CheckBox ID="activechkbx" AutoPostBack="true" Checked="true" OnCheckedChanged="filterinactive" runat="server" />
                                         </div>
                                     </div>
                                     <div class="col-md-1 col-sm-1 pe-2 ps-2">
                                          <label class="mont-font fw-400 font-xsss">Inactive</label>
                                         <div class="card d-block border-0 shadow-xss rounded-3 overflow-hidden mb-3">
                                             <asp:CheckBox ID="inactivechkbx" AutoPostBack="true" Checked="true" OnCheckedChanged="filterinactive" runat="server" />
                                         </div>
                                     </div>
                                    <%-- <div class="col-md-1 col-sm-1 pe-2 ps-2">
                                         <div class="card d-block border-0 shadow-xss rounded-3 overflow-hidden mb-3">
                                             <asp:CheckBox ID="CheckBox3" runat="server" />
                                         </div>
                                     </div>--%>
                                 </div>
                            </div>

                            <!-- ALERT -->
                              <div class="alert alert-danger" role="alert" id="exceptiondiv" runat="server" visible="false">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"></button><span id="exceptiontxt" runat="server"></span>
                                </div>

                            <div class="row ps-2 pe-2">
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCreated="Repeater1_ItemCreated">
                                        <ItemTemplate>
                                <div class="col-md-3 col-sm-4 pe-2 ps-2">
                                    <div class="card d-block border-0 shadow-xss rounded-3 overflow-hidden mb-3">
                                        <div class="card-body d-block w-100 ps-3 pe-3 pb-4 text-center">
                                            <a href="member_profile?mid=<%# Eval("MemberId") %>">
                                            <figure class="avatar ms-auto me-auto mb-0 position-relative w65 z-index-1"><img src="/images/rounddefault.jpg" alt="image" class="float-right p-0 bg-white rounded-circle w-100 shadow-xss"></figure>
                                            <div class="clearfix"></div>
                                            <asp:Label ID="entrytxt"  Visible = "false" runat="server" Text='<%# Eval("MemberId") %>' />
                                            <h4 class="fw-700 font-xsss mt-3 mb-1"><%# Eval("FirstName") %>  <%# Eval("LastName") %> </h4>
                                            <p class="fw-500 font-xsssss text-grey-500 mt-0 mb-0">@<%# Eval("Phone") %></p>
                                            <p class="fw-500 font-xsssss text-grey-500 mt-0 mb-3">@<%# Eval("Email") %></p>
                                            </a>
                                            <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Download Profile" OnClick="Download_profile" class="mt-0 btn pt-2 pb-2 ps-3 pe-3 lh-24 ms-1 ls-3 d-inline-block rounded-xl bg-success font-xsssss fw-700 ls-lg text-white"><i class="feather-download-cloud fw-700 text-white-900- ms-0"></i></asp:LinkButton>
                                            <a href="edit_profile?mid=<%# Eval("MemberId") %>" title="Edit Profile" class="mt-0 btn pt-2 pb-2 ps-3 pe-3 lh-24 ms-1 ls-3 d-inline-block rounded-xl bg-success font-xsssss fw-700 ls-lg text-white"><i class="feather-edit text-white fw-700 ms-0"></i> </a>
                                            <asp:LinkButton ID="activateuser" ToolTip="Activate User" runat="server" OnClick="activate_user" Visible="false" class="mt-0 btn pt-2 pb-2 ps-3 pe-3 lh-24 ms-1 ls-3 d-inline-block rounded-xl bg-success font-xsssss fw-700 ls-lg text-white"><i class="feather-unlock fw-700 text-white-900- ms-0"></i></asp:LinkButton>
                                            <asp:LinkButton ID="deactivtaeuser" ToolTip="Deactivate User" runat="server" OnClick="deactivate_user" Visible="false" class="mt-0 btn pt-2 pb-2 ps-3 pe-3 lh-24 ms-1 ls-3 d-inline-block rounded-xl bg-danger font-xsssss fw-700 ls-lg text-white"><i class="feather-lock fw-700 text-white-900- ms-0"></i></asp:LinkButton>
                                            </div>
                                    </div>
                                </div>  
                                        </ItemTemplate>
                                    </asp:Repeater>
                               
                            </div>
                        </div>               
                    </div>
                </div>
                 
            </div>   
         </div>
        <!-- main content -->
   
</asp:Content>
