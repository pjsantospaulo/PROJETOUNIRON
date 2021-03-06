﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mpSegundaria.master" AutoEventWireup="true" CodeBehind="wfCliente.aspx.cs" Inherits="Apresentacao.wfCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderSegundaria" runat="server">
    <div class="form-c">
        <div class=" form-control">
            <asp:Label Text="" runat="server" ID="lblMsg" />
            <br />
            <asp:HiddenField ID="hfId" runat="server" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="CPF:"></asp:Label>
            <br />
            <asp:TextBox ID="txtCpf" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Nome:"></asp:Label>
            <br />
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Data de Nascimento:"></asp:Label>
            <br />
            <asp:TextBox ID="txtDtNascimento" runat="server" type="datetime"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label10" runat="server" Text="Sexo"></asp:Label>
            <br />
            <asp:DropDownList ID="dpdlSexo" runat="server" OnSelectedIndexChanged="dpdlSexo_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div>

            <asp:Label ID="Label4" runat="server" Text="Endereço"></asp:Label>
            <br />
            <asp:TextBox ID="txtEndereco" runat="server" Height="22px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label7" runat="server" Text="Numero"></asp:Label>
            <br />
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label9" runat="server" Text="UF"></asp:Label>
            <br />
            <asp:DropDownList ID="dpdlUf" runat="server" OnSelectedIndexChanged="dpdlUf_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label8" runat="server" Text="Cidade"></asp:Label>
            <br />
            
                <asp:DropDownList ID="dpdlCidade" CssClass="dropdown-toggle chosen-select" runat="server" Height="22px" Width="210px">
                </asp:DropDownList>
          
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="RG:"></asp:Label>
            <br />
            <asp:TextBox ID="txtRg" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="Label6" runat="server" Text="Orgão Expedidor"></asp:Label>
            <br />
            <asp:TextBox ID="txtOrgaoExpedidor" runat="server"></asp:TextBox>
        </div>
    </div>
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <div>
                <asp:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
                <asp:Button ID="btnNovo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
                <br />
            </div>
            <div>
                <asp:TextBox ID="txtLocalizar" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                <br />
            </div>
            <div>
                <asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnSelectedIndexChanged="gvCliente_SelectedIndexChanged" OnPageIndexChanging="gvCliente_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                        <asp:BoundField DataField="nome" HeaderText="Nome" />
                        <asp:BoundField DataField="cpf" HeaderText="CPF" />
                        <asp:BoundField DataField="endereco" HeaderText="Endereço" />
                        <asp:BoundField DataField="numero" HeaderText="Numero" />
                        <asp:BoundField DataField="dataNascimento" HeaderText="Data de Nascimento" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="_Sexo" HeaderText="Sexo" />
                        <asp:BoundField DataField="rg" HeaderText="RG" />
                        <asp:BoundField DataField="orgaoExpedidor" HeaderText="Orgão Expedidor" />
                        <asp:BoundField DataField="Cidade.Nome" HeaderText="Cidade" />
                        <asp:CommandField SelectText="Selecionar" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
