using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CustomFrameShadow
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        bool selection1Active = true;
        bool selection2Active = false;
        bool selection3Active = false;
        private double valueX, valueY;
        private bool IsTurnX, IsTurnY;
        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new ShadowBoxShell(Content,50,50));
        }

        bool left = false;
        bool right = false;
        public void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var x = e.TotalX; // TotalX Left/Right
            var y = e.TotalY; // TotalY Up/Down

            // StatusType
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    Debug.WriteLine("Started");
                    break;
                case GestureStatus.Running:
                    Debug.WriteLine("Running");

                    // Check that the movement is x or y
                    if ((x >= 5 || x <= -5) && !IsTurnX && !IsTurnY)
                    {
                        IsTurnX = true;
                    }

                    if ((y >= 5 || y <= -5) && !IsTurnY && !IsTurnX)
                    {
                        IsTurnY = true;
                    }

                    if (x <= valueX)
                    {
                        //left
                        left = true;
                    }
                    if (x >= valueX)
                    {
                        //right
                        right = true;
                    }
                        


                    break;
                case GestureStatus.Completed:
                    Debug.WriteLine("Completed");

                    
                    // X (Horizontal)
                    if (IsTurnX && !IsTurnY)
                    {

                        if (left)
                        {
                            // Left
                            if (selection2Active)
                            {
                                //make selection1 move to selection 2
                                selection1Active = true;
                                selection2Active = false;
                                text2.TextColor = Color.Black;
                                text1.TextColor = Color.White;
                                runningFrame.TranslateTo(0, 0, 120);
                                var duration = TimeSpan.FromSeconds(1);
                                Vibration.Vibrate(duration);

                            }
                            else if (selection3Active)
                            {
                                //make selection3 move to selection 2
                                selection2Active = true;
                                selection3Active = false;
                                text3.TextColor = Color.Black;
                                text2.TextColor = Color.White;
                                runningFrame.TranslateTo(  95, 0, 120);
                                var duration = TimeSpan.FromSeconds(1);
                                Vibration.Vibrate(duration);
                            }
                        }
                        if (right)
                        {
                            // Right
                            if (selection2Active)
                            {
                                //make selection2 move to selection 1
                                selection2Active = false;
                                selection3Active = true;
                                text3.TextColor = Color.White;
                                text2.TextColor = Color.Black;
                                runningFrame.TranslateTo( 190, 0, 120);
                                var duration = TimeSpan.FromSeconds(1);
                                Vibration.Vibrate(duration);

                            }

                            if (selection1Active)
                            {
                                //make selection2 move to selection 1
                                selection1Active = false;
                                selection2Active = true;
                                text2.TextColor = Color.White;
                                text1.TextColor = Color.Black;
                                runningFrame.TranslateTo( 95, 0, 120);
                                var duration = TimeSpan.FromSeconds(1);
                                Vibration.Vibrate(duration);

                            }
                        }
                    }
                IsTurnX = false;
                    IsTurnY = false;
                    left = false;right = false;
                    DisplayContentView();
                    break;
                case GestureStatus.Canceled:
                    Debug.WriteLine("Canceled");
                    break;


            }
        }

        void OnText1Tapped(System.Object sender, System.EventArgs e)
        {
            if (selection2Active)
            {
                //make selection1 move to selection 2

                selection1Active = true;
                selection2Active = false;
                text2.TextColor = Color.Black;
                text1.TextColor = Color.White;
                runningFrame.TranslateTo(0, 0, 120);
                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            if (selection3Active)
            {
                //make selection1 move to selection 2

                selection1Active = true;
                selection3Active = false;
                text3.TextColor = Color.Black;
                text1.TextColor = Color.White;
                runningFrame.TranslateTo(0, 0, 120);
                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            DisplayContentView();
        }

        void OnText2Tapped(System.Object sender, System.EventArgs e)
        {
            if (selection1Active)
            {
                //make selection2 move to selection 1
                selection1Active = false;
                selection2Active = true;
                text2.TextColor = Color.White;
                text1.TextColor = Color.Black;
                runningFrame.TranslateTo(95, 0, 120);
                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            if (selection3Active)
            {
                //make selection2 move to selection 1
                selection3Active = false;
                selection2Active = true;
                text2.TextColor = Color.White;
                text3.TextColor = Color.Black;
                runningFrame.TranslateTo(95, 0, 120);
                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            DisplayContentView();
        }

        void OnText3Tapped(System.Object sender, System.EventArgs e)
        {
            if (selection1Active)
            {
                //make selection2 move to selection 1
                selection1Active = false;
                selection3Active = true;
                text3.TextColor = Color.White;
                text1.TextColor = Color.Black;
                runningFrame.TranslateTo(190, 0, 120);
                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            if (selection2Active)
            {
                //make selection2 move to selection 1
                selection2Active = false;
                selection3Active = true;
                text3.TextColor = Color.White;
                text2.TextColor = Color.Black;
                runningFrame.TranslateTo(190, 0, 120);
                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            DisplayContentView();
        }


        private void DisplayContentView()
        {
            if (selection1Active)
            {
                defaultContentView.IsVisible = true;
                shadow1ContentView.IsVisible = false;
                shadow2ContentView.IsVisible = false;
            }
            if (selection2Active)
            {
                defaultContentView.IsVisible = false;
                shadow1ContentView.IsVisible = true;
                shadow2ContentView.IsVisible = false;
            }
            if (selection3Active)
            {
                defaultContentView.IsVisible = false;
                shadow1ContentView.IsVisible = false;
                shadow2ContentView.IsVisible = true;
            }
        }

    }
}
