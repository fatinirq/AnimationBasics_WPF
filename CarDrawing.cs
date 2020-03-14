

using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CaricatureBasics
{
    class CarDrawing
    {
        #region nonRelative
        /// <summary>
        /// Drawing Car from nonRelative File Data
        /// </summary>
        /// <returns></returns>
        public Path nonRelative()
        {
            string text = System.IO.File.ReadAllText(@"Car");
            Regex r1 = new Regex(@"\n"); //specify delimiter (spaces)
            Regex r2 = new Regex(@" +"); //specify delimiter (spaces)
            Regex r3 = new Regex(@"\d+");
            string[] words = r1.Split(text); //(convert string to array of words)
            System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();                               //foreach (string s in words)
            GeometryGroup car = new GeometryGroup();
            myPath.Stroke = Brushes.DarkOrange;
            myPath.StrokeThickness = 3;
            myPath.Data = car;

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
            return myPath;
        }
        #endregion
        #region relative
        /// <summary>
        /// Drawing Car from Relative file data
        /// </summary>
        /// <returns></returns>
        public Path relative()
        {
            string text = System.IO.File.ReadAllText(@"Car2");
            Regex r1 = new Regex(@"\n"); //specify delimiter (spaces)
            Regex r2 = new Regex(@" +"); //specify delimiter (spaces)
            Regex r3 = new Regex(@"\d+");
            string[] words = r1.Split(text); //(convert string to array of words)
            System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();                               //foreach (string s in words)
            GeometryGroup car = new GeometryGroup();
            PathFigure carPrt = new PathFigure();
            PathGeometry carPath = new PathGeometry();
            foreach (String W in words)
            {
                int i;
                string[] digits = r2.Split(W);
                // MessageBox.Show(digits[0].Length.ToString()

                if (r3.IsMatch(digits[0]))
                {
                    if (Int32.Parse(digits[0]) == 0)
                    {
                        carPath.Figures.Add(carPrt);
                        carPrt = new PathFigure();
                        carPrt.StartPoint = new Point(Int32.Parse(digits[1]), Int32.Parse(digits[2]));
                    }
                    if (Int32.Parse(digits[0].Trim()) == 1 || Int32.Parse(digits[0].Trim()) == 4)
                    {
                        LineSegment line = new LineSegment((new Point(int.Parse(digits[1]), int.Parse(digits[2]))), true);

                        carPrt.Segments.Add(line);

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
            carPath.Figures.Add(carPrt);
            car.Children.Add(carPath);
            myPath.Stroke = Brushes.DarkOrange;
            myPath.StrokeThickness = 3;
            myPath.Data = car;
           
           

            return myPath;
    }

    }
    #endregion
}
