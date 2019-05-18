using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System;
using System.Diagnostics;

namespace KioskApp
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            Console.WriteLine(this.Screens.Primary.Bounds);
            this.Width = this.Screens.Primary.Bounds.Width;
            this.Height = this.Screens.Primary.Bounds.Height;
            Console.WriteLine(this.Position);
            this.Position = new PixelPoint(0, 0);
        }

        public void OnButtonClicked(object sender, RoutedEventArgs args)
        {
            Application.Current.Exit();
        }
    }
}