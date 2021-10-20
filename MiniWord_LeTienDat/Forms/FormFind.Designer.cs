
namespace MiniWord_LeTienDat.Froms
{
    partial class FormFind
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gDirection = new System.Windows.Forms.Panel();
            this.oDown = new System.Windows.Forms.RadioButton();
            this.oUp = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.gDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what:";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(135, 47);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(168, 23);
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(348, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gDirection
            // 
            this.gDirection.BackColor = System.Drawing.Color.White;
            this.gDirection.Controls.Add(this.oDown);
            this.gDirection.Controls.Add(this.oUp);
            this.gDirection.Location = new System.Drawing.Point(181, 103);
            this.gDirection.Name = "gDirection";
            this.gDirection.Size = new System.Drawing.Size(122, 60);
            this.gDirection.TabIndex = 4;
            // 
            // oDown
            // 
            this.oDown.AutoSize = true;
            this.oDown.Location = new System.Drawing.Point(64, 21);
            this.oDown.Name = "oDown";
            this.oDown.Size = new System.Drawing.Size(56, 19);
            this.oDown.TabIndex = 7;
            this.oDown.TabStop = true;
            this.oDown.Text = "Down";
            this.oDown.UseVisualStyleBackColor = true;
            // 
            // oUp
            // 
            this.oUp.AutoSize = true;
            this.oUp.Location = new System.Drawing.Point(3, 21);
            this.oUp.Name = "oUp";
            this.oUp.Size = new System.Drawing.Size(40, 19);
            this.oUp.TabIndex = 6;
            this.oUp.TabStop = true;
            this.oUp.Text = "Up";
            this.oUp.UseVisualStyleBackColor = true;
            this.oUp.CheckedChanged += new System.EventHandler(this.oUp_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Direction";
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(48, 124);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(88, 19);
            this.chkMatchCase.TabIndex = 6;
            this.chkMatchCase.Text = "Match Case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            this.chkMatchCase.CheckedChanged += new System.EventHandler(this.chkMatchCase_CheckedChanged);
            // 
            // btnFindNext
            // 
            this.btnFindNext.Location = new System.Drawing.Point(348, 46);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(75, 23);
            this.btnFindNext.TabIndex = 7;
            this.btnFindNext.Text = "Find Next";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // FormFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 202);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gDirection);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label1);
            this.Name = "FormFind";
            this.Text = "FormFind";
            this.gDirection.ResumeLayout(false);
            this.gDirection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel gDirection;
        private System.Windows.Forms.RadioButton oUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton oDown;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.Button btnFindNext;
    }
}