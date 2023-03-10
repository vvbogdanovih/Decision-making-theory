using System;
using System.Collections.Generic;
using System.Drawing;
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

        //public Relation() { }
        //public Relation(int SIZE) => _SIZE = SIZE;
        /// <summary>
        /// matrixA, matrixB, matrix SIZE
        /// </summary>
        public Relation(int[,] matrixA, int[,] matrixB, int SIZE)
        {
            _matrixA = matrixA;
            _matrixB = matrixB;
            _SIZE = SIZE;
            _resultMatrix = new int[_SIZE, _SIZE];
        }
        public void SetMatrixA(int[,] matrixA) => _matrixA = matrixA;
        public void SetMatrixB(int[,] matrixB) => _matrixA = matrixB;

        public int[,] Intersection()
        {
            for(int i = 0; i < _SIZE; i++){
                for(int j = 0; j < _SIZE; j++)
                {
                    if (_matrixA[i,j] == _matrixB[i, j])
                    {
                        _resultMatrix[i,j] = _matrixA[i,j];
                    }
                    else{
                        _resultMatrix[i, j] = 0;
                    }
                }
            }
            List<List<int>> matrix = new List<List<int>>();

            matrix.Add(new List<int> { 1, 2, 3 });
            matrix.Add(new List<int> { 4, 5, 6 });
            matrix.Add(new List<int> { 7, 8, 9 });
            Console.WriteLine();

            return _resultMatrix;
        }        
        public int[,] Union()
        {
            for (int i = 0; i < _SIZE; i++){
                for (int j = 0; j < _SIZE; j++)
                {
                    if (_matrixA[i, j] == 1 || _matrixB[i, j] == 1)
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
        public int[,] Subtraction()
        {
            for (int i = 0; i < _SIZE; i++){
                for (int j = 0; j < _SIZE; j++)
                {
                    if (_matrixA[i, j] == 1 && _matrixB[i, j] == 0){
                        _resultMatrix[i, j] = 1;
                    }
                    else{
                        _resultMatrix[i, j] = 0;
                    }
                }
            }
            return _resultMatrix;
        }
        public int[,] SymmetricSubtraction()
        {
            for (int i = 0; i < _SIZE; i++){
                for (int j = 0; j < _SIZE; j++)
                {
                    if (_matrixA[i, j] == _matrixB[i, j])
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
        public int[,] Addition()
        {
            for (int i = 0; i < _SIZE; i++){
                for (int j = 0; j < _SIZE; j++)
                {
                    if (_matrixA[i, j] == 1)
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
        public int[,] InverseRelation()
        {
            for (int i = 0; i < _SIZE; i++)
            {
                for (int j = 0; j < _SIZE; j++)
                {
                    _resultMatrix[i, j] = _matrixA[j, i];
                }
            }
            return _resultMatrix;
        }
        public int[,] Composition()
        {
            for (int i = 0; i < _SIZE; i++){
                for (int j = 0; j < _SIZE; j++)
                {
                    _resultMatrix[i, j] = 0; // ініціалізуємо елемент таблиці істинності

                    // обчислюємо логічне "І" для всіх відповідних пар значень
                    for (int k = 0; k < _SIZE; k++)
                    {
                        _resultMatrix[i, j] = _resultMatrix[i, j] | (_matrixA[i, k] & _matrixB[k, j]);
                    }                 
                }
            }
            return _resultMatrix;
        }
        public int[,] Narrowing(int size)
        {
            _resultMatrix = new int[size, size];

            for (int i = 0; i < size; i++) { 
                for(int j = 0; j < size; j++)
                {
                    _resultMatrix[i,j] = _matrixA[i, j];
                }
            }

            return _resultMatrix;
        }
    }
}
