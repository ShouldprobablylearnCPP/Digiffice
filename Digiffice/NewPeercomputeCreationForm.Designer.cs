namespace Digiffice
{
    partial class NewPeercomputeCreationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPeercomputeCreationForm));
            newPeercomputeNameLbl = new Label();
            newPeercomputeNameBtn = new TextBox();
            label1 = new Label();
            p2pPeercomputeTypeBtn = new RadioButton();
            clientServerTypeBtn = new RadioButton();
            SuspendLayout();
            // 
            // newPeercomputeNameLbl
            // 
            newPeercomputeNameLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newPeercomputeNameLbl.AutoSize = true;
            newPeercomputeNameLbl.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newPeercomputeNameLbl.Location = new Point(2, 6);
            newPeercomputeNameLbl.Name = "newPeercomputeNameLbl";
            newPeercomputeNameLbl.Size = new Size(145, 14);
            newPeercomputeNameLbl.TabIndex = 0;
            newPeercomputeNameLbl.Text = "New Peercompute Name:";
            // 
            // newPeercomputeNameBtn
            // 
            newPeercomputeNameBtn.Location = new Point(151, 2);
            newPeercomputeNameBtn.Name = "newPeercomputeNameBtn";
            newPeercomputeNameBtn.Size = new Size(131, 23);
            newPeercomputeNameBtn.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(2, 37);
            label1.Name = "label1";
            label1.Size = new Size(111, 14);
            label1.TabIndex = 2;
            label1.Text = "Peercompute Type:";
            // 
            // p2pPeercomputeTypeBtn
            // 
            p2pPeercomputeTypeBtn.AutoSize = true;
            p2pPeercomputeTypeBtn.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            p2pPeercomputeTypeBtn.Location = new Point(116, 35);
            p2pPeercomputeTypeBtn.Name = "p2pPeercomputeTypeBtn";
            p2pPeercomputeTypeBtn.Size = new Size(48, 18);
            p2pPeercomputeTypeBtn.TabIndex = 3;
            p2pPeercomputeTypeBtn.TabStop = true;
            p2pPeercomputeTypeBtn.Text = "P2P";
            p2pPeercomputeTypeBtn.UseVisualStyleBackColor = true;
            p2pPeercomputeTypeBtn.CheckedChanged += p2pPeercomputeTypeBtn_CheckedChanged;
            // 
            // clientServerTypeBtn
            // 
            clientServerTypeBtn.AutoSize = true;
            clientServerTypeBtn.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clientServerTypeBtn.Location = new Point(170, 35);
            clientServerTypeBtn.Name = "clientServerTypeBtn";
            clientServerTypeBtn.Size = new Size(94, 18);
            clientServerTypeBtn.TabIndex = 4;
            clientServerTypeBtn.TabStop = true;
            clientServerTypeBtn.Text = "Client/Server";
            clientServerTypeBtn.UseVisualStyleBackColor = true;
            clientServerTypeBtn.CheckedChanged += clientServerTypeBtn_CheckedChanged;
            // 
            // NewPeercomputeCreationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 261);
            Controls.Add(clientServerTypeBtn);
            Controls.Add(p2pPeercomputeTypeBtn);
            Controls.Add(label1);
            Controls.Add(newPeercomputeNameBtn);
            Controls.Add(newPeercomputeNameLbl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewPeercomputeCreationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create a new Peercompute";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label newPeercomputeNameLbl;
        private TextBox newPeercomputeNameBtn;
        private Label label1;
        private RadioButton p2pPeercomputeTypeBtn;
        private RadioButton clientServerTypeBtn;
    }
}