<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TechPub_Product.ascx.cs" Inherits="Sitecore.Ecommerce.TP.Layouts.Sublayouts.TechPub_Product" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div>
    <p><sc:Text runat="server" Field="Title" /></p>
    <p><sc:Text runat="server" Field="Short Description"/></p>
    <p>Stock: <sc:Text runat="server" Field="Stock"/></p>
    <p>Price: <asp:Literal runat="server" ID="litPrice"></asp:Literal></p>
   
    <p><a href="#" onclick="javascript:AddToShoppingCart('<%= Sitecore.Context.Item["product code"] %>')">Add to basket</a></p>
</div>