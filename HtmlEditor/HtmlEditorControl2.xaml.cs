using mshtml;
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

namespace HtmlEditor
{
    /// <summary>
    /// Interaction logic for HtmlEditorControl2.xaml
    /// </summary>
    public partial class HtmlEditorControl2 : UserControl
    {
        string htmlContent = "<html><head></head><body>test</body></html>";
        HTMLDocument doc;
        //IHTMLDocument2 htmlDocument = (IHTMLDocument2)new mshtml.HTMLDocument();

        public HtmlEditorControl2()
        {
            InitializeComponent();
            //htmlDocument.write(htmlContent);

            //IHTMLElementCollection allElements = htmlDocument.all;

            //// Iterate all the elements and display tag names
            //foreach (IHTMLElement element in allElements)
            //{
            //    Console.WriteLine(element.tagName); 
            //}

            NewDocument();

        }

        //Om jag ska göra så här måste jag fånga tangentkommandon, annars blir togglefärgen felaktig. Ex ctrl + B

        public void NewDocument()
        {
            webBrowser.NavigateToString(htmlContent);
            doc = webBrowser.Document as HTMLDocument;
            doc.designMode = "On";
        }


        public static void ToggleBoldFont(HTMLDocument doc)
        {
            doc.execCommand("Bold", false, null);
        }

        public static void ToggleItalicFont(HTMLDocument doc)
        {
            doc.execCommand("Italic", false, null);
        }



        public static void ToggleUnnumberedList(HTMLDocument doc)
        {
            if (doc != null)
            {
                doc.execCommand("InsertUnorderedList", false, null);
            }
        }

        public static void ToggleOrderedList(HTMLDocument doc)
        {
            if (doc != null)
            {
                doc.execCommand("InsertOrderedList", false, null);
            }
        }

        private void ToggleBold_Checked(object sender, RoutedEventArgs e)
        {
            ToggleBoldFont(doc);
        }

        private void ToggleItalic_Checked(object sender, RoutedEventArgs e)
        {
            ToggleItalicFont(doc);
        }

        private void ToggleBulletedList_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void ToggleNumberedList_Checked(object sender, RoutedEventArgs e)
        {
            ToggleOrderedList(doc);
        }


    }
}
