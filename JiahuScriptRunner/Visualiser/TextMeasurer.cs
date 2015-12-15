using System.Drawing;

namespace JiahuScriptRunner.Visualiser
{
    static public class TextMeasurer
    {
        static Image _fakeImage;

        static public SizeF MeasureString(string text, Font font)
        {
            if (_fakeImage == null)
            {
                _fakeImage = new Bitmap(1, 1);
            }

            using (Graphics g = Graphics.FromImage(_fakeImage))
            {
                return g.MeasureString(text, font);
            }
        }
    }
}
