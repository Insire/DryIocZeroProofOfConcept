using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace ServiceLibrary
{
    public sealed class AsciiConverterService : IAsciiConverterService
    {
        private static readonly string[] _asciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", " " };

        public string Name => GetType().Name;

        public ICollection<string> Items { get; }

        public AsciiConverterService()
        {
            Items = new ObservableCollection<string>(_asciiChars);
        }

        public string Convert(string imagePath)
        {
            return ConvertInternal(imagePath);
        }

        private static string ConvertInternal(string imagePath)
        {
            using (var image = new Bitmap(imagePath, true))
            {
                //Calculate the new Height of the image from its width

                using (var g = Graphics.FromImage(image))
                {
                    //The interpolation mode produces high quality images

                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, 0, 0, image.Width, image.Height);
                }

                return ConvertToAscii(image);
            }
        }

        private static string ConvertToAscii(Bitmap image)
        {
            var toggle = false;
            var sb = new StringBuilder();

            for (int h = 0; h < image.Height; h++)
            {
                for (int w = 0; w < image.Width; w++)
                {
                    var pixelColor = image.GetPixel(w, h);

                    //Average out the RGB components to find the Gray Color

                    int red = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int green = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    var grayColor = Color.FromArgb(red, green, blue);

                    //Use the toggle flag to minimize height-wise stretch

                    if (!toggle)
                    {
                        int index = (grayColor.R * 10) / 255;
                        sb.Append(_asciiChars[index]);
                    }
                }

                if (!toggle)
                {
                    sb.Append("S");
                    toggle = true;
                }
                else
                    toggle = false;
            }

            return sb.ToString();
        }
    }
}
