<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/pagina maestra/maestra.master" AutoEventWireup="true" CodeFile="Hotel.aspx.cs" Inherits="Formulario_form_hereda_Hotel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="row">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
<div  style="margin-bottom:0; height:auto;">
        <div id="Ali" class="container BuscadorHotel col-lg-6 well well-lg">        
            <h3>¿Estas búscando un hotel?</h3>
            <div class="row">
                
                <div class="col-lg-6 objetobuscador" >
                    <asp:Label ID="Label1" runat="server" Text="Entrada"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>                  
                    <asp:ImageButton ID="ImageButton1" ImageUrl="~/Imagenes/calendar.png" OnClick="ImageButton1_Click" runat="server" /><asp:Calendar ID="Calendar1" OnSelectionChanged="Calendar1_SelectionChanged"  runat="server"></asp:Calendar>
                </div> 
                <div class="col-lg-6 objetobuscador">
                    <asp:Label ID="Label2" runat="server" Text="Salida"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>    
                    <asp:ImageButton ID="ImageButton2" ImageUrl="~/Imagenes/calendar.png"  OnClick="ImageButton2_Click" runat="server" /><asp:Calendar ID="Calendar2" OnSelectionChanged="Calendar2_SelectionChanged" runat="server"></asp:Calendar>
                </div>    
                <div class="row orientarDerecha objetobuscador">
                    <div class="col-lg-12">
                                            
                    </div>
                </div>    
                <div class="container-fluid orientarDerecha">
                      <div class="row">
                        <div class="col-lg-4 objetobuscador">                            
                            <asp:Label ID="Label3" Text="Adultos" runat="server" />
                            <div class="row objetobuscador">
                                <asp:DropDownList ID="DropDownList1" CssClass="DropDown2" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-4 objetobuscador">
                            <asp:Label ID="Label4" Text="Menores" runat="server" />
                            <div class="row objetobuscador">
                                <asp:DropDownList ID="DropDownList2" CssClass="DropDown2" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>    
                </div>            
               <div class="row">
                    <div class="col-lg- objetobuscador">
                        
                    </div>
                </div>
                <div class="row orientarDerecha">
                    <div class="col-lg-12">
                        <asp:Button Text="Búscar" OnClick="Unnamed_Click" runat="server" />
                    </div>
                </div>
            </div>        
          </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="col-lg-4 container" style="margin-top:4%;width:41%; height:420px; float:right;">
            <div class="well well-lg" style="height:400px;">
                <div id="slider1" class="slider page-header" > 
                    <div id="myCarousel1" class="carousel slide" data-ride="carousel">
                      <!-- Indicators -->
                      <ol class="carousel-indicators">
                        <li data-target="#myCarousel1" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel1" data-slide-to="1"></li>
                        <li data-target="#myCarousel1" data-slide-to="2"></li>
                        <li data-target="#myCarousel1" data-slide-to="3"></li>
                      </ol>
                      <!-- Wrapper for slides -->
                      <div class="carousel-inner" role="listbox">
                        <div class="item active">
                          <img style="height:300px;" src="../../Imagenes/img-best/img1.jpg" alt="Chania"/>
                          <div class="carousel-caption">
                              <h4>Ofertas exclusivas</h4>
                            
                          </div>
                        </div>

                        <div class="item">
                          <img style="height:300px;"  src="../../Imagenes/img-best/img2.jpg" alt="Chania"/>
                          <div class="carousel-caption">
                            <h3>Descubre Cartagena</h3>
                            <p>¡Empieza ahora!</p>
                          </div>
                        </div>

                        <div class="item">
                          <img style="height:300px;"  src="../../Imagenes/img-best/img3.jpg"  alt="Flower" />
                          <div class="carousel-caption">
                            <h4>Seguro</h4>
                            <p>Mantenemos su identidad protegida.</p>
                          </div>
                        </div>

                        <div class="item">
                          <img style="height:300px;"  src="../../Imagenes/img-best/img4.jpg"  alt="Flower" />
                          <div class="carousel-caption">
                            <h4>Exelentes paquetes</h4>                            
                          </div>
                        </div>
                      </div>
                </div>        
        </div>
    </div>
</div>
</div>

</div>
    <div class="row " >
        <div class="col-lg-4" style="margin-top:1%; height:420px;">
                        <div class="well well-lg" style="height:400px;">
                    <div id="slider2" class="slider page-header"> 
                        <div id="myCarousel2" class="carousel slide" data-ride="carousel">
                          <!-- Indicators -->
                          <ol class="carousel-indicators">
                            <li data-target="#myCarousel2" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel2" data-slide-to="1"></li>
                            <li data-target="#myCarousel2" data-slide-to="2"></li>
                            <li data-target="#myCarousel2" data-slide-to="3"></li>
                          </ol>
                          <!-- Wrapper for slides -->
                          <div class="carousel-inner" role="listbox">
                            <div class="item active">
                              <img style="height:300px;" src="../../Imagenes/img-best/img5.jpg" alt="Chania"/>
                              <div class="carousel-caption">
                                  <h4>Facil y Rápido</h4>
                              </div>
                            </div>

                            <div class="item">
                              <img style="height:300px;"  src="../../Imagenes/img-best/img6.jpg" alt="Chania"/>
                              <div class="carousel-caption">
                                <p>Descubre descuentos exclusivos</p>
                              </div>
                            </div>

                            <div class="item">
                              <img style="height:300px;"  src="../../Imagenes/img-best/img7.jpg"  alt="Flower" />
                              <div class="carousel-caption">

                              </div>
                            </div>

                            <div class="item">
                              <img style="height:300px;"  src="../../Imagenes/img-best/img8.jpg"  alt="Flower" />
                              <div class="carousel-caption">

                              </div>
                            </div>
                          </div>
                    </div>
        
                </div>
            </div>
        </div>
        <div class="col-lg-4" style="margin-top:1%; height:420px;">
                        <div class="well well-lg" style="height:400px;">
                    <div id="slider3" class="slider page-header"> 
                        <div id="myCarousel3" class="carousel slide" data-ride="carousel">
                          <!-- Indicators -->
                          <ol class="carousel-indicators">
                            <li data-target="#myCarousel3" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel3" data-slide-to="1"></li>
                            <li data-target="#myCarousel3" data-slide-to="2"></li>
                            <li data-target="#myCarousel3" data-slide-to="3"></li>
                          </ol>
                          <!-- Wrapper for slides -->
                          <div class="carousel-inner" role="listbox">
                            <div class="item active">
                              <img style="height:300px;" src="../../Imagenes/img-best/img9.jpg" alt="Chania"/>
                              <div class="carousel-caption">
                              </div>
                            </div>

                            <div class="item">
                              <img style="height:300px;"  src="../../Imagenes/img-best/img10.jpg" alt="Chania"/>
                              <div class="carousel-caption">

                              </div>
                            </div>

                            <div class="item">
                              <img style="height:300px;"  src="../../Imagenes/img-best/img11.png"  alt="Flower" />
                              <div class="carousel-caption">

                              </div>
                            </div>

                            <div class="item">
                              <img style="height:300px;"  src="../../Imagenes/img-best/img12.jpg"  alt="Flower" />
                              <div class="carousel-caption">

                              </div>
                            </div>
                          </div>
                    </div>
        
                </div>
            </div>
        </div>
        <div class="col-lg-4" style="margin-top:1%; height:420px;">
                        <div class="well well-lg" style="height:400px;">
                    <div id="slider4" class="slider page-header"> 
                        <div id="myCarousel4" class="carousel slide" data-ride="carousel">
                          <!-- Indicators -->
                          <ol class="carousel-indicators">
                            <li data-target="#myCarousel4" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel4" data-slide-to="1"></li>
                            <li data-target="#myCarousel4" data-slide-to="2"></li>
                            <li data-target="#myCarousel4" data-slide-to="3"></li>
                          </ol>
                          <!-- Wrapper for slides -->
                          <div class="carousel-inner" role="listbox">
                            <div class="item active">
                              <img style="height:300px;" src="../../Imagenes/img-best/img13.jpg" alt="Chania"/>
                              <div class="carousel-caption">

                              </div>
                            </div>

                            <div class="item">
                              <img style="height:300px;"  src="../../Imagenes/img-best/img14.jpg" alt="Chania"/>
                              <div class="carousel-caption">

                              </div>
                            </div>

                            <div class="item">
                              <img style="height:300px;"  src="../../Imagenes/img-best/img15.jpg"  alt="Flower" />
                              <div class="carousel-caption">

                              </div>
                            </div>

                            <div class="item">
                              <img style="height:300px;"  src="../../Imagenes/img-best/img16.jpg"  alt="Flower" />
                              <div class="carousel-caption">

                              </div>
                            </div>
                          </div>
                    </div>
        
                </div>
            </div>
        </div>
    </div>
</asp:Content>

