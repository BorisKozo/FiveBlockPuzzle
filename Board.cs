using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveBlockPuzzle
{
    public class Board
    {
        private int _width = 8;

        public int Width
        {
            get { return _width; }
        }

        private int _height = 8;

        public int Height
        {
            get { return _height; }
        }

        private Dictionary<Vertex, string> _data = new Dictionary<Vertex,string>();

        public bool CanPut(Shape shape)
        {
            ReadOnlyCollection<Vertex> vertices = shape.GetVertices();
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertex vertex = vertices[i];
                if (_data.ContainsKey(vertex)) return false;
                if (vertex.X < 0 || vertex.X >= _width) return false;
                if (vertex.Y < 0 || vertex.Y >= _height) return false;
            }
            return true;
        }

        public void Put(Shape shape)
        {
            ReadOnlyCollection<Vertex> vertices = shape.GetVertices();
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertex vertex = vertices[i].Clone();
                _data.Add(vertex, shape.Id);
            }
        }

        public Board Clone()
        {
            Board result = new Board();
            foreach (Vertex key in _data.Keys)
            {
                result._data.Add(key.Clone(), _data[key]);
            }

            return result;
        }

        public void CloseVertex(Vertex vertex)
        {
            if (_data.ContainsKey(vertex))
            {
                _data[vertex] = "X";
            }
            else
            {
                _data.Add(vertex, "X");
            }
        }

        public void Print()
        {
            for (int j = _height-1; j >= 0; j--)
            {
                for (int i = 0; i < _width; i++)
                {
                    Vertex vertex = new Vertex(i, j);
                    if (_data.ContainsKey(vertex))
                    {
                        Console.Write(_data[vertex]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
