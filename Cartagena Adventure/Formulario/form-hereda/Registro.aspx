<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/pagina maestra/maestra.master" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="Formulario_form_hereda_iniciarSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src='https://www.google.com/recaptcha/api.js'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="row">
            <h1 class="myfuente" style="color:#01A6BD;">Registrate y empieza a disfrutar </h1>
            <div class="col-lg-6 formularioLogl">
               <img class="img-thumbnail" src="../../Imagenes/Torre-do-Relogio.jpg" />
            </div>        
        <div class="col-lg-5" >
            
                <div class="well well-lg formularioLogR" >
                     <div class="row formulariocompleto">
                        <div class="col-lg-3">
                            <asp:Label ID="Label6" CssClass="formLabel" runat="server" Text="Identificación:"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="TextBox6" CssClass="letras" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row formulariocompleto">
                        <div class="col-lg-3">
                            <asp:Label ID="Label1" CssClass="formLabel" runat="server" Text="Nombre:"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="TextBox1"  runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row formulariocompleto" >
                        <div class="col-lg-3">
                            <asp:Label ID="Label2" CssClass="formLabel" runat="server" Text="Apellido:"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="TextBox2" placeHolder="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row formulariocompleto">
                        <div class="col-lg-3">
                            <asp:Label ID="Label5" CssClass="formLabel" runat="server" Text="E-mail:"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="TextBox3" placeholder="ejemplo@acartagena.com" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row formulariocompleto" >
                        <div class="col-lg-3">    
                            <asp:Label ID="Label3" CssClass="formLabel" runat="server" Text="Celular:"></asp:Label>
                        </div>
                       <div class="col-lg-3">
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row formulariocompleto" >
                        <div class="col-lg-3">
                            <asp:Label ID="Label4" CssClass="formLabel" runat="server" Text="Teléfono:"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row formulariocompleto" >
                        <div class="col-lg-3">
                            <asp:Label ID="Label9" CssClass="formLabel" runat="server" Text="Genero:"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="DropDownList1" CssClass="DropDown1" runat="server" >
                                <asp:ListItem Value="0">Masculino</asp:ListItem>
                                <asp:ListItem Value="1">Femenino</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row formulariocompleto" >
                        <div class="col-lg-3">
                            <asp:Label ID="Label7" CssClass="formLabel" runat="server" Text="Contraseña:"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row formulariocompleto" >
                        <div class="col-lg-3">
                            <asp:Label ID="Label8" CssClass="formLabel" runat="server" Text="Confirmar contraseña:"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    
                    <asp:Button ID="Button1" runat="server" CssClass="btn-sm" Text="Registrar" OnClick="registrar" /><asp:Label ID="Label10" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                </div>


            
        </div>

</asp:Content>
