using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsNotify
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // 显示标题
        public static string title = "title";
        //// 显示正文
        //public static string msg = "msg";
        // 弹窗持续时间
        public static int duration = 5;
        // 是否是浅色模式（默认深色模式）
        public static bool isLightMode = false;
        // 正文模板（默认不使用模板）
        public static string template = string.Empty;
        // 保存其他用户自定义参数，用于自定义模板中，需要key - value对应
        public static Dictionary<string, string> other_params = new Dictionary<string, string>()
        {
            { "msg", "msg" }
        };

        private void ParseArgs(object sender, StartupEventArgs e)
        {
            for (int index = 0; index < e.Args.Length; index += 2)
            {
                if (e.Args.Length == index + 1 || e.Args[index + 1].StartsWith("-"))
                {
                    //args.Add(e.Args[index], string.Empty);
                    if (e.Args[index] == "-light")
                    {
                        isLightMode = true;
                    }
                    index--;
                }

                if (e.Args.Length >= index + 1 && !e.Args[index + 1].StartsWith("-"))
                {
                    switch (e.Args[index])
                    {
                        case "-title":
                            title = e.Args[index + 1];
                            break;
                        // msg放在other_params里面，方便渲染内容文本
                        //case "-msg":
                        //    msg = e.Args[index + 1];
                        //    break;
                        case "-duration":
                            if (!Int32.TryParse(e.Args[index + 1], out duration))
                            {
                                duration = 5;
                            }
                            break;
                        case "-template":
                            template = e.Args[index + 1];
                            break;
                        default:
                            other_params.Add(e.Args[index][1..], e.Args[index + 1]);
                            break;
                    }
                }
            }
        }
    }
}
