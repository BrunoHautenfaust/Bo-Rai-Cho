using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.UI.Input.Inking;
using Windows.Devices.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Input;

using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        InkManager inkManager = new Windows.UI.Input.Inking.InkManager();
        Point previousContactPt;
        uint penID = 0;
        const double STROKETHICKNESS = 5;
        uint touchID = 0;

        static SolidColorBrush changedColor = new SolidColorBrush(Windows.UI.Colors.Black);

        public MainPage()
        {
            this.InitializeComponent();

            InkCanvas.PointerPressed += new PointerEventHandler(InkCanvas_PointerPressed);
            InkCanvas.PointerMoved += new PointerEventHandler(InkCanvas_PointerMoved);
            InkCanvas.PointerReleased += new PointerEventHandler(InkCanvas_PointerReleased);
            InkCanvas.PointerExited += new PointerEventHandler(InkCanvas_PointerReleased);
        }

        public void InkCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // Get information about the pointer location.
            PointerPoint pt = e.GetCurrentPoint(InkCanvas);
            previousContactPt = pt.Position;

            // Accept input only from a pen or mouse with the left button pressed. 
            PointerDeviceType pointerDevType = e.Pointer.PointerDeviceType;
            if (pointerDevType == PointerDeviceType.Pen ||
                    pointerDevType == PointerDeviceType.Mouse &&
                    pt.Properties.IsLeftButtonPressed)
            {
                // Pass the pointer information to the InkManager.
                inkManager.ProcessPointerDown(pt);
                penID = pt.PointerId;

                e.Handled = true;
            }

            else if (pointerDevType == PointerDeviceType.Touch)
            {
                // Process touch input
            }
        }

        public void InkCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerId == penID)
            {
                PointerPoint pt = e.GetCurrentPoint(InkCanvas);

                // Render a red line on the canvas as the pointer moves. 
                // Distance() is an application-defined function that tests
                // whether the pointer has moved far enough to justify 
                // drawing a new line.
                Point currentContactPt = pt.Position;
                if (Distance(currentContactPt, previousContactPt) > 2)
                {
                    Line line = new Line()
                    {
                        X1 = previousContactPt.X,
                        Y1 = previousContactPt.Y,
                        X2 = currentContactPt.X,
                        Y2 = currentContactPt.Y,
                        StrokeThickness = STROKETHICKNESS,
                        Stroke = changedColor   // Stroke = new SolidColorBrush(Windows.UI.Colors.Black)
                    };

                    previousContactPt = currentContactPt;

                    // Draw the line on the canvas by adding the Line object as
                    // a child of the Canvas object.
                    InkCanvas.Children.Add(line);

                    // Pass the pointer information to the InkManager.
                    inkManager.ProcessPointerUpdate(pt);
                }
            }

            else if (e.Pointer.PointerId == touchID)
            {
                // Process touch input
            }

            e.Handled = true;
        }

        public void InkCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerId == penID)
            {
                PointerPoint pt = e.GetCurrentPoint(InkCanvas);

                // Pass the pointer information to the InkManager. 
                inkManager.ProcessPointerUp(pt);
            }

            else if (e.Pointer.PointerId == touchID)
            {
                // Process touch input
            }

            touchID = 0;
            penID = 0;

            // Call an application-defined function to render the ink strokes.
            RenderAllStrokes();

            e.Handled = true;
        }

        private void RenderAllStrokes()
        {
            // Clear the canvas.
          //  InkCanvas.Children.Clear();

            // Get the InkStroke objects.
            IReadOnlyList<InkStroke> inkStrokes = inkManager.GetStrokes();

            // Process each stroke.
            foreach (InkStroke inkStroke in inkStrokes)
            {
                PathGeometry pathGeometry = new PathGeometry();
                PathFigureCollection pathFigures = new PathFigureCollection();
                PathFigure pathFigure = new PathFigure();
                PathSegmentCollection pathSegments = new PathSegmentCollection();

                // Create a path and define its attributes.
                Windows.UI.Xaml.Shapes.Path path = new Windows.UI.Xaml.Shapes.Path();
                /*
                Color red = new Color();
                red.A = 1;
                red.R = 55;
                red.G = 55;
                red.B = 55;
                path.Stroke = new SolidColorBrush(red);  // Colors.Red
                path.StrokeThickness = STROKETHICKNESS;
                */

                // Get the stroke segments.
                IReadOnlyList<InkStrokeRenderingSegment> segments;
                segments = inkStroke.GetRenderingSegments();

                // Process each stroke segment.
                bool first = true;
                foreach (InkStrokeRenderingSegment segment in segments)
                {
                    // The first segment is the starting point for the path.
                    if (first)
                    {
                        pathFigure.StartPoint = segment.BezierControlPoint1;
                        first = false;
                    }

                    // Copy each ink segment into a bezier segment.
                    BezierSegment bezSegment = new BezierSegment();
                    bezSegment.Point1 = segment.BezierControlPoint1;
                    bezSegment.Point2 = segment.BezierControlPoint2;
                    bezSegment.Point3 = segment.Position;

                    // Add the bezier segment to the path.
                    pathSegments.Add(bezSegment);
                }

                // Build the path geometerty object.
                pathFigure.Segments = pathSegments;
                pathFigures.Add(pathFigure);
                pathGeometry.Figures = pathFigures;

                // Assign the path geometry object as the path data.
                path.Data = pathGeometry;

                // Render the path by adding it as a child of the Canvas object.
                InkCanvas.Children.Add(path);
            }
        }

        private double Distance(Point currentContact, Point previousContact)
        {
            return Math.Sqrt(Math.Pow(currentContact.X - previousContact.X, 2) +
                    Math.Pow(currentContact.Y - previousContact.Y, 2));
        }
        
        private static bool flag = false;
        public static bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        private static string keyword;

        public static string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }

        public static void PickColor() { 
        if (MainPage.Flag == true)
            {
               // System.Diagnostics.Debug.WriteLine("keyword: " + Keyword);
                switch (Keyword)
                {
                    case "Black": changedColor = new SolidColorBrush(Windows.UI.Colors.Black); break;
                    case "Red": changedColor = new SolidColorBrush(Windows.UI.Colors.Red); break;
                    case "Orange": changedColor = new SolidColorBrush(Windows.UI.Colors.Orange); break;
                    case "Yellow": changedColor = new SolidColorBrush(Windows.UI.Colors.Yellow); break;
                    case "Green": changedColor = new SolidColorBrush(Windows.UI.Colors.Green); break;
                    case "White": changedColor = new SolidColorBrush(Windows.UI.Colors.White); break;
                    case "Gray": changedColor = new SolidColorBrush(Windows.UI.Colors.Gray); break;
                    case "Blue": changedColor = new SolidColorBrush(Windows.UI.Colors.Blue); break;
                    case "Purple": changedColor = new SolidColorBrush(Windows.UI.Colors.Purple); break;
                    case "Brown": changedColor = new SolidColorBrush(Windows.UI.Colors.Brown); break;
                    default: break;
                }
                MainPage.Flag = false;
            }
        }

        private void BlackRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            changedColor = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        public void RedRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            changedColor = new SolidColorBrush(Windows.UI.Colors.Red);
        }

        private void OrangeRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            changedColor = new SolidColorBrush(Windows.UI.Colors.Orange);
        }

        private void YellowRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            changedColor = new SolidColorBrush(Windows.UI.Colors.Yellow);
        }

        private void GreenRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            changedColor = new SolidColorBrush(Windows.UI.Colors.Green);
        }

        private void WhiteRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            changedColor = new SolidColorBrush(Windows.UI.Colors.White);
        }

        private void GrayRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            changedColor = new SolidColorBrush(Windows.UI.Colors.Gray);
        }

        private void BlueRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            changedColor = new SolidColorBrush(Windows.UI.Colors.Blue);
        }

        private void PurpleRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            changedColor = new SolidColorBrush(Windows.UI.Colors.Purple);
        }

        private void BrownRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            changedColor = new SolidColorBrush(Windows.UI.Colors.Brown);
        }

        private void ListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            InkCanvas.Children.Clear();
        }
    }
}
