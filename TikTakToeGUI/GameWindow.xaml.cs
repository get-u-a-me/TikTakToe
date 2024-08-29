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
    /// Interaktionslogik für GameWindow.xaml
    /// </summary>
    public partial class GameWindow : UserControl
    {
        static char currentPlayer = 'X';

        public GameWindow()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Window window = Window.GetWindow(this);

            if (string.IsNullOrEmpty(btn.Content?.ToString()))
            {
                btn.Content = currentPlayer;
                CheckWin(window);
                PlayerSwitch();
                errorMessage.Content = "";
                if (IsBoardFull())
                {
                    ResetField();
                }
            }
            else
            {
                errorMessage.Content = "Feld bereits vergeben";
            }
        }

        private void PlayerSwitch()
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            playerturn.Content = currentPlayer == 'X' ? "Spieler 1 ist an der Reihe" : "Spieler 2 is an der Reihe";
        }

        private void CheckWin(Window window)
        {
            //Zeilen
            if(CheckLine(field_1, field_2, field_3) ||
                CheckLine(field_4, field_5, field_6) ||
                CheckLine(field_7, field_8, field_9) ||
            //Spalten
                CheckLine(field_1, field_4, field_7) ||
                CheckLine(field_2, field_5, field_8) ||
                CheckLine(field_3, field_6, field_9) ||
            //Diagonale
                CheckLine(field_1, field_5, field_9) ||
                CheckLine(field_3, field_5, field_7))
            {
                window.Content = new WinWindow(currentPlayer);

                ResetField();
            }
        }

        private bool CheckLine(Button b1, Button b2, Button b3)
        {
            string c1 = b1.Content?.ToString();
            string c2 = b2.Content?.ToString();
            string c3 = b3.Content?.ToString();

            return !string.IsNullOrEmpty(c1) && c1 == c2 && c2 == c3;
        }


        private void ResetField()
        {
            field_1.Content = field_2.Content = field_3.Content =
            field_4.Content = field_5.Content = field_6.Content =
            field_7.Content = field_8.Content = field_9.Content = string.Empty;
        }

        private bool IsBoardFull()
        {
            return !GetAvailableButtons().Any();
        }

        private List<Button> GetAvailableButtons()
        {
            return new List<Button>
    {
        field_1, field_2, field_3,
        field_4, field_5, field_6,
        field_7, field_8, field_9
    }.Where(b => string.IsNullOrEmpty(b.Content?.ToString())).ToList();
        }
    }
}
