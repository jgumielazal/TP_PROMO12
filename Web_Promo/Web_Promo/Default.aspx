<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_Promo.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div style="display: flex; justify-content: center; align-items: center; height: 100vh;">
    <div class="col-md-4">
        <div class="card" id="VoucherInput"  style="background-color: black; color: white;">
            <div class="card-body">
                <h5>Promo Ganá!</h5>
                    <asp:TextBox ID="txtCodigoVoucher" runat="server" CssClass="form-control" Placeholder="xxxxxxx">

                    </asp:TextBox>
                    <asp:Button ID="btnValidar" runat="server" Text="Validar" CssClass="btn btn-primary" OnClick="btnValidar_Click" />

                </div>
            </div>
            <asp:Label ID="lblError" runat="server" Font-Italic="True" ForeColor="Red" Visible="False"></asp:Label>
      </div>
   </div>
    
</asp:Content>
