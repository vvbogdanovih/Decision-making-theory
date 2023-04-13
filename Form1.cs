using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Decision_making_theory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// returns int 2D array
        /// </summary>
        private int [,] GetDataGridViewData(DataGridView dataGridView)
        {
            int size = Convert.ToInt32(comboBox1.Text);
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = Convert.ToInt32(dataGridView.Rows[i].Cells[j].Value);
                }
            }
            return matrix;
        }

        /// <summary>
        /// fill dataGridView from int 2D array
        /// </summary>
        private void SetDataGridViewData(DataGridView dataGridView, int[,] matrix)
        {
            if (matrix == null) return;
            int size = matrix.GetLength(0);
            dataGridView4.RowCount = size;
            dataGridView4.ColumnCount = size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        private void ShowAnswer(bool answer)
        {
            if (answer) MessageBox.Show("Так");
            else MessageBox.Show("Ні"); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // fill comboBox by possible matrix sizes
            for (int i = 2; i < 9; i++)
            {
                comboBox1.Items.Add(i);
                comboBox3.Items.Add(i);
            }
            comboBox1.Text = "3";
            dataGridView1.RowCount = Int32.Parse(comboBox1.Text);
            dataGridView1.ColumnCount = Int32.Parse(comboBox1.Text);
            dataGridView2.RowCount = Int32.Parse(comboBox1.Text);
            dataGridView2.ColumnCount = Int32.Parse(comboBox1.Text);
            dataGridView3.RowCount = Int32.Parse(comboBox1.Text);
            dataGridView3.ColumnCount = Int32.Parse(comboBox1.Text);
            dataGridView4.RowCount = Int32.Parse(comboBox1.Text);
            dataGridView4.ColumnCount = Int32.Parse(comboBox1.Text);

            
            domainUpDown1.Items.Add("A");
            domainUpDown1.Items.Add("B");
            domainUpDown1.Items.Add("C");
            domainUpDown2.Items.Add("A");
            domainUpDown2.Items.Add("B");
            domainUpDown2.Items.Add("C");
            domainUpDown1.Text = "A";
            domainUpDown2.Text = "B";
            

            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;
            dataGridView4.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView3.ColumnHeadersVisible = false;
            dataGridView4.ColumnHeadersVisible = false;
            comboBox2.Items.Add("Перетин");
            comboBox2.Items.Add("Об'єднання");
            comboBox2.Items.Add("Різниця");
            comboBox2.Items.Add("Симетрична різниця");
            comboBox2.Items.Add("Доповнення");
            comboBox2.Items.Add("Обернене відношення");
            comboBox2.Items.Add("Композиція");
            comboBox2.Items.Add("Звуження");
            comboBox2.Items.Add("------------------------------------------------");
            // Lab2
            comboBox2.Items.Add("Рефлексивна");
            comboBox2.Items.Add("Антирефлексивна");
            comboBox2.Items.Add("Симетрична");
            comboBox2.Items.Add("Асиметрична");
            comboBox2.Items.Add("Антисиметрична");
            comboBox2.Items.Add("Транзитивне");
            comboBox2.Items.Add("Транзитивне замикання");
            comboBox2.Items.Add("Ациклічне");
            comboBox2.Items.Add("Зв'язне");
            comboBox2.Items.Add("Симетрична складова");
            comboBox2.Items.Add("АСиметрична складова");
            comboBox2.Items.Add("Толерантність");
            comboBox2.Items.Add("Еквівалентність");
            comboBox2.Items.Add("Квазіпорядок");
            comboBox2.Items.Add("Порядок");
            comboBox2.Items.Add("Досяжність");
            comboBox2.Items.Add("Взаємна досяжність");
            comboBox2.Items.Add("------------------------------------------------");

            // Lab3
            comboBox2.Items.Add("Адитивно транзитивне");
            comboBox2.Items.Add("Мультиплікативність");
            comboBox2.Items.Add("Перетин Метризованих");
            comboBox2.Items.Add("Об'єднання Метризованих");
            comboBox2.Items.Add("Різниця Метризованих");
            comboBox2.Items.Add("Композиція Метризованих");
            comboBox2.Items.Add("Узгодженість Метризованих");
            comboBox2.Items.Add("Адитивність Метризованих");
            comboBox2.Items.Add("Мультиплікативно транзитвне Метризованих");

            comboBox2.Text = "Перетин";
        }

        // Calculate
        private void button6_Click(object sender, EventArgs e)
        {
            int[,] matrixA = null;
            int[,] matrixB = null;
            switch (domainUpDown1.Text)
            {
                case "A":
                    matrixA = GetDataGridViewData(dataGridView1);
                    break;
                case "B":
                    matrixA = GetDataGridViewData(dataGridView2);
                    break;
                case "C":
                    matrixA = GetDataGridViewData(dataGridView3);
                    break;
            }
            switch (domainUpDown2.Text)
            {
                case "A":
                    matrixB = GetDataGridViewData(dataGridView1);
                    break;
                case "B":
                    matrixB = GetDataGridViewData(dataGridView2);
                    break;
                case "C":
                    matrixB = GetDataGridViewData(dataGridView3);
                    break;
            }


            if (comboBox2.Text != "------------------------------------------------") ;
            switch (comboBox2.Text)
            {
                case "Перетин":
                    SetDataGridViewData(dataGridView4, Relation.Intersection(matrixA, matrixB));
                    break;
                case "Об'єднання":
                    SetDataGridViewData(dataGridView4, Relation.Union(matrixA, matrixB));
                    break;
                case "Різниця":
                    SetDataGridViewData(dataGridView4, Relation.Subtraction(matrixA, matrixB));
                    break;
                case "Симетрична різниця":
                    SetDataGridViewData(dataGridView4, Relation.SymmetricSubtraction(matrixA, matrixB));
                    break;
                case "Доповнення":
                    SetDataGridViewData(dataGridView4, Relation.Addition(matrixA));
                    break;
                case "Обернене відношення":
                    SetDataGridViewData(dataGridView4, Relation.InverseRelation(matrixA));
                    break;
                case "Композиція":
                    SetDataGridViewData(dataGridView4, Relation.Composition(matrixA, matrixB));
                    break;
                case "Звуження":
                    SetDataGridViewData(dataGridView4, Relation.Narrowing(matrixA, Convert.ToInt32(comboBox3.Text)));
                    break;
                case "Рефлексивна":
                    ShowAnswer(Relation.isReflective(matrixA));
                    break;
                case "Антирефлексивна":
                    ShowAnswer(Relation.isAntiReflective(matrixA));
                    break;
                case "Симетрична":
                    ShowAnswer(Relation.isSymmetric(matrixA));
                    break;
                case "Асиметрична":
                    ShowAnswer(Relation.isASymmetric(matrixA));
                    break;
                case "Антисиметрична":
                    ShowAnswer(Relation.isAntiSymmetric(matrixA));
                    break;
                case "Транзитивне":
                    ShowAnswer(Relation.isTransitive(matrixA));
                    break;
                case "Транзитивне замикання":
                    SetDataGridViewData(dataGridView4, Relation.TransitiveClosure(matrixA));
                    break;
                case "Ациклічне":
                    ShowAnswer(Relation.isAcyclicity(matrixA));
                    break;
                case "Зв'язне":
                    ShowAnswer(Relation.isConnected(matrixA));
                    break;
                case "Симетрична складова":
                    SetDataGridViewData(dataGridView4, Relation.SymmetricalComponent(matrixA));
                    break;
                case "АСиметрична складова":
                    SetDataGridViewData(dataGridView4, Relation.ASymmetricalComponent(matrixA));
                    break;
                case "Толерантність":
                    ShowAnswer(Relation.isTolerant(matrixA));
                    break;
                case "Еквівалентність":
                    ShowAnswer(Relation.isEquivalent(matrixA));
                    break;
                case "Квазіпорядок":
                    ShowAnswer(Relation.isQuasi_order(matrixA));
                    break;
                case "Порядок":
                    ShowAnswer(Relation.isOrder(matrixA));
                    break;
                case "Досяжність":
                    SetDataGridViewData(dataGridView4, Relation.Attainability(matrixA));
                    break;
                case "Взаємна досяжність":
                    SetDataGridViewData(dataGridView4, Relation.MutualAttainability(matrixA));
                    break;
                case "Адитивно транзитивне":
                    ShowAnswer(Relation.isAdditiveTransitive(matrixA));
                    break;
                case "Мультиплікативність":
                    ShowAnswer(Relation.isMultiplicative(matrixA));
                    break;
                case "Перетин Метризованих":
                    SetDataGridViewData(dataGridView4, Relation.IntersectionM(matrixA, matrixB));
                    break;
                case "Об'єднання Метризованих":
                    SetDataGridViewData(dataGridView4, Relation.UnionM(matrixA, matrixB));
                    break;
                case "Різниця Метризованих":
                    SetDataGridViewData(dataGridView4, Relation.SubtractionM(matrixA, matrixB));
                    break;
                case "Композиція Метризованих":
                    SetDataGridViewData(dataGridView4, Relation.CompositionM(matrixA, matrixB));
                    break;
                case "Узгодженість Метризованих":
                    ShowAnswer(Relation.isCoherent(matrixA));
                    break;
                case "Адитивність Метризованих":
                    ShowAnswer(Relation.isAdditiveM(matrixA));
                    break;
                case "Мультиплікативно транзитвне Метризованих":
                    ShowAnswer(Relation.isMultiplicativeTransitiveM(matrixA));
                    break;
                default: MessageBox.Show("Wrong argument!");
                    break;

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = Int32.Parse(comboBox1.Text);
            dataGridView1.ColumnCount = Int32.Parse(comboBox1.Text);
            dataGridView2.RowCount = Int32.Parse(comboBox1.Text);
            dataGridView2.ColumnCount = Int32.Parse(comboBox1.Text);
            dataGridView3.RowCount = Int32.Parse(comboBox1.Text);
            dataGridView3.ColumnCount = Int32.Parse(comboBox1.Text);
            dataGridView4.RowCount = Int32.Parse(comboBox1.Text);
            dataGridView4.ColumnCount = Int32.Parse(comboBox1.Text);
        }

        // Empty
        private void button1_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox1.Text)];
            for (int i = 0; i < Convert.ToInt32(comboBox1.Text); i++)
            {
                for (int j = 0; j < Convert.ToInt32(comboBox1.Text); j++)
                {
                    matrix[i, j] = 0;
                }
            }
            
            if (radioButton1.Checked){
                SetDataGridViewData(dataGridView1, matrix);
            }
            else if (radioButton2.Checked){
                SetDataGridViewData(dataGridView2, matrix);
            }else{
                SetDataGridViewData(dataGridView3, matrix);
            }
        }
        // Singl
        private void button2_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox1.Text)];
            for (int i = 0; i < Convert.ToInt32(comboBox1.Text); i++)
            {
                for (int j = 0; j < Convert.ToInt32(comboBox1.Text); j++)
                {
                    matrix[i, j] = 1;
                }
            }

            if (radioButton1.Checked){
                SetDataGridViewData(dataGridView1, matrix);
            }
            else if (radioButton2.Checked){
                SetDataGridViewData(dataGridView2, matrix);
            }
            else{
                SetDataGridViewData(dataGridView3, matrix);
            }
        }
        // Rundom
        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int[,] matrix = new int[Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox1.Text)];
            for (int i = 0; i < Convert.ToInt32(comboBox1.Text); i++)
            {
                for (int j = 0; j < Convert.ToInt32(comboBox1.Text); j++)
                {
                    matrix[i, j] = rand.Next(2);
                }
            }

            if (radioButton1.Checked){
                SetDataGridViewData(dataGridView1, matrix);
            }
            else if (radioButton2.Checked){
                SetDataGridViewData(dataGridView2, matrix);
            }
            else{
                SetDataGridViewData(dataGridView3, matrix);
            }

        }
        // Diagonal
        private void button4_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox1.Text)];
            for (int i = 0; i < Convert.ToInt32(comboBox1.Text); i++){
                for (int j = 0; j < Convert.ToInt32(comboBox1.Text); j++){
                    if (i == j){
                        matrix[i, j] = 1;
                    }
                    else{
                        matrix[i, j] = 0;
                    }
                }
            }

            if (radioButton1.Checked){
                SetDataGridViewData(dataGridView1, matrix);
            }
            else if (radioButton2.Checked){
                SetDataGridViewData(dataGridView2, matrix);
            }
            else{
                SetDataGridViewData(dataGridView3, matrix);
            }
        }
        // AntiDiagonl
        private void button5_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox1.Text)];
            for (int i = 0; i < Convert.ToInt32(comboBox1.Text); i++){
                for (int j = 0; j < Convert.ToInt32(comboBox1.Text); j++){
                    if (i + j == Convert.ToInt32(comboBox1.Text) - 1){
                        matrix[i, j] = 1;
                    }
                    else{
                        matrix[i, j] = 0;
                    }
                }
            }

            if (radioButton1.Checked){
                SetDataGridViewData(dataGridView1, matrix);
            }
            else if (radioButton2.Checked){
                SetDataGridViewData(dataGridView2, matrix);
            }
            else{
                SetDataGridViewData(dataGridView3, matrix);
            }
        }
    }
}
