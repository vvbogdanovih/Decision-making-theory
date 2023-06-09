﻿using System;
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
            domainUpDown2.Text = "A";
            

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

            comboBox2.Text = "Перетин";
        }

        // Calculate
        private void button6_Click(object sender, EventArgs e)
        {
            int[,] matrixA = GetDataGridViewData(dataGridView1);
            int[,] matrixB = GetDataGridViewData(dataGridView2);
            
            Relation binariRelation = new Relation(matrixA, matrixB, Convert.ToInt32(comboBox1.Text));

            switch (comboBox2.Text)
            {
                case "Перетин":
                    SetDataGridViewData(dataGridView4, binariRelation.Intersection());
                    break;
                case "Об'єднання":
                    SetDataGridViewData(dataGridView4, binariRelation.Union());
                    break;
                case "Різниця":
                    SetDataGridViewData(dataGridView4, binariRelation.Subtraction());
                    break;
                case "Симетрична різниця":
                    SetDataGridViewData(dataGridView4, binariRelation.SymmetricSubtraction());
                    break;
                case "Доповнення":
                    SetDataGridViewData(dataGridView4, binariRelation.Addition());
                    break;
                case "Обернене відношення":
                    SetDataGridViewData(dataGridView4, binariRelation.InverseRelation());
                    break;
                case "Композиція":
                    SetDataGridViewData(dataGridView4, binariRelation.Composition());
                    break;
                case "Звуження":
                    SetDataGridViewData(dataGridView4, binariRelation.Narrowing(Convert.ToInt32(comboBox3.Text)));
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
