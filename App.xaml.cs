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
        public static string title = "title";
        public static string msg = "msg";
        public static int duration = 5;

        private void ParseArgs(object sender, StartupEventArgs e)
        {
            for (int index = 0; index < e.Args.Length; index += 2)
            {
                if (e.Args.Length == index + 1 || e.Args[index + 1].StartsWith("-"))
                {
                    //args.Add(e.Args[index], string.Empty);
                    index--;
                }

                if (e.Args.Length >= index + 1 && !e.Args[index + 1].StartsWith("-"))
                {
                    //args.Add(e.Args[index], e.Args[index + 1]);
                    if (e.Args[index] == "-title")
                    {
                        title = e.Args[index + 1];
                    }
                    else if (e.Args[index] == "-msg")
                    {
                        msg = e.Args[index + 1];
                    }
                    else if (e.Args[index] == "-duration")
                    {
                        if (!Int32.TryParse(e.Args[index + 1], out duration))
                        {
                            duration = 5;
                        }
                    }
                }
            }
        }
    }
}
