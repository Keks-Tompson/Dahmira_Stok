using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace load__baze
{
    public partial class logotip : Form
    {
        public logotip()
        {
            InitializeComponent();
            //фон
            this.BackgroundImageLayout = ImageLayout.Stretch;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            BackgroundImage = load__baze.Properties.Resources._222; // картинка
            ImageAnimator.Animate(BackgroundImage, OnFrameChanged);

        }


        int frime = 180;
        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (frime > 0)
            {
                frime--;
                if (InvokeRequired)
                {
                    BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                    return;
                }
                ImageAnimator.UpdateFrames();
                Invalidate(false);
            }

 
        }

    }
}
