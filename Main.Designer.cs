namespace EEW_Viewer
{
    public partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Singen = new System.Windows.Forms.Label();
            this.SAIDAISINDO = new System.Windows.Forms.Label();
            this.M_Depth = new System.Windows.Forms.Label();
            this.Loading = new System.Windows.Forms.Label();
            this.sindo = new System.Windows.Forms.Label();
            this.YohouKeihou_Hou_Final_Time = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Label();
            this.JsonTimer = new System.Windows.Forms.Timer(this.components);
            this.Version = new System.Windows.Forms.Label();
            this.Tunami = new System.Windows.Forms.Label();
            this.Warn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Singen
            // 
            this.Singen.AutoSize = true;
            this.Singen.Font = new System.Drawing.Font("Roboto", 20F);
            this.Singen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Singen.Location = new System.Drawing.Point(90, 24);
            this.Singen.Margin = new System.Windows.Forms.Padding(0);
            this.Singen.Name = "Singen";
            this.Singen.Size = new System.Drawing.Size(0, 41);
            this.Singen.TabIndex = 1;
            // 
            // SAIDAISINDO
            // 
            this.SAIDAISINDO.AutoSize = true;
            this.SAIDAISINDO.Font = new System.Drawing.Font("Roboto", 10F);
            this.SAIDAISINDO.Location = new System.Drawing.Point(10, 26);
            this.SAIDAISINDO.Margin = new System.Windows.Forms.Padding(0);
            this.SAIDAISINDO.Name = "SAIDAISINDO";
            this.SAIDAISINDO.Size = new System.Drawing.Size(0, 20);
            this.SAIDAISINDO.TabIndex = 2;
            // 
            // M_Depth
            // 
            this.M_Depth.AutoSize = true;
            this.M_Depth.Font = new System.Drawing.Font("Roboto", 15F);
            this.M_Depth.Location = new System.Drawing.Point(111, 67);
            this.M_Depth.Margin = new System.Windows.Forms.Padding(0);
            this.M_Depth.Name = "M_Depth";
            this.M_Depth.Size = new System.Drawing.Size(0, 30);
            this.M_Depth.TabIndex = 3;
            // 
            // Loading
            // 
            this.Loading.AutoSize = true;
            this.Loading.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Loading.Font = new System.Drawing.Font("Roboto", 17F);
            this.Loading.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Loading.Location = new System.Drawing.Point(193, 65);
            this.Loading.Margin = new System.Windows.Forms.Padding(0);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(210, 35);
            this.Loading.TabIndex = 4;
            this.Loading.Text = "Now Loading...";
            // 
            // sindo
            // 
            this.sindo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sindo.Font = new System.Drawing.Font("Roboto", 30F);
            this.sindo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sindo.Location = new System.Drawing.Point(-4, 47);
            this.sindo.Margin = new System.Windows.Forms.Padding(0);
            this.sindo.Name = "sindo";
            this.sindo.Size = new System.Drawing.Size(116, 57);
            this.sindo.TabIndex = 5;
            this.sindo.Tag = "Shido";
            this.sindo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YohouKeihou_Hou_Final_Time
            // 
            this.YohouKeihou_Hou_Final_Time.AutoSize = true;
            this.YohouKeihou_Hou_Final_Time.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YohouKeihou_Hou_Final_Time.ForeColor = System.Drawing.Color.GhostWhite;
            this.YohouKeihou_Hou_Final_Time.Location = new System.Drawing.Point(0, 0);
            this.YohouKeihou_Hou_Final_Time.Margin = new System.Windows.Forms.Padding(0);
            this.YohouKeihou_Hou_Final_Time.Name = "YohouKeihou_Hou_Final_Time";
            this.YohouKeihou_Hou_Final_Time.Size = new System.Drawing.Size(0, 18);
            this.YohouKeihou_Hou_Final_Time.TabIndex = 6;
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("MS UI Gothic", 1F);
            this.Back.Location = new System.Drawing.Point(0, 0);
            this.Back.Margin = new System.Windows.Forms.Padding(0);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(426, 133);
            this.Back.TabIndex = 50;
            this.Back.Text = "　　　　";
            this.Back.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // JsonTimer
            // 
            this.JsonTimer.Enabled = true;
            this.JsonTimer.Interval = 3000;
            this.JsonTimer.Tick += new System.EventHandler(this.EEW);
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Font = new System.Drawing.Font("Roboto", 6F);
            this.Version.Location = new System.Drawing.Point(216, 101);
            this.Version.Name = "Version";
            this.Version.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Version.Size = new System.Drawing.Size(0, 13);
            this.Version.TabIndex = 53;
            // 
            // Tunami
            // 
            this.Tunami.AutoSize = true;
            this.Tunami.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tunami.Location = new System.Drawing.Point(310, 68);
            this.Tunami.Margin = new System.Windows.Forms.Padding(0);
            this.Tunami.Name = "Tunami";
            this.Tunami.Size = new System.Drawing.Size(0, 18);
            this.Tunami.TabIndex = 54;
            // 
            // Warn
            // 
            this.Warn.AutoSize = true;
            this.Warn.Font = new System.Drawing.Font("Roboto", 10F);
            this.Warn.Location = new System.Drawing.Point(5, 95);
            this.Warn.Margin = new System.Windows.Forms.Padding(0);
            this.Warn.Name = "Warn";
            this.Warn.Size = new System.Drawing.Size(0, 20);
            this.Warn.TabIndex = 55;
            this.Warn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(412, 113);
            this.Controls.Add(this.Warn);
            this.Controls.Add(this.Loading);
            this.Controls.Add(this.SAIDAISINDO);
            this.Controls.Add(this.Singen);
            this.Controls.Add(this.YohouKeihou_Hou_Final_Time);
            this.Controls.Add(this.sindo);
            this.Controls.Add(this.M_Depth);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.Tunami);
            this.Controls.Add(this.Back);
            this.ForeColor = System.Drawing.Color.GhostWhite;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EEW_Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Singen;
        private System.Windows.Forms.Label SAIDAISINDO;
        private System.Windows.Forms.Label M_Depth;
        private System.Windows.Forms.Label Loading;
        private System.Windows.Forms.Label sindo;
        private System.Windows.Forms.Label YohouKeihou_Hou_Final_Time;
        private System.Windows.Forms.Label Back;
        private System.Windows.Forms.Timer JsonTimer;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Label Tunami;
        private System.Windows.Forms.Label Warn;
    }
}

