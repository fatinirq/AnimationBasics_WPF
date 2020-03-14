using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CaricatureBasics
{
   
  
    class ObjectTransform
    {
        #region storyboard method
        /// <summary>
        /// Storyboard path transform method
        /// </summary>'
        public Storyboard animByStoryboard(Path myPath)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.To = 90;
            da.Duration = new Duration(TimeSpan.FromSeconds(10));
            myPath.Name = "myPath";
            Storyboard mine = new Storyboard();
            RotateTransform rotate = new RotateTransform();
            rotate.Angle = 0;
            myPath.RenderTransform = rotate;
            Storyboard.SetTarget(da, myPath);
            Storyboard.SetTargetProperty(da, new PropertyPath("(rotate.Angle)"));
            mine.Duration = da.Duration;
            mine.Children.Add(da);
            return mine;
        }

        #endregion

        #region doubleanimation
        /// <summary>
        /// Method of DoubleAnimation
        /// </summary>
        public void animBYDA(Path myPath)
        {
            TransformGroup tranG = new TransformGroup();
            ScaleTransform scaleT = new ScaleTransform(0.7, 0.7);
            RotateTransform rotateT = new RotateTransform(30);
            TranslateTransform transT = new TranslateTransform();
            tranG.Children.Add(scaleT);
            tranG.Children.Add(rotateT);
            tranG.Children.Add(transT);
            myPath.RenderTransform = tranG;
            DoubleAnimation daRotate = new DoubleAnimation();
            daRotate.Duration = new Duration(TimeSpan.FromSeconds(4));
            daRotate.To = 0;
            DoubleAnimation daTranX = new DoubleAnimation();
            daTranX.Duration = new Duration(TimeSpan.FromSeconds(4));
            daTranX.To = 300;
            DoubleAnimation daTranY = new DoubleAnimation();
            daTranY.Duration = new Duration(TimeSpan.FromSeconds(4));
            daTranY.To = 400;
            DoubleAnimationUsingPath da = new DoubleAnimationUsingPath();
            rotateT.BeginAnimation(RotateTransform.AngleProperty, daRotate);
            transT.BeginAnimation(TranslateTransform.XProperty, daTranX);
            transT.BeginAnimation(TranslateTransform.YProperty, daTranY);
            rotateT.BeginAnimation(RotateTransform.AngleProperty, daRotate);
        }
        #endregion
    }
}
