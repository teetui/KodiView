using KodiRPC.RPC;
using KodiRPC.Responses;
using KodiRPC.ExceptionHandling;
using KodiRPC.RPC.RequestResponse.Params.VideoLibrary;
using KodiRPC.RPC.Specifications.Properties;
using KodiRPC.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Documents;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KodiView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var Service = new KodiService();
            var movieParams = new GetMoviesParams() { Properties = MovieProperties.All() };
            var movies = Service.GetMovies(movieParams);

            for (int i = 0; i < 50; i++)
             {
                var row = movies.Result.Movies[i];

                ListViewItem item = new ListViewItem();
                item.Content = new Grid();
                Grid grid = (Grid)item.Content;
                grid.Height = 100;
                grid.Margin = new Thickness(0, 0, 0, 0);

                ColumnDefinition col1 = new ColumnDefinition();
                ColumnDefinition col2 = new ColumnDefinition();
                col1.Width = new GridLength(0, GridUnitType.Auto);
                col2.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(col1);
                grid.ColumnDefinitions.Add(col2);

                Image image = new Image();
                BitmapImage bitmap = new BitmapImage();
                string uriUnescape = Uri.UnescapeDataString(row.Art.Poster).ToString();
                bitmap.UriSource = new Uri(uriUnescape.Substring(8, uriUnescape.Length - 9));
                image.Source = bitmap;
                image.Margin = new Thickness(0, 0, 5, 0);

                RichTextBlock richTextBlock = new RichTextBlock();
                richTextBlock.TextWrapping = TextWrapping.Wrap;
                Paragraph paragraph1 = new Paragraph();
                Paragraph paragraph2 = new Paragraph();
                Run title = new Run();
                Run plot = new Run();
                title.Text = $"{row.Title} ({row.Year})";
                title.FontWeight = FontWeights.Bold;
                plot.Text = row.Plot;
                paragraph1.Inlines.Add(title);
                paragraph2.Inlines.Add(plot);
                richTextBlock.Blocks.Add(paragraph1);
                richTextBlock.Blocks.Add(paragraph2);

                grid.Children.Add(image);
                grid.Children.Add(richTextBlock);

                Grid.SetColumn(image, 0);
                Grid.SetColumn(richTextBlock, 1);

                MediaList.Items.Add(item);
            }
        }
    }
}
