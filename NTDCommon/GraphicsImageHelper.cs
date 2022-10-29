using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    /// <summary>
    /// 界面的绘制
    /// </summary>
    public class GraphicsImageHelper
    {
        private Graphics graphics;
        private Bitmap previewImage { get; set; }
        private Bitmap batchPreviewImage { get; set; }



        public static Bitmap UpdatePreview(Bitmap bitmap, string str, float x, float y)
        {
            Bitmap previewImage = bitmap;
            var g = Graphics.FromImage(previewImage);
            g.DrawString(str, new Font("宋体", 14F, FontStyle.Bold), new SolidBrush(Color.White), x, y);
            g.Dispose();
            return previewImage;
        }
        public static Bitmap UpdatePreview(Image image, string str, float x, float y)
        {
            Bitmap previewImage = new Bitmap(image);
            var g = Graphics.FromImage(previewImage);
            g.DrawString(str, new Font("宋体", 14F, FontStyle.Bold), new SolidBrush(Color.White), x, y);
            g.Dispose();
            return previewImage;
        }
        public static Bitmap UpdatePreview(Bitmap bitmap, string str, Font font, Brush brush, float x, float y)
        {
            Bitmap previewImage = bitmap;
            var g = Graphics.FromImage(previewImage);
            g.DrawString(str, font == null ? new Font("宋体", 14F, FontStyle.Bold) : font, brush == null ? new SolidBrush(Color.White) : brush, x, y);
            g.Dispose();
            return previewImage;
        }

        public static Bitmap UpdatePreview(Image image, string str, Font font, Brush brush, float x, float y)
        {
            Bitmap previewImage = new Bitmap(image);
            var g = Graphics.FromImage(previewImage);
            g.DrawString(str, font == null ? new Font("宋体", 14F, FontStyle.Bold) : font, brush == null ? new SolidBrush(Color.White) : brush, x, y);
            g.Dispose();
            return previewImage;
        }


        public void Init(Bitmap bitmap)
        {
            previewImage = bitmap;
        }
        public void Init(Image image)
        {
            previewImage = new Bitmap(image);
        }
        public Bitmap UpdatePreview(string str, float x, float y)
        {
            if (previewImage == null) return null;
            var g = Graphics.FromImage(previewImage);
            g.DrawString(str, new Font("宋体", 14F, FontStyle.Bold), new SolidBrush(Color.White), x, y);
            g.Dispose();
            return previewImage;
        }
        public Bitmap UpdatePreview(string str, Font font, Brush brush, float x, float y)
        {
            if (previewImage == null) return null;
            var g = Graphics.FromImage(previewImage);
            g.DrawString(str, font == null ? new Font("宋体", 14F, FontStyle.Bold) : font, brush == null ? new SolidBrush(Color.White) : brush, x, y);
            g.Dispose();
            return previewImage;
        }



        public void BatchInit(Bitmap bitmap)
        {
            if (graphics != null)
            {
                graphics.Dispose();
            }
            batchPreviewImage = bitmap;
            graphics = Graphics.FromImage(batchPreviewImage);

        }
        public void BatchInit(Image image)
        {
            if (graphics != null)
            {
                graphics.Dispose();
            }
            batchPreviewImage = new Bitmap(image);
            graphics = Graphics.FromImage(batchPreviewImage);

        }
        public bool BatchUpdatePreview(string str, float x, float y)
        {
            if (batchPreviewImage == null) return false;

            graphics.DrawString(str, new Font("宋体", 14F, FontStyle.Bold), new SolidBrush(Color.White), x, y);
            return true;
        }
        public bool BatchUpdatePreview(string str, Font font, Brush brush, float x, float y)
        {
            if (batchPreviewImage == null) return false;

            graphics.DrawString(str, font == null ? new Font("宋体", 14F, FontStyle.Bold) : font, brush == null ? new SolidBrush(Color.White) : brush, x, y);
            return true;
        }
        public Bitmap BatchCloseOrReturn()
        {
            if (graphics != null)
            {
                graphics.Dispose();
            }
            return batchPreviewImage;
        }

    }
}
