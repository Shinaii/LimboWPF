using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Limbo
{
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private static bool isFirstWindow = true;
        private int windowID = 0;
        private static bool CorrectKey = false;
        private int CorrectKeyID = 0;
        private static bool GotClicked = false;
        private static int totalWindows = 8;
        private static int windowsCreated = 0;

        public MainWindow(int windowID, int CorrectKeyID)
        {
            this.windowID = windowID;
            this.CorrectKeyID = CorrectKeyID;
            InitializeComponent();

            idTextBlock.Text = "ID: " + windowID.ToString();

            if (isFirstWindow)
            {
                mediaPlayer.Open(new Uri("Resource/LIMBO.mp3", UriKind.Relative));
                mediaPlayer.Position = TimeSpan.FromSeconds(176);
                mediaPlayer.Play();
                isFirstWindow = false;
            }

            windowsCreated++;

            if (windowID == CorrectKeyID)
            {
                CorrectKey = true;
            }

            App.AllWindowsCreated += StartAnimation;
        }

        private void StartAnimation()
        {
            if (windowID == CorrectKeyID)
            {
                DoubleAnimation opacityAnimation = new DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    Duration = new Duration(TimeSpan.FromSeconds(0.8)),
                    AutoReverse = true,
                    RepeatBehavior = new RepeatBehavior(3)
                };
                fadeImage.BeginAnimation(OpacityProperty, opacityAnimation);
            }
        }
        
    }
}