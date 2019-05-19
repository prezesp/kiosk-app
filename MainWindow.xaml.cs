using Autofac;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System;
using System.Diagnostics;
using KioskApp.Utils.Printing;
using KioskApp.Utils;

namespace KioskApp
{
    public class MainWindow : Window
    {
        private readonly SystemService _service;

        public MainWindow(SystemService service) : base()
        {
            this._service = service;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.ActivateFullScreen();
        }

        private void ActivateFullScreen()
        {
            this.Width = this.Screens.Primary.Bounds.Width;
            this.Height = this.Screens.Primary.Bounds.Height;
            this.Position = new PixelPoint(0, 0);
        }

#region ElementsHandlers
        
        private void OnButtonClicked(object sender, RoutedEventArgs args)
        {
            switch((sender as Button).Content.ToString()) 
            {
                case "scenario #1": { } break;
                case "scenario #2": 
                { 
                    this._service.GetPrinter<IPrinter>().Print(null);
                } break;
                case "scenario #3 (exit)": 
                { 
                    Application.Current.Exit();
                } break;
                
            }
        } 

#endregion
    }
}