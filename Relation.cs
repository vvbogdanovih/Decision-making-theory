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
        private static int[,] _resultMatrix;
        private int[,] U =
        {
            {1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1}
        };
        private int[,] E =
        {
            {1,0,0,0,0,0,0,0 },
            {0,1,0,0,0,0,0,0 },
            {0,0,1,0,0,0,0,0 },
            {0,0,0,1,0,0,0,0 },
            {0,0,0,0,1,0,0,0 },
            {0,0,0,0,0,1,0,0 },
            {0,0,0,0,0,0,1,0 },
            {0,0,0,0,0,0,0,1 }
        };

        public Relation() { }
        public Relation(int SIZE) => _SIZE = SIZE;
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
        //public void SetMatrixA(int[,] matrixA) => _matrixA = matrixA;
        //public void SetMatrixB(int[,] matrixB) => _matrixA = matrixB;

        public static int[,] InverseMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[,] B = new int[n, 2 * n]; // Розширена матриця, що містить одиничну матрицю

            // Заповнюємо початкові значення розширеної матриці
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    B[i, j] = matrix[i, j];
                }
                B[i, i + n] = 1;
            }

            // Виконуємо послідовність елементарних операцій над матрицями
            for (int i = 0; i < n; i++)
            {
                // Знаходимо максимальний елемент у стовпці i
                int maxRow = i;
                int maxValue = B[i, i];
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(B[j, i]) > Math.Abs(maxValue))
                    {
                        maxRow = j;
                        maxValue = B[j, i];
                    }
                }

                // Обмінюємо рядки, якщо максимальний елемент не перший
                if (maxRow != i)
                {
                    for (int j = i; j < 2 * n; j++)
                    {
                        int temp = B[i, j];
                        B[i, j] = B[maxRow, j];
                        B[maxRow, j] = temp;
                    }
                }

                // Ділимо рядок i на B[i,i], щоб отримати 1 на діагоналі
                int divValue = B[i, i];
                for (int j = i; j < 2 * n; j++)
                {
                    B[i, j] /= divValue;
                }
                // Віднімаємо i-тий рядок від інших рядків, щоб отримати 0 на всіх елементах, крім діагоналі
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        int mulValue = B[j, i];
                        for (int k = i; k < 2 * n; k++)
                        {
                            B[j, k] -= mulValue * B[i, k];
                        }
                    }
                }
            }

            // Повертаємо зворотню матрицю
            int[,] result = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = B[i, j + n];
                }
            }
            return result;
        } 
        public static bool isEmpty(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++){
                for( int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] != 0) return false;
                }
            }
            return true;
        }
        // Lab1
        public static int[,] Intersection(int[,] matrixA, int[,] matrixB)
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
        public static int[,] Union(int[,] matrixA, int[,] matrixB)
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
        public static int[,] Subtraction(int[,] matrixA, int[,] matrixB)
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
        public static int[,] SymmetricSubtraction(int[,] matrixA, int[,] matrixB)
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
        public static int[,] Addition(int[,] matrix)
        {
            _resultMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++){
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
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
        public static int[,] InverseRelation(int[,] matrix)
        {
            _resultMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    _resultMatrix[i, j] = matrix[j, i];
                }
            }
            return _resultMatrix;
        }
        public static int[,] Composition(int[,] matrixA, int[,] matrixB)
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
        public static int[,] Narrowing(int[,] matrix, int size)
        {
            _resultMatrix = new int[size, size];

            for (int i = 0; i < size; i++) { 
                for(int j = 0; j < size; j++)
                {
                    _resultMatrix[i,j] = matrix[i, j];
                }
            }

            return _resultMatrix;
        }

        // Lab2
        public static bool isReflective(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if(matrix[i,i] != 1)
                    return false;                
            }
            return true;
        }
        public static bool isAntiReflective(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] != 0)
                    return false;
            }
            return true;
        }
        public static bool isSymmetric(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++){
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != matrix[j, i]) return false;
                }
            }
            return true;
        }
        public static bool isASymmetric(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != matrix[j, i]) return true;
                }
            }
            return false;
        }
        public static bool isAntiSymmetric(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols)
            {
                // матриця не є квадратною
                return false;
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == j)
                    {
                        // елементи на головній діагоналі мають бути нулями
                        if (matrix[i, j] != 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        // перевірка антисиметричності
                        if (matrix[i, j] != -matrix[j, i])
                        {
                            return false;
                        }
                    }
                }
            }
            // якщо програма не виявила жодної помилки, то матриця є антисиметричною
            return true;
        }
        public static bool isTransitive(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            // Перевірка умови транзитивності: для кожної пари (i, j) знаходимо всі k, для яких має місце (i, k) і (k, j)
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 1)
                    { // якщо існує відношення (i, j)
                        for (int k = 0; k < size; k++)
                        {
                            if (matrix[j, k] == 1 && matrix[i, k] == 0)
                            { // якщо існують відношення (j, k) і (i, k) не існує, то відношення не транзитивне
                                return false;
                            }
                        }
                    }
                }
            }

            // Якщо усі умови транзитивності виконуються, то відношення транзитивне
            return true;
        }
        public static int[,] TransitiveClosure(int[,] matrix) => Composition(matrix, matrix);
        public static bool isAcyclicity(int[,] matrix) => isEmpty(Intersection(Composition(matrix, matrix),InverseMatrix(matrix)));
        
    }
}
