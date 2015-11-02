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

using SampleInterface;

namespace SamplePluin
{
    /// <summary>
    /// メニューにボタンを追加するプラグインのクラスを定義します。
    /// </summary>
    public class SamplePugin : IMenuPlugin
    {
        // ------------------------------------------------------------------------------------------------------------
        #region コンストラクタ

        /// <summary>
        /// SamplePluin.SamplePluin クラスの新しいインスタンスを初期化します。
        /// </summary>
        public SamplePugin()
        {

        }

        #endregion
        // ------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 機能を実行するボタンを作成して返します。
        /// </summary>
        /// <returns>作成したボタンコントロールを返します。</returns>
        public Button CreateMenuButton()
        {
            return this.DoCreateButton();
        }

        /// <summary>
        /// Buttonコントロールを使用して 機能を実行するボタンを作成して返します。
        /// </summary>
        /// <param name="sample">プロパティをコピーするコントロールを指定します。</param>
        /// <returns>作成したボタンコントロールを返します。</returns>
        public Button CreateMenuButton(Button sample)
        {
            var rtButton = DoCreateButton();
            var b = sample;
            rtButton.Width = b.Width;
            rtButton.Height = b.Height;
            rtButton.BorderThickness = b.BorderThickness;
            rtButton.HorizontalAlignment = b.HorizontalAlignment;
            rtButton.VerticalAlignment = b.VerticalAlignment;
            rtButton.HorizontalContentAlignment = b.HorizontalContentAlignment;
            rtButton.Margin = new Thickness(b.Margin.Left + b.Width + 5, b.Margin.Top, 0, 0);
            rtButton.Padding = b.Padding;
            return rtButton;
        }

        /// <summary>
        /// ボタンコントロールを作成して返します。
        /// </summary>
        /// <returns></returns>
        private Button DoCreateButton()
        {
            // ボタン
            var btn = new Button();
            btn.Click += ButtonClick;

            // スタックパネルとアイコン
            var panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Children.Add(new FileIcon());

            // テキスト表示
            var tb = new TextBlock();
            tb.Text = "プラグイン実行！";
            tb.Padding = new Thickness(5);
            tb.VerticalAlignment = VerticalAlignment.Center;

            // コントロールを結合
            panel.Children.Add(tb);
            btn.Content = panel;

            return btn;
        }

        /// <summary>
        /// ボタンのクリックイベントを処理します。
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクトを指定します。</param>
        /// <param name="e">イベント引数を指定します。</param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            new SamplePulginWindow().Show();
        }
    }
}
