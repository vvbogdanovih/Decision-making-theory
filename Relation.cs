using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decision_making_theory
{
    public class Relation
    {
        private int _SIZE;
        private int[,] _matrixA;
        private int[,] _matrixB;
        private static int[,] _resultMatrix;
        private static int[,] _U;
        private static int[,] _E;
        

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
        
        private static int[,] GetEMatrix(int size)
        {
            if(size < 1) return null;
            _E = new int[size, size];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if(i== j)
                    {
                        _E[i,j] = 1;
                    }
                    else
                    {
                        _E[i,j] = 0;
                    }
                }
            }
            return _E;
        }
        private static int[,] GetUMatrix(int size)
        {
            if (size < 1) return null;
            _U = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    _U[i, j] = 1;
            }
            return _U;
        }
        public static int[,] InverseMatrix(int[,] matrix)
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
            if (matrixA == null || matrixB == null) return null;
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
            if (matrixA == null || matrixB == null) return null;
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
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != matrix[j, i]) return false;
                }
            }
            return true;
        }
        public static bool isASymmetric(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if(matrix[i, i] != 0) return false;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != matrix[j, i]) return true;
                }
            }
            return false;
        }
        public static bool isAntiSymmetric(int[,] matrix)
        {
            _resultMatrix = Intersection(matrix, InverseMatrix(matrix));

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
                        continue;
                    }
                    else
                    {
                        // перевірка антисиметричності
                        if (_resultMatrix[i, j] != 0)
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

            // Перевірка умови транзитивності: для кожної пари (i, j) знаходимо всі j, для яких має місце (i, j) і (j, j)
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 1)
                    { // якщо існує відношення (i, j)
                        for (int k = 0; k < size; k++)
                        {
                            if (matrix[j, k] == 1 && matrix[i, k] == 0)
                            { // якщо існують відношення (j, j) і (i, j) не існує, то відношення не транзитивне
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
        public static bool isConnected(int[,] matrix)
        {
            int[,] tmp1 = Subtraction(Union(matrix, InverseMatrix(matrix)), GetEMatrix(matrix.GetLength(0)));
            int[,] tmp2 = Subtraction(GetUMatrix(matrix.GetLength(0)), GetEMatrix(matrix.GetLength(0)));
            for(int i = 0; i < tmp1.GetLength(0); i++)
            {
                for(int j = 0; j < tmp2.GetLength(0); j++)
                {
                    if (tmp1[i, j] != tmp2[i, j]) return false;
                }
            }return true;
        }
        public static int[,] SymmetricalComponent(int[,] matrix) => Intersection(matrix, InverseMatrix(matrix));
        public static int[,] ASymmetricalComponent(int[,] matrix) => Subtraction(matrix, SymmetricalComponent(matrix));
        public static bool isTolerant(int[,] matrix) => isReflective(matrix) && isSymmetric(matrix);
        public static bool isEquivalent(int[,] matrix) => isReflective(matrix) && isSymmetric(matrix) && isTransitive(matrix);
        public static bool isQuasi_order(int[,] matrix) => isReflective(matrix) && isTransitive(matrix);
        public static bool isOrder(int[,] matrix) => isReflective(matrix) && isTransitive(matrix) && isAntiSymmetric(matrix);
        public static int[,] Attainability(int[,] matrix) => Union(GetEMatrix(matrix.GetLength(0)), TransitiveClosure(matrix));
        public static int[,] MutualAttainability(int[,] matrix) => Intersection(Attainability(matrix), InverseMatrix(Attainability(matrix)));

        // Lab3
        public static bool isAdditive(int[,] matrix)
        {
            for(int i = 0;  i < matrix.GetLength(0); i++)
            {
                for(int k = 0;  k < matrix.GetLength(0); k++)
                {
                    for(int j = 0;  j < matrix.GetLength(0); j++)
                    {
                        if (matrix[i,j] !=0 && matrix[j,k] != 0)
                        {
                            int tmp = matrix[i, j] + matrix[j, k];
                            if (tmp != matrix[i, k])
                            {
                                return false;
                            }
                        }
                    }   
                }
            }
            return true;
        }
        public static bool isMultiplicative(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (matrix[i, j] != 0 && matrix[j, k] != 0)
                        {
                            int tmp = matrix[i, j] * matrix[j, k];
                            if (tmp != matrix[i, k])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }        
        public static int[,] IntersectionM(int[,] matrixP, int[,] matrixQ)
        {
            int[,] temp1 = matrixP;            

            if (isAdditive(matrixP)){
                for (int i = 0; i < matrixP.GetLength(0); i++){
                    for (int j = 0; j < matrixP.GetLength(0); j++){
                        temp1[i, j] = (matrixP[i, j] + matrixQ[i, j]) / 2;                        
                    }
                }
                return temp1;
            }

            for (int i = 0; i < matrixP.GetLength(0); i++){
                for (int j = 0; j < matrixP.GetLength(0); j++){
                    temp1[i, j] = (int)Math.Sqrt(matrixP[i, j] * matrixQ[i, j]);
                }
            }
            return temp1;
        }
        public static int[,] UnionM(int[,] matrixP, int[,] matrixQ)
        {
            int[,] temp1 = matrixP;

            if (isAdditive(matrixP))
            {
                for (int i = 0; i < matrixP.GetLength(0); i++){
                    for (int j = 0; j < matrixP.GetLength(0); j++){
                        if (matrixP[i, j] == 0){
                            temp1[i, j] = matrixQ[i, j];                            
                        }
                        if (matrixQ[i, j] == 0){
                            temp1[i, j] = matrixP[i, j];                            
                        }
                        else
                        {
                            temp1[i, j] = ((matrixP[i, j] + matrixQ[i, j]) / 2);
                        }
                                               
                    }
                }
                return temp1;
            }

            for (int i = 0; i < matrixP.GetLength(0); i++){
                for (int j = 0; j < matrixP.GetLength(0); j++){
                    if (matrixP[i, j] == 0){
                        temp1[i, j] = matrixQ[i, j];
                    }
                    if (matrixQ[i, j] == 0){
                        temp1[i, j] = matrixP[i, j];
                    }
                    else
                    {
                        temp1[i, j] = (int)Math.Abs(matrixP[i, j] + matrixQ[i, j]);
                    }
                    
                }
            }
            return temp1;
        }
        public static int[,] SubtractionM(int[,] matrixP, int[,] matrixQ) => matrixP;
        public static int[,] CompositionM(int[,] matrixP, int[,] matrixQ)
        {
            int[,] R1 = matrixP;
            int temp1 = 1;

            if (isAdditive(matrixP))
            {
                temp1 = 0;
                for (int i = 0; i < matrixP.GetLength(0); i++){
                    for (int k = 0; k < matrixP.GetLength(0); k++){
                        for (int j = 0; j < matrixP.GetLength(0); j++){
                            temp1 += matrixP[i, j] + matrixQ[i, j];
                            temp1 /= matrixP.GetLength(0);
                            R1[i, j] = temp1;
                            temp1 = 0;
                        }
                    }
                }
                return R1;
            }
            for (int i = 0; i < matrixP.GetLength(0); i++){
                for (int k = 0; k < matrixP.GetLength(0); k++){
                    for (int j = 0; j < matrixP.GetLength(0); j++){
                        temp1 *= matrixP[i, j] * matrixQ[i, j];
                        temp1 = (int)Math.Pow(temp1, 1.0 / matrixP.GetLength(0));
                        R1[i, j] = temp1;

                        temp1 = 1;
                    }
                }
            }

            return R1;
        }
        public static bool isCoherent(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j=0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] != matrix[j,i]) return false;
                }
            }return true;
        }
        public static bool isAdditiveTransitiveM(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (matrix[i, j] != 0 && matrix[j, k] != 0)
                        {
                            if (!(matrix[i, k] != 0 && (matrix[i, j] + matrix[j, k]) != matrix[i, k])) return false;
                        }
                    }
                }
            }
            return true;
        }
        public static bool isMultiplicativeTransitiveM(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (matrix[i, j] != 0 && matrix[j, k] != 0)
                        {
                            if (!(matrix[i, k] != 0 && (matrix[i, j] * matrix[j, k]) == matrix[i, k])) return false;
                        }
                    }
                }
            }
            return true;
        }

        // Lab4
        public static int MeasureOfCloseness(int[,] matrixA, int[,] matrixB)
        {
            int sum = 0;
            
            for(int i = 0; i < matrixA.GetLength(0); i++)
            {
                for(int j = 0; j < matrixA.GetLength(0); j++)
                {
                    sum += Math.Abs(matrixA[i, j] - matrixB[i, j]);
                }
            }

            return sum/2;
        }
        public static int[,] MeasureOfClosenessM(int[,] matrixA, int[,] matrixB)
        {
            _resultMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(0)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(0); j++)
                {
                    if ((matrixA[i, j] != 999999 && matrixB[i, j] != 999999)) _resultMatrix[i, j] = Math.Abs(matrixA[i, j] - matrixB[i, j]);
                    else if (matrixA[i, j] != 999999) _resultMatrix[i, j] = 0;
                    else _resultMatrix[i, j] = 999999;
                }
            }
            return _resultMatrix;
        }


        // Lab5
        public static string HasMaximum(int[,] matrix)
        {
            string res = "";

            for (int i = 0; i < matrix.GetLength(0); i++){
                for (int j = 0; j < matrix.GetLength(1); j++){
                    if (matrix[i, j] != 1) break;
                    if(j == matrix.GetLength(0)-1) res += $"d {i + 1} - максимум\n";
                }
            }
            return res.Length > 0 ? res : "Максимум відсутній!";
        }
        public static string HasMinorant(int[,] matrix)
        {
            string res = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0) break;
                    if (j == matrix.GetLength(0) - 1) res += $"d {i + 1} - мінорант\n";
                }
            }
            return res.Length > 0 ? res : "Мінорант відсутній!";
        }
        public static string HasMinimum(int[,] matrix)
        {
            string res = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[j, i] != 1) break;
                    if (j == matrix.GetLength(0) - 1) res += $"d {i + 1} - мінімум\n";
                }
            }
            return res.Length > 0 ? res : "Мінімум!";
        }
        public static string HasMajorant(int[,] matrix)
        {
            string res = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[j, i] != 0) break;
                    if (j == matrix.GetLength(0) - 1) res += $"d {i + 1} - мажорант\n";
                }
            }
            return res.Length > 0 ? res : "Мажорант відсутній!";
        }
        public static int[,] Pareto(int[,] matrix)
        {
            _resultMatrix = matrix;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    bool dominates = false;
                    for (int k = 0; k < matrix.GetLength(0); k++)
                    {
                        if (matrix[i, k] >= matrix[j, k])
                        {
                            dominates = true;
                        }
                        else
                        {
                            dominates = false;
                            break;
                        }
                    }
                    if (dominates)
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
        public static int[,] Slayter(int[,] matrix)
        {
            _resultMatrix = matrix;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    bool dominates = false;
                    for (int k = 0; k < matrix.GetLength(0); k++)
                    {
                        if (matrix[i, k] > matrix[j, k])
                        {
                            dominates = true;
                        }
                        else
                        {
                            dominates = false;
                            break;
                        }
                    }
                    if (dominates)
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
        public static int[,] Etalon(int[,] matrix)
        {           

            // Обчислення di
            int[] d = new int[4];
            for (int i = 0; i < 3; i++)
            {
                int a = matrix[i, 0];
                int b = matrix[4, 0];
                int c = matrix[i, 1];
                int e = matrix[4, 1];
                int f = matrix[i, 2];
                int g = matrix[4, 2];
                d[i] = Math.Abs(a - b) + Math.Abs(c - e) + Math.Abs(f - g);
            }

            // Створення еталонної матриці
            int[,] referenceMatrix = new int[4, 4];
            for (int j = 0; j < 4; j++)
            {
                referenceMatrix[0, j] = (d[j] >= d[0]) ? 1 : 0;
                referenceMatrix[1, j] = (d[j] >= d[1]) ? 1 : 0;
                referenceMatrix[2, j] = (d[j] >= d[2]) ? 1 : 0;
                referenceMatrix[3, j] = (d[j] >= d[3]) ? 1 : 0;
            }
            return referenceMatrix;
        }
    }


}
