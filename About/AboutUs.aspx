<%@ Page Title="About Us" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="About_AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="Server">
    <p>This is copyright of Jamie Butterworth.</p>

    <asp:Button ID="Button1" runat="server" Text="Button" />
    <br />
    <Wrox:Banner ID="Banner2" runat="server" DisplayDirection="Horizontal" />
</asp:Content>
