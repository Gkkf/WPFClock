using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ZegarWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DispatcherTimer timer2;


        public object selected;
        public int h = 0;
        public int m = 0;
        public int s = 0;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();

            timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += Timer2_Tick;
            timer2.Start();

            MakeClock();
            MakeDate();
        }

        public void MakeDate()
        {
            DateTime currentTime = DateTime.Now;
            string dateString = currentTime.ToString("dd MMMM yyyy");
            dateTextBlock.Text = dateString;
        }

        public void MakeClock()
        {
            Canvas canv = new Canvas();

            for(int i = 0; i < 60; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;

                if (i % 5 == 0)
                {
                    line.X1 = 0;
                    line.Y1 = 150;
                    line.X2 = 10;
                    line.Y2 = 150;
                }
                else
                {
                    line.X1 = 0;
                    line.Y1 = 150;
                    line.X2 = 3;
                    line.Y2 = 150;
                }

                line.RenderTransform = new RotateTransform(6 * i, 150, 150);

                canv.Children.Add(line);
            }

            clock.Children.Add(canv);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            var seconds = currentTime.Second * 6; // 360 stopni / 60 sekund = 6 stopni na sekunde
            var minutes = (currentTime.Minute * 60 + currentTime.Second) * 0.1; // 360 stopni / (60 minut * 60 sekund) = 0.1 stopnia na sekunde
            var hours = (currentTime.Hour * 60 + currentTime.Minute) * 0.5; // 360 stopni / (12 godzin * 60 minut) = 0.5 stopnia na minute

            RotateTransform secondRotateTransform = new RotateTransform(seconds);
            second.RenderTransform = secondRotateTransform;

            RotateTransform minuteRotateTransform = new RotateTransform(minutes);
            minute.RenderTransform = minuteRotateTransform;

            RotateTransform hourRotateTransform = new RotateTransform(hours);
            hour.RenderTransform = hourRotateTransform;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("HH:mm:ss");
            clockTextBlock.Text = timeString;
        }

        private void dateTextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            datepicker.IsDropDownOpen = true;
        }
        
        private void datepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            selected = Convert.ToDateTime(datepicker.SelectedDate).ToString("dd MMMM yyyy");
            if (selected != null)
            {
                dateTextBlock.Text = selected.ToString();
            }
        }

        private void clockTextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EditDigital editDigital = new EditDigital();
            editDigital.ShowDialog();

            if (editDigital.clicked == true)
            {
                h = editDigital.hr;
                m = editDigital.min;
                s = editDigital.sec;

                timer.Tick += Timer_Tick1;
                timer.Interval = TimeSpan.FromSeconds(1);
                timer2.Tick += Timer2_Tick1;
                timer2.Interval = TimeSpan.FromSeconds(1);
            }
        }

        private void Timer2_Tick1(object sender, EventArgs e)
        {
            var seconds = s * 6; // 360 stopni / 60 sekund = 6 stopni na sekunde
            var minutes = (m * 60 + s) * 0.1; // 360 stopni / (60 minut * 60 sekund) = 0.1 stopnia na sekunde
            var hours = (h * 60 + m) * 0.5; // 360 stopni / (12 godzin * 60 minut) = 0.5 stopnia na minute

            RotateTransform secondRotateTransform = new RotateTransform(seconds);
            second.RenderTransform = secondRotateTransform;

            RotateTransform minuteRotateTransform = new RotateTransform(minutes);
            minute.RenderTransform = minuteRotateTransform;

            RotateTransform hourRotateTransform = new RotateTransform(hours);
            hour.RenderTransform = hourRotateTransform;
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            
            if(s>59)
            {
                s = 0;
                m++;
            }

            if(m>=60) 
            {
                m = 0;
                h++;
            }

            if(h>=24)
            {
                h = 0;
            }

            string timeString = h + ":" + m + ":" + s;
            s++;

            if (h < 10 && m < 10 && s < 10) 
            {
                timeString = "0"+ h + ":0" + m + ":0" + s;
            }
            else if(h < 10 && m < 10)
            {
                timeString = "0" + h + ":0" + m + ":" + s;
            }
            else if(h < 10 && s < 10)
            {
                timeString = "0" + h + ":" + m + ":0" + s;
            }
            else if(m < 10 && s < 10)
            {
                timeString = h + ":0" + m + ":0" + s;
            }
            else if(h < 10)
            {
                timeString = "0" + h + ":" + m + ":" + s;
            }
            else if(m < 10)
            {
                timeString = h + ":0" + m + ":" + s;
            }
            else if(s < 10)
            {
                timeString = h + ":" + m + ":0" + s;
            }
            
            clockTextBlock.Text = timeString;
        }
    }
}
