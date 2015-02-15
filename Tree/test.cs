using System;
using System.Drawing;
namespace TurtleGraphics
{
	// This class encapsulates pen
	// information and will be
	// used by our TurtleEngine
	class Pen
	{
		// Private members
		private Color m_color;
		private double m_width;
		private bool m_down;
		// Public properties
		public Color Color
		{
			get { return m_color; }
			set { m_color = value; }
		}
		public double Width
		{
			get { return m_width; }
			set { m_width = value; }
		}
		public bool Down
		{
			get { return m_down; }
			set { m_down = value; }
		}
		// Constructor
		public Pen()
		{
			m_color =
			  Color.Red;
			m_width = 0.0;
			m_down = false;
		}
	}
	// The main Turtle Graphics engine
	class TurtleEngine
	{
		// Private members
		private Transaction m_trans;
		private Polyline m_poly;
		private Pen m_pen;
		private Point3d m_position;
		private Vector3d m_direction;
		private bool m_updateGraphics;
		// Public properties
		public Point3d Position
		{
			get { return m_position; }
			set { m_position = value; }
		}
		public Vector3d Direction
		{
			get { return m_direction; }
			set { m_direction = value; }
		}
		// Constructor
		public TurtleEngine()
		{
			m_pen = new Pen();
			m_poly = null;
			m_position = Point3d.Origin;
			m_direction = new Vector3d(1.0, 0.0, 0.0);
			m_updateGraphics = false;
		}
		// Public methods
		public void Turn(double angle)
		{
			// Rotate our direction by the
			// specified angle
			Matrix3d mat = Matrix3d.Rotation(angle, Vector3d.ZAxis, Position);
			Direction = Direction.TransformBy(mat);
		}
		public void Move(double distance)
		{
			// Move the cursor by a specified
			// distance in the direction in
			// which we're pointing
			Point3d oldPos = Position;
			Position += Direction * distance;
			// If the pen is down, we draw something
			if (m_pen.Down)
				GenerateSegment(oldPos, Position);
		}
		public void PenDown()
		{
			m_pen.Down = true;
		}
		public void PenUp()
		{
			m_pen.Down = false;
			// We'll start a new entity with the next
			// use of the pen
			m_poly = null;
		}
		public void SetPenWidth(double width)
		{
			m_pen.Width = width;
		}
		public void SetPenColor(int idx)
		{
			// Right now we just use an ACI,
			// to make the code simpler
			Color col = Color.Red;
			// If we have to change the color,
			// we'll start a new entity
			// (if the entity type we're creating
			// supports per-segment colors, we
			// don't need to do this)
			if (col != m_pen.Color)
			{
				m_poly = null;
				m_pen.Color = col;
			}
		}
		// Internal helper to generate geometry
		// (this could be optimised to keep the
		// object we're generating open, rather
		// than having to reopen it each time)
		private void GenerateSegment(
		  Point3d oldPos, Point3d newPos)
		{

			if (m_poly == null)
			{
				// Create the polyline
				m_poly = new Polyline();
				m_poly.Color = m_pen.Color;

				// Add the first vertex
				m_poly.AddVertexAt(0, oldPos.Convert2d(plane), 0.0, m_pen.Width, m_pen.Width);

				m_trans.AddNewlyCreatedDBObject(m_poly, true);
			}

			// Make sure the previous vertex has its
			// width set appropriately
			if (m_pen.Width > 0.0)
			{
				m_poly.SetStartWidthAt(
				  m_poly.NumberOfVertices - 1,
				  m_pen.Width
				);
				m_poly.SetEndWidthAt(
				  m_poly.NumberOfVertices - 1,
				  m_pen.Width
				);
			}
			// Add the new vertex
			m_poly.AddVertexAt(
			  m_poly.NumberOfVertices,
			  newPos.Convert2d(plane),
			  0.0, m_pen.Width, m_pen.Width
			);

		}
	}
	public class Commands
	{
		static void Tree(TurtleEngine te, double distance)
		{
			if (distance < 5.0)
				return;
			// Width of the trunk/branch is a tenth of
			// of the length
			te.SetPenWidth(distance / 10);
			// Draw the main trunk/branch
			te.Move(distance);
			// Draw the left-hand sub-tree
			te.Turn(Math.PI / 6);
			Tree(te, distance - 10);
			// Draw the right-hand sub-tree
			te.Turn(Math.PI / -3);
			Tree(te, distance - 10);
			// Turn back to the original angle
			te.Turn(Math.PI / 6);
			// Draw back down to the start of this sub-
			// tree, with the same thickness, as this
			// may have changed in deeper sub-trees
			te.SetPenWidth(distance / 10);
			te.Move(-distance);
		}

		static void RandomTree(TurtleEngine te, double distance, int variability)
		{
			if (distance < 5.0)
				return;
			// Generate 3 random factors, each on the same basis:
			//  a base amount = 100 - half the variability
			//  + a random amount from 0 to the variability
			// So a variability of 20 results in 90 to 110 (0.9-1.1)
			Random rnd = new Random();
			int basic = 100 - (variability / 2);
			int num = rnd.Next(variability);
			double factor = (basic + num) / 100.0;
			num = rnd.Next(variability);
			double factor1 = (basic + num) / 100.0;
			num = rnd.Next(variability);
			double factor2 = (basic + num) / 100.0;
			// Multiple out the various items by the factors
			double distance1 = factor * distance;
			double angle1 = factor1 * Math.PI / 6;
			double angle2 = factor2 * Math.PI / -3;
			// The last angle is the total angle
			double angle3 = angle1 + angle2;
			// Width of the trunk/branch is a tenth of
			// of the length
			te.SetPenWidth(distance1 / 10);
			// Draw the main trunk/branch
			te.Move(distance1);
			// Draw the left-hand sub-tree
			te.Turn(angle1);
			RandomTree(te, distance - 10, variability);
			// Draw the right-hand sub-tree
			te.Turn(angle2);
			RandomTree(te, distance - 10, variability);
			// Turn back to the original angle
			te.Turn(-angle3);
			// Draw back down to the start of this sub-
			// tree, with the same thickness, as this
			// may have changed in deeper sub-trees
			te.SetPenWidth(distance1 / 10);
			te.Move(-distance1);
		}

		static public void FractalTree()
		{
			Point3d position;
			TurtleEngine te = new TurtleEngine();
			// Draw a fractal tree
			te.Position = position;
			te.SetPenColor(0);
			te.SetPenWidth(0);
			te.Turn(Math.PI / 2);
			te.PenDown();
			Tree(te, treeLength);
		}

		static public void RandomFractalTree()
		{
			TurtleEngine te = new TurtleEngine();
			// Draw a random fractal tree
			te.Position = position;
			te.SetPenColor(0);
			te.SetPenWidth(0);
			te.Turn(Math.PI / 2);
			te.PenDown();
			RandomTree(te, treeLength, variability);
		}
	}
}