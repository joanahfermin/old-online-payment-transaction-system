using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SampleRPT1
{
    internal class ImageUtil
    {
        public const int MAX_IMAGE_WIDTH = 1000;
        public const int JPG_QUALITY = 50;

        /// <summary>
        /// This is to reduce the size of the attached picture.
        /// </summary>
        /// <param name="sourceData"></param>
        /// <returns></returns>
        public static byte[] resizeJpg(byte[] sourceData)
        {
            using (Image sourceImage = imageFromByteArray(sourceData))
            {
                int newWidth = sourceImage.Width;
                int newHeight = sourceImage.Height;
                if (newWidth > MAX_IMAGE_WIDTH)
                {
                    newWidth = MAX_IMAGE_WIDTH;
                    newHeight = sourceImage.Height * MAX_IMAGE_WIDTH / sourceImage.Width;
                }
                using (var result = new Bitmap(newWidth, newHeight))
                {
                    using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
                    {
                        g.DrawImage(sourceImage, 0, 0, newWidth, newHeight);
                    }

                    ImageCodecInfo ici = ImageCodecInfo.GetImageEncoders().First(v => v.FormatID == ImageFormat.Jpeg.Guid);
                    EncoderParameters eps = new EncoderParameters(1);
                    eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, JPG_QUALITY);

                    using (var stream = new MemoryStream())
                    {
                        result.Save(stream, ici, eps);
                        return stream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Conversion of the picture to byte array.
        /// </summary>
        /// <param name="sourceData"></param>
        /// <returns></returns>
        public static Image imageFromByteArray(byte[] sourceData)
        {
            using (var ms = new MemoryStream(sourceData))
            {
                return (Bitmap)((new ImageConverter()).ConvertFrom(sourceData));
            }
        }
    }
}
