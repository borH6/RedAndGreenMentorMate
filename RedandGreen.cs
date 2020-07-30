using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAndGreen
{
    //създаваме клас Матрица който ще ни съдържа атрибутите, параметрите и функцкиите
    class Matrix
    {
        int[,] arr;
        int W;
        int H;
        int cellX;
        int cellY;
        int K;
        int[,] b;

        public Matrix(int[,] inputMatrix,int inputWidth,int inputHeight,int inputX,int inputY,int inputK, int[,] newMatrix)
        {
            arr = inputMatrix;
            W = inputWidth;
            H = inputHeight;
            cellX = inputX;
            cellY = inputY;
            K = inputK;
            b = newMatrix;
        }
        //главната ни функция за итерация на матрицата
        public void nextIteration()
        {

            // c ще ни служи за брояч на зелени клетки (1-ци)
            int c = 0;
            // timesGreen е втория брояч който е за това колко пъти дадена клетка става зелена
            int timesGreen = 0;
            do
            {
                K--;
                //Два nested for цикъла за итериране на матрицата
                for (int i = 0; i < W; i++)
                {
                   // Console.WriteLine();
                    for (int j = 0; j < H; j++)
                    {
                        c = 0;

                        // Тук брояча се увеличава ако има зелени съседи  

                        if (i > 0 && arr[i - 1, j] == 1)
                            c++;
                        if (j > 0 && arr[i, j - 1] == 1)
                            c++;
                        if (i > 0 && j > 0 && arr[i - 1, j - 1] == 1)
                            c++;
                        if (i < W - 1 && arr[i + 1, j] == 1)
                            c++;
                        if (j < H - 1 && arr[i, j + 1] == 1)
                            c++;
                        if (i < W - 1 && j < H - 1 &&
                            arr[i + 1, j + 1] == 1)
                            c++;
                        if (i < W - 1 && j > 0 &&
                            arr[i + 1, j - 1] == 1)
                            c++;
                        if (i > 0 && j < W - 1 && arr[i - 1, j + 1] == 1)
                            c++;

                        // След като имаме брой зелени клетки съседи, правим проверка на клетката дали ще бъде зелена или червена (1 или 0) 
                        if (arr[i, j] == 1)
                        {
                            if (c == 2 || c == 3 || c == 6)
                                b[i, j] = 1;
                            else
                                b[i, j] = 0;
                        }
                        if (arr[i, j] == 0)
                        {
                            if (c == 3 || c == 6)
                                b[i, j] = 1;
                            else
                                b[i, j] = 0;
                        }
                       // Console.Write(b[i, j] + " ");
                    }
                }
                if (b[cellX, cellY] == 1)
                {
                    ++timesGreen;
                }
                // Копираме промените на главната матрица 
                for (int k = 0; k < W; k++)
                    for (int m = 0; m < H; m++)
                        arr[k, m] = b[k, m];
            } while (K != 0);
            Console.WriteLine();
            Console.Write("Брой пъти която е светнала клетка в зелено [{0}] [{1}] : {2} пъти",cellX,cellY,timesGreen);
        }
    }
    class RedandGreen
    {
        public static void Main(string[] args)
        {
             //Вход от потребител
            Console.WriteLine("Въведете измерения: X Y");
            var line = Console.ReadLine();
            var data = line.Split(' ');
            var W2 = int.Parse(data[0]); 
            var H2 = int.Parse(data[1]);
            while(W2>H2)
            {
                Console.WriteLine("X трябва да е по-малко от Y");
                line = Console.ReadLine();
                data = line.Split(' ');
                W2 = int.Parse(data[0]);
                H2 = int.Parse(data[1]);
            }
            //По правило от задачата, X<=Y<1000
            
             int[,] A = new int[W2, H2];
             Console.WriteLine("Въведете матрицата:");
             for (int i = 0; i < W2; i++)
             {
                 var lineinput = Console.ReadLine();
                 var dataMatrix = lineinput.Split(' ');
                 for (int j = 0; j < H2; j++)
                 {
                     A[i, j] = int.Parse(dataMatrix[j]);
                 }
             }
             Console.WriteLine("Въведете X,Y координати на клетка за проверка и брой итерации:");
             var line2 = Console.ReadLine();
             var data2 = line2.Split(' ');
             var chosenX2 = int.Parse(data2[0]);
             var chosenY2 = int.Parse(data2[1]);
             var K2 = int.Parse(data2[2]);

             int[,] b2 = new int[W2, H2];
             
             Matrix m2 = new Matrix(A, W2, H2, chosenX2, chosenY2, K2, b2);
             m2.nextIteration();
            Console.WriteLine();
            
            
        }
    }
}
