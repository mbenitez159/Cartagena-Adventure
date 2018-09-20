<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/pagina maestra/maestra.master" AutoEventWireup="true" CodeFile="sitiosInteres.aspx.cs" Inherits="Formulario_form_hereda_sitiosInteres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="form1"  style="margin-top:5%;">
        <h2 style="text-align:center; margin-bottom:2%" >Sitios de Interes en Cartagena</h2>
    <asp:Repeater ID="Repeater1"  runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>

        </HeaderTemplate>
        <ItemTemplate>
            
            <div class="container well" style="padding-top:0%;">
               <strong> <h3 style="text-align:center; "><%# Eval("nombre") %></h3></strong>
              <div class="row">
                    <div class="col-lg-8">
                        <img src="<%# Eval("Portada")%>" style="width:100%; height:380px;" alt=" Hi since Manga" />
                    
                    </div>
                    <div class="col-lg-4">
                         <iframe src="<%# Eval("DirGoo") %>" width="100%" height="380px" frameborder="0" style="border:0" allowfullscreen></iframe>
                    </div>
                  
                    <p style="padding:2%;"><%# Eval("Descripción") %></p>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cartagenaConnectionString %>" SelectCommand="SELECT * FROM [sitiosInteres]"></asp:SqlDataSource>
            
</asp:Content>

