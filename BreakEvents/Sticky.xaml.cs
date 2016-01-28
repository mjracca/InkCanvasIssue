using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BreakEvents
{
    public sealed partial class Sticky : UserControl
    {
        private TranslateTransform translateTransform;

        public Sticky()
        {
            this.InitializeComponent();
            this.RenderTransform = this.translateTransform = new TranslateTransform();

            this.ManipulationStarted += Sticky_ManipulationStarted;
            this.ManipulationDelta += Sticky_ManipulationDelta;
            this.ManipulationCompleted += Sticky_ManipulationCompleted;
        }

        private void Sticky_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            e.Handled = true;
            this.view.Background = new SolidColorBrush(Color.FromArgb(100, 0, 0, 255));
            this.text.Text = "Started";
        }

        private void Sticky_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            e.Handled = true;
            this.text.Text = "Delta";
        }

        private void Sticky_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            e.Handled = true;
            this.view.Background = new SolidColorBrush(Colors.Yellow);
            this.text.Text = "Completed";
        }
    }
}