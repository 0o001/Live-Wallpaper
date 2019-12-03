namespace Live_Wallpaper
{
    partial class frm_livewallpaper
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_extract = new System.Windows.Forms.Button();
            this.pbr_extract = new System.Windows.Forms.ProgressBar();
            this.flp_pictures = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_run = new System.Windows.Forms.Button();
            this.bgw_run = new System.ComponentModel.BackgroundWorker();
            this.bgw_pictures = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btn_extract
            // 
            this.btn_extract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_extract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_extract.Location = new System.Drawing.Point(12, 12);
            this.btn_extract.Name = "btn_extract";
            this.btn_extract.Size = new System.Drawing.Size(661, 33);
            this.btn_extract.TabIndex = 0;
            this.btn_extract.Text = "Video Dosyası Seç";
            this.btn_extract.UseVisualStyleBackColor = true;
            this.btn_extract.Click += new System.EventHandler(this.btn_extract_Click);
            // 
            // pbr_extract
            // 
            this.pbr_extract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbr_extract.Location = new System.Drawing.Point(12, 51);
            this.pbr_extract.Name = "pbr_extract";
            this.pbr_extract.Size = new System.Drawing.Size(661, 23);
            this.pbr_extract.TabIndex = 1;
            // 
            // flp_pictures
            // 
            this.flp_pictures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_pictures.AutoScroll = true;
            this.flp_pictures.Location = new System.Drawing.Point(12, 80);
            this.flp_pictures.Name = "flp_pictures";
            this.flp_pictures.Size = new System.Drawing.Size(661, 225);
            this.flp_pictures.TabIndex = 2;
            // 
            // btn_run
            // 
            this.btn_run.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_run.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_run.Location = new System.Drawing.Point(12, 311);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(661, 35);
            this.btn_run.TabIndex = 4;
            this.btn_run.Text = "Çalıştır";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // bgw_run
            // 
            this.bgw_run.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_run_DoWork);
            // 
            // bgw_pictures
            // 
            this.bgw_pictures.WorkerReportsProgress = true;
            this.bgw_pictures.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_pictures_DoWork);
            this.bgw_pictures.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_pictures_ProgressChanged);
            // 
            // frm_livewallpaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 358);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.flp_pictures);
            this.Controls.Add(this.pbr_extract);
            this.Controls.Add(this.btn_extract);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_livewallpaper";
            this.Text = "Live Wallpaper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_extract;
        private System.Windows.Forms.ProgressBar pbr_extract;
        private System.Windows.Forms.FlowLayoutPanel flp_pictures;
        private System.Windows.Forms.Button btn_run;
        private System.ComponentModel.BackgroundWorker bgw_run;
        private System.ComponentModel.BackgroundWorker bgw_pictures;
    }
}

