using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CaricatureBasics
{
    /// <summary>
    /// Interaction logic for UC_Swan1.xaml
    /// </summary>
    public partial class UC_Swan1 : UserControl
    {
        public UC_Swan1()
        {
            InitializeComponent();
        }
      
        private void btnFixedDraw_Click(object sender, RoutedEventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"SW2");
            Regex r1 = new Regex(@"\n"); //specify delimiter (spaces)
            Regex r2 = new Regex(@" +"); //specify delimiter (spaces)
            Regex r3 = new Regex(@"\d+");
            string[] words = r1.Split(text); //(convert string to array of words)
            //foreach (string s in words)
            

            foreach (String W in words)
            { int i;
                string[] digits = r2.Split(W);


                // MessageBox.Show(digits[0].Length.ToString());

                if (r3.IsMatch(digits[0]))
                {
                    if (Int32.Parse(digits[0].Trim()) == 1)
                    {
                        Line line = new Line();
                        line.Stroke = Brushes.Chocolate;
                        line.X1 = int.Parse(digits[1].Trim());
                        line.Y1 = int.Parse(digits[2].Trim());
                        line.X2 = int.Parse(digits[3]);
                        line.Y2 = int.Parse(digits[4]);
                        line.StrokeThickness = 2;
                        MyCanvas.Children.Add(line);
                    }
                  
                    if (Int32.Parse(digits[0].Trim()) == 2)
                    {
                        
                        ArcSegment seg = new ArcSegment();
                        PathFigure myFig = new PathFigure();
                        Point arcPoint = new Point(Double.Parse(digits[3]), Double.Parse(digits[4]));
                        seg.Point= new Point(Double.Parse(digits[3]), Double.Parse(digits[4]));
                        seg.Size = new Size(Double.Parse(digits[5]), Double.Parse(digits[5]));
                        myFig = new PathFigure();
                        myFig.StartPoint = new Point(Double.Parse(digits[1]), Double.Parse(digits[2]));
                        myFig.Segments.Add(seg);
                        PathGeometry myGeo = new PathGeometry();
                        myGeo.Figures.Add(myFig);
                        System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();
                        myPath.Stroke = Brushes.DarkOrange;
                        myPath.StrokeThickness = 3;
                        myPath.Data = myGeo;
                        MyCanvas.Children.Add(myPath);
                    }
                }
                }
               
            }
            

        }
    }

