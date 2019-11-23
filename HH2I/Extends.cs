namespace House2Invest
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.CompilerServices;

    [Extension]
    public static class Extends
    {
        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < imageEncoders.Length; i++)
            {
                if (imageEncoders[i].get_MimeType() == mimeType)
                {
                    return imageEncoders[i];
                }
            }
            return null;
        }

        [Extension]
        public static Image Resize(Image current, int maxWidth, int maxHeight)
        {
            int num;
            int num2;
            if (current.get_Width() > current.get_Height())
            {
                num = maxWidth;
                num2 = Convert.ToInt32((double) (((double) (current.get_Height() * maxHeight)) / ((double) current.get_Width())));
            }
            else
            {
                num = Convert.ToInt32((double) (((double) (current.get_Width() * maxWidth)) / ((double) current.get_Height())));
                num2 = maxHeight;
            }
            Bitmap bitmap = new Bitmap(num, num2);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.set_CompositingQuality(2);
                graphics.set_InterpolationMode(7);
                graphics.set_CompositingMode(1);
                graphics.DrawImage(current, new Rectangle(0, 0, num, num2));
            }
            return bitmap;
        }

        [Extension]
        public static byte[] ToByteArray(Image current)
        {
            ImageCodecInfo encoderInfo = GetEncoderInfo("image/jpeg");
            EncoderParameters parameters = new EncoderParameters(1);
            EncoderParameter parameter = new EncoderParameter(Encoder.Quality, (long) 90);
            parameters.get_Param()[0] = parameter;
            using (MemoryStream stream = new MemoryStream())
            {
                current.Save((Stream) stream, encoderInfo, parameters);
                return stream.ToArray();
            }
        }
    }
}

