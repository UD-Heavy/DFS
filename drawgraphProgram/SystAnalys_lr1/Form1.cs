using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace SystAnalys_lr1
{
    public partial class Form1 : Form
    {
        int startVertex; // начальная вершина
        StringBuilder resultWay = new StringBuilder(); // запись пути
        HashSet<int> blackVertices = new HashSet<int>(); //пройденные вершины

        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;
        int Timer;

        int selected1; //выбранные вершины, для соединения линиями
        int selected2;

        //форма - инициализация
        public Form1()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(sheet.Width, sheet.Height);
            E = new List<Edge>();
            Timer = new int();
            sheet.Image = G.GetBitmap();
        }

        //кнопка - выбрать вершину
        private void selectButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
        }

        //кнопка - рисовать вершину
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            selectButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать ребро
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        //кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - удалить граф
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.clearSheet();
                sheet.Image = G.GetBitmap();
            }
        }

        //функция - обход в глубину в глубину (рекурсия)
        private void DFS_Visit(Vertex vertex)
        {
            vertex.Color = "Gray";
            vertex.timeIn = ++Timer;
            foreach (Edge edge in E)
            {
                if (edge.v1 == V.IndexOf(vertex) && V[edge.v2].Color.Equals("White"))
                {
                    V[edge.v2].Parent = vertex;
                    DFS_Visit(V[edge.v2]);
                }
            }
            vertex.Color = "Black";
            vertex.timeOut = ++Timer;
        }

        //кнопка - обход в глубину
        private void chainButton_Click(object sender, EventArgs e)
        {
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();

            richTextBox1.Text = "";
            resultWay = new StringBuilder();

            startVertex = System.Convert.ToInt32(enterNumTextBox.Text) - 1;
            foreach (Vertex vertex in V)
            {
                vertex.Color = "White";
                vertex.Parent = null;
            }
            Timer = 0;
            DFS_Visit(V[startVertex]);
            foreach (Vertex vertex in V)
            {
                if (vertex.Color.Equals("White"))
                {
                    DFS_Visit(vertex);
                }
            }
            PrintResult(V);
        }

        //функция - вывод пути
        private void PrintResult(List<Vertex> V)
        {
            string str = "";
            foreach (Vertex vertex in V)
            {
                if (vertex.Parent == null)
                    resultWay.Append((V.IndexOf(vertex) + 1).ToString() + ": " + "\n");
                else
                    resultWay.Append((V.IndexOf(vertex) + 1).ToString() + ": " + PrintParent(vertex, str) + (V.IndexOf(vertex) + 1).ToString() + "\n");

            }
            richTextBox1.Text = Convert.ToString(resultWay);
            return;
        }

        //функция - поиск предков
        private string PrintParent(Vertex vertex, string str)
        {
            if (vertex.Parent == null) return str;
            str += PrintParent(vertex.Parent, str);
            str += (V.IndexOf(vertex.Parent) + 1).ToString() + ";";
            return str;
        }

        //текст
        private void enterNumbLabel_Click(object sender, EventArgs e)
        {

        }

        //окно - вывод результата
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //окно - ввод данных
        private void enterNumTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            //нажата кнопка "выбрать вершину", ищем степень вершины
            if (selectButton.Enabled == false)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        if (selected1 != -1)
                        {
                            selected1 = -1;
                            G.clearSheet();
                            G.drawALLGraph(V, E);
                            sheet.Image = G.GetBitmap();
                        }
                        if (selected1 == -1)
                        {
                            G.drawSelectedVertex(V[i].x, V[i].y);
                            selected1 = i;
                            sheet.Image = G.GetBitmap();
                            // createAdjAndOut();
                            //listBoxMatrix.Items.Clear();
                            //int degree = 0;
                            //for (int j = 0; j < V.Count; j++)
                            //degree += AMatrix[selected1, j];
                            //listBoxMatrix.Items.Add("Степень вершины №" + (selected1 + 1) + " равна " + degree);
                            break;
                        }
                    }
                }
            }
            //нажата кнопка "рисовать вершину"
            if (drawVertexButton.Enabled == false)
            {
                V.Add(new Vertex(e.X, e.Y));
                G.drawVertex(e.X, e.Y, V.Count.ToString());
                sheet.Image = G.GetBitmap();
            }
            //нажата кнопка "рисовать ребро"
            if (drawEdgeButton.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected2 = i;
                                E.Add(new Edge(selected1, selected2));
                                G.drawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1);
                                selected1 = -1;
                                selected2 = -1;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                            //var coordX = V[edge.v2].x;
                            //var coordY = V[edge.v2].y;
                            //G.drawDFSVertex(coordX, coordY, (edge.v2 + 1).ToString());
                            //sheet.Image = G.GetBitmap();
                            //Thread.Sleep(500);
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString());
                        selected1 = -1;
                        sheet.Image = G.GetBitmap();
                    }
                }
            }
            //нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].v1 == i) || (E[j].v2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].v1 > i) E[j].v1--;
                                if (E[j].v2 > i) E[j].v2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                //ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].v1 == E[i].v2) //если это петля
                        {
                            if ((Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                    (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    G.clearSheet();
                    G.drawALLGraph(V, E);
                    sheet.Image = G.GetBitmap();
                }
            }
        }
    }
}
