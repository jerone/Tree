using System;
using System.Drawing;
using System.Windows.Media.Media3D;
using System.Windows.Media.Media3D.Converters;

namespace TurtleGraphics
{
	// The main Turtle Graphics engine
	class TurtleEngine
	{
		// Private members
		private Pen m_pen;
		private Point3D m_position;
		private Vector3D m_direction;
		private Graphics g;
		// Public properties
		public Point3D Position
		{
			get { return m_position; }
			set { m_position = value; }
		}
		public Vector3D Direction
		{
			get { return m_direction; }
			set { m_direction = value; }
		}
		// Constructor
		public TurtleEngine(Graphics _g)
		{
			g = _g;
			m_pen = new Pen(Color.Red);
			m_position = new Point3D();// Point3D.Origin;
			m_direction = new Vector3D(1.0, 0.0, 0.0);
		}
		// Public methods
		public void Turn(double angle)
		{
			// Rotate our direction by the specified angle
			/*
			Matrix3D mat = Matrix3D.Rotation(angle, Vector3D.ZAxis, Position);
			Direction = Direction.TransformBy(mat);
			*/

			double rad = angle * Math.PI / 180;
			Double x = Position.Y * Math.Cos(rad);
			Double y = Position.X * Math.Sin(rad);

			Vector3D temp = new Vector3D(x, y, Position.Z);

			Direction = temp;
		}
		public void Move(double distance)
		{
			// Move the cursor by a specified
			// distance in the direction in
			// which we're pointing
			Point3D oldPos = Position;
			Position += Direction * distance;

			GenerateSegment(oldPos, Position, g);
		}
		public void SetPenWidth(int width)
		{
			m_pen.Width = width;
		}
		public void SetPenColor(int idx)
		{
		Color col = Color.Red;// FromColorIndex(ColorMethod.ByAci, (short)idx);

			if (col != m_pen.Color)
			{
				m_pen.Color = col;
			}
		}
		private void GenerateSegment(Point3D oldPos, Point3D newPos, Graphics g)
		{
			Point old = new Point((int)oldPos.X +100, (int)oldPos.Y + 100);
			Point nwe = new Point((int)newPos.X +100, (int)newPos.Y+100);

			g.DrawLine(m_pen, old, nwe);
		}
	}
	public class Commands
	{
		// A command to create some simple geometry
		static public void DrawTurtleGraphics(Graphics g)
		{
			TurtleEngine te = new TurtleEngine(g);
			// Draw a red circle
			te.SetPenColor(1);
			te.SetPenWidth(1);
			System.Diagnostics.Debug.WriteLine(te.Position.ToString());
			te.Move(10);
			te.Turn(180);
			System.Diagnostics.Debug.WriteLine(te.Position.ToString());
			te.Move(10);
			te.Turn(180);
			System.Diagnostics.Debug.WriteLine(te.Position.ToString());
			/*
			for (int i = 0; i < 20; i++)
			{
				te.Move(2);
				System.Diagnostics.Debug.WriteLine(te.Position.ToString());
				te.Turn(Math.PI / 180);
			}
			for (int i = 0; i < 20; i++)
			{
				te.Move(2);
				System.Diagnostics.Debug.WriteLine(te.Position.ToString());
				te.Turn(Math.PI / -180);
			}
			 * */
			/*
			// Move to the next space
			te.Move(200);
			// Draw a green square
			te.SetPenColor(3);
			te.SetPenWidth(5);
			for (int i = 0; i < 4; i++)
			{
				te.Move(230);
				te.Turn(Math.PI / 2);
			}
			// Move to the next space
			te.Move(300);
			// Draw a blue triangle
			te.SetPenColor(5);
			te.SetPenWidth(3);
			for (int i = 0; i < 3; i++)
			{
				te.Move(266);
				te.Turn(2 * Math.PI / 3);
			}
			// Move to the next space
			te.Move(400);
			te.Turn(Math.PI / 2);
			te.Move(115);
			te.Turn(Math.PI / -2);
			// Draw a multi-colored, spirograph-like shape
			te.SetPenWidth(1);
			for (int i = 0; i < 36; i++)
			{
				te.Turn(Math.PI / 18);
				te.SetPenColor(i);
				for (int j = 0; j < 360; j++)
				{
					te.Move(1);
					te.Turn(Math.PI / 180);
				}
			}
			 */
		}
	}
}