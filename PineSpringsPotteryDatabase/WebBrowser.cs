using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PineSpringsPotteryDatabase
{
    public partial class WebBrowser : Form
    {
        private String website;

        public WebBrowser(String pWebsite)
        {
            website = pWebsite;
            InitializeComponent();
        }

        private void WebBrowser_Load(object sender, EventArgs e)
        {
            // When the form loads, open this web page.
            webBrowser1.Navigate(website);
        }



        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Better use the e parameter to get the url.
            // ... This makes the method more generic and reusable.
            this.Text = e.Url.ToString() + " loaded";
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // Set text while the page has not yet loaded.
            this.Text = "Navigating";
        }
    }
}
