using System;
using System.Collections.Generic;
using System.Linq;

namespace PTA.Types.Extensions
{
    /// <summary>
    /// Point extension methods.
    /// </summary>
    public static class PointExtensions
    {
        /// <summary>
        /// Calculates the distance for given path.
        /// Retuens 0 if collection is null or empty.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static int SumDistance(this IList<PointD> points)
        {
            if (points != null)
            {
                var distance = 0;
                for (int i = 0; i < points?.Count - 1; i++)
                {
                    distance += points[i].CalculateDistance(points[+1]);
                }
                return distance;
            }
            else
            {
                throw new ArgumentNullException(nameof(points));
            }
        }

        /// <summary>
        /// Calculates the distance between points.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int CalculateDistance(this PointD start, PointD end)
        {
            return Math
                .Sqrt(Math.Pow((end.X - start.X), 2) + Math.Pow((end.Y - start.Y), 2))
                .AsInt();
        }

        /// <summary>
        /// Returns points that form a line between start and end points.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static IEnumerable<PointD> GetPointsOnLine(this PointD start, PointD end)
        {
            int x1 = start.X.AsInt();
            int y1 = start.Y.AsInt();
            int x2 = end.X.AsInt();
            int y2 = end.Y.AsInt();
            bool steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            if (steep)
            {
                int t;
                t = x1; // swap x0 and y0
                x1 = y1;
                y1 = t;
                t = x2; // swap x1 and y1
                x2 = y2;
                y2 = t;
            }
            if (x1 > x2)
            {
                int t;
                t = x1; // swap x0 and x1
                x1 = x2;
                x2 = t;
                t = y1; // swap y0 and y1
                y1 = y2;
                y2 = t;
            }
            int dx = x2 - x1;
            int dy = Math.Abs(y2 - y1);
            int error = dx / 2;
            int ystep = (y1 < y2) ? 1 : -1;
            int y = y1;
            for (int x = x1; x <= x2; x++)
            {
                yield return new PointD((steep ? y : x), (steep ? x : y));
                error = error - dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
            yield break;
        }

        /// <summary>
        /// Fills the space between path points by adding new ones.
        /// Throws ex if input is empty or have only one item.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<PointD> CreateFullPath(this IEnumerable<PointD> path)
        {
            if (path?.Count() < 2)
            {
                throw new InvalidOperationException(
                    "Collection is empty or has less than 2 items");
            }

            var fullPath = path
                .SelectTwo((x, y) => x.GetPointsOnLine(y))
                .SelectMany(x => x)
                .ToList();

            fullPath.Insert(0, path.First());
            fullPath.Add(path.Last());

            return fullPath;
        }

        /// <summary>
        /// Converts coordinates from pixels to metric units.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mapOrigin"></param>
        /// <param name="mapResolution"></param>
        /// <param name="mapHeight"></param>
        /// <returns></returns>
        public static PointD ToMetric(this PointD value, PointD mapOrigin, double mapResolution, double mapHeight)
        {
            return new PointD()
            {
                X = (value.X * mapResolution) + mapOrigin.X,
                Y = mapResolution * -(value.Y - mapHeight) + mapOrigin.Y,
                Orientation = value.Orientation + mapOrigin.Orientation
            };
        }

        /// <summary>
        /// Converts paths from pixels to metric units.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mapOrigin"></param>
        /// <param name="mapResolution"></param>
        /// <param name="mapHeight"></param>
        /// <returns></returns>
        public static PointD[] ToMetric(this PointD[] value, PointD mapOrigin, double mapResolution, double mapHeight)
        {
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = value[i].ToMetric(mapOrigin, mapResolution, mapHeight);
            }
            return value;
        }

        /// <summary>
        /// Converts coordinates from metric units to pixels.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mapOrigin"></param>
        /// <param name="mapResolution"></param>
        /// <param name="mapHeight"></param>
        /// <returns></returns>
        public static PointD ToPixels(this PointD value, PointD mapOrigin, double mapResolution, double mapHeight)
        {
            return new PointD()
            {
                X = (value.X - mapOrigin.X) / mapResolution,
                Y = mapHeight - (value.Y - mapOrigin.Y) / mapResolution,
                Orientation = (value.Orientation - mapOrigin.Orientation)
            };
        }
    }
}
