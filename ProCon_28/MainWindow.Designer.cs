namespace ProCon_28
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.qrB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.StatusL = new System.Windows.Forms.Label();
            this.QRInputT = new System.Windows.Forms.TextBox();
            this.TestQRB = new System.Windows.Forms.Button();
            this.PieceView = new System.Windows.Forms.ListView();
            this.QRTimer = new System.Windows.Forms.Timer(this.components);
            this.GenPuzzleB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // qrB
            // 
            this.qrB.Location = new System.Drawing.Point(12, 12);
            this.qrB.Name = "qrB";
            this.qrB.Size = new System.Drawing.Size(179, 51);
            this.qrB.TabIndex = 0;
            this.qrB.Text = " QR";
            this.qrB.UseVisualStyleBackColor = true;
            this.qrB.Click += new System.EventHandler(this.qrB_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "プレビュー";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StatusL
            // 
            this.StatusL.AutoSize = true;
            this.StatusL.Location = new System.Drawing.Point(197, 25);
            this.StatusL.Name = "StatusL";
            this.StatusL.Size = new System.Drawing.Size(58, 24);
            this.StatusL.TabIndex = 2;
            this.StatusL.Text = "状態";
            // 
            // QRInputT
            // 
            this.QRInputT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QRInputT.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.QRInputT.Location = new System.Drawing.Point(197, 74);
            this.QRInputT.Name = "QRInputT";
            this.QRInputT.Size = new System.Drawing.Size(1343, 39);
            this.QRInputT.TabIndex = 3;
            // 
            // TestQRB
            // 
            this.TestQRB.Location = new System.Drawing.Point(12, 130);
            this.TestQRB.Name = "TestQRB";
            this.TestQRB.Size = new System.Drawing.Size(179, 62);
            this.TestQRB.TabIndex = 4;
            this.TestQRB.Text = "テストQR";
            this.TestQRB.UseVisualStyleBackColor = true;
            this.TestQRB.Click += new System.EventHandler(this.TestQRB_Click);
            // 
            // PieceView
            // 
            this.PieceView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PieceView.Location = new System.Drawing.Point(12, 198);
            this.PieceView.Name = "PieceView";
            this.PieceView.Size = new System.Drawing.Size(1528, 935);
            this.PieceView.TabIndex = 5;
            this.PieceView.UseCompatibleStateImageBehavior = false;
            // 
            // QRTimer
            // 
            this.QRTimer.Interval = 500;
            this.QRTimer.Tick += new System.EventHandler(this.QRTimer_Tick);
            // 
            // GenPuzzleB
            // 
            this.GenPuzzleB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenPuzzleB.Location = new System.Drawing.Point(1323, 119);
            this.GenPuzzleB.Name = "GenPuzzleB";
            this.GenPuzzleB.Size = new System.Drawing.Size(217, 73);
            this.GenPuzzleB.TabIndex = 6;
            this.GenPuzzleB.Text = "パズル生成";
            this.GenPuzzleB.UseVisualStyleBackColor = true;
            this.GenPuzzleB.Click += new System.EventHandler(this.GenPuzzleB_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1552, 1145);
            this.Controls.Add(this.GenPuzzleB);
            this.Controls.Add(this.PieceView);
            this.Controls.Add(this.TestQRB);
            this.Controls.Add(this.QRInputT);
            this.Controls.Add(this.StatusL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.qrB);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button qrB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label StatusL;
        private System.Windows.Forms.TextBox QRInputT;
        private System.Windows.Forms.Button TestQRB;
        private System.Windows.Forms.ListView PieceView;
        private System.Windows.Forms.Timer QRTimer;
        private System.Windows.Forms.Button GenPuzzleB;
    }
}