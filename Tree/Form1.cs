using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Tree
{
	public partial class frm_tree : Form
	{
		private Tree Tree;

		public frm_tree()
		{
			InitializeComponent();

			hideDebugger();  // debugger code;

			Tree = new Tree(pnl_tree, 10);
		}

		private void pnl_tree_Paint(object sender, PaintEventArgs e)
		{
			Tree.Paint();
		}

		private void frm_tree_Shown(object sender, EventArgs e)
		{
			if (Program.isDebug)
			{
				openDebugger();
			}
		}

		#region Debugger;
		private Int32 debuggerSize = 200;
		private void hideDebugger()
		{
			debuggerSize = this.pnl_debug.Width;
			this.Width -= debuggerSize;
			pnl_debug.Hide();
		}
		private void openDebugger()
		{
			Int32 endSize = this.Width + debuggerSize;
			Double steps = debuggerSize / 30;
			while (this.Width <= endSize)
			{
				this.Width += (Int32)steps;
				this.Left -= (Int32)(steps / 2);
				Application.DoEvents();  // needed to not stall the program;
			}
			pnl_debug.Show();
		}
		#endregion Debugger;
	}
}
