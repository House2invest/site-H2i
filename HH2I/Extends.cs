namespace House2Invest
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.CompilerServices;

    
    public static class Extends
    {
        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < imageEncoders.Length; i++)
            {
                if (imageEncoders[i].MimeType == mimeType)
                {
                    return imageEncoders[i];
                }
            }
            return null;
        }

        
        public static Image Resize(Image current, int maxWidth, int maxHeight)
        {
            int num;
            int num2;
            if (current.Width > current.Height)
            {
                num = maxWidth;
                num2 = Convert.ToInt32((double) (((double) (current.Height * maxHeight)) / ((double) current.Width)));
            }
            else
            {
                num = Convert.ToInt32((double) (((double) (current.Width * maxWidth)) / ((double) current.Height)));
                num2 = maxHeight;
            }
            Bitmap bitmap = new Bitmap(num, num2);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingQuality=System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode=System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                graphics.DrawImage(current, new Rectangle(0, 0, num, num2));
            }
            return bitmap;
        }

        
        public static byte[] ToByteArray(Image current)
        {
            ImageCodecInfo encoderInfo = GetEncoderInfo("image/jpeg");
            EncoderParameters parameters = new EncoderParameters(1);
            EncoderParameter parameter = new EncoderParameter(Encoder.Quality, (long) 90);
            parameters.Param[0] = parameter;
            using (MemoryStream stream = new MemoryStream())
            {
                current.Save((Stream) stream, encoderInfo, parameters);
                return stream.ToArray();
            }
        }
    }
}

