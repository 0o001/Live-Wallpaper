using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Live_Wallpaper
{
    public partial class frm_livewallpaper : Form
    {
        public frm_livewallpaper()
        {
            InitializeComponent();
        }

        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Themes\\Live";

        OpenFileDialog ofd_file = new OpenFileDialog();

        private void btn_extract_Click(object sender, EventArgs e)
        {
            ofd_file.Filter = "Video Dosyası |*.mp4";

            if (ofd_file.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                using (var engine = new Engine())
                {
                    var mp4 = new MediaFile { Filename = ofd_file.FileName };

                    engine.GetMetadata(mp4);

                    pbr_extract.Maximum = mp4.Metadata.Duration.Milliseconds;
                }

                bgw_pictures.RunWorkerAsync();
            }
        }

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched
        }
        
        private void btn_run_Click(object sender, EventArgs e)
        {
            bgw_run.RunWorkerAsync();
        }

        private void bgw_run_DoWork(object sender, DoWorkEventArgs e)
        {
            IEnumerable<string> paths = Directory.EnumerateFiles(folder).Select(fn => new FileInfo(fn)).OrderBy(item => item.CreationTime).Select( item => item.FullName);
            
            while (true)
            {
                foreach (string path in paths)
                {
                    SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
                }
            }
        }

        private void bgw_pictures_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var engine = new Engine())
            {
                var mp4 = new MediaFile { Filename = ofd_file.FileName };

                engine.GetMetadata(mp4);

                int i = 0;
                while (i < mp4.Metadata.Duration.Milliseconds)
                {
                    string wallpaperPath = Path.Combine(folder, String.Format("{0}.jpg", i));

                    var options = new ConversionOptions { Seek = TimeSpan.FromMilliseconds(i * 30) };
                    var outputFile = new MediaFile { Filename = wallpaperPath };
                    engine.GetThumbnail(mp4, outputFile, options);


                    bgw_pictures.ReportProgress(i, wallpaperPath);

                    i++;
                }
            }
        }

        private void bgw_pictures_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PictureBox pcr_picture = new PictureBox();
            pcr_picture.ImageLocation = (string) e.UserState;
            pcr_picture.Width = 150;
            pcr_picture.Height = 100;
            pcr_picture.SizeMode = PictureBoxSizeMode.StretchImage;
            flp_pictures.Controls.Add(pcr_picture);

            pbr_extract.Value++;
           
            if (pbr_extract.Maximum == pbr_extract.Value)
            {
                MessageBox.Show("Video Çıkartıldı", "Bilgi", MessageBoxButtons.OK);
            }
        }
    }
}
