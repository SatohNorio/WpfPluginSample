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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleInterface
{
    /// <summary>
    /// メニュー画面に機能を追加するプラグインのインターフェースを定義します。
    /// </summary>
    public interface IMenuPlugin
    {
        /// <summary>
        /// 機能を実行するボタンを作成して返します。
        /// </summary>
        /// <returns>作成したボタンコントロールを返します。</returns>
        Button CreateMenuButton();

        /// <summary>
        /// Buttonコントロールを使用して 機能を実行するボタンを作成して返します。
        /// </summary>
        /// <param name="sample">プロパティをコピーするコントロールを指定します。</param>
        /// <returns>作成したボタンコントロールを返します。</returns>
        Button CreateMenuButton(Button sample);
    }
}
