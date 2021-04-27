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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsNotify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            label_title.Content = App.title;
            label_msg.Content = App.msg;

            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height;

            if (App.isLightMode)
            {
                panel_title.Style = (Style)Resources["panel_title_light"];
                label_title.Style = (Style)Resources["label_title_light"];
                panel_msg.Style = (Style)Resources["panel_msg_light"];
                label_msg.Style = (Style)Resources["label_msg_light"];
            }
            else
            {
                panel_title.Style = (Style)Resources["panel_title_dark"];
                label_title.Style = (Style)Resources["label_title_dark"];
                panel_msg.Style = (Style)Resources["panel_msg_dark"];
                label_msg.Style = (Style)Resources["label_msg_dark"];
            }
            

            this.Loaded += WindowReady;
        }

        private void WindowReady(object sender, RoutedEventArgs e)
        {
            MainWindow self = sender as MainWindow;
            self.UpdateLayout();

            double top = SystemParameters.PrimaryScreenHeight - self.Height;
            double bottom = SystemParameters.PrimaryScreenHeight;
            int animation_duration = 500;

            Task.Factory.StartNew(delegate
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(App.duration));
                this.Dispatcher.Invoke(delegate
                {
                    DoubleAnimation animation = new DoubleAnimation();
                    animation.Duration = new Duration(TimeSpan.FromMilliseconds(animation_duration));
                    animation.From = top;
                    animation.To = bottom;
                    animation.Completed += Exit;
                    self.BeginAnimation(Window.TopProperty, animation);
                });
            });
        }

        /// <summary>
        /// 退出按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_close_Click(object sender, RoutedEventArgs e)
        {
            Exit(sender, e);
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
