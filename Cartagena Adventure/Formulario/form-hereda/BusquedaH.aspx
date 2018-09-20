<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/pagina maestra/maestra.master" AutoEventWireup="true" CodeFile="BusquedaH.aspx.cs" Inherits="Formulario_form_hereda_BusquedaH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>

        </HeaderTemplate>
        
        <ItemTemplate>
            
            <div class="container well" style=" margin-top:2%;">
                
              <div class="row" style="padding:0; margin:0; font-family:Arial;">
                    <div class="col-lg-5" style=" padding:0; margin:0;">                        
                                        
                                    <div id="slider1" class="slider page-header" style=" padding:0; margin:0;" > 
                                        <div id="M<%#Eval("codigo") %>" class="carousel slide" data-ride="carousel">
                                            <!-- Indicators -->
                                            <ol class="carousel-indicators">
                                            <li data-target="#M<%#Eval("codigo") %>" data-slide-to="0" class="active"></li>
                                            <li data-target="#M<%#Eval("codigo") %>" data-slide-to="1"></li>
                                            <li data-target="#M<%#Eval("codigo") %>" data-slide-to="2"></li>
                                            <li data-target="#M<%#Eval("codigo") %>" data-slide-to="3"></li>
                                            </ol>
                                            <!-- Wrapper for slides -->
                                            <div class="carousel-inner" role="listbox">
                                            <div class="item active">
                                                <img style="height:300px;" src="<%# Eval("ImgPH") %>" alt="Chania"/>

                                            </div>

                                            <div class="item">
                                                <img style="height:300px;"  src="<%# Eval("Img1H") %>" alt="Chania"/>
                                                <div class="carousel-caption">

                                                </div>
                                            </div>

                                            <div class="item">
                                                <img style="height:300px;"  src="<%# Eval("ImgHA1") %>"  alt="Flower" />

                                            </div>

                                            <div class="item">
                                                <img style="height:300px;"  src="<%# Eval("ImgHA2") %>"  alt="Flower" />
                                            </div>
                                            </div>
                                    </div>        
                            </div>
                                
                           
                    </div>
                <div class="col-lg-4" >
                  <h3 style="text-align:center;"><%# Eval("nombre") %></h3><br />
                    
                          <div style="margin-left:4%;">
                             <h6>Número de Adultos:  <%# Eval("numeroAdultos") %></h6><br />

                            <h6>Número de Niños:<%#  Eval("numeroNiños") %></h6><br />

                            <h6>Número de Camas Dobles:  <%# Eval("camasDobles") %></h6><br />  
                           </div>                                  
               
                    </div>
                    <div class="col-lg-3 img-rounded" style="height:300px; background:rgba(17, 174, 224, 0.13);">
                        <br /><h6 style="text-align:center;">Habitación por Noche</h6>
                        <strong><h4>$<%# Eval("precio") %></h4></strong><br />
                        
                      <div style="text-align:right;"> Imp y tasas:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$<%# Eval("Imp") %></div><br />
                        <div style="text-align:right;"> Cargos:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$10000</div>
                        <hr style="color:red;"/>
                        <h5>Total</h5> <h4 style="text-align:right;">$<%# Eval("total") %></h4>
                        <asp:Button ID="btn" CssClass="btn btn-info"  runat="server" OnClick="Button1_Click" Text="Reservar" />
                        
                        
                    </div>
                </div>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cartagenaConnectionString %>" SelectCommand="  "></asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

