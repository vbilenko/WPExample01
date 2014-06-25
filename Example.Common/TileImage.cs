using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Example.Common
{
    public static class TileImage
    {
        public static Uri Render(
            String title,
            string row1,
            bool row1Bold,
            bool row1Italic,
            string row2,
            bool row2Bold,
            bool row2Italic)
        {
            var bitmap = new WriteableBitmap(Constants.TileWidth, Constants.TileHeight);
            var canvas = new Grid
            {
                Width = bitmap.PixelWidth,
                Height = bitmap.PixelHeight
            };
            var background = new Canvas
            {
                Height = bitmap.PixelHeight,
                Width = bitmap.PixelWidth,
                Background = new SolidColorBrush(Constants.TileBackgroundColor)
            };

            #region title
            var titleBlock = new TextBlock
            {
                Text = title,
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Left,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(Constants.TilePadding),
                TextWrapping = TextWrapping.NoWrap,
                Foreground = new SolidColorBrush(Constants.TileForegroundColor),
                FontSize = Constants.TileTitleFontSize,
                Width = bitmap.PixelWidth - Constants.TilePadding * 2
            };
            #endregion

            #region first row
            var firstRowBlock = new TextBlock
            {
                Text = row1,
                TextAlignment = TextAlignment.Left,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(Constants.TilePadding, Constants.TilePadding * 2 + Constants.TileTitleFontSize, Constants.TilePadding, Constants.TilePadding),
                TextWrapping = TextWrapping.NoWrap,
                Foreground = new SolidColorBrush(Constants.TileForegroundColor),
                FontSize = Constants.TileTextFontSize,
                Width = bitmap.PixelWidth - Constants.TilePadding * 2
            };
            if (row1Bold)
            {
                firstRowBlock.FontWeight = FontWeights.Bold;
            }
            if (row1Italic)
            {
                firstRowBlock.FontStyle = FontStyles.Italic;
            }
            #endregion

            #region second row
            var secondRowBlock = new TextBlock
            {
                Text = row2,
                TextAlignment = TextAlignment.Left,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(Constants.TilePadding, Constants.TilePadding * 3 + Constants.TileTitleFontSize + Constants.TileTextFontSize, Constants.TilePadding, Constants.TilePadding),
                TextWrapping = TextWrapping.Wrap,
                Foreground = new SolidColorBrush(Constants.TileForegroundColor),
                FontSize = Constants.TileTextFontSize,
                Width = bitmap.PixelWidth - Constants.TilePadding * 2
            };
            if (row2Bold)
            {
                secondRowBlock.FontWeight = FontWeights.Bold;
            }
            if (row2Italic)
            {
                secondRowBlock.FontStyle = FontStyles.Italic;
            }
            #endregion

            canvas.Children.Add(titleBlock);
            canvas.Children.Add(firstRowBlock);
            canvas.Children.Add(secondRowBlock);

            bitmap.Render(background, null);
            bitmap.Render(canvas, null);
            bitmap.Invalidate();

            using (var imageStream = new IsolatedStorageFileStream(Constants.TilePath, FileMode.Create, Constants.AppStorage))
            {
                bitmap.WritePNG(imageStream);
            }
            return new Uri("isostore:" + Constants.TilePath, UriKind.Absolute);
        }

    }
}
