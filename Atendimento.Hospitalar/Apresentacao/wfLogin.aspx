<%@ Page Title="" Language="C#" MasterPageFile="~/mpExterna.Master" AutoEventWireup="true" CodeBehind="wfLogin.aspx.cs" Inherits="Apresentacao.wfLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpExterna" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnLogar" runat="server" Text="Logar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    </div>
</asp:Content>
