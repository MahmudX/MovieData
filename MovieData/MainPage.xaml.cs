using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace MovieData
{
    public sealed partial class MainPage : Page
    {
        bool imageMagnifierButtonValidation = false;
        public MainPage()
        {
            this.InitializeComponent();
            imageMagnifier.IsEnabled = false;
        }
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RootObject myMovieData = await OMDbAPI.GetIMDbData(searchBox.Text.ToString());
                Warning.Text = "";
                movieName.Text = myMovieData.Title;
                movieGenre.Text = myMovieData.Genre;
                movieRated.Text = myMovieData.Rated;
                movieRating.Text = myMovieData.imdbRating;
                movieYear.Text = myMovieData.Year;
                movieDirector.Text = myMovieData.Director;
                movieBoxOffice.Text = myMovieData.BoxOffice;
                moviePoster.Source = new BitmapImage(new Uri(myMovieData.Poster, UriKind.Absolute));
                imageMagnifierButtonValidation = true;
                imageMagnifier.IsEnabled = true;
                imageMagnifier.Content = "Zoom IO";
            }
            catch (Exception)
            {
                Warning.Text = "Please enter a valid movie name.";
                imageMagnifierButtonValidation = false;
            }            
        }

        private void imageMagnifier_Click(object sender, RoutedEventArgs e)
        {
            if (moviePoster.Height == 500)
            {
                moviePoster.Height = 200;
            }
            else if (moviePoster.Height == 200)
            {
                moviePoster.Height = 500;
            }
            
        }
    }
}
