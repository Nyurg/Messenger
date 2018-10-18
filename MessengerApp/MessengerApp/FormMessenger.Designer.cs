namespace MessengerApp
{
    partial class FormMessenger
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
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.textBoxMessenger = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.buttonSend.Location = new System.Drawing.Point(12, 495);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(684, 37);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send a message";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxMessage.Location = new System.Drawing.Point(12, 415);
            this.textBoxMessage.MaxLength = 150;
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(684, 74);
            this.textBoxMessage.TabIndex = 1;
            // 
            // textBoxMessenger
            // 
            this.textBoxMessenger.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxMessenger.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxMessenger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxMessenger.ForeColor = System.Drawing.Color.Lime;
            this.textBoxMessenger.Location = new System.Drawing.Point(12, 55);
            this.textBoxMessenger.Multiline = true;
            this.textBoxMessenger.Name = "textBoxMessenger";
            this.textBoxMessenger.ReadOnly = true;
            this.textBoxMessenger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMessenger.Size = new System.Drawing.Size(684, 353);
            this.textBoxMessenger.TabIndex = 3;
            this.textBoxMessenger.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonExit.Location = new System.Drawing.Point(544, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(152, 37);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.TabStop = false;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormMessenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 544);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.textBoxMessenger);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonSend);
            this.Name = "FormMessenger";
            this.Text = "Messenger";
            this.Load += new System.EventHandler(this.FormMessenger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.TextBox textBoxMessenger;
        private System.Windows.Forms.Button buttonExit;
    }
}

