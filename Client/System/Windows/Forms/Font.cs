using System.Drawing;

namespace System.Windows.Forms
{
    internal class Font
    {
        private string v1;
        private float v2;
        private FontStyle bold;

        public Font(string v1, float v2, FontStyle bold)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.bold = bold;
        }
    }
}