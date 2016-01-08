// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    using Windows.UI;
    using Windows.UI.Core;
    using Windows.UI.Input.Inking;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static Color changedColor;

        private static InkDrawingAttributes inkDrawingAttributes = new InkDrawingAttributes();
        private static InkCanvas staticInkCanvas;

        private static Color black = Windows.UI.Colors.Black;
        private static Color red = Windows.UI.Colors.Red;
        private static Color orange = Windows.UI.Colors.Orange;
        private static Color yellow = Windows.UI.Colors.Yellow;
        private static Color green = Windows.UI.Colors.Green;

        private static Color white = Windows.UI.Colors.White;
        private static Color blue = Windows.UI.Colors.Blue;
        private static Color gray = Windows.UI.Colors.Gray;
        private static Color purple = Windows.UI.Colors.Purple;
        private static Color brown = Windows.UI.Colors.Brown;

        public MainPage()
        {
            this.InitializeComponent();

            staticInkCanvas = inkCanvas;
            staticInkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch;
        }
        
        public static Color ChangedColor
        {
            get { return changedColor; }
            set
            {
                changedColor = value;
                inkDrawingAttributes.Color = ChangedColor;
                staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
            }
        }

        public static void ClearCanvas()
        {
            staticInkCanvas.InkPresenter.StrokeContainer.Clear();
        }

        private void BlackRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = black;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        public void RedRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = red;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }
        
        private void OrangeRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = orange;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void YellowRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = yellow;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void GreenRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = green;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void WhiteRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = white;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void GrayRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = gray;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void BlueRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = blue;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void PurpleRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = purple;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void BrownRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = brown;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void ListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClearCanvas();
        }
        
    }
}
