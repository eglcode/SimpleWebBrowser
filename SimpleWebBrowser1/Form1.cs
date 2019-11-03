using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //Close the program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was made by Eric.");
        }

        /// <summary>
        /// When Navigate is clicked the web control will display the requested page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }

        private void NavigateToPage()
        {
            toolStripStatusLabel1.Text = "Navigation has started";
            
            //Dsiabling buttons until navigation is completed.
            button1.Enabled = false;
            textBox1.Enabled = false;
            //navigating to site.
            webBrowser1.Navigate(textBox1.Text);
        }

        //Will fire every time a key is pressed.
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //If enter is pressed we will call the Navigate function. 
            //had to cast ConsoleKey to char 
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage();
            }
        }

        //Re-enabling text box and navigation button once the page has fully loaded.
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;

            toolStripStatusLabel1.Text = "Navigation Complete";
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
            //Future functionality
        }

        //Displaying the progress bar
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            //Not running progress percentage if we're not loading anything (ie: avoid divide by 0 exception)
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        }
    }
}
