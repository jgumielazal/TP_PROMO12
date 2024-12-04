<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="Web_Promo.Premios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center mb-3">Elegí tu premio</h1>
    <div class="row" style="margin-top: -20px;">
        <asp:Repeater ID="rptArticulos" runat="server" OnItemDataBound="rptArticulos_ItemDataBound">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card">
                        <asp:Label ID="lblNombre" runat="server" CssClass="card-title text-center pt-2" />
                        <asp:Image ID="imgArticulo" runat="server" CssClass="card-img-top p-3" style="max-height: 200px; width: auto; object-fit: contain;" />
                        <asp:Label ID="lblDescripcion" runat="server" CssClass="card-text text-center" />
                        <div class="text-center mb-3">
                            <asp:Button ID="btnElegir" runat="server" Text="¡Quiero este!" CssClass="btn btn-primary" OnClick="btnElegir_Click" />
                            <asp:Button ID="btnSiguiente" runat="server" Text="→" CssClass="btn btn-secondary" OnClick="btnSiguiente_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>




        </div>

            
</asp:Content>
