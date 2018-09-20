<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/pagina maestra/maestra.master" AutoEventWireup="true" CodeFile="Barrios.aspx.cs" Inherits="Formulario_form_hereda_Barrios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="form1"  style="margin-top:6%;">
        <h2 >Barrios de Cartagena</h2>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>

        </HeaderTemplate>
        <ItemTemplate>
            
            <div class="container well" style="padding-top:0%;">
                <h3 style="text-align:center;"><%# Eval("nombre") %></h3>
              <div class="row">
                    <div class="col-lg-8">
                        <img src="<%# Eval("DirImg")%>" style="width:100%; height:450px;" alt=" Hi since Manga" />
                    
                    </div>
                    <div class="col-lg-4">
                         <iframe src="<%# Eval("DirGoo") %>" width="100%" height="450px" frameborder="0" style="border:0" allowfullscreen></iframe>
                    </div>
                    <p style="padding:1.5%;"><%# Eval("texto") %></p>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cartagenaConnectionString %>" SelectCommand="SELECT * FROM [Barrios]"></asp:SqlDataSource>

</div>
</asp:Content>

