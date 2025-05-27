namespace Project
{
    partial class CodeForm
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
            lblCode = new Label();
            SuspendLayout();
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblCode.Location = new Point(147, 9);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(107, 41);
            lblCode.TabIndex = 0;
            lblCode.Text = "ШИФР";
            // 
            // CodeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 453);
            Controls.Add(lblCode);
            Name = "CodeForm";
            Text = "CodeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCode;
    }
}