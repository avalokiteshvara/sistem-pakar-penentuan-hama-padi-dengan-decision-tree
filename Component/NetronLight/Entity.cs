using System;
using System.Drawing;
using System.ComponentModel;
namespace NetronLight
{
    /// <summary>
    /// Abstract base class for every object part of the diagram
    /// </summary>
    public abstract class Entity
    {
        #region Fields
        /// <summary>
        /// tells whether the current entity is hovered by the mouse
        /// </summary>
        protected internal bool hovered = false;
        /// <summary>
        /// the control to which the eneity belongs
        /// </summary>
        protected GraphControl site;
        /// <summary>
        /// tells whether the entity is selected
        /// </summary>
        protected bool isSelected = false;

        /// <summary>
        /// Default font for drawing text
        /// </summary>
        protected Font font = new Font("Verdana", 10F);

        /// <summary>
        /// Default black pen
        /// </summary>
        protected Pen blackPen = new Pen(Brushes.Black, 1F);

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets whether the entity is selected
        /// </summary>
        [Browsable(false)]
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
        /// <summary>
        /// Gets or sets the site of the entity
        /// </summary>
        [Browsable(false)]
        public GraphControl Site
        {
            get { return site; }
            set { site = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public Entity()
        {
        }

        /// <summary>
        /// Ctor with the site of the entity
        /// </summary>
        /// <param name="site"></param>
        public Entity(GraphControl site)
        {
            this.site = site;
        }


        #endregion

        #region Methods
        /// <summary>
        /// Paints the entity on the control
        /// </summary>
        /// <param name="g">the graphics object to paint on</param>
        public abstract void Paint(Graphics g);
        /// <summary>
        /// Tests whether the shape is hit by the mouse
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public abstract bool Hit(Point p);
        /// <summary>
        /// Invalidates the entity
        /// </summary>
        public abstract void Invalidate();
        /// <summary>
        /// Moves the entity on the canvas
        /// </summary>
        /// <param name="p">the shifting vector, not an absolute position!</param>
        public abstract void Move(Point p);

        #endregion
    }
}
