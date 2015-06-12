<%@ Page Title="" Language="C#" MasterPageFile="~/mpPrincipal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Apresentacao.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="row">
        <p></p>
        <p></p>
        <p></p>
        <p></p>
    </div>
    <div class="row">
        <div class="col-lg-5 col-lg-offset-5">
            <div class="panel panel-default">
                <div class="panel-heading well-lg text-center"><span>PJ-MONTADORA</span></div>
                <div class="panel-body">
                    <hr />
                    
                    <div class="form-inline ">
                        <div class="form-group form-group-lg">
                            <div class="input-group">
                                <div class="input-group-addon"><small class="glyphicon glyphicon-user"></small></div>
                                <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control-static" placeholder="Usuario"></asp:TextBox>
                                <div class="input-group-addon"></div>
                            </div>
                            <p></p>
                            <p></p>
                            <div class="input-group form-group-lg">
                                <div class="input-group-addon "><small class="glyphicon glyphicon-wrench"></small></div>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control-static"></asp:TextBox>
                                <div class="input-group-addon"></div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div >
                        <asp:Button ID="bntEntrar" CssClass="btn btn-lg btn-primary btn-block " runat="server" Text="Entrar" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
