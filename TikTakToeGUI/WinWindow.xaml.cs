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

namespace TikTakToeGUI
{
    /// <summary>
    /// Interaktionslogik für WinWindow.xaml
    /// </summary>
    public partial class WinWindow : UserControl
    {
        public WinWindow(char lol)
        {
            InitializeComponent();

            text.Content = lol == 'X' ? "Spieler 1 hat gewonnen" : "Spieler 2 hat gewonnen";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new GameWindow();
        }
    }
}
