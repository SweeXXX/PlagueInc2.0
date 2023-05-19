using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plague_Inc._2._0.Classes
{
    internal static class ImageWork
    {
        internal static Image CreateDimmedImage(Image originalImage)
        {
            // Create a new bitmap with the same dimensions as the original image
            Bitmap dimmedBitmap = new Bitmap(originalImage.Width, originalImage.Height);

            using (Graphics g = Graphics.FromImage(dimmedBitmap))
            {
                // Create a color matrix to apply the dimming effect
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
            new float[] {0.5f, 0, 0, 0, 0}, // Red component
            new float[] {0, 0.5f, 0, 0, 0}, // Green component
            new float[] {0, 0, 0.5f, 0, 0}, // Blue component
            new float[] {0, 0, 0, 1, 0}, // Alpha component
            new float[] {0, 0, 0, 0, 1} // Additional transformations
                });

                using (ImageAttributes imageAttributes = new ImageAttributes())
                {
                    // Apply the color matrix to the image attributes
                    imageAttributes.SetColorMatrix(colorMatrix);

                    // Draw the original image onto the dimmed bitmap using the image attributes
                    g.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                        0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, imageAttributes);
                }
            }

            return dimmedBitmap;
        }
    }
}
