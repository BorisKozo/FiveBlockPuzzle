using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveBlockPuzzle
{
    public class Vertex:IEquatable<Vertex>
    {
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public Vertex Clone()
        {
            return new Vertex(this.X, this.Y);
        }

        public Vertex(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(Vertex other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vertex)
            {
                return Equals(obj as Vertex);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.X*257 + this.Y;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
    }
}
