using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Mapsui;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Styles;
using Mapsui.Styles.Thematics;

using ShapefileApp.Shapefile;

namespace nuget.MapSuiSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //MyMap.Map.Layers.Add(OpenStreetMap.CreateTileLayer());

            // Create a theme style for shape file

            //Set a gradient theme on the countries layer, based on Population density
            //First create two styles that specify min and max styles
            //In this case we will just use the default values and override the fill-colors
            //using a colorblender. If different line-widths, line- and fill-colors where used
            //in the min and max styles, these would automatically get linearly interpolated.
            var min = new VectorStyle { Outline = new Mapsui.Styles.Pen { Color = Mapsui.Styles.Color.Black } };
            var max = new VectorStyle { Outline = new Mapsui.Styles.Pen { Color = Mapsui.Styles.Color.Black } };

            //Create theme using a density from 0 (min) to 400 (max)
            var style = new GradientTheme("PopDens", 0, 400, min, max) { FillColorBlend = ColorBlend.Rainbow5 };

            var map = new Map
            {
                CRS = "EPSG:3857",
                Transformation = new MinimalTransformation()
            };

            map.Layers.Add(new Layer
            {
                Name = "Countries",
                //DataSource = new ShapeFile(".\\ShapeFiles\\countries.shp", true),
                DataSource = new ShapeFile(".\\ShapeFiles\\thailand_adm1.shp", true),
                //DataSource = new ShapeFile(".\\ShapeFiles\\thailand_adm2.shp", true),
                //DataSource = new ShapeFile(".\\ShapeFiles\\thailand_adm3.shp", true),
                Style = style,
            });

            MyMap.Map = map;
            MyMap.RenderMode = Mapsui.UI.Wpf.RenderMode.Skia;
        }
    }
}
