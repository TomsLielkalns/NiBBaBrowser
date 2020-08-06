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
            InitializeForm();
        }

        private void InitializeForm()
        {
            tabPageAdd.Height = ClientRectangle.Height - 25;
        }

        private void InitalizeBrowser()
        {
            Cef.Initialize(new CefSettings());
            //tabPageAdd.TabPages[0].Dispose();
            tabPageAdd.TabPages[0].Dispose();
            AddBrowserTab();
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            Navigate(toolStripAdressBar.Text);
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }
        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                toolStripAdressBar.Text = e.Address;
            }));
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)sender;
            this.Invoke(new MethodInvoker(() =>
            {
                selectedBrowser.Parent.Text = e.Title;
            }));
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            browser.Reload();
        }

        private void toolStripAdressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Navigate(toolStripAdressBar.Text);
            }
        }
        private void Navigate(string address)
        {
            try
            {
                var selectedBrowser = (ChromiumWebBrowser)tabPageAdd.SelectedTab.Controls[0];
                selectedBrowser.Load(address);
            }
            catch
            {

            }
        }

        private void AddBrowserTab()
        {
            //adding a tab
            var newTabPage = new TabPage();
            newTabPage.Text = "New Tab";
            tabPageAdd.TabPages.Add(newTabPage);


            //adding browser
            browser = new ChromiumWebBrowser("https://google.com");
            browser.Dock = DockStyle.Fill;
            browser.AddressChanged += Browser_AddressChanged;
            browser.TitleChanged += Browser_TitleChanged;
            browser.AddressChanged += Browser_AddressChanged;
            newTabPage.Controls.Add(browser);
        }


        private void toolStripButtonAddTab_Click(object sender, EventArgs e)
        {
            AddBrowserTab();
            //select the latest browser tab
            tabPageAdd.SelectedTab = tabPageAdd.TabPages[tabPageAdd.TabPages.Count - 1];
        }
    }
}
