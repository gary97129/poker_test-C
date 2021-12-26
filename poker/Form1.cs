using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace poker
{
    public partial class Form1 : Form
    {
        System.Net.WebClient WC = new System.Net.WebClient();
        Random rnd = new Random();
        List<string> cards = new List<string> {""};
        int po = 1;
        double n;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setpb();
            
        }

        private void setpb()
        {
            if (po < 6 && Convert.ToDouble(button1.Text) < 10.5)
            {
                string[] f = { "spade", "heart", "diamond", "club" };
                n = rnd.Next(13) + 1;
                PictureBox pb = new PictureBox();
                pb.Location = new Point(po * 120 - 60, 100);
                pb.Size = new Size(100, 200);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                string card = "";
                while (cards.Contains(card))
                {
                    card = $"https://goclass.github.io/poker/{n}_of_{f[rnd.Next(4)]}s.png";
                }
                MemoryStream Ms = new MemoryStream(WC.DownloadData(card));
                pb.Image = Image.FromStream(Ms);
                this.Controls.Add(pb);
                po += 1;
                if (n > 10)
                {
                    n = 0.5;
                }
                button1.Text = (Convert.ToDouble(button1.Text) + n).ToString();
                cards.Add(card);
            }
        }
    }
}
