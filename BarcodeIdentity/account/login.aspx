<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BarcodeIdentity.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>QrId - Personal ID Suite</title>

    <link rel="stylesheet" href="/css/themify-icons.css">
    <link rel="stylesheet" href="/css/feather.css">
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="/images/favicon.png">
    <!-- Custom Stylesheet -->
    <link rel="stylesheet" href="/css/style.css"> 
</head>
<body class="color-theme-blue">
    <form id="form1" runat="server">
        <div class="preloader"></div>

    <div class="main-wrap">

        <div class="nav-header bg-transparent shadow-none border-0">
            <div class="nav-top w-100">
                <a href="/"><img src="/images/translogo.png" alt="users" class="w40 mt--1"><span class="d-inline-block fredoka-font ls-3 fw-600 text-current font-xxl logo-text mb-0">QrID. </span> </a>
                <a href="#" class="mob-menu ms-auto me-2 chat-active-btn"><i class="feather-message-circle text-grey-900 font-sm btn-round-md bg-greylight"></i></a>
                <a href="default-video.html" class="mob-menu me-2"><i class="feather-video text-grey-900 font-sm btn-round-md bg-greylight"></i></a>
                <a href="#" class="me-2 menu-search-icon mob-menu"><i class="feather-search text-grey-900 font-sm btn-round-md bg-greylight"></i></a>
                <button class="nav-menu me-0 ms-2"></button>

                <a href="#" class="header-btn d-none d-lg-block bg-dark fw-500 text-white font-xsss p-3 ms-auto w100 text-center lh-20 rounded-xl"  data-bs-toggle="modal" data-bs-target="#Modallogin">Admin Panel</a>
                <%--<a href="#" class="header-btn d-none d-lg-block bg-current fw-500 text-white font-xsss p-3 ms-2 w100 text-center lh-20 rounded-xl"  data-bs-toggle="modal" data-bs-target="#Modalregister">Register</a>--%>

            </div>
            
            
        </div>

        <div class="row">
            <div class="col-xl-5 d-none d-xl-block p-0 vh-100 bg-image-cover bg-no-repeat" style="background-image: url(/images/login-bg.jpg);"></div>
            <div class="col-xl-7 vh-100 align-items-center d-flex bg-white rounded-3 overflow-hidden">
                <div class="card shadow-none border-0 ms-auto me-auto login-card">
                    <div class="card-body rounded-0 text-left">
                        <h2 class="fw-700 display1-size display2-md-size mb-3">Admin Login</h2>
                        <div>
                            
                            <div class="form-group icon-input mb-3">
                                <i class="font-sm ti-email text-grey-500 pe-0"></i>
                                <input type="email" runat="server" id="emailtxt" class="style2-input ps-5 form-control text-grey-900 font-xsss fw-600" placeholder="Your Email Address"/>                        
                            </div>
                            <div class="form-group icon-input mb-1">
                                <input type="Password" id="passwordtxt" runat="server" class="style2-input ps-5 form-control text-grey-900 font-xss ls-3" placeholder="Password"/>
                                <i class="font-sm ti-lock text-grey-500 pe-0"></i>
                            </div>
                            <div class="form-check text-left mb-3">
                                <input type="checkbox" class="form-check-input mt-2" id="exampleCheck5"/>
                                <label class="form-check-label font-xsss text-grey-500" for="exampleCheck5">Remember me</label>
                                <a href="forgot_password" class="fw-600 font-xsss text-grey-700 mt-1 float-right">Forgot your Password?</a>
                            </div>
                        </div>
                          <!-- ALERT -->
                              <div class="alert alert-danger" role="alert" id="exceptiondiv" runat="server" visible="false">
                                    <span id="exceptiontxt" runat="server"></span>
                                </div>
                        <div class="col-sm-12 p-0 text-left">
                            <div class="form-group mb-1">
                                <asp:Button ID="Button1" class="form-control text-center style2-input text-white fw-600 bg-success border-0 p-0 " runat="server" OnClick="Button1_Click" Text="Login" /></div>
                   
                    </div>
                </div> 
            </div>
        </div>
    </div>
     

   
    </form>
    <script src="/js/plugin.js"></script>
    <script src="/js/scripts.js"></script>
</body>
</html>
