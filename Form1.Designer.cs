namespace UnityDarkThemeEnabler
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
            this.btn_enable = new System.Windows.Forms.Button();
            this.btn_disable = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btn_selectUnityExe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_enable
            // 
            this.btn_enable.Enabled = false;
            this.btn_enable.Location = new System.Drawing.Point(12, 46);
            this.btn_enable.Name = "btn_enable";
            this.btn_enable.Size = new System.Drawing.Size(75, 23);
            this.btn_enable.TabIndex = 0;
            this.btn_enable.Text = "Dark";
            this.btn_enable.UseVisualStyleBackColor = true;
            this.btn_enable.Click += new System.EventHandler(this.btn_enable_Click);
            // 
            // btn_disable
            // 
            this.btn_disable.Enabled = false;
            this.btn_disable.Location = new System.Drawing.Point(93, 46);
            this.btn_disable.Name = "btn_disable";
            this.btn_disable.Size = new System.Drawing.Size(75, 23);
            this.btn_disable.TabIndex = 1;
            this.btn_disable.Text = "Light";
            this.btn_disable.UseVisualStyleBackColor = true;
            this.btn_disable.Click += new System.EventHandler(this.btn_disable_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Unity 3D executable|Unity.exe";
            this.openFileDialog.Title = "Select Unity.exe file";
            // 
            // btn_selectUnityExe
            // 
            this.btn_selectUnityExe.Location = new System.Drawing.Point(12, 12);
            this.btn_selectUnityExe.Name = "btn_selectUnityExe";
            this.btn_selectUnityExe.Size = new System.Drawing.Size(156, 23);
            this.btn_selectUnityExe.TabIndex = 2;
            this.btn_selectUnityExe.Text = "Select Unity EXE";
            this.btn_selectUnityExe.UseVisualStyleBackColor = true;
            this.btn_selectUnityExe.Click += new System.EventHandler(this.btn_selectUnityExe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(183, 81);
            this.Controls.Add(this.btn_selectUnityExe);
            this.Controls.Add(this.btn_disable);
            this.Controls.Add(this.btn_enable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(199, 120);
            this.MinimumSize = new System.Drawing.Size(199, 120);
            this.Name = "Form1";
            this.Text = "UnityThemeSwitcher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_enable;
        private System.Windows.Forms.Button btn_disable;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_selectUnityExe;
    }
}

