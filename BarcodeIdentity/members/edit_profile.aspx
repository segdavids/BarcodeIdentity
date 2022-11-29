<%@ Page Title="" Language="C#" MasterPageFile="~/account/barcode.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="edit_profile.aspx.cs" Inherits="BarcodeIdentity.members.edit_profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BarcodID - Personal ID Suite - Edit Profile</title>
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
                    <div class="middle-wrap">
                        <div class="card w-100 border-0 bg-white shadow-xs p-0 mb-4">
                            <div class="card-body p-4 w-100 bg-current border-0 d-flex rounded-3">
                                <a href="/members" class="d-inline-block mt-2"><i class="ti-arrow-left font-sm text-white"></i></a>
                                <h4 class="font-xs text-white fw-600 ms-4 mb-0 mt-2">Edit User</h4>
                            </div>
                            <div class="card-body p-lg-5 p-4 w-100 border-0 ">
                            <div class="row justify-content-center">
                                <div class="col-lg-4 text-center">
                                    <figure class="avatar ms-auto me-auto mb-0 mt-2 w100"><img src="/images/rounddefault.jpg" alt="image" class="shadow-sm rounded-3 w-100"></figure>
                                    <h2 class="fw-700 font-sm text-grey-900 mt-3"><span id="fullnametxt" runat="server"></span></h2>
                                    <h4 class="text-grey-500 fw-500 mb-3 font-xsss mb-4"><span id="emailadd" runat="server"></span></h4>    
                                    <!-- <a href="#" class="p-3 alert-primary text-primary font-xsss fw-500 mt-2 rounded-3">Upload New Photo</a> -->
                                </div>
                            </div>

                            <div action="#">
                                <div class="row">
                                    <div class="col-lg-6 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">First Name</label>
                                            <input type="text" id="firstnametxt" runat="server" class="form-control">
                                        </div>        
                                    </div>

                                    <div class="col-lg-6 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">Last Name</label>
                                            <input type="text" id="lastnametxt" runat="server" class="form-control">
                                        </div>        
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-6 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">Email</label>
                                            <input type="email" id="emailtxt" runat="server" disabled="disabled" class="form-control">
                                        </div>        
                                    </div>

                                    <div class="col-lg-6 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">Phone</label>
                                            <input type="text" id="phonetxt" runat="server" class="form-control">
                                        </div>        
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-6 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">Nick Name</label>
                                            <input type="text" id="nicknametxt" runat="server" class="form-control">
                                        </div>        
                                    </div>

                                    <div class="col-lg-6 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">Country</label>
                                            <asp:DropDownList ID="countrydll" class="form-control" runat="server"></asp:DropDownList>
                                        </div>        
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-6 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">State</label>
                                            <asp:DropDownList ID="statedll" class="form-control" runat="server"></asp:DropDownList>
                                        </div>        
                                    </div>

                                    <div class="col-lg-6 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">DOB</label>
                                            <input type="date" id="dobtxt" runat="server" class="form-control">
                                        </div>        
                                    </div>
                                      <div class="col-lg-6 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">Active</label>
                                            <asp:DropDownList ID="activedll" class="form-control" runat="server">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>        
                                    </div>
                                    <div class="col-lg-6 mb-3">
                                        <div class="form-group">
                                            <label class="mont-font fw-600 font-xsss">Profile URL</label>
                                            <input type="text" id="urltxt" runat="server" disabled="disabled" class="form-control">
                                        </div>        
                                    </div>
                                    <div class="col-lg-12 mb-3">
                                        <div class="card mt-3 border-0">
                                            <div class="card-body d-flex justify-content-between align-items-end p-0">
                                                <div class="form-group mb-0 w-100">
                                                    <label class="mont-font fw-600 font-xsss">Photo</label>
                                                   <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
<%--                                                    <input type="file" name="file" id="file" class="input-file">--%>
                                              <%--      <label for="file" class="rounded-3 text-center bg-white btn-tertiary js-labelFile p-4 w-100 border-dashed">
                                                    <i class="ti-cloud-down large-icon me-3 d-block"></i>
                                                    <span class="js-fileName">Drag and drop or click to replace</span>
                                                         
                                                    </label>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 mb-3">
                                        <label class="mont-font fw-600 font-xsss">About/Bio</label>
                                        <textarea class="form-control mb-0 p-3 h100  lh-16" rows="5" id="abouttxt" runat="server" spellcheck="true"></textarea>
                                    </div>

                                    <div class="col-lg-12">
                                        <asp:Button ID="Button1" OnClick="Update" class="bg-current text-center text-white font-xsss fw-600 p-3 w175 rounded-3 d-inline-block" runat="server" Text="Update" />
                                    </div>
                                </div>

                            </div>
                            </div>
                        </div>
                        <!-- <div class="card w-100 border-0 p-2"></div> -->
                    </div>
                </div>
                 
            </div>            
        </div>
        <!-- main content -->
</asp:Content>
