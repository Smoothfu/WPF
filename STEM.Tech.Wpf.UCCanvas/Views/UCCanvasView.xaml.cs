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
using System.IO;
using System.Windows.Media.Animation;

namespace STEM.Tech.Wpf.UCCanvas.Views
{
    /// <summary>
    /// Interaction logic for UCCanvasView.xaml
    /// </summary>
    public partial class UCCanvasView : UserControl
    {
        public UCCanvasView()
        {
            InitializeComponent();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            string imgUrl = @"../../../STEM.Tech.Wpf.UCCanvas/Resources/Images/1.jpg";
            if(!File.Exists(imgUrl))
            {
                return;
            }

            base.OnRender(drawingContext);
            Rect rec = new Rect();
            RectAnimation animation = new RectAnimation();
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.AutoReverse = true;
            animation.From = new Rect(0, 0, 100, 200);
            animation.To = new Rect(1500, 700, 100, 200);
            animation.Duration = TimeSpan.FromSeconds(5);
            var rectAnimationClock = animation.CreateClock();
            var imgSource=GetImageSourceViaUrl(imgUrl);
            drawingContext.DrawImage(imgSource, new Rect(0,0,100,200), rectAnimationClock);

        }

        private ImageSource GetImageSourceViaUrl(string imgUrl)
        {
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.UriSource=new Uri(imgUrl,UriKind.RelativeOrAbsolute);
            bmi.EndInit();
            if(bmi.CanFreeze)
            {
                bmi.Freeze();
            }
            return bmi;
        }
    }
}
