namespace WinForms_DDC
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.B_TrackBar = new System.Windows.Forms.TrackBar();
            this.BValue_now = new System.Windows.Forms.Label();
            this.B_btn = new System.Windows.Forms.Button();
            this.BValue_set = new System.Windows.Forms.Label();
            this.CValue_set = new System.Windows.Forms.Label();
            this.C_btn = new System.Windows.Forms.Button();
            this.CValue_now = new System.Windows.Forms.Label();
            this.C_TrackBar = new System.Windows.Forms.TrackBar();
            this.modeA = new System.Windows.Forms.Button();
            this.modeB = new System.Windows.Forms.Button();
            this.modeC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.B_TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // B_TrackBar
            // 
            this.B_TrackBar.Location = new System.Drawing.Point(32, 33);
            this.B_TrackBar.Maximum = 100;
            this.B_TrackBar.Name = "B_TrackBar";
            this.B_TrackBar.Size = new System.Drawing.Size(104, 45);
            this.B_TrackBar.TabIndex = 0;
            this.B_TrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // BValue_now
            // 
            this.BValue_now.AutoSize = true;
            this.BValue_now.Location = new System.Drawing.Point(158, 66);
            this.BValue_now.Name = "BValue_now";
            this.BValue_now.Size = new System.Drawing.Size(59, 12);
            this.BValue_now.TabIndex = 1;
            this.BValue_now.Text = "當前亮度 :";
            // 
            // B_btn
            // 
            this.B_btn.Location = new System.Drawing.Point(32, 84);
            this.B_btn.Name = "B_btn";
            this.B_btn.Size = new System.Drawing.Size(75, 23);
            this.B_btn.TabIndex = 2;
            this.B_btn.Text = "變更亮度";
            this.B_btn.UseVisualStyleBackColor = true;
            this.B_btn.Click += new System.EventHandler(this.B_btn_Click);
            // 
            // BValue_set
            // 
            this.BValue_set.AutoSize = true;
            this.BValue_set.Location = new System.Drawing.Point(158, 33);
            this.BValue_set.Name = "BValue_set";
            this.BValue_set.Size = new System.Drawing.Size(59, 12);
            this.BValue_set.TabIndex = 4;
            this.BValue_set.Text = "設定亮度 :";
            // 
            // CValue_set
            // 
            this.CValue_set.AutoSize = true;
            this.CValue_set.Location = new System.Drawing.Point(158, 146);
            this.CValue_set.Name = "CValue_set";
            this.CValue_set.Size = new System.Drawing.Size(71, 12);
            this.CValue_set.TabIndex = 8;
            this.CValue_set.Text = "設定對比度 :";
            // 
            // C_btn
            // 
            this.C_btn.Location = new System.Drawing.Point(32, 197);
            this.C_btn.Name = "C_btn";
            this.C_btn.Size = new System.Drawing.Size(75, 23);
            this.C_btn.TabIndex = 7;
            this.C_btn.Text = "變更對比度";
            this.C_btn.UseVisualStyleBackColor = true;
            this.C_btn.Click += new System.EventHandler(this.C_btn_Click);
            // 
            // CValue_now
            // 
            this.CValue_now.AutoSize = true;
            this.CValue_now.Location = new System.Drawing.Point(158, 179);
            this.CValue_now.Name = "CValue_now";
            this.CValue_now.Size = new System.Drawing.Size(71, 12);
            this.CValue_now.TabIndex = 6;
            this.CValue_now.Text = "當前對比度 :";
            // 
            // C_TrackBar
            // 
            this.C_TrackBar.Location = new System.Drawing.Point(32, 146);
            this.C_TrackBar.Maximum = 100;
            this.C_TrackBar.Name = "C_TrackBar";
            this.C_TrackBar.Size = new System.Drawing.Size(104, 45);
            this.C_TrackBar.TabIndex = 5;
            this.C_TrackBar.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // modeA
            // 
            this.modeA.Location = new System.Drawing.Point(299, 37);
            this.modeA.Name = "modeA";
            this.modeA.Size = new System.Drawing.Size(75, 23);
            this.modeA.TabIndex = 9;
            this.modeA.Text = "Mode A";
            this.modeA.UseVisualStyleBackColor = true;
            this.modeA.Click += new System.EventHandler(this.modeA_Click);
            // 
            // modeB
            // 
            this.modeB.Location = new System.Drawing.Point(299, 66);
            this.modeB.Name = "modeB";
            this.modeB.Size = new System.Drawing.Size(75, 23);
            this.modeB.TabIndex = 10;
            this.modeB.Text = "Mode B";
            this.modeB.UseVisualStyleBackColor = true;
            this.modeB.Click += new System.EventHandler(this.modeB_Click);
            // 
            // modeC
            // 
            this.modeC.Location = new System.Drawing.Point(299, 95);
            this.modeC.Name = "modeC";
            this.modeC.Size = new System.Drawing.Size(75, 23);
            this.modeC.TabIndex = 11;
            this.modeC.Text = "Mode C";
            this.modeC.UseVisualStyleBackColor = true;
            this.modeC.Click += new System.EventHandler(this.modeC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.modeC);
            this.Controls.Add(this.modeB);
            this.Controls.Add(this.modeA);
            this.Controls.Add(this.CValue_set);
            this.Controls.Add(this.C_btn);
            this.Controls.Add(this.CValue_now);
            this.Controls.Add(this.C_TrackBar);
            this.Controls.Add(this.BValue_set);
            this.Controls.Add(this.B_btn);
            this.Controls.Add(this.BValue_now);
            this.Controls.Add(this.B_TrackBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.B_TrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar B_TrackBar;
        private System.Windows.Forms.Label BValue_now;
        private System.Windows.Forms.Button B_btn;
        private System.Windows.Forms.Label BValue_set;
        private System.Windows.Forms.Label CValue_set;
        private System.Windows.Forms.Button C_btn;
        private System.Windows.Forms.Label CValue_now;
        private System.Windows.Forms.TrackBar C_TrackBar;
        private System.Windows.Forms.Button modeA;
        private System.Windows.Forms.Button modeB;
        private System.Windows.Forms.Button modeC;
    }
}

