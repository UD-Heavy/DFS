using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystAnalys_lr1
{
    class Vertex
    {
        public int x;
        public int y;
        public Vertex Parent;
        public string Color;
        public int timeIn, timeOut;
        
        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Edge
    {
        public int v1, v2;
        public string wayV1, wayV2;


        public Edge(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    class NormVector
    {
        public float X, Y;

        public NormVector(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen crimson;
        Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 20; //радиус окружности вершины

        //параметры фигур
        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 1;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            crimson = new Pen(Color.Crimson);
            crimson.Width = 7;
            fo = new Font("Arial", 15);
            br = Brushes.Black;
        }

        //полотно
        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        //очистка полотна
        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        //рисуем вершину
        public void drawVertex(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        //Закрашиваем верщину
        public void drawDFSVertex(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.Red, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        //выделить вершину
        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        // находим смещение
        public NormVector Offset(int x1, int y1, int x2, int y2, int offset)
        {

            float length = (float)Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            float dx = (x2 - x1) / length * (R + offset);
            float dy = (y2 - y1) / length * (R + offset);
            float Xc = x2 - dx;
            float Yc = y2 - dy;
            return new NormVector(Xc, Yc);
        }

        //рисуем ребро
        public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
        {
            crimson.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            NormVector vector1 = Offset(V2.x, V2.y, V1.x, V1.y, 5);
            NormVector vector2 = Offset(V1.x, V1.y, V2.x, V2.y, 0);

            if (E.v1 == E.v2) // ребро из самой в себя
            {
                gr.DrawArc(crimson, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
            }
            else // ребро между различными вершинами
            {
                gr.DrawLine(crimson, vector1.X, vector1.Y, vector2.X, vector2.Y);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
                drawVertex(V2.x, V2.y, (E.v2 + 1).ToString());
            }
        }

        //рисуем граф
        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            //рисуем ребра
            for (int i = 0; i < E.Count; i++)
            {
                crimson.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                if (E[i].v1 == E[i].v2)
                {
                    gr.DrawArc(crimson, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                }
                else
                {
                    NormVector vector2 = Offset(V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y, 0);
                    NormVector vector1 = Offset(V[E[i].v2].x, V[E[i].v2].y, V[E[i].v1].x, V[E[i].v1].y, 5);
                    gr.DrawLine(crimson, vector1.X, vector1.Y, vector2.X, vector2.Y);
                }
            }
            //рисуем вершины
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].x, V[i].y, (i + 1).ToString());
            }
        }
    }
}