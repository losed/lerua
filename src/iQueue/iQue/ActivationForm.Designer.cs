namespace iQueue
{
    partial class ActivationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivationForm));
            this.activationMessage = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // activationMessage
            // 
            this.activationMessage.AutoWordSelection = true;
            this.activationMessage.BackColor = System.Drawing.SystemColors.Control;
            this.activationMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.activationMessage.Location = new System.Drawing.Point(0, 0);
            this.activationMessage.Margin = new System.Windows.Forms.Padding(10);
            this.activationMessage.Name = "activationMessage";
            this.activationMessage.ReadOnly = true;
            this.activationMessage.Size = new System.Drawing.Size(686, 376);
            this.activationMessage.TabIndex = 0;
            this.activationMessage.Text = "";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(543, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ActivationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 429);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.activationMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActivationForm";
            this.Text = "Активация программного обеспечения";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox activationMessage;
        private System.Windows.Forms.Button button1;
    }
}