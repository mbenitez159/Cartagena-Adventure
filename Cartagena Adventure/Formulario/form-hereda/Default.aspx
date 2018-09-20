<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/pagina maestra/maestra.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Formulario_form_hereda_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
    <script src="../Javascrip/admincontenido.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="slider" class="slider page-header"> 
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
              <!-- Indicators -->
              <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
                <li data-target="#myCarousel" data-slide-to="3"></li>
              </ol>
              <!-- Wrapper for slides -->
              <div class="carousel-inner" role="listbox">
                <div class="item active">
                  <img style="height:450px;" src="../../Imagenes/img-slider/slider1.jpg" alt="Chania" />
                  <div class="carousel-caption">
                      <h3>Descubre Cartagena</h3>                    
                  </div>
                </div>

                <div class="item">
                  <img style="height:450px;"  src="../../Imagenes/img-slider/slider2.jpg" alt="Chania"/>
                  <div class="carousel-caption">

                  </div>
                </div>

                <div class="item">
                  <img style="height:450px;"  src="../../Imagenes/img-slider/slider3.jpg"  alt="Flower" />
                  <div class="carousel-caption">

                  </div>
                </div>

                <div class="item">
                  <img style="height:450px;"  src="../../Imagenes/img-slider/slider4.jpg" alt="Flower"/>
                  <div class="carousel-caption">

                  </div>
                </div>
              </div>

              <!-- controls  del slider-->
              <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
              </a>
              <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
              </a>
        </div>
        
    </div>
        
        <div class="row i1 ">
        <div class="col-lg-4 imagenesCuadro">            
            <div class="img-rounded well">
                <h4>Torre del reloj</h4>
                <img class="img-responsive img-rounded well well-sm" src="../../Imagenes/imagen-co/sector_antiguo_de_la_ciudad_de_cartagena_de_indias_2.jpg" />
                <p>Es el símbolo representativo de Cartagena, y puerta principal de entrada a la ciudad. La torre del reloj fue añadida en el siglo XIX. Delante de la torre, se encuentra una estatua de Pedro de Heredia, el fundador de la ciudad. Además Esta construcción se encuentra ubicada entre las plazas de los coches y de la paz.</p>
                <asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-info" runat="server" Text="Leer más" />
            </div>
        </div>
        <div class="col-lg-4 imagenesCuadro">
            <div class="img-rounded well">
                <h4>Bahía de Cartagena</h4>
                <img class="img-responsive img-rounded well well-sm" src="../../Imagenes/imagen-co/Vista-nocturna-de-Cartagena_.jpg"/>
                <p>Puerto Bahía es un terminal portuario a gran escala de acceso público, con infraestructura de talla mundial para el manejo de importaciones y exportaciones de hidrocarburos. Puerto Bahía se estructura bajo el concepto de complejo portuario a gran escala de uso público.</p>
                <asp:Button ID="Button2" OnClick="Button2_Click" CssClass="btn btn-info" runat="server" Text="Leer más" />
            </div>
        </div>
        <div class="col-lg-4 imagenesCuadro">
            <div class="img-rounded well">
                <h4>Playas</h4>
                   <img class="img-responsive img-rounded well well-sm" src="../../Imagenes/imagen-co/beach%20in%20cartagena.jpg"/>
                <p>En Cartagena puedes encontrar playas verdaderamente hermosas y espectaculares, más tranquilas y con más posibilidades de realizar actividades en el mar, de una manera mucho más agradable, libre de vendedores ambulantes y algunas de estas son muy tranquilas y propicias para realizar buceo.</p>
                <asp:Button ID="Button3" OnClick="Button3_Click" CssClass="btn btn-info" runat="server" Text="Leer más" />
            </div>
        </div>
    </div>
        <div class="row i1 ">
            <div class="col-lg-4 imagenesCuadro">            
                <div class="img-rounded well">
                    <h4>Castillo San Felipe de Barajas</h4>
                    <img class="img-responsive img-rounded well well-sm" src="../../Imagenes/imagen-co/blas-lezo-estatua.jpg" />
                    <p>Sin lugar duda es la mayor fortificación construida por los españoles en las colonias, originalmente se construyó entre 1639 y 1657, y en 1762 fue ampliado. Muestra de la ingeniería militar de la Época, unos interminables túneles que servían para distribuir provisiones y facilitar la evacuación.</p>
                    <asp:Button ID="Button4" OnClick="Button4_Click" CssClass="btn btn-info" runat="server" Text="Leer más" />
                </div>
            </div>
            <div class="col-lg-4 imagenesCuadro">
                <div class="img-rounded well">
                    <h4>Muelle de los Pegasos</h4>
                    <img class="img-responsive img-rounded well well-sm" src="../../Imagenes/imagen-co/719.jpg" />
                    <p>El Muelle de los Pegasos es hoy un centro de actividades culturales y un embarcadero turístico. Su decoración muestra dos esculturas de pegasos, los caballos alados de la mitología griega. El Muelle de los Pegasos está en la Bahía de las Ánimas,a 100 metros de la Torre del Reloj, la entrada principal a la Ciudad Amurallada.</p>
                    <asp:Button ID="Button5" OnClick="Button5_Click" CssClass="btn btn-info" runat="server" Text="Leer más" />
                </div>
            </div>
            <div class="col-lg-4 imagenesCuadro">
                <div class="img-rounded well">
                    <h4>Fuerte de San Fernando</h4>
                        <img class="img-responsive img-rounded well well-sm" src="../../Imagenes/imagen-co/010_Fuerte_San_Fernando_Cartagena_Colombia.jpg" />
                    <p>Con forma de herradura, el fuerte de San Fernando de Bocachica fue construido sobre un lugar alto de la isla de Carex (tortuga, en lengua caribe) que hoy se llama Tierrabomba. Los planos los hizo el ingeniero Mac Evan y las obras se iniciaron en 1753. En ambos extremos surgen dos baluartes que miran hacia el norte.</p>
                    <asp:Button ID="Button6" OnClick="Button6_Click" CssClass="btn btn-info" runat="server" Text="Leer más" />
                </div>
            </div>
        </div>

   <div class="  i1 ">
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d125576.5650698972!2d-75.57785616672611!3d10.40030349772769!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8ef625e7ae9d1351%3A0xb161392e033f26ca!2sCartagena%2C+Bol%C3%ADvar!5e0!3m2!1ses-419!2sco!4v1462125146179" width="100%" height="520px" frameborder="0" style="border:0" allowfullscreen></iframe>
    </div> 


</asp:Content>

