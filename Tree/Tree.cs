using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tree
{
	class Tree
	{
		private Graphics g;
		private Turtle turtle;
		private Panel panel;
		private Int32 level;

		public Tree(Panel _panel, Int32 _level)
		{
			panel = _panel;
			level = _level;
			g = Graphics.FromHwnd(panel.Handle);
			turtle = new Turtle(g);
		}

		public void Paint()
		{
			turtle.Start(panel.Size, level);
		}
	}
}
