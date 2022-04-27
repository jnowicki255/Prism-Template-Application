namespace PTA.Types
{
    /// <summary>
    /// Represents an ordered pair of double-point x- and y-coordinates that defines a point in a two-dimensional plane.
    /// </summary>
    public class PointD
    {
        /// <summary>
        /// Gets or sets the x-coordinate of this <see cref="PointD"/>.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Gets or sets the y-coordinate of this <see cref="PointD"/>.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets orientation of this <see cref="PointD"/>
        /// </summary>
        public double Orientation { get; set; }

        /// <summary>
        /// Initializes a new instance of a <see cref="PointD"/> class.
        /// </summary>
        public PointD() { }

        /// <summary>
        /// Initializes a new instance of <see cref="PointD"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x">The horizontal position of the point.</param>
        /// <param name="y">The vertical position of the point.</param>
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PointD"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x">The horizontal position of the point.</param>
        /// <param name="y">The vertical position of the point.</param>
        /// <param name="orientation"></param>
        public PointD(double x, double y, double orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        /// <summary>
        /// + operation overload.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static PointD operator +(PointD p1, PointD p2)
        {
            return new PointD(p1.X + p2.X, p1.Y + p2.Y, p1.Orientation);
        }

        /// <summary>
        /// + operation overload.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static PointD operator +(PointD p, double d)
        {
            return new PointD(p.X + d, p.Y + d, p.Orientation);
        }

        /// <summary>
        /// + operation overload.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static PointD operator +(double d, PointD p)
        {
            return p + d;
        }

        /// <summary>
        /// - operation overload.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static PointD operator -(PointD p1, PointD p2)
        {
            return new PointD(p1.X - p2.X, p1.Y - p2.Y, p1.Orientation);
        }

        /// <summary>
        /// - operation overload.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static PointD operator -(PointD p, double d)
        {
            return new PointD(p.X - d, p.Y - d, p.Orientation);
        }

        /// <summary>
        /// - operation overload.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static PointD operator -(double d, PointD p)
        {
            return p - d;
        }

        /// <summary>
        /// * operation overload.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static PointD operator *(PointD p1, PointD p2)
        {
            return new PointD(p1.X * p2.X, p1.Y * p2.Y, p1.Orientation);
        }

        /// <summary>
        /// * operation overload.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static PointD operator *(PointD p, double d)
        {
            return new PointD(p.X * d, p.Y * d, p.Orientation);
        }

        /// <summary>
        /// * operation overload.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static PointD operator *(double d, PointD p)
        {
            return p * d;
        }

        /// <summary>
        /// / operation overload.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static PointD operator /(PointD p1, PointD p2)
        {
            return new PointD(p1.X / p2.X, p1.Y / p2.Y, p1.Orientation);
        }

        /// <summary>
        /// / operation overload.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static PointD operator /(PointD p, double d)
        {
            return new PointD(p.X / d, p.Y / d, p.Orientation);
        }

        /// <summary>
        /// / operation overload.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static PointD operator /(double d, PointD p)
        {
            return new PointD(d / p.X, d / p.Y, p.Orientation);
        }

        public override string ToString()
        {
            return $"[{X}, {Y}, {Orientation}]";
        }
    }
}
