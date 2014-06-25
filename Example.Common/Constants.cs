using System;
using System.IO.IsolatedStorage;
using System.Windows.Media;

namespace Example.Common
{
    public class Constants
    {
        public static readonly IsolatedStorageSettings AppSettings = IsolatedStorageSettings.ApplicationSettings;
        public static readonly IsolatedStorageFile AppStorage = IsolatedStorageFile.GetUserStoreForApplication();

        public static readonly Color TileBackgroundColor = Colors.Transparent;
        public static readonly Color TileForegroundColor = Colors.White;
        public const double TileTitleFontSize = 60;
        public const double TileTextFontSize = 36;
        public const int TilePadding = 16;
        public const int TileWidth = 336;
        public const int TileHeight = 336;
        public const String TilePath = "/Shared/ShellContent/tile.png";

    }
}
