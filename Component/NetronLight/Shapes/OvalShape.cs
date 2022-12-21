using System.Drawing;

namespace NetronLight.Shapes
{
	/// <summary>
	/// A simple rectangular shape
	/// </summary>
	public class OvalShape : ShapeBase
	{
		#region Fields
		/// <summary>
		/// holds the bottom connector
		/// </summary>
		private readonly Connector cBottom;

	    /// <summary>
	    /// holds the bottom connector
	    /// </summary>
	    private readonly Connector cLeft;

	    /// <summary>
	    /// holds the bottom connector
	    /// </summary>
	    private readonly Connector cRight;

	    /// <summary>
	    /// holds the bottom connector
	    /// </summary>
	    private readonly Connector cTop;

	    #endregion

		#region Constructor
		/// <summary>
		/// Default ctor
		/// </summary>
		/// <param name="s"></param>
		public OvalShape(GraphControl s) : base(s)
		{
			cBottom = new Connector(new Point((int) (rectangle.Left+rectangle.Width/2),rectangle.Bottom))
			              {Site = this.site, Name = "Bottom connector"};
		    connectors.Add(cBottom);

			cLeft = new Connector(new Point(rectangle.Left,(int) (rectangle.Top +rectangle.Height/2)))
			            {Site = this.site, Name = "Left connector"};
		    connectors.Add(cLeft);

			cRight = new Connector(new Point(rectangle.Right,(int) (rectangle.Top +rectangle.Height/2)))
			             {Site = this.site, Name = "Right connector"};
		    connectors.Add(cRight);

			cTop = new Connector(new Point((int) (rectangle.Left+rectangle.Width/2),rectangle.Top))
			           {Site = this.site, Name = "Top connector"};
		    connectors.Add(cTop);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Tests whether the mouse hits this shape
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public override bool Hit(Point p)
		{
			Rectangle r= new Rectangle(p, new Size(5,5));
			return rectangle.Contains(r);			
		}



		/// <summary>
		/// Paints the shape on the canvas
		/// </summary>
		/// <param name="g"></param>
		public override void Paint(Graphics g)
		{
			g.FillEllipse(shapeBrush,rectangle);
			
			
			if(hovered || isSelected)
				g.DrawEllipse(new Pen(Color.Red,2F),rectangle);
			else
				g.DrawEllipse(blackPen,rectangle);
			for(int k=0;k<connectors.Count;k++)
			{
				connectors[k].Paint(g);
			}
			//well, a lot should be said here like
			//the fact that one should measure the text before drawing it,
			//resize the width and height if the text if bigger than the rectangle,
			//alignment can be set and changes the drawing as well...
			//here we keep it really simple:
			if(text !=string.Empty)
				g.DrawString(text,font,Brushes.Black, rectangle.X+10,rectangle.Y+10);
		}

		/// <summary>
		/// Invalidates the shape
		/// </summary>
		public override void Invalidate()
		{
			Rectangle r = rectangle;
			r.Offset(-5,-5);
			r.Inflate(20,20);
			site.Invalidate(r);
		}
		public override void Resize(int width, int height)
		{
			base.Resize(width,height);
			cBottom.Point = new Point((int) (rectangle.Left+rectangle.Width/2),rectangle.Bottom);	
			cLeft.Point = new Point(rectangle.Left,(int) (rectangle.Top +rectangle.Height/2));
			cRight.Point = new Point(rectangle.Right,(int) (rectangle.Top +rectangle.Height/2));
			cTop.Point = new Point((int) (rectangle.Left+rectangle.Width/2),rectangle.Top);
			Invalidate();
		}

		#endregion	
	}
}
