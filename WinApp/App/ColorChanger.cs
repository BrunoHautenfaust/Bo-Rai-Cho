namespace App1
{
    using Windows.UI;
    using Windows.UI.Input.Inking;

    public static class ColorChanger
    {
        private static string keyword;
        private static InkDrawingAttributes inkDrawingAttributes = new InkDrawingAttributes();

        private static Color black = Colors.Black;
        private static Color red = Colors.Red;
        private static Color orange = Colors.Orange;
        private static Color yellow = Colors.Yellow;
        private static Color green = Colors.Green;

        private static Color white = Colors.White;
        private static Color blue = Colors.Blue;
        private static Color gray = Colors.Gray;
        private static Color purple = Colors.Purple;
        private static Color brown = Colors.Brown;


        #region Colors Props

        public static Color Black
        {
            get { return black; }
        }

        public static Color Red
        {
            get { return red; }
        }

        public static Color Orange
        {
            get { return orange; }
        }

        public static Color Yellow
        {
            get { return yellow; }
        }

        public static Color Green
        {
            get { return green; }
        }

        public static Color White
        {
            get { return white; }
        }

        public static Color Blue
        {
            get { return blue; }
        }

        public static Color Gray
        {
            get { return gray; }
        }

        public static Color Purple
        {
            get { return purple; }
        }

        public static Color Brown
        {
            get { return brown; }
        }
        #endregion

        public static InkDrawingAttributes InkDrawingAttributes
        {
            get { return inkDrawingAttributes; }
            set { inkDrawingAttributes = value; }
        }

        public static string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }

        public static void PickColor()
        {
                // System.Diagnostics.Debug.WriteLine("keyword: " + Keyword);
                switch (Keyword)
                {
                case "Black":
                    MainPage.ChangedColor = Black;
                    break;

                case "Red":
                    MainPage.ChangedColor = Red;
                    break;

                case "Orange":
                    MainPage.ChangedColor = Orange;
                    break;

                case "Yellow":
                    MainPage.ChangedColor = Yellow;
                    break;

                case "Green":
                    MainPage.ChangedColor = Green;
                    break;

                case "White":
                    MainPage.ChangedColor = White;
                    break;

                case "Blue":
                    MainPage.ChangedColor = Blue;
                    break;

                case "Gray":
                    MainPage.ChangedColor = Gray;
                    break;

                case "Purple":
                    MainPage.ChangedColor = Purple;
                    break;

                case "Brown":
                    MainPage.ChangedColor = Brown;
                    break;

                default: break;
                }
        }
    }
}
