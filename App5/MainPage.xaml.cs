using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace App5
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.SizeChanged += (s, e) =>
            {
                var state = "VisualState000";
                if (e.NewSize.Width > 0)
                {
                    R.Visibility = Visibility.Collapsed;
                }
                if (e.NewSize.Width > 700)
                {
                    R.Visibility = Visibility.Visible;
                    state = "VisualState700";
                }
                    VisualStateManager.GoToState(this, state, true);
            };
        }

        public ObservableCollection<record> signin = new ObservableCollection<record>();

        public class record
        {
            public string name { get; set; }
            public string pwd { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (A.Text != "" && B.Password != "")
            {
            signin.Add(new record { name = "用户名：" + A.Text + "；", pwd = "密码：" + B.Password });
            records.ItemsSource = signin;
            }
        }

        private void records_ItemClick(object sender, ItemClickEventArgs e)
        {
            signin.Remove((record)e.ClickedItem);
        }
    }
}
