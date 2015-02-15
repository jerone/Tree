namespace Tree
{
	partial class frm_tree
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnl_tree = new System.Windows.Forms.Panel();
			this.txt_debug = new System.Windows.Forms.TextBox();
			this.pnl_debug = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.pnl_debug.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 450);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(694, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(350, 17);
			this.toolStripStatusLabel1.Text = "Opdracht 2, Tree, gemaakt door Jeroen van Warmerdam [448872]";
			// 
			// pnl_tree
			// 
			this.pnl_tree.Location = new System.Drawing.Point(12, 13);
			this.pnl_tree.Name = "pnl_tree";
			this.pnl_tree.Size = new System.Drawing.Size(470, 420);
			this.pnl_tree.TabIndex = 1;
			this.pnl_tree.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_tree_Paint);
			// 
			// txt_debug
			// 
			this.txt_debug.Location = new System.Drawing.Point(3, 20);
			this.txt_debug.Multiline = true;
			this.txt_debug.Name = "txt_debug";
			this.txt_debug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_debug.Size = new System.Drawing.Size(187, 397);
			this.txt_debug.TabIndex = 2;
			// 
			// pnl_debug
			// 
			this.pnl_debug.Controls.Add(this.label1);
			this.pnl_debug.Controls.Add(this.txt_debug);
			this.pnl_debug.Location = new System.Drawing.Point(489, 13);
			this.pnl_debug.Name = "pnl_debug";
			this.pnl_debug.Size = new System.Drawing.Size(193, 420);
			this.pnl_debug.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Debug:";
			// 
			// frm_tree
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(694, 472);
			this.Controls.Add(this.pnl_debug);
			this.Controls.Add(this.pnl_tree);
			this.Controls.Add(this.statusStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "frm_tree";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tree";
			this.TransparencyKey = System.Drawing.Color.Magenta;
			this.Shown += new System.EventHandler(this.frm_tree_Shown);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.pnl_debug.ResumeLayout(false);
			this.pnl_debug.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Panel pnl_tree;
		private System.Windows.Forms.TextBox txt_debug;
		private System.Windows.Forms.Panel pnl_debug;
		private System.Windows.Forms.Label label1;
	}
}

