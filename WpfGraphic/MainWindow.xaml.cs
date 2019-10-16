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

namespace WpfGraphic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyGraphicLine currentLine;
        bool isMouseDown;
        Point mouseLocationPred;

        public MainWindow()
        {
            InitializeComponent();
            isMouseDown = false;
        }

        //Создание новой линии
        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            currentLine = new MyGraphicLine(canvas);
        }

        //Удаление линии с холста
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (currentLine != null && currentLine.IsCurrent) currentLine.Remove();
        }

        //Нажатие мыши на холсте
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
            if (currentLine != null) currentLine.TryDrawCurrent(e.GetPosition(canvas));
        }

        //Отжание мыши на холсте
        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
        }

        //Выход из приложения
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Движение мыши на холсте
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            labelMouseX.Content = (int)e.GetPosition(canvas).X - (int)canvas.Width / 2;
            labelMouseY.Content = (int)canvas.Height / 2 - (int)e.GetPosition(canvas).Y;

            if (currentLine != null && isMouseDown && currentLine.IsCurrent) currentLine.Move(mouseLocationPred, e.GetPosition(canvas));
            mouseLocationPred = e.GetPosition(canvas);
        }

        //Мышь пропадает с холста
        private void Canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            labelMouseX.Content = "None";
            labelMouseY.Content = "None";
        }
    }
}
