using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Other
{
    public sealed partial class RingLoader : UserControl
    {
        private TextBlock progressRingText;

        public TextBlock ProgressRingText
        {
            get
            {
                return progressRingText;
            }

            set
            {
                progressRingText = value;
            }
        }

        public RingLoader()
        {
            this.InitializeComponent();
            this.ProgressRingText = this.progressRingTextB;
        }

    }
}
