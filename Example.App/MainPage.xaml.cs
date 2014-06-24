using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using Example.Common;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Example.App
{
    public partial class MainPage : PhoneApplicationPage
    {

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = App.MainViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // generate updated tile on page exit
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                var defTileData = new StandardTileData
                {
                    Title = "",
                    BackgroundImage = TileImage.Render(
                    App.MainViewModel.Title,
                    App.MainViewModel.Row1,
                    App.MainViewModel.Row1Bold,
                    App.MainViewModel.Row1Italic,
                    App.MainViewModel.Row2,
                    App.MainViewModel.Row2Bold,
                    App.MainViewModel.Row2Italic)
                };
                var defTile = ShellTile.ActiveTiles.FirstOrDefault();
                if (defTile != null)
                    defTile.Update(defTileData);
            });
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}