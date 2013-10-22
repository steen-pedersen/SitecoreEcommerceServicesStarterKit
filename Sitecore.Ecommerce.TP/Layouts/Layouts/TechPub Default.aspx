<%@ Page Language="c#" CodePage="65001" AutoEventWireup="true" Inherits="Sitecore.Ecommerce.TP.Layouts.Layouts.Layout1" CodeBehind="TechPub Default.aspx.cs" %>

<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en" xml:lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>TechPub Shop
    </title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <sc:VisitorIdentification runat="server" />
    <script type='text/javascript' src='/js/jquery.min.js'></script>
    <script type="text/javascript" src="/js/MyFunctions.js"></script>
    <link href="/Css/TechPub.css" rel="stylesheet" />
</head>
<body>

    <form method="post" runat="server" id="mainform">
        <div style="position: relative; overflow: hidden;">
            <div style="margin: 0 auto;width:800px;">
                <div id="top">
                    <div style="width: 500px;">
                        <sc:Placeholder runat="server" ID="phtop" Key="top" />
                    </div>
                    <div style="width: 270px;min-height: 81px;">
                        <sc:Placeholder runat="server" ID="phcart" Key="cart" />
                    </div>
                    <div class="clear" style="padding:0;margin:0;"></div>
                </div>
                <div id="main">
                    <div id="left">
                        <sc:Placeholder runat="server" ID="phleft" Key="left" />
                    </div>
                    <div id="center">
                        <sc:Placeholder runat="server" ID="phcontent" Key="content" />
                    </div>
                    <div id="right">
                        <sc:Placeholder runat="server" ID="phright" Key="rightx" />
                    </div>
                    <div class="clear" style="padding:0;margin:0;"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
