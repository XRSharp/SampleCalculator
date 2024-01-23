using System;
using XRSharp.Controls;

namespace Calculator3D
{
    class PaperTrail
    {
        string args;

        private readonly TextBlock3D PaperBox;

        public PaperTrail()
        {
            //PaperBox.IsEnabled = false;
        }

        public PaperTrail(TextBlock3D paperBox)
        {
            PaperBox = paperBox;
        }

        public void AddArguments(string a)
        {
            args = a;
        }

        public void AddResult(string r)
        {
            PaperBox.Text += string.Format("{0}={1}{2}", args, r, Environment.NewLine);
        }

        public void Clear()
        {
            PaperBox.Text = args = string.Empty;
        }
    }
}
