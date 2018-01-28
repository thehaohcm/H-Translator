using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;


namespace H_BingTranslator
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            boxfrom.Text = "Auto";
            boxto.Text = "Vietnamese";
            comboBox1.Text = "Auto";
            comboBox2.Text = "Vietnamese";
        }

        private string viettat(string str)
        {
            var tranfrom = new[] { "Auto", "Arabic", "Bulgarian", "Catalan", "Chinese (Simplified)", "Chinese (Traditional)", "Czech", "Danish", "Dutch", "English", "Estonian", "Finnish", "French", "German", "Greek", "Haitian Creole", "Hebrew", "Hindi", "Hmong Daw", "Hungarian", "Indonesian", "Italian", "Japanese", "Klingon", "Klingon (pIqaD)", "Korean", "Latvian", "Lithuanian", "Malay", "Maltese", "Norwegian", "Persian", "Polish", "Portuguese", "Romanian", "Russian", "Slovak", "Slovenian", "Spanish", "Swedish", "Thai", "Turkish", "Ukrainian", "Urdu", "Vietnamese", "Welsh" };
            var tranto = new[] { "", "ar", "bg", "ca", "zh-CHS", "zh-CHT", "cs", "da", "nl", "en", "et", "fi", "fr", "de", "el", "ht", "he", "hi", "mww", "hu", "id", "it", "ja", "tlh", "tlh-Qaak", "ko", "lv", "lt", "ms", "mt", "no", "fa", "pl", "pt", "ro", "ru", "sk", "sl", "es", "sv", "th", "tr", "uk", "ur", "vi", "cy" };
            int i = 0;
            for (; i < tranfrom.Length; i++)
            {
                if (str == tranfrom[i])
                    break;
            }
            return tranto[i];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            this.Cursor=Cursors.WaitCursor;
            
            try
            {

                txtTranslatedText.Text = bingTranslate(txtTranslateFrom.Text, viettat(boxfrom.Text), viettat(boxto.Text)); //bingTranslate(txtTranslateFrom.Text,fromtxt,totxt);
            }
            catch (Exception)
            {
                MessageBox.Show("Đã có lỗi xảy ra", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
            
        }


        public String bingTranslate(String query, String langFrom, String langTo)
        {   
            
            String appId = "78280AF4DFA1CE1676AFE86340C690023A5AC139";   

            String url = "http://api.microsofttranslator.com/V2/Ajax.svc/Translate?appId="+     appId+"&from=" + langFrom + "&to=" + langTo + "&text=" + query;
            
            //string solute;
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();
            string kq=result.Replace("\"", "");
            return kq.Replace("\\u000d\\u000a", "\n");
        } 
       
        private void txtTranslateFrom_TextChanged(object sender, EventArgs e)
        {
            if (txtTranslateFrom.Text != null)
                Button1.Enabled = true;
            else
                Button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Computer my = new Computer();
            var i =my.Clock.LocalTime;
            string hours = Convert.ToString(my.Clock.LocalTime.Hour);
            string minute = Convert.ToString(my.Clock.LocalTime.Minute);
            string sencond = Convert.ToString(my.Clock.LocalTime.Second);
            if (i.Hour < 10)
                hours = "0" + hours;
            if (i.Minute < 10)
                minute = "0" + minute;
            if (i.Second < 10)
                sencond = "0"+sencond;
            Clock.Text = hours +" : "+ minute+" : " + sencond;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                Process.Start("http://www.microsofttranslator.com/bv.aspx?from="+viettat(comboBox1.Text)+"&to="+viettat(comboBox2.Text)+"&a=" + url.Text);
                
            }
                catch
            {
                MessageBox.Show("Đã có lỗi xảy ra", "Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        

        private void tabPage1_Click(object sender, EventArgs e)
        {
            

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }


        
    }
}
