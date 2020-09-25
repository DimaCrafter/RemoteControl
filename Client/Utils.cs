using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace RCClient {
    class Utils {
        public class PareseIntError : Exception {
            public PareseIntError (string message): base(message) {
            }
        }
        public static int ParseInt (string str, int min, int max, string errMessage) {
            var result = int.Parse(str);
            if (result < min)
                throw new PareseIntError(errMessage);
            if (result > max)
                throw new PareseIntError(errMessage);
            return result;
        }

        public static unsafe Bitmap GrayscaleImage (Image _img) {
            var img = (Bitmap) _img.Clone();
            var imgData = img.LockBits(new Rectangle(Point.Empty, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            for (var y = 0; y < img.Height; y++) {
                for (var x = 0; x < img.Width; x++) {
                    var i = (byte*) imgData.Scan0 + imgData.Stride * y + x * 4;
                    i[2] = i[1] = i[0] = (byte) ((i[2] + i[1] + i[0]) / 3);
                }
            }

            img.UnlockBits(imgData);
            return img;
        }
    }
}
