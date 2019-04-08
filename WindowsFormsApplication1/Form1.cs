using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://vnexpress.net/";

            IList<IWebElement> elements = driver.FindElements(By.CssSelector("article.list_news"));
            int y = 0;
            foreach(IWebElement article in elements)
            {
                try
                {
                    string title = article.FindElement(By.CssSelector("h4.title_news")).Text;
                    string des = article.FindElement(By.CssSelector("p.description")).Text;
                    string path = article.FindElement(By.CssSelector("div thumb_art img")).GetAttribute("src");

                    New n = new New();
                    n.Label1.Text = title;
                    n.Label2.Text = des;
                    n.PictureBox1.ImageLocation = path;
                    n.Location = new Point(0, y);

                    panel1.Controls.Add(n);
                    y += 100;
                }
                catch (Exception ex)
                { }
                
            }
            driver.Quit();
        }
    }
}
