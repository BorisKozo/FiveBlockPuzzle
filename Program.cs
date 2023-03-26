using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveBlockPuzzle
{
    class Program
    {
        private static Object _locker = new object();

        class PutShapeState
        {
            public Shape shape;
            public List<List<Shape>> shapeSetList;
            public Board board;
        }

        static void PrintShapes(List<Shape> shapes)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                shapes[i].Print();
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {

            List<List<Shape>> shapeSetList = GenerateShapes();
            List<Vertex> inputVertices = new List<Vertex>();
            if (args.Length == 1)
            {
                string[] verticesStrings = args[0].Split(' ');
                foreach (string vertexString in verticesStrings)
                {
                    string[] splitVertexString = vertexString.Split(',');
                    inputVertices.Add(new Vertex(Int32.Parse(splitVertexString[0]), Int32.Parse(splitVertexString[1])));
                }

            }
            Execute(shapeSetList,inputVertices);
        }

        static List<List<Shape>> GenerateShapes()
        {
            var vertices = new List<Vertex>();

            var shapeSetList = new List<List<Shape>>();

            //Stick
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(0, 1));
            vertices.Add(new Vertex(0, 2));
            vertices.Add(new Vertex(0, 3));
            vertices.Add(new Vertex(0, 4));
            Shape stick = new Shape(vertices, "A");
            shapeSetList.Add(stick.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //Z
            vertices.Add(new Vertex(0, 2));
            vertices.Add(new Vertex(1, 2));
            vertices.Add(new Vertex(1, 1));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(2, 0));
            Shape z = new Shape(vertices, "B");
            shapeSetList.Add(z.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //Lightning 
            vertices.Add(new Vertex(0, 3));
            vertices.Add(new Vertex(0, 2));
            vertices.Add(new Vertex(1, 2));
            vertices.Add(new Vertex(1, 1));
            vertices.Add(new Vertex(1, 0));
            Shape lightning = new Shape(vertices, "C");
            shapeSetList.Add(lightning.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //House 
            vertices.Add(new Vertex(0, 1));
            vertices.Add(new Vertex(1, 1));
            vertices.Add(new Vertex(2, 1));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(2, 0));
            Shape house = new Shape(vertices, "D");
            shapeSetList.Add(house.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //L
            vertices.Add(new Vertex(0, 3));
            vertices.Add(new Vertex(0, 2));
            vertices.Add(new Vertex(0, 1));
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(1, 0));
            Shape l = new Shape(vertices, "E");
            shapeSetList.Add(l.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //T
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(2, 0));
            vertices.Add(new Vertex(1, 1));
            vertices.Add(new Vertex(1, 2));
            Shape t = new Shape(vertices, "F");
            shapeSetList.Add(t.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //Hook
            vertices.Add(new Vertex(0, 1));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(1, 1));
            vertices.Add(new Vertex(1, 2));
            vertices.Add(new Vertex(2, 2));
            Shape hook = new Shape(vertices, "G");
            shapeSetList.Add(hook.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //Bridge
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(1, 1));
            vertices.Add(new Vertex(1, 2));
            vertices.Add(new Vertex(0, 2));
            Shape bridge = new Shape(vertices, "H");
            shapeSetList.Add(bridge.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //Corner
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(0, 1));
            vertices.Add(new Vertex(0, 2));
            vertices.Add(new Vertex(1, 2));
            vertices.Add(new Vertex(2, 2));
            Shape corner = new Shape(vertices, "I");
            shapeSetList.Add(corner.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //Plus
            vertices.Add(new Vertex(0, 1));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(1, 1));
            vertices.Add(new Vertex(1, 2));
            vertices.Add(new Vertex(2, 1));
            Shape plus = new Shape(vertices, "J");
            shapeSetList.Add(plus.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //Wave
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(0, 1));
            vertices.Add(new Vertex(1, 1));
            vertices.Add(new Vertex(1, 2));
            vertices.Add(new Vertex(2, 2));
            Shape wave = new Shape(vertices, "K");
            shapeSetList.Add(wave.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            //gun
            vertices.Add(new Vertex(0, 1));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(1, 1));
            vertices.Add(new Vertex(1, 2));
            vertices.Add(new Vertex(1, 3));
            Shape gun = new Shape(vertices, "L");
            shapeSetList.Add(gun.GenerateShapeSet());
            //PrintShapes(shapeSetList[shapeSetList.Count - 1]);
            vertices.Clear();

            return shapeSetList;

        }

        private static void Execute(List<List<Shape>> shapeSetList, List<Vertex> inputVertices)
        {
            Board board = new Board();
            foreach (Vertex vertex in inputVertices)
            {
                board.CloseVertex(vertex);
            }

            PutShapeSet(shapeSetList, board);
        }

        private static void PutShapeSet(List<List<Shape>> shapeSetList, Board board)
        {
            if (shapeSetList.Count == 0)
            {
                lock (_locker)
                {
                    board.Print();
                    Console.WriteLine();
                }
                return;
            }

            List<Task> activeTasks = new List<Task>();
            List<Shape> shapeSet = shapeSetList[0];
            
            shapeSetList.RemoveAt(0);                    
            for (int i = 0; i < shapeSet.Count; i++)
            {
                PutShapeState tempState = new PutShapeState();
                tempState.shape = shapeSet[i];
                tempState.board = board.Clone();
                tempState.shapeSetList = shapeSetList;
                Task task = new Task((state) =>
                {
                    PutShapeState currentState = state as PutShapeState;
                    PutShape(currentState.shape, currentState.shapeSetList, currentState.board);
                }, tempState);
                activeTasks.Add(task);
                task.Start();
            }
            Task.WaitAll(activeTasks.ToArray());
        }

        private static void PutShape(Shape shape, List<List<Shape>> shapeSetList, Board board)
        {
            shape.Normalize();
            for (int j = 0; j < board.Height; j++)
            {
                for (int i = 0; i < board.Width; i++)
                {
                    Shape tempShape = shape.CloneMove(i,j);
                    if (board.CanPut(tempShape))
                    {
                        Board tempBoard = board.Clone();
                        tempBoard.Put(tempShape);
                        PutShapeSet(CloneShapeSet(shapeSetList), tempBoard);
                    }
                }
            }
        }

        private static List<List<Shape>> CloneShapeSet(List<List<Shape>> shapeSetList)
        {
            List<List<Shape>> result = new List<List<Shape>>(shapeSetList);
            return result;
        }

    }
}
