using System;
using System.Collections.Generic;
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

        }
        public void btnCargar_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                try
                {
                    using (var reader = new StreamReader(fileUpload.PostedFile.InputStream))
                    {
                        string xmlContent = reader.ReadToEnd();
                        XDocument xDocument = XDocument.Parse(xmlContent);
                        var padres = from padre in xDocument.Descendants("Padre")
                                     select new
                                     {
                                         Nombre = padre.Element("Nombre").Value,
                                         FechaNacimiento = padre.Element("FechaNacimiento").Value,
                                         Edad = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(DateTime.Parse(padre.Element("FechaNacimiento").Value).Year),
                                         Peso = padre.Element("Peso").Value,
                                         Altura = padre.Element("Altura").Value
                                     };
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
                    }
                }
                catch
                {

                }
            }
        }
        public void btnNombre_Click(object sender, EventArgs e)
        {
            var padres = new List<dynamic>();
            foreach(GridViewRow gridView in gvPadres.Rows)
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

            var padresOrdenados = from padre in padres
                                  orderby padre.Nombre
                                  select padre;
            gvPadres.DataSource = padresOrdenados.ToList();
            gvPadres.DataBind();
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
        }
        public void btnEdad_Click(object sender, EventArgs e)
        {
            var padres = new List<dynamic>();   
            foreach(GridViewRow gridView in gvPadres.Rows)
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
            var padresOrdenados = from padre in padres
                                  orderby padre.Edad
                                  select padre;
            gvPadres.DataSource = padresOrdenados.ToList();
            gvPadres.DataBind();

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
        }
    }
}