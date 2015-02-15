using System;
using System.Drawing;

namespace Tree
{
	class Turtle
	{
		private const float shrinking = 0.75f;	// Ratio used for decreasing length of lines (preferred: 0.5f & 0.95f);
		private const Int32 angle = 40;			// Angle between parent and child line (in degrees);
		private const float pi = (float)Math.PI;
		private Graphics g;
		private Int32 levels = 8;

		public Turtle(Graphics _g)
		{
			g = _g;
		}

		public void Start(Size size)
		{
			Start(size, levels);
		}
		public void Start(Size size, Int32 level)
		{
			levels = level;
			Draw(new PointF(size.Width / 2, size.Height), new PointF(size.Width / 2, size.Height * shrinking), levels);
		}

		private void Draw(PointF start, PointF end, Int32 level)
		{
			Color color = Color.Brown;
			if ((levels * 0.2) >= level)
			{
				color = Color.Green;
			}

			g.DrawLine(new Pen(color, 1 * level), start, end);

			PointF newEnd = new PointF(end.X + (end.X - start.X) * shrinking,
									   end.Y + (end.Y - start.Y) * shrinking);

			if (level > 1)  // recursion;
			{
				//System.Threading.Thread.Sleep(10*level);
				Draw(end, Rotate(end, newEnd, angle), level - 1);
				Draw(end, Rotate(end, newEnd, -angle), level - 1);
			}
		}

		private PointF Rotate(PointF start, PointF end, float angle)
		{
			angle = angle / 180.0f * pi;

			float diffX = end.X - start.X;
			float diffY = end.Y - start.Y;

			return new PointF(
			  (diffX * (float)Math.Cos(angle)) - (diffY * (float)Math.Sin(angle)) + start.X,
			  (diffX * (float)Math.Sin(angle)) + (diffY * (float)Math.Cos(angle)) + start.Y);
		}

		/*
		public void Forward(Int32 pixels)
		{
			x += pixels;
		}

		public void Back(Int32 pixels)
		{
			x -= pixels;
		}

		public void Left(Int32 degrees)
		{
			Int32 distance = 0;
			Int32 rad = degrees * (Int32)Math.PI / 180;
			Int32 x1 = x + distance * (Int32)Math.Cos(rad);
			Int32 y1 = y + distance * (Int32)Math.Sin(rad);
		}

		public void Right(Int32 degrees)
		{
			Int32 distance = 0;
			Int32 rad = degrees * (Int32)Math.PI / 180;
			Int32 x1 = x + distance * (Int32)Math.Cos(rad);
			Int32 y1 = y + distance * (Int32)Math.Sin(rad);
		}
		 * */
	}
}
