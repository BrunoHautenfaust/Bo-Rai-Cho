// UNUSED FOR NOW           <<<<<<<<<<<<<<<<<<<< !!!!!!!!!!!!!!!!!!!!!!!!!!!

namespace App1
{
    using System.ComponentModel;
    using Windows.UI;
    using Windows.UI.Input.Inking;

    public   class ColorChanger : INotifyPropertyChanged
    {
        //  private   bool flag = false;
        private   string keyword;
        private   InkDrawingAttributes inkDrawingAttributes = new InkDrawingAttributes();

        private Color changedColor;
        private   Color black = Colors.Black;
        private   Color red = Colors.Red;
        private   Color orange = Colors.Orange;
        private   Color yellow = Colors.Yellow;
        private   Color green = Colors.Green;

        private   Color white = Colors.White;
        private   Color blue = Colors.Blue;
        private   Color gray = Colors.Gray;
        private   Color purple = Colors.Purple;
        private   Color brown = Colors.Brown;

        // Weird error! Bug maybe?
     //   private Color changedColor = black;


        public event PropertyChangedEventHandler PropertyChanged;

        public ColorChanger CChanger
        {
            get { return this; }
        }


        #region Colors Props

        public   Color Black
        {
            get { return black; }
        }

        public   Color Red
        {
            get { return red; }
        }

        public   Color Orange
        {
            get { return orange; }
        }

        public   Color Yellow
        {
            get { return yellow; }
        }

        public   Color Green
        {
            get { return green; }
        }

        public   Color White
        {
            get { return white; }
        }

        public   Color Blue
        {
            get { return blue; }
        }

        public   Color Gray
        {
            get { return gray; }
        }

        public   Color Purple
        {
            get { return purple; }
        }

        public   Color Brown
        {
            get { return brown; }
        }
        #endregion
        public   InkDrawingAttributes InkDrawingAttributes
        {
            get { return inkDrawingAttributes; }
            set { inkDrawingAttributes = value; }
        }

        public   Color ChangedColor
        {
            get { return changedColor; }
            set
            {
                changedColor = value;
                // Insert notification here!
                Notify();
              
            }
        }

        private   void Notify()
        {
            System.Diagnostics.Debug.WriteLine("Notified!");
            // must notify InkCanvas in MainPage here. Delegate?
        }

        /*
public   bool Flag
{
   get { return flag; }
   set { flag = value; }
}
*/
        public   string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }

        public   void PickColor()
        {
          //  if (Flag == true)
         //   {
                // System.Diagnostics.Debug.WriteLine("keyword: " + Keyword);
                switch (Keyword)
                {
// Maybe create an InkCanvas object
                    case "Red": ChangedColor = Red;
                   // NotifyEventHandler n;
                   // InkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(ColorChanger.InkDrawingAttributes);
                    break;

                    case "Blue": ChangedColor = Blue; break;
                default: break;
                }
            InkDrawingAttributes.Color = ChangedColor;
            //  Flag = false;
            //  }
        }
    }
}
