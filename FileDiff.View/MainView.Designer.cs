namespace FileDiff.View
{
    partial class MainView
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
            this.FirstFileTextBox = new System.Windows.Forms.TextBox();
            this.SecondFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstFileButton = new System.Windows.Forms.Button();
            this.SecondFileButton = new System.Windows.Forms.Button();
            this.ResultButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.diffListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.diffListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstFileTextBox
            // 
            this.FirstFileTextBox.Location = new System.Drawing.Point(141, 8);
            this.FirstFileTextBox.Name = "FirstFileTextBox";
            this.FirstFileTextBox.Size = new System.Drawing.Size(100, 20);
            this.FirstFileTextBox.TabIndex = 0;
            // 
            // SecondFileTextBox
            // 
            this.SecondFileTextBox.Location = new System.Drawing.Point(141, 36);
            this.SecondFileTextBox.Name = "SecondFileTextBox";
            this.SecondFileTextBox.Size = new System.Drawing.Size(100, 20);
            this.SecondFileTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Исходный файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Изменённый файл";
            // 
            // FirstFileButton
            // 
            this.FirstFileButton.Location = new System.Drawing.Point(265, 6);
            this.FirstFileButton.Name = "FirstFileButton";
            this.FirstFileButton.Size = new System.Drawing.Size(75, 23);
            this.FirstFileButton.TabIndex = 4;
            this.FirstFileButton.Text = "Добавить";
            this.FirstFileButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FirstFileButton.UseVisualStyleBackColor = true;
            // 
            // SecondFileButton
            // 
            this.SecondFileButton.Location = new System.Drawing.Point(265, 36);
            this.SecondFileButton.Name = "SecondFileButton";
            this.SecondFileButton.Size = new System.Drawing.Size(75, 23);
            this.SecondFileButton.TabIndex = 5;
            this.SecondFileButton.Text = "Добавить";
            this.SecondFileButton.UseVisualStyleBackColor = true;
            // 
            // ResultButton
            // 
            this.ResultButton.Location = new System.Drawing.Point(141, 75);
            this.ResultButton.Name = "ResultButton";
            this.ResultButton.Size = new System.Drawing.Size(199, 23);
            this.ResultButton.TabIndex = 6;
            this.ResultButton.Text = "Показать изменения";
            this.ResultButton.UseVisualStyleBackColor = true;
            // 
            // listBox
            // 
            this.listBox.DataSource = this.diffListBindingSource;
            this.listBox.DisplayMember = "Value";
            this.listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(25, 123);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(315, 134);
            this.listBox.TabIndex = 7;
            // 
            // diffListBindingSource
            // 
            this.diffListBindingSource.DataMember = "DiffList";
            this.diffListBindingSource.DataSource = this.bindingSource1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(FileDiff.ViewModel.MainViewModel);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 345);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.ResultButton);
            this.Controls.Add(this.SecondFileButton);
            this.Controls.Add(this.FirstFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SecondFileTextBox);
            this.Controls.Add(this.FirstFileTextBox);
            this.Name = "MainView";
            this.Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)(this.diffListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox FirstFileTextBox;
        public System.Windows.Forms.TextBox SecondFileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button SecondFileButton;
        public System.Windows.Forms.Button ResultButton;
        public System.Windows.Forms.Button FirstFileButton;
        public System.Windows.Forms.BindingSource bindingSource1;
        public System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.BindingSource diffListBindingSource;
    }
}