using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CaricatureBasics
{
    /// <summary>
    /// Interaction logic for UC_Car.xaml
    /// </summary>
    public partial class UC_Car : UserControl
    {
        int _frameCounter = 0;
        public UC_Car()
        {
            InitializeComponent();  
        }
        private DispatcherTimer moveCar = new DispatcherTimer();

        #region FixDraw
        /// <summary>
        /// Fixed Draw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFixedDraw_Click(object sender, RoutedEventArgs e)
        {
            TransformGroup tranG = new TransformGroup();
            ScaleTransform scaleT = new ScaleTransform(0.7, 0.7);
            RotateTransform rotateT = new RotateTransform();
            TranslateTransform transT = new TranslateTransform();
            tranG.Children.Add(scaleT);
            tranG.Children.Add(rotateT);
            tranG.Children.Add(transT);

            string text = System.IO.File.ReadAllText(@"Car");
            Regex r1 = new Regex(@"\n"); //specify delimiter (spaces)
            Regex r2 = new Regex(@" +"); //specify delimiter (spaces)
            Regex r3 = new Regex(@"\d+");
            string[] words = r1.Split(text); //(convert string to array of words)
            System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();                               //foreach (string s in words)
            GeometryGroup car = new GeometryGroup();

            foreach (String W in words)
            {
                int i;
                string[] digits = r2.Split(W);


                // MessageBox.Show(digits[0].Length.ToString());

                if (r3.IsMatch(digits[0]))
                {
                    if (Int32.Parse(digits[0].Trim()) == 1 || Int32.Parse(digits[0].Trim()) == 4)
                    {
                        LineGeometry line = new LineGeometry(new Point(int.Parse(digits[1]), int.Parse(digits[2])), new Point(int.Parse(digits[3]), int.Parse(digits[4])));

                        car.Children.Add(line);

                    }

                    if (Int32.Parse(digits[0].Trim()) == 2)
                    {
                        EllipseGeometry ellipse = new EllipseGeometry(new Point(int.Parse(digits[1]), int.Parse(digits[2])), double.Parse(digits[3]), double.Parse(digits[4]));

                        car.Children.Add(ellipse);
                        //Point arcPoint = new Point(Double.Parse(digits[1]), Double.Parse(digits[2]));

                    }
                    if (Int32.Parse(digits[0].Trim()) == 3)
                    {
                        RectangleGeometry rec = new RectangleGeometry(new Rect(double.Parse(digits[1]), double.Parse(digits[2]), double.Parse(digits[4]), double.Parse(digits[3])), 2, 2);

                        car.Children.Add(rec);
                        //Point arcPoint = new Point(Double.Parse(digits[1]), Double.Parse(digits[2]));

                    }
                }
            }

            myPath.Stroke = Brushes.DarkOrange;
            myPath.StrokeThickness = 3;
            myPath.Data = car;
            myPath.RenderTransform = tranG;
            MyCanvas.Children.Clear();

            MyCanvas.Children.Add(myPath);


        }
        #endregion


        private void btnAnimate_Click(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering += DrawCar;
            CarDrawing myCar = new CarDrawing();
            Path myPath = new Path();
            myPath = myCar.relative();
            ObjectTransform objTran = new ObjectTransform();
            MyCanvas.Children.Add(myPath);
            Storyboard sb =objTran.animByStoryboard(myPath);
            sb.Begin(MyCanvas);
        }

        private void btnAnimate2_Click(object sender, RoutedEventArgs e)
        {
            CarDrawing myCar = new CarDrawing();
            Path myPath = new Path();
            myPath = myCar.relative();
           
            ObjectTransform objTran = new ObjectTransform();
            objTran.animBYDA(myPath);
            MyCanvas.Children.Add(myPath);
        }
        Stopwatch _stopwatch = new Stopwatch();
        Point _pt = new Point(6, 7);
       
        protected void DrawCar(object sender, EventArgs e)
        {
            if (_frameCounter++ == 0)
            {
                // Starting timing.
                _stopwatch.Start();
            }

            // Determine frame rate in fps (frames per second).
            long frameRate = (long)(_frameCounter / this._stopwatch.Elapsed.TotalSeconds);
            if (frameRate > 0)
            {
                // Update elapsed time, number of frames, and frame rate.
                myStopwatchLabel.Content = _stopwatch.Elapsed.ToString();
                myFrameCounterLabel.Content = _frameCounter.ToString();
                myFrameRateLabel.Content = frameRate.ToString();
            }

            // Update the background of the canvas by converting MouseMove info to RGB info.
            byte redColor = (byte)(_pt.X / 3.0);
            byte blueColor = (byte)(_pt.Y / 2.0);
            MyCanvas.Background = new SolidColorBrush(Color.FromRgb(redColor, 0x0, blueColor));
        }
    }
}

