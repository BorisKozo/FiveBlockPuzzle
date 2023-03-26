using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveBlockPuzzle
{
    public class Shape : IEquatable<Shape>
    {
        public string Id
        {
            get;
            private set;
        }

        private List<Vertex> _vertices = new List<Vertex>(5);

        public int Left()
        {
            var minX = Int32.MaxValue;
            for (int i = 0; i < _vertices.Count; i++)
            {
                if (_vertices[i].X < minX)
                    minX = _vertices[i].X;
            }

            return minX;
        }

        public int Right()
        {
            var maxX = Int32.MinValue;
            for (int i = 0; i < _vertices.Count; i++)
            {
                if (_vertices[i].X > maxX)
                    maxX = _vertices[i].X;
            }

            return maxX;
        }

        public int Bottom()
        {
            var minY = Int32.MaxValue;
            for (int i = 0; i < _vertices.Count; i++)
            {
                if (_vertices[i].Y < minY)
                    minY = _vertices[i].Y;
            }

            return minY;
        }

        public int Top()
        {
            var maxY = Int32.MinValue;
            for (int i = 0; i < _vertices.Count; i++)
            {
                if (_vertices[i].Y > maxY)
                    maxY = _vertices[i].Y;
            }

            return maxY;
        }

        public void Move(int dx, int dy)
        {
            for (int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i].X += dx;
                _vertices[i].Y += dy;
            }
        }

        public void Normalize() //Moves the shape so that it is at the bottom left (i.e. Bottom and Left = 0);
        {
            var dx = -Left();
            var dy = -Bottom();
            Move(dx, dy);
        }

        public void FlipX() //Flips the shape over the Y axis
        {
            for (int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i].X = -_vertices[i].X;
            }
            Normalize();
        }

        public Shape(List<Vertex> vertices, string id)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                _vertices.Add(vertices[i].Clone());
            }
            Id = id;
        }

        private Shape(string id)
        {
            this.Id = id;
        }

        public bool Equals(Shape other)
        {
            if (this._vertices.Count != other._vertices.Count)
            {
                return false;
            }

            for (int i = 0; i < _vertices.Count; i++)
            {
                if (!other._vertices.Contains(this._vertices[i]))
                    return false;
            }

            return true;
        }

        public void RotateCW()
        {
            var result = new List<Vertex>();
            for (int i = 0; i < _vertices.Count; i++)
            {
                result.Add(new Vertex(_vertices[i].Y, -_vertices[i].X));
            }
            _vertices = result;
        }

        public Shape Clone()
        {
            return new Shape(_vertices, Id);
        }

        public Shape CloneMove(int dx, int dy)
        {
            Shape result = new Shape(this.Id);
            for (int i = 0; i < this._vertices.Count; i++)
            {
                result._vertices.Add(new Vertex(this._vertices[i].X + dx, this._vertices[i].Y + dy));
            }

            return result;
        }

        public List<Shape> GenerateShapeSet()
        {
            List<Shape> data = new List<Shape>();
            for (int i = 0; i < 2; i++) //Add all the rotations of the current shape and the flipped shape
            {
                Normalize();
                data.Add(Clone());
                RotateCW();
                Normalize();
                data.Add(Clone());
                RotateCW();
                Normalize();
                data.Add(Clone());
                RotateCW();
                Normalize();
                data.Add(Clone());
                RotateCW();
                Normalize();
                FlipX();
                Normalize();
            }

            List<Shape> result = new List<Shape>();
            for (int i = 0; i < data.Count; i++)
            {
                if (result.Contains(data[i]))
                    continue;
                result.Add(data[i]);
            }

            return result;
        }

        public ReadOnlyCollection<Vertex> GetVertices()
        {
            return _vertices.AsReadOnly();
        }

        public void Print()
        {
            for (int j = Top(); j >= Bottom(); j--)
            {
                for (int i = Left(); i <= Right(); i++)
                {
                    if (_vertices.Contains(new Vertex(i, j)))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _vertices.Count; i++)
            {
                sb.Append(_vertices[i].ToString());
            }
            return sb.ToString();
        }
         
    }

}
