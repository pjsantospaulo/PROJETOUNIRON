<%@ Page Title="" Language="C#" MasterPageFile="~/mpSegundaria.master" AutoEventWireup="true" CodeBehind="wfFornecedor.aspx.cs" Inherits="Apresentacao.wfFornecedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderSegundaria" runat="server">

    <div>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <br />
        <asp:HiddenField ID="hfId" runat="server" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label>
    <br />
    <asp:TextBox ID="txtNome" runat="server" Width="311px"></asp:TextBox>
</div>
<div>
    <asp:Label ID="Label4" runat="server" Text="CPF:"></asp:Label>
    <br />
    <asp:TextBox ID="txtCpf" runat="server" EnableTheming="True" ValidateRequestMode="Enabled"></asp:TextBox>
    <br />
</div>
<div>
    <asp:Label ID="Label5" runat="server" Text="Endereço:"></asp:Label>
    <br />
    <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
    <br />
    <br />
</div>
<div style="width: 1250px">
    <asp:Button ID="btnGravar" runat="server" OnClick="btnGravar_Click" Text="Gravar" />
    <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
    <asp:Button ID="btnLocalizar" runat="server" Text="Localizar" OnClick="btnLocalizar_Click" />
    <asp:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
    <br />
</div>
    
    <div>
        <asp:TextBox ID="txtLocalizar" runat="server"></asp:TextBox>
        <br />
        <asp:GridView ID="gvFornecedor" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvFornecedor_SelectedIndexChanged" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="Cpf" HeaderText="Cpf" />
                <asp:BoundField DataField="endereco" HeaderText="Endereço" />
                <asp:BoundField DataField="id" Visible="False" />
                <asp:CommandField SelectText="Selecionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    
    <p>
        &nbsp;</p>

</asp:Content>
