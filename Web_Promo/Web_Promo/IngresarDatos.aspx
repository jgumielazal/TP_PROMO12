<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="IngresarDatos.aspx.cs" Inherits="Web_Promo.IngresarDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  <h1 class="text-center mb-2">Ingresa tus datos</h1>
    <div class="row justify-content-center">
      <div class = "col-4">
        <div class="card mt-3" style="background-color: black; color: white;">
            <div class="card-body">
                <div class="mb-3">
                <div>
                    <asp:Label ID="lblResultado" runat="server" Text="Solicitud envida con éxito!
                        Gracias por participar. Redirigiendolo a la pagina de inicio."  ForeColor="Lime" Visible="False" />
                </div>
                    <label>DNI</label>
                <div class="d-flex">
                    <asp:TextBox ID="txtDNI" runat="server"  CssClass="form-control" />
                    <asp:Button ID="btnBuscarDNI" runat="server" Text="🔍" CssClass="btn btn-secondary" OnClick="btnBuscarDNI_Click" />
                    </div>
                </div>

                <div class="mb-3">
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                 </div>

                <div class="mb-3">
                    <label>Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label>Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                    <asp:Label ID="lblErrorArroba" runat="server"  ForeColor="Red" Text = "El email debe contener @" Visible="False"/>
                
                </div>

                <div class="mb-3">
                    <label>Dirección</label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
                 </div>

                <div class="mb-3">
                    <label>Ciudad</label>
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control"/>
                </div>

                <div class="mb-3">
                    <label>Código Postal</label>
                    <asp:TextBox ID="txtCodPos" runat="server" CssClass="form-control" />
                </div>
                <div>
                    <asp:Label ID="lblErrorCampoVacio" runat="server"  ForeColor="Red" Text = "Todos los campos son obligatorios" Visible="False"/>
                </div>
                <div class="mb-3">
                    <asp:CheckBox ID="chkTermsConds" runat="server" Text="Acepto los términos y condiciones"/>
                     <asp:Label ID="lblErrorTerminos" runat="server"  ForeColor="Red" Text = "Debe aceptar los términos y condiciones" Visible="False"/>
                </div>

                <asp:Button ID="btnParticipar" runat="server" Text="Participar!" 
                    CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
             </div>
        </div>
      </div>
    </div>
</asp:Content>
