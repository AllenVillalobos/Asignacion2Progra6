using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Asignacion2Progra6.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///<summary>
            /// Se ejecuta al cargar la página por primera vez
            /// Se inicializan los GridView a nulo
            ///</summary>
            if (!IsPostBack)
            {
                gvPadres.DataSource = null;
                gvPadres.DataBind();
                gvHijos.DataSource = null;
                gvHijos.DataBind();
                gvMadres.DataSource = null;
                gvMadres.DataBind();
            }
        }
        /// <summary>
        /// Este método se ejecuta al hacer clic en el botón "Cargar"
        /// Este método lee un archivo XML cargado por el usuario,
        /// Deserializa su contenido y lo muestra en tres GridView diferentes:
        /// Uno para padres, otro para hijos y otro para madres
        /// </summary>
        public void btnCargar_Click(object sender, EventArgs e)
        {
            /// Verifica si se ha cargado un archivo
            if (fileUpload.HasFile)
            {
                try
                {
                    // Lee el contenido del archivo XML
                    using (var reader = new StreamReader(fileUpload.PostedFile.InputStream))
                    {
                        // Convierte el contenido del archivo en un XDocument para su manipulación
                        string xmlContent = reader.ReadToEnd();
                        XDocument xDocument = XDocument.Parse(xmlContent);
                        // Consulta LINQ para extraer datos de padres, hijos y madres
                        var padres = from padre in xDocument.Descendants("Padre")
                                     select new
                                     {
                                         Nombre = padre.Element("Nombre").Value,
                                         FechaNacimiento = padre.Element("FechaNacimiento").Value,
                                         Edad = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(DateTime.Parse(padre.Element("FechaNacimiento").Value).Year),
                                         Peso = padre.Element("Peso").Value,
                                         Altura = padre.Element("Altura").Value
                                     };
                        // Asigna los datos al GridView correspondiente y lo enlaza
                        gvPadres.DataSource = padres.ToList();
                        gvPadres.DataBind();
                        var hijos = from hijo in xDocument.Descendants("Hijo")
                                    select new
                                    {
                                        Nombre = hijo.Element("Nombre").Value,
                                        FechaNacimiento = hijo.Element("FechaNacimiento").Value,
                                        Edad = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(DateTime.Parse(hijo.Element("FechaNacimiento").Value).Year),
                                        Peso = hijo.Element("Peso").Value,
                                        Altura = hijo.Element("Altura").Value
                                    };
                        gvHijos.DataSource = hijos.ToList();
                        gvHijos.DataBind();
                        var madres = from madre in xDocument.Descendants("Madre")
                                     select new
                                     {
                                         Nombre = madre.Element("Nombre").Value,
                                         FechaNacimiento = madre.Element("FechaNacimiento").Value,
                                         Edad = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(DateTime.Parse(madre.Element("FechaNacimiento").Value).Year),
                                         Peso = madre.Element("Peso").Value,
                                         Altura = madre.Element("Altura").Value
                                     };
                        gvMadres.DataSource = madres.ToList();
                        gvMadres.DataBind();
                        lblMensaje.Text = "Archivo cargado exitosamente.";
                        lblMensaje.CssClass = "text-success alert alert-light";
                        lblMensaje.Visible = true;
                    }
                }
                catch
                {
                    lblMensaje.Text = "Error al cargar el archivo. Asegúrese de que el archivo sea un XML válido.";
                    lblMensaje.CssClass = "text-danger alert alert-light";
                    lblMensaje.Visible = true;
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, seleccione un archivo para cargar.";
                lblMensaje.CssClass = "text-warning alert alert-light";
                lblMensaje.Visible = true;
            }
        }

        /// <summary>
        /// Metodo que se ejecuta al hacer clic en el botón "Ordenar por Nombre"
        /// Este método ordena los datos mostrados en los GridView
        /// Respecto al nombre de cada persona (padres, hijos y madres)
        /// Recoge los datos actuales de cada GridView,
        /// Para luego ordenarlos alfabéticamente por nombre
        /// </summary>
        public void btnNombre_Click(object sender, EventArgs e)
        {
            // Verifica si hay datos en los GridView
            if (gvHijos.Rows.Count != 0 || gvMadres.Rows.Count != 0 || gvPadres.Rows.Count != 0)
            {
                // Crea listas dinámicas para almacenar los datos de cada GridView
                var padres = new List<dynamic>();

                // Recorre las filas del GridView de padres y agrega los datos a la lista
                foreach (GridViewRow gridView in gvPadres.Rows)
                {
                    var padre = new
                    {
                        Nombre = HttpUtility.HtmlDecode(gridView.Cells[0].Text),
                        FechaNacimiento = gridView.Cells[1].Text,
                        Edad = Convert.ToInt32(gridView.Cells[2].Text),
                        Peso = gridView.Cells[3].Text,
                        Altura = gridView.Cells[4].Text
                    };
                    padres.Add(padre);
                }

                // Ordena la lista de padres por nombre
                var padresOrdenados = from padre in padres
                                      orderby padre.Nombre
                                      select padre;

                // Asigna los datos ordenados al GridView y lo enlaza
                gvPadres.DataSource = padresOrdenados.ToList();
                gvPadres.DataBind();

                // Repite el proceso para los hijos
                var hijos = new List<dynamic>();
                foreach (GridViewRow gridView in gvHijos.Rows)
                {
                    var hijo = new
                    {
                        Nombre = HttpUtility.HtmlDecode(gridView.Cells[0].Text),
                        FechaNacimiento = gridView.Cells[1].Text,
                        Edad = Convert.ToInt32(gridView.Cells[2].Text),
                        Peso = gridView.Cells[3].Text,
                        Altura = gridView.Cells[4].Text
                    };
                    hijos.Add(hijo);
                }

                var hijosOrdenados = from hijo in hijos
                                     orderby hijo.Nombre
                                     select hijo;
                gvHijos.DataSource = hijosOrdenados.ToList();
                gvHijos.DataBind();

                // Repite el proceso para las madres
                var madres = new List<dynamic>();
                foreach (GridViewRow gridView in gvMadres.Rows)
                {
                    var madre = new
                    {
                        Nombre = HttpUtility.HtmlDecode(gridView.Cells[0].Text),
                        FechaNacimiento = gridView.Cells[1].Text,
                        Edad = Convert.ToInt32(gridView.Cells[2].Text),
                        Peso = gridView.Cells[3].Text,
                        Altura = gridView.Cells[4].Text
                    };
                    madres.Add(madre);
                }

                var madresOrdenadas = from madre in madres
                                      orderby madre.Nombre
                                      select madre;
                gvMadres.DataSource = madresOrdenadas.ToList();
                gvMadres.DataBind();

                lblMensaje.Text = "Datos ordenados por nombre";
                lblMensaje.CssClass = "text-success alert alert-light";
                lblMensaje.Visible = true;
            }
            else
            {
                lblMensaje.Text = "Por favor, seleccione un archivo para cargar.";
                lblMensaje.CssClass = "text-warning alert alert-light";
                lblMensaje.Visible = true;
            }
        }
        /// <summary>
        /// Este método se ejecuta al hacer clic en el botón "Ordenar por Edad"
        /// Metodo que ordena los datos mostrados en los GridView
        /// De acuerdo a la edad de cada persona (padres, hijos y madres)
        /// Al igual que el método anterior,
        /// Recoge los datos actuales de cada GridView
        /// Para luego ordenarlos por edad
        /// </summary>

        public void btnEdad_Click(object sender, EventArgs e)
        {
            // Verifica si hay datos en los GridView
            if (gvHijos.Rows.Count != 0 || gvMadres.Rows.Count != 0 || gvPadres.Rows.Count != 0)
            {
                // Crea listas dinámicas para almacenar los datos de cada GridView
                var padres = new List<dynamic>();

                // Recorre las filas del GridView de padres y agrega los datos a la lista
                foreach (GridViewRow gridView in gvPadres.Rows)
                {
                    var padre = new
                    {
                        Nombre = HttpUtility.HtmlDecode(gridView.Cells[0].Text),
                        FechaNacimiento = gridView.Cells[1].Text,
                        Edad = Convert.ToInt32(gridView.Cells[2].Text),
                        Peso = gridView.Cells[3].Text,
                        Altura = gridView.Cells[4].Text
                    };
                    padres.Add(padre);
                }

                // Ordena la lista de padres por edad
                var padresOrdenados = from padre in padres
                                      orderby padre.Edad
                                      select padre;

                // Asigna los datos ordenados al GridView y lo enlaza
                gvPadres.DataSource = padresOrdenados.ToList();
                gvPadres.DataBind();

                // Repite el proceso para los hijos
                var hijos = new List<dynamic>();
                foreach (GridViewRow gridView in gvHijos.Rows)
                {
                    var hijo = new
                    {
                        Nombre = HttpUtility.HtmlDecode(gridView.Cells[0].Text),
                        FechaNacimiento = gridView.Cells[1].Text,
                        Edad = Convert.ToInt32(gridView.Cells[2].Text),
                        Peso = gridView.Cells[3].Text,
                        Altura = gridView.Cells[4].Text
                    };
                    hijos.Add(hijo);
                }

                var hijosOrdenados = from hijo in hijos
                                     orderby hijo.Edad
                                     select hijo;

                gvHijos.DataSource = hijosOrdenados.ToList();
                gvHijos.DataBind();

                // Repite el proceso para las madres
                var madres = new List<dynamic>();
                foreach (GridViewRow gridView in gvMadres.Rows)
                {
                    var madre = new
                    {
                        Nombre = HttpUtility.HtmlDecode(gridView.Cells[0].Text),
                        FechaNacimiento = gridView.Cells[1].Text,
                        Edad = Convert.ToInt32(gridView.Cells[2].Text),
                        Peso = gridView.Cells[3].Text,
                        Altura = gridView.Cells[4].Text
                    };
                    madres.Add(madre);
                }

                var madresOrdenadas = from madre in madres
                                      orderby madre.Edad
                                      select madre;

                gvMadres.DataSource = madresOrdenadas.ToList();
                gvMadres.DataBind();

                lblMensaje.Text = "Datos ordenados por edad";
                lblMensaje.CssClass = "text-success alert alert-light";
                lblMensaje.Visible = true;
            }
            else
            {
                lblMensaje.Text = "Por favor, seleccione un archivo para cargar.";
                lblMensaje.CssClass = "text-warning alert alert-light";
                lblMensaje.Visible = true;
            }
        }
    }
}