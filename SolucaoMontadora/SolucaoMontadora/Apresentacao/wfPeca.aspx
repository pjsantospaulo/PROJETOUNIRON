

<%@ Page Title="" Language="C#" MasterPageFile="~/mpSegundaria.master" AutoEventWireup="true" CodeBehind="wfPeca.aspx.cs" Inherits="Apresentacao.wfPeca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderSegundaria" runat="server">
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Fornecedor"></asp:Label>
            <br />
            <asp:DropDownList ID="dpdlFornecedor" runat="server" OnSelectedIndexChanged="dpdlFornecedor_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Data de Fabricação"></asp:Label>
            <br />
            <asp:TextBox ID="txtDtFabricacao" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Número de Série"></asp:Label><br />
            <asp:TextBox ID="txtNumSerie" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Descrição"></asp:Label> <br />
            <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Valor"></asp:Label><br />
            <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />

    <div>
        <div>
            <asp:Button ID="btnGravar" runat="server" Text="Gravar" />
            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" />
            <asp:Button ID="btnNovo" runat="server" Text="Novo" />
        </div>
        <br />
        <div>
            <asp:TextBox ID="txtLocalizar" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
        </div>
        <br />
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                    <asp:BoundField DataField="numeroSerie" HeaderText="Numero de Série" />
                    <asp:BoundField DataField="descricao" HeaderText="Descricao" />
                    <asp:BoundField DataField="dataFabricacao" HeaderText="Data de Fabricação" />
                    <asp:BoundField DataField="valor" HeaderText="Valor" />
                    <asp:BoundField DataField="fornecedor" HeaderText="Fornecedor" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
