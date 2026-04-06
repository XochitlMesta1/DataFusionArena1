using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.Json;
using System.Xml.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataFusionArena1
{
    public partial class Form1 : Form
    {

        List<DataItem> listaDatos = new List<DataItem>();
        Dictionary<string, List<DataItem>> porCategoria = new Dictionary<string, List<DataItem>>();
        Dictionary<int, DataItem> porId = new Dictionary<int, DataItem>();


        public Form1()
        {
            InitializeComponent();
        }

        private void LeerArchivo(string ruta)
        {
            try
            {
                string extension = Path.GetExtension(ruta).ToLower();
                switch (extension)
                {
                    case ".csv": LeerCSV(ruta); break;
                    case ".json": LeerJSON(ruta); break;
                    case ".xml": LeerXML(ruta); break;
                    case ".txt": LeerTXT(ruta); break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en {Path.GetFileName(ruta)}: {ex.Message}");
            }
        }
        private void LeerJSON(string ruta)
        {
            try
            {
                string json = File.ReadAllText(ruta);
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<DataItem> datos = JsonSerializer.Deserialize<List<DataItem>>(json, opciones);
                if (datos != null)
                {
                    foreach (var item in datos)
                    {
                        item.Id = listaDatos.Count + 1;
                        listaDatos.Add(item);
                    }
                }
            }
            catch { MessageBox.Show("JSON mal formado detectado."); }

        }
        private void LeerCSV(string ruta)
        {
            string[] lineas = File.ReadAllLines(ruta);

            for (int i = 1; i < lineas.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lineas[i])) continue;
                string[] columnas = lineas[i].Split(',');

                if (columnas.Length < 4) continue;

                bool esNumero = double.TryParse(columnas[3].Trim(),
                                                System.Globalization.NumberStyles.Any,
                                                System.Globalization.CultureInfo.InvariantCulture,
                                                out double valor);

                if (esNumero)
                {
                    listaDatos.Add(new DataItem
                    {
                        Id = listaDatos.Count + 1,
                        Nombre = columnas[1].Trim(),
                        Categoria = columnas[2].Trim(),
                        Valor = valor
                    });
                }
            }
        }
        private void LeerXML(string ruta)
        {
            try
            {
                XDocument xml = XDocument.Load(ruta);
                var nodos = xml.Descendants().Where(e => e.Name.LocalName.Equals("Item", StringComparison.OrdinalIgnoreCase));

                foreach (var nodo in nodos)
                {
                    double.TryParse(nodo.Element("Valor")?.Value, out double v);
                    listaDatos.Add(new DataItem
                    {
                        Id = listaDatos.Count + 1,
                        Nombre = nodo.Element("Nombre")?.Value ?? "N/A",
                        Categoria = nodo.Element("Categoria")?.Value ?? "General",
                        Valor = v
                    });
                }
            }
            catch { MessageBox.Show("XML inválido o vacío."); }
        }
        private void LeerTXT(string ruta)
        {
            string[] lineas = File.ReadAllLines(ruta);
            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(',');
                if (datos.Length < 3) continue;

                if (double.TryParse(datos[2].Trim(), out double v))
                {
                    listaDatos.Add(new DataItem
                    {
                        Id = listaDatos.Count + 1,
                        Nombre = datos[0].Trim(),
                        Categoria = datos[1].Trim(),
                        Valor = v
                    });
                }
            }
        }


        private void OrganizarEnDiccionarios()
        {
            porCategoria.Clear();
            porId.Clear();

            foreach (var item in listaDatos)
            {
                if (!porId.ContainsKey(item.Id)) porId.Add(item.Id, item);


                if (!porCategoria.ContainsKey(item.Categoria))
                    porCategoria[item.Categoria] = new List<DataItem>();

                porCategoria[item.Categoria].Add(item);
            }
        }

        private void MostrarDatos(List<DataItem> datos)
        {
            dgvListaDatos.DataSource = null;
            dgvListaDatos.DataSource = datos;
            dgvListaDatos.Refresh();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog
            {
                Filter = "Archivos|*.csv;*.json;*.xml;*.txt",
                Multiselect = true
            };

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                listaDatos.Clear();
                foreach (string archivo in abrir.FileNames)
                {
                    LeerArchivo(archivo);
                }
                OrganizarEnDiccionarios();
                MostrarDatos(listaDatos);
                MessageBox.Show($"Carga exitosa: {listaDatos.Count} registros.");
            }
        }


        private void btnAgrupar_Click_1(object sender, EventArgs e)
        {
            porCategoria.Clear();

            foreach (var item in listaDatos)
            {
                if (!porCategoria.ContainsKey(item.Categoria))
                {
                    porCategoria[item.Categoria] = new List<DataItem>();
                }
                porCategoria[item.Categoria].Add(item);
            }

            MessageBox.Show($"Datos agrupados en {porCategoria.Count} categorías.");
        }

        private void btnOrdenar_Click_1(object sender, EventArgs e)
        {
            listaDatos = listaDatos.OrderBy(x => x.Valor).ToList();
            MostrarDatos(listaDatos);
        }

        private void btnDuplicados_Click_1(object sender, EventArgs e)
        {
            HashSet<string> nombresVistos = new HashSet<string>();
            List<DataItem> duplicados = new List<DataItem>();

            foreach (var item in listaDatos)
            {
                if (!nombresVistos.Add(item.Nombre))
                {
                    duplicados.Add(item);
                }
            }

            if (duplicados.Count > 0)
            {
                MostrarDatos(duplicados);
                MessageBox.Show($"Se encontraron {duplicados.Count} registros duplicados por nombre.");
            }
            else
            {
                MessageBox.Show("No se encontraron duplicados.");
            }
        }

        private void btnGrafica_Click_1(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();
            chart1.Titles.Clear();

            ChartArea area = new ChartArea();
            chart1.ChartAreas.Add(area);

            Legend legend = new Legend();
            chart1.Legends.Add(legend);

            Series serie = new Series("Categorías");
            serie.ChartType = SeriesChartType.Pie;
            serie.IsValueShownAsLabel = true;

            var resumen = listaDatos
                .GroupBy(x => x.Categoria)
                .Select(g => new
                {
                    Categoria = g.Key,
                    Total = g.Count()
                });

            foreach (var item in resumen)
            {
                serie.Points.AddXY(item.Categoria, item.Total);
            }

            chart1.Series.Add(serie);
            chart1.Titles.Add("Distribución por categorías");
        }

        private void btnBuscarId_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscarID.Text, out int idBusqueda))
            {
                if (porId.ContainsKey(idBusqueda))
                {
                    List<DataItem> resultado = new List<DataItem> { porId[idBusqueda] };
                    MostrarDatos(resultado);
                }
                else
                {
                    MessageBox.Show("ID no encontrado en el sistema.");
                }
            }
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            string categoriaFiltro = txtCategoria.Text.Trim();
            List<DataItem> filtrados = new List<DataItem>();

            foreach (var item in listaDatos)
            {
                if (item.Categoria.Equals(categoriaFiltro, StringComparison.OrdinalIgnoreCase))
                {
                    filtrados.Add(item);
                }
            }

            MostrarDatos(filtrados);
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {

            MostrarDatos(listaDatos);
        }
    }
}