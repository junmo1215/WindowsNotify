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
        // 调试
        public const bool isDebugMode = false;

        private void ParseArgs(object sender, StartupEventArgs e)
        {
            string[] args = e.Args;
            // 用于调试命令行传入的参数（参数中不能有空格，实际传的时候可以，这里调试简化了参数解析）
            //ReadArgs("-title title -template my_template_with_url -query test", out args);

            for (int index = 0; index < args.Length; index += 2)
            {
                if (args.Length == index + 1 || args[index + 1].StartsWith("-"))
                {
                    //args.Add(args[index], string.Empty);
                    if (args[index] == "-light")
                    {
                        isLightMode = true;
                    }
                    index--;
                }

                if (args.Length >= index + 1 && !args[index + 1].StartsWith("-"))
                {
                    switch (args[index])
                    {
                        case "-title":
                            title = args[index + 1];
                            break;
                        // msg放在other_params里面，方便渲染内容文本
                        //case "-msg":
                        //    msg = args[index + 1];
                        //    break;
                        case "-duration":
                            if (!Int32.TryParse(args[index + 1], out duration))
                            {
                                duration = 5;
                            }
                            break;
                        case "-template":
                            template = args[index + 1];
                            break;
                        default:
                            string key = args[index][1..];
                            if (other_params.ContainsKey(key))
                            {
                                other_params[key] = args[index + 1];
                            }
                            else
                            {
                                other_params.Add(key, args[index + 1]);
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析字符串到args中，用于调试
        /// </summary>
        /// <param name="cmds"></param>
        /// <param name="args"></param>
        private void ReadArgs(string cmds, out string[] args)
        {
            if (cmds == string.Empty) {
                args = new string[]{ };
                return;
            }
            
            args = cmds.Split(" ");
        }
    }
}
