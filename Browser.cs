using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace NiBBaBrowser
{
    public partial class Browser : Form
    {
        private ChromiumWebBrowser browser;


        public Browser()
        {
            InitializeComponent();
            InitalizeBrowser();
        }

        private void InitalizeBrowser()
        {
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser("https://www.salacgrivasvsk.lv");
            browser.Dock = DockStyle.Fill;
            this.Controls.Add(browser);
        }
    }
}
