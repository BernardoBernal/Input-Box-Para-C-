namespace InputBox
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
            this.labelValor = new System.Windows.Forms.Label();
            this.labelDialogResult = new System.Windows.Forms.Label();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.textBoxDialogResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(34, 47);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(45, 17);
            this.labelValor.TabIndex = 0;
            this.labelValor.Text = "Valor:";
            // 
            // labelDialogResult
            // 
            this.labelDialogResult.AutoSize = true;
            this.labelDialogResult.Location = new System.Drawing.Point(37, 84);
            this.labelDialogResult.Name = "labelDialogResult";
            this.labelDialogResult.Size = new System.Drawing.Size(92, 17);
            this.labelDialogResult.TabIndex = 1;
            this.labelDialogResult.Text = "DialogResult:";
            // 
            // textBoxValor
            // 
            this.textBoxValor.Location = new System.Drawing.Point(129, 47);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(100, 22);
            this.textBoxValor.TabIndex = 2;
            // 
            // textBoxDialogResult
            // 
            this.textBoxDialogResult.Location = new System.Drawing.Point(135, 84);
            this.textBoxDialogResult.Name = "textBoxDialogResult";
            this.textBoxDialogResult.Size = new System.Drawing.Size(100, 22);
            this.textBoxDialogResult.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxDialogResult);
            this.Controls.Add(this.textBoxValor);
            this.Controls.Add(this.labelDialogResult);
            this.Controls.Add(this.labelValor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.Label labelDialogResult;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.TextBox textBoxDialogResult;
    }
}