﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Desktop_Manger
{
    class PowerTimer : StackPanel
    {
        //TODO
        //      1-make the close and minimize button functional
        //      2-No need for reapearance of the PowerTimer after minimizing we will od it later
        //      3-Add Hover Effects for the Buttons (u r free to do it later)
        public TextBlock Timer = null;
        public Thread WorkerThread = null;
        //HINT
        //      U May need to take Worker Thread as Parameter to abort it whenever u want or (do whatever u want to make it fuctional)
        //      UseThis(if u Had Choosen To take The Thread as Parameter):
        //              public PowerTimer(Thread PowerTimerThread)
        public PowerTimer()
        {
            //TODO
            //     Code is Messy :)
            //      if u got enough time fix it 
            Orientation = Orientation.Horizontal;
            VerticalAlignment = System.Windows.VerticalAlignment.Top;
            HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#60000000"));
            TextBlock Timer = new TextBlock();
            Timer.FontSize = 40;
            this.Timer = Timer;
            Border br = new Border();
            br.BorderThickness = new System.Windows.Thickness(1, 0, 0, 0);
            br.BorderBrush = Brushes.LightGray;
            br.Margin = new System.Windows.Thickness(10, 0, 10, 0);
            Timer.Foreground = Brushes.White;
            TextBlock CloseButton = Createtb("\xE10A");
            CloseButton.MouseLeftButtonUp += (sender, e) => CloseButton_MouseLeftButtonUp(CloseButton);
            CloseButton.Foreground = Brushes.Red;
            TextBlock MinimizeButton = Createtb("\xE108");
            MinimizeButton.MouseLeftButtonUp += MinimizeButton_MouseLeftButtonUp;
            MinimizeButton.Foreground = Brushes.Yellow;
            Children.Add(Timer);
            Children.Add(br);
            Children.Add(MinimizeButton);
            Children.Add(CloseButton); 
        }

        private void MinimizeButton_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            if (Timer.Visibility == System.Windows.Visibility.Collapsed)
            {
                Timer.Visibility = System.Windows.Visibility.Visible;
                (sender as TextBlock).Text = "\xE108";
            }
            else
            {
                Timer.Visibility = System.Windows.Visibility.Collapsed;
                (sender as TextBlock).Text = "\xE109";
            }
        }
        private void CloseButton_MouseLeftButtonUp(object sender)
        {
            power.PowerWorker.CancelAsync();
            power.PowerWorker = new System.ComponentModel.BackgroundWorker();
            power.PowerWorkerThread.Abort();
            Panel Parent = this.Parent as Panel;
            Parent.Children.Remove(this);
        }

        private TextBlock Createtb(string Text)
        {
            TextBlock tb = new TextBlock();
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            tb.FontFamily = new FontFamily("Segoe MDL2 Assets");
            tb.FontSize = 20;
            tb.Text = Text;
            tb.Margin = new System.Windows.Thickness(5, 0, 5, 0);
            return tb;
        }
    }
}
