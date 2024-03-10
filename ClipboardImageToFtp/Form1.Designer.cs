namespace ClipboardImageToFtp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusLabel = new Label();
            textBoxPrefix = new TextBox();
            buttonSelect = new Button();
            buttonClear = new Button();
            textBoxSuffix = new TextBox();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 9);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(38, 15);
            statusLabel.TabIndex = 0;
            statusLabel.Text = "label1";
            // 
            // textBoxPrefix
            // 
            textBoxPrefix.Location = new Point(12, 27);
            textBoxPrefix.Name = "textBoxPrefix";
            textBoxPrefix.Size = new Size(202, 23);
            textBoxPrefix.TabIndex = 1;
            textBoxPrefix.KeyPress += textBoxPrefix_KeyPress;
            // 
            // buttonSelect
            // 
            buttonSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSelect.Location = new Point(533, 26);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(58, 23);
            buttonSelect.TabIndex = 4;
            buttonSelect.Text = "Send";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(220, 26);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(25, 23);
            buttonClear.TabIndex = 2;
            buttonClear.Text = "X";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // textBoxSuffix
            // 
            textBoxSuffix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSuffix.Location = new Point(251, 27);
            textBoxSuffix.Name = "textBoxSuffix";
            textBoxSuffix.Size = new Size(276, 23);
            textBoxSuffix.TabIndex = 3;
            textBoxSuffix.KeyPress += textBoxSuffix_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(603, 101);
            Controls.Add(textBoxSuffix);
            Controls.Add(buttonClear);
            Controls.Add(buttonSelect);
            Controls.Add(textBoxPrefix);
            Controls.Add(statusLabel);
            MaximumSize = new Size(1024, 140);
            MinimumSize = new Size(524, 140);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clipboard Image to FTP";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label statusLabel;
        private TextBox textBoxPrefix;
        private Button buttonSelect;
        private Button buttonClear;
        private TextBox textBoxSuffix;
    }
}
