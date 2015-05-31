<%@ Page Title="" Language="C#" MasterPageFile="~/mpSegundaria.master" AutoEventWireup="true" CodeBehind="wfMontador.aspx.cs" Inherits="Apresentacao.wfMontador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mpSegundaria" runat="server">
    <p style="height: 58px">
        <br />
        Montadores
        <asp:HiddenField ID="hfID" runat="server" />
    </p>
    <div>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>

    <asp:Panel ID="pDetalhe" runat="server" Height="245px" BorderStyle="Dashed">
        Detalhe<br />
        <div>
            <p></p>
            CPF
        </div>
        <asp:TextBox ID="txtCpf" runat="server"></asp:TextBox>
        <br />
        <div>
            Nome:
        </div>
        <div>
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        </div>


        <div>
            Salario
        </div>

        <div style="height: 25px">
            <asp:TextBox ID="txtSalario" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnGravar" runat="server" OnClick="btnGravar_Click" Text="Gravar" />
            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pBusca" runat="server">
        <asp:Button ID="btnLocalizar" runat="server" OnClick="btnLocalizar_Click" Text="Localizar" />
        <br />
        <asp:TextBox ID="txtBusca" runat="server" Width="960px"></asp:TextBox>

        <asp:GridView ID="gvMontador" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="gvMontador_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="id" Visible="False" />
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="cpf" HeaderText="CPF" />
                <asp:BoundField DataField="salario" HeaderText="Salario" />
                <asp:CommandField SelectText="Selecionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

    </asp:Panel>



</asp:Content>
