using System.Windows;
using System.Windows.Controls.Primitives;

namespace HoteL.View.Windows
{
    internal class Feedback
    {
        public static void Error(string text, string title="Ошибка")
        {
            MessageBox.Show(text,title,MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void Warning(string text, string title="Предупреждение")
        {
            MessageBox.Show(text, title,MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void Information(string text,string title="Информация")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}