using System;
using System.Collections.Generic;
using System.IO;
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

            // 设置弹窗位置
            SetLocation();

            // 设置内容（html格式）
            string html_text = SetTemplate(App.template, App.other_params);

            // 设置主题
            html_text = SetColorMode(App.isLightMode, html_text);

            label_title.Content = App.title;
            //label_msg.Content = App.msg;
            msg_browser.NavigateToString(html_text);

            this.Loaded += WindowReady;
        }

        /// <summary>
        /// 设置主题颜色
        /// </summary>
        private string SetColorMode(bool isLightMode, string html_text)
        {
            if (isLightMode)
            {
                panel_title.Style = (Style)Resources["panel_title_light"];
                label_title.Style = (Style)Resources["label_title_light"];
                panel_msg.Style = (Style)Resources["panel_msg_light"];
                //label_msg.Style = (Style)Resources["label_msg_light"];
                html_text = html_text.Replace("{body_class}", "light");
            }
            else
            {
                panel_title.Style = (Style)Resources["panel_title_dark"];
                label_title.Style = (Style)Resources["label_title_dark"];
                panel_msg.Style = (Style)Resources["panel_msg_dark"];
                //label_msg.Style = (Style)Resources["label_msg_dark"];
                html_text = html_text.Replace("{body_class}", "dark");
            }
            
            return html_text;
        }

        /// <summary>
        /// 设置模板并返回弹窗内容
        /// </summary>
        private string SetTemplate(string template, Dictionary<string, string> other_params)
        {
            const string DEFAULT_TEMPLATE = @"<p>{msg}</p>";
            const string HTML_TEMPLATE = @"<!DOCTYPE html>
<html>
<head>
<style>
  html{overflow:hidden;}
  body.dark {
    background-color:#1D2224;
    color: #CAD3DB;
  }
  body.dark > p {color:#CAD3DB;}

  body.light {
    background-color:#F8F8F8;
    color: #383A42;
  }
  body.light > p {color:#383A42;}
</style>
</head>
<body class='{body_class}'>{body}</body>
</html>";
            string template_file = System.IO.Path.GetFullPath(string.Format("template/{0}.html", template));
            string body_template = DEFAULT_TEMPLATE;
            if (File.Exists(template_file))
            {
                body_template = File.ReadAllText(template_file);
            }

            foreach (var param in other_params)
            {
                body_template = body_template.Replace("{" + param.Key + "}", param.Value);
            }

            string html_text = HTML_TEMPLATE.Replace("{body}", body_template);
            return html_text;
        }

        /// <summary>
        /// 弹窗位置
        /// </summary>
        void SetLocation()
        {
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height;
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
