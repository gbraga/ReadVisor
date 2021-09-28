using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ReadVisor.Agent
{
    public class Painter
    {
        public void PrintScreen()
        {
            byte[] result;

            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height))
            using (Graphics g = Graphics.FromImage(bmpScreenCapture))
            {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                 Screen.PrimaryScreen.Bounds.Y,
                                 0, 0,
                                 bmpScreenCapture.Size,
                                 CopyPixelOperation.SourceCopy);

                using (MemoryStream ms = new MemoryStream())
                {
                    var path = "\\images";

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    var rand = DateTime.Now.Millisecond;

                    bmpScreenCapture.Save($"{path}\\{ms}_{rand}.png", ImageFormat.Png);
                    result = ms.ToArray();
                }
            }
        }
    }
}
