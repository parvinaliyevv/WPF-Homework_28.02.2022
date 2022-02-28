using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Number { get; set; } = 7;

        public MainWindow() => InitializeComponent();

        private void Button_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (sender is Button btn)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    btn.Background = typeof(Brushes).GetProperties()[new Random().Next(0, typeof(Brushes).GetProperties().Length)].GetValue(null) as Brush;
                    MessageBox.Show(string.Format("Content: {0}\nColor Hexcode: {1}", btn.Content, btn.Background), "Cliked Button Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button btn)
            {
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    Title = btn.Content.ToString();
                    (btn.Parent as StackPanel).Children.Remove(btn);
                }
                else if (e.MiddleButton == MouseButtonState.Pressed)
                {
                    if ((btn.Parent as StackPanel).Children.Count >= 3)
                    {
                        MessageBox.Show("You can't create more than 3 buttons (Full StackPanel)!", "Invalid Operation!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    
                    var newBtn = new Button()
                    {
                        Content = Number++.ToString(),
                        Background = typeof(Brushes).GetProperties()[new Random().Next(0, typeof(Brushes).GetProperties().Length)].GetValue(null) as Brush,
                        FontFamily = new FontFamily("Calibri"),
                        FontSize = 20,
                        Height = 80,
                        Width = 150,
                        Margin = new Thickness(30)
                    };

                    newBtn.GotMouseCapture += Button_GotMouseCapture;
                    newBtn.MouseDown += Button_MouseDown;

                    (btn.Parent as StackPanel).Children.Add(newBtn);
                }
            }
        }
    }
}
