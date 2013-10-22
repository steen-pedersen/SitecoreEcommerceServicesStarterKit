<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TechPub_Header.ascx.cs" Inherits="Sitecore.Ecommerce.TP.Layouts.Sublayouts.TechPub_Header" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div style="padding:10px;">
    <sc:Image runat="server" Field="Image" MaxHeight="60" ID="scimg1"/>
    <sc:Text runat="server" ID="sctxtTitle" Field="Title"/>
</div>