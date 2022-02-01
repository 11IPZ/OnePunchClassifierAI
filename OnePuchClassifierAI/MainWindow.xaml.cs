using Microsoft.Win32;
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

namespace OnePuchClassifierAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenImageButton(object Sender, RoutedEventArgs E)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Вибір зоображення",
                Filter = "Зоображення|*.png; *.jpg; *.bmp;|Всі файли (*.*)|*.*",
                CheckFileExists = true,
            };

            if (dialog.ShowDialog(this) != true) return;

            var file = dialog.FileName;

            imageView.Source = new BitmapImage(new Uri(file));

            var result = AI.Predict(new AI.ModelInput()
            {
                ImageSource = file,
            });

            ResultText.Text = $"{result.Prediction} - {result.Score.Max():p0}";
        }
        
    }
}
