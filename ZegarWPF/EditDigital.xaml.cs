using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ZegarWPF
{
    /// <summary>
    /// Logika interakcji dla klasy EditDigital.xaml
    /// </summary>
    public partial class EditDigital : Window
    {
        public int hr;
        public int min;
        public int sec;
        public bool clicked = false;

        public EditDigital()
        {
            InitializeComponent();
        }

        private void tbhr_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbhr.BorderBrush = Brushes.Gray;
            var text = (TextBox)sender;
            Regex regex = new Regex("^[0-9]+$");

            if (!regex.IsMatch(text.Text))
            {
                int startIndex = text.Text.Length - 1;
                if (startIndex >= 0)
                {
                    text.Text = text.Text.Remove(startIndex);
                }
            }
        }

        private void tbmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbmin.BorderBrush = Brushes.Gray;
            var text = (TextBox)sender;
            Regex regex = new Regex("^[0-9]+$");

            if (!regex.IsMatch(text.Text))
            {
                int startIndex = text.Text.Length - 1;
                if (startIndex >= 0)
                {
                    text.Text = text.Text.Remove(startIndex);
                }
            }
        }

        private void tbsec_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbsec.BorderBrush = Brushes.Gray;
            var text = (TextBox)sender;
            Regex regex = new Regex("^[0-9]+$");

            if (!regex.IsMatch(text.Text))
            {
                int startIndex = text.Text.Length - 1;
                if (startIndex >= 0)
                {
                    text.Text = text.Text.Remove(startIndex);
                }
            }
        }

        private bool ValidateHr(int h)
        {
            bool valide = true;

            if (h > 24 || h < 0)
            {
                valide = false;
            }

            return valide;
        }

        private bool ValidateMin(int m)
        {
            bool valide = true;

            if (m >= 60 || m < 0)
            {
                valide = false;
            }

            return valide;
        }

        private bool ValidateSec(int s)
        {
            bool valide = true;

            if (s >= 60 || s < 0)
            {
                valide = false;
            }

            return valide;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbhr.Text == "" || tbmin.Text == "" || tbsec.Text == "" || ValidateHr(Convert.ToInt32(tbhr.Text)) == false || ValidateMin(Convert.ToInt32(tbmin.Text)) == false || ValidateSec(Convert.ToInt32(tbsec.Text)) == false)
            {
                MessageBox.Show("Błędnie wypełnione pola");

                if(tbhr.Text == "")
                {
                    tbhr.BorderBrush = Brushes.HotPink;
                }

                if(tbmin.Text == "")
                {
                    tbmin.BorderBrush = Brushes.HotPink;
                }

                if(tbsec.Text == "")
                {
                    tbsec.BorderBrush = Brushes.HotPink;
                }

                if(tbhr.Text != "" && tbmin.Text != "" && tbsec.Text != "")
                {
                    if (ValidateHr(Convert.ToInt32(tbhr.Text)) == false)
                    {
                        tbhr.BorderBrush = Brushes.HotPink;
                    }

                    if (ValidateMin(Convert.ToInt32(tbmin.Text)) == false)
                    {
                        tbmin.BorderBrush = Brushes.HotPink;
                    }

                    if (ValidateSec(Convert.ToInt32(tbsec.Text)) == false)
                    {
                        tbsec.BorderBrush = Brushes.HotPink;
                    }
                }
            }
            else
            {
                this.hr = Convert.ToInt32(tbhr.Text);
                this.min = Convert.ToInt32(tbmin.Text);
                this.sec = Convert.ToInt32(tbsec.Text);
                this.clicked = true;
                this.Close();
            }
        }
    }
}
