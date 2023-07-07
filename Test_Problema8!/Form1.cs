using System;
using System.Net.Http;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Test_Problema8_
{
    public partial class Form1 : Form
    {
        public List<Serial> seriale;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var endpoints = new Uri("https://api.tvmaze.com/search/shows?q=ted");
                var result = client.GetAsync(endpoints).Result;
                var json = result.Content.ReadAsStringAsync().Result;


                seriale = JsonConvert.DeserializeObject<List<Serial>>(json);

                Serial matchingShow = seriale.FirstOrDefault(s => s.Show != null && s.Show.Name != null && s.Show.Name.Contains(textBox1.Text));



                if (matchingShow != null)
                {
                    Show show = matchingShow.Show;
                    string serializedShow = JsonConvert.SerializeObject(show, Formatting.Indented);
                    richTextBox1.AppendText(serializedShow + Environment.NewLine);
                }
                else
                {
                    richTextBox1.AppendText("No matching show found." + Environment.NewLine);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }



    public class Serial
    {
        public double Score { get; set; }
        public Show Show { get; set; }
    }

    public class Show
    {
        public int ID { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public List<string> Genres { get; set; }
        public string Status { get; set; }
        public int? Runtime { get; set; }
        public int? AverageRuntime { get; set; }
        public string Premiered { get; set; }
        public string Ended { get; set; }
        public string OfficialSite { get; set; }
        public Schedule Schedule { get; set; }
        public Rating Rating { get; set; }
        public int Weight { get; set; }
        public Network Network { get; set; }
        public WebChannel WebChannel { get; set; }
        public string DVDCountry { get; set; }
        public Externals Externals { get; set; }
        public Image Image { get; set; }
        public string Summary { get; set; }
        public long Updated { get; set; }
        public Links Links { get; set; }
    }

    public class Schedule
    {
        public string Time { get; set; }
        public List<string> Days { get; set; }
    }

    public class Rating
    {
        public double? Average { get; set; }
    }

    public class Network
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public string OfficialSite { get; set; }
    }

    public class WebChannel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public object Country { get; set; }
        public string OfficialSite { get; set; }
    }

    public class Externals
    {
        public object Tvrage { get; set; }
        public int? TheTVDB { get; set; }
        public string IMDB { get; set; }
    }

    public class Image
    {
        public string Medium { get; set; }
        public string Original { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Timezone { get; set; }
    }

    public class Links
    {
        public Self Self { get; set; }
        public Previousepisode Previousepisode { get; set; }
    }

    public class Self
    {
        public string Href { get; set; }
    }

    public class Previousepisode
    {
        public string Href { get; set; }
    }

  

}
