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
using mshtml;

namespace HtmlEditor
{
    /// <summary>
    /// Interaction logic for HtmlEditor.xaml
    /// </summary>
    public partial class HtmlEditorControl : UserControl
    {
        private HTMLDocument htmldoc;
        bool isDocReady;

        public HtmlEditorControl()
        {
            InitializeComponent();
        }

        public HTMLDocument Document
        {
            get { return htmldoc; }
        }


        private string editorBindingContent = string.Empty;

        public string EditorContent
        {
            get { return (string)GetValue(EditorContentProperty); }
            set { SetValue(EditorContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditorContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditorContentProperty =
            DependencyProperty.Register("EditorContent", typeof(string), typeof(HtmlEditorControl), 
                new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnEditorContentChanged)));


        private static void OnEditorContentChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            HtmlEditorControl editor = (HtmlEditorControl)sender;
            editor.editorBindingContent = (string)e.NewValue;
            editor.EditorContent = editor.editorBindingContent;
        }


        private void NotifyBindingContentChanged()
        {
            if (editorBindingContent != this.HtmlContent)
            {
                EditorContent = this.HtmlContent;
            }
        }

        //private void OnVisualEditorStatusTextChanged(object sender, EventArgs e)
        //{
        //    if (Document == null) return;

        //    RaiseEvent(DocumentStateChangedEventArgs);
        //    if (Document.State == HtmlDocumentState.Complete)
        //    {
        //        if (isDocReady)
        //        {
        //            Dispatcher.BeginInvoke(new Action(this.NotifyBindingContentChanged));
        //        }
        //        else
        //        {
        //            isDocReady = true;
        //            RaiseEvent(new RoutedEventArgs(HtmlEditorControl.DocumentReadyEvent));
        //        }
        //    }
        //}


        public string HtmlContent
        {
            get
            {
                if (ToggleCodeMode.IsChecked == true)
                    VisualEditor.Document.Body.InnerHtml = CodeEditorTextBox.Text;
                return VisualEditor.Document.Body.InnerHtml;
            }
            set
            {
                value = (value != null ? value : string.Empty);
                HtmlContent = value;
                if (VisualEditor.Document != null && VisualEditor.Document.Body != null)
                    VisualEditor.Document.Body.InnerHtml = value;

                if (ToggleCodeMode.IsChecked == true)
                    CodeEditorTextBox.Text = VisualEditor.Document.Body.InnerHtml;
            }
        }


    }
}
