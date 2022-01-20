namespace Kse.Algorithms.Samples
{
    using System;

    public class Point
    {
        public int Column { get; }
        public int Row { get; }

        public Point(int column, int row)
        {
            Column = column;
            Row = row;
        }

        protected bool Equals(Point other)
        {
            return Column == other.Column && Row == other.Row;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Column, Row);
        }
    }
}