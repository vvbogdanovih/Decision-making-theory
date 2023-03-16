using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Decision_making_theory
{
    public class Relation
    {
        private int _SIZE;
        private int[,] _matrixA;
        private int[,] _matrixB;
        private int[,] _resultMatrix;

        public Relation() { }
        //public Relation(int SIZE) => _SIZE = SIZE;
        /// <summary>
        /// matrixA, matrixB, matrix SIZE
        /// </summary>
        //public Relation(int[,] matrixA, int[,] matrixB, int SIZE)
        //{
        //    _matrixA = matrixA;
        //    _matrixB = matrixB;
        //    _SIZE = SIZE;
        //    _resultMatrix = new int[_SIZE, _SIZE];
        //}
        public void SetMatrixA(int[,] matrixA) => _matrixA = matrixA;
        public void SetMatrixB(int[,] matrixB) => _matrixA = matrixB;

        public int[,] Intersection(int[,] matrixA, int[,] matrixB)
        {
            _resultMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++){
                for(int j = 0; j < matrixA.GetLength(1); j++)
                {
                    if (matrixA[i,j] == matrixB[i, j])
                    {
                        _resultMatrix[i,j] = matrixA[i,j];
                    }
                    else{
                        _resultMatrix[i, j] = 0;
                    }
                }
            }

            return _resultMatrix;
        }        
        public int[,] Union(int[,] matrixA, int[,] matrixB)
        {
            _resultMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++){
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    if (matrixA[i, j] == 1 || matrixB[i, j] == 1)
                    {
                        _resultMatrix[i, j] = 1;
                    }
                    else
                    {
                        _resultMatrix[i, j] = 0;
                    }
                }
            }
            return _resultMatrix;
        }
        public int[,] Subtraction(int[,] matrixA, int[,] matrixB)
        {
            _resultMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++){
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    if (matrixA[i, j] == 1 && matrixB[i, j] == 0){
                        _resultMatrix[i, j] = 1;
                    }
                    else{
                        _resultMatrix[i, j] = 0;
                    }
                }
            }
            return _resultMatrix;
        }
        public int[,] SymmetricSubtraction(int[,] matrixA, int[,] matrixB)
        {
            _resultMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++){
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    if (matrixA[i, j] == matrixB[i, j])
                    {
                        _resultMatrix[i, j] = 0;
                    }
                    else
                    {
                        _resultMatrix[i, j] = 1;
                    }
                }
            }
            return _resultMatrix;
        }
        public int[,] Addition(int[,] matrixA)
        {
            _resultMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++){
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    if (matrixA[i, j] == 1)
                    {
                        _resultMatrix[i, j] = 0;
                    }
                    else
                    {
                        _resultMatrix[i, j] = 1;
                    }
                }
            }
            return _resultMatrix;
        }
        public int[,] InverseRelation(int[,] matrixA)
        {
            _resultMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    _resultMatrix[i, j] = matrixA[j, i];
                }
            }
            return _resultMatrix;
        }
        public int[,] Composition(int[,] matrixA, int[,] matrixB)
        {
            _resultMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++){
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    _resultMatrix[i, j] = 0; // ініціалізуємо елемент таблиці істинності

                    // обчислюємо логічне "І" для всіх відповідних пар значень
                    for (int k = 0; k < matrixA.GetLength(0); k++)
                    {
                        _resultMatrix[i, j] = _resultMatrix[i, j] | (matrixA[i, k] & matrixB[k, j]);
                    }                 
                }
            }
            return _resultMatrix;
        }
        public int[,] Narrowing(int[,] matrixA, int size)
        {
            _resultMatrix = new int[size, size];

            for (int i = 0; i < size; i++) { 
                for(int j = 0; j < size; j++)
                {
                    _resultMatrix[i,j] = matrixA[i, j];
                }
            }

            return _resultMatrix;
        }


        public bool isReflective()
        {

            return true;
        }
    }
}
