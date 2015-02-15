using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tree
{
	static class Program
	{
		private static Boolean debug = false;
		public static Boolean isDebug
		{
			get
			{
				return debug;
			}
			set
			{
				debug = value;
			}
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(String[] arguments)
		{
			if (arguments.Contains("debug"))
			{
				isDebug = true;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frm_tree());
		}
	}
}
