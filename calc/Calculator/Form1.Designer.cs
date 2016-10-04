namespace Calculator
{
    partial class Form1
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
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.rtbHistory = new System.Windows.Forms.RichTextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(12, 12);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(70, 20);
            this.txtX.TabIndex = 0;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(91, 12);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(70, 20);
            this.txtY.TabIndex = 2;
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.Location = new System.Drawing.Point(373, 12);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(70, 20);
            this.btnCalc.TabIndex = 3;
            this.btnCalc.Text = "calc";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // rtbHistory
            // 
            this.rtbHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbHistory.Location = new System.Drawing.Point(0, 266);
            this.rtbHistory.Name = "rtbHistory";
            this.rtbHistory.Size = new System.Drawing.Size(455, 106);
            this.rtbHistory.TabIndex = 7;
            this.rtbHistory.Text = "";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(187, 15);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 227);
            this.panel1.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(385, 352);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 20);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 372);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.rtbHistory);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.RichTextBox rtbHistory;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
    }
}

