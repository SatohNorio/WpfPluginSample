using System;
using System.IO;
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
using System.Reflection;

using SampleInterface;

namespace WpfPluginSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // ------------------------------------------------------------------------------------------------------------
        #region コンストラクタ

        /// <summary>
        /// WpfPluginSample.MainWindow クラスの新しいインスタンスを初期化します。
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            var files = Directory.GetFiles(@".\Plugin");
            foreach (var f in files)
            {
                var asm = Assembly.LoadFrom(f);
                foreach (var t in asm.GetExportedTypes())
                {
                    if (typeof(IMenuPlugin).IsAssignableFrom(t))
                    {
                        var plugin = Activator.CreateInstance(t) as IMenuPlugin;
                        var b = this.button;
                        var btn = plugin.CreateMenuButton(b);
                        btn.Margin = new Thickness(b.Margin.Left + b.Width + 5, b.Margin.Top, 0, 0);
                        this.FBaseGrid.Children.Add(btn);
                    }
                }
            }
        }

        #endregion
        // ------------------------------------------------------------------------------------------------------------
    }
}
