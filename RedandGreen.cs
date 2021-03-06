﻿using System;

namespace RedAndGreen
{
    //създаваме клас Матрица който ще ни съдържа атрибутите, параметрите и функцкиите
    class Matrix
    {
        int[,] arr; //двуизмерен масив който ще съдържа матрицата
        int W;      // ширина на матрицата
        int H;      // височина на матрицата
        int cellX;  // посочена клетка по координата Х
        int cellY;  // посочена клетка по координата Y
        int K;      // брой итерации
        int[,] b;   // следващата генерация на матрицата, която се генерира сама като се извърши итерация

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
            // timesGreen е втория брояч който служи за това колко пъти дадена клетка става зелена
            int timesGreen = 0;
            do
            {
                K--;
                //Два nested for цикъла за итериране на матрицата
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        c = 0;

                        // Тук брояча се увеличава ако има зелени съседи (1-ци)

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
                    }
                }
                //Увеличаваме брояча за това дадената клетка колко пъти е станала зелена
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
            var W = int.Parse(data[0]); 
            var H = int.Parse(data[1]);
            while(W>H || H>1000)
            {
                Console.WriteLine("X трябва да е по-малко от Y");
                line = Console.ReadLine();
                data = line.Split(' ');
                W = int.Parse(data[0]);
                H = int.Parse(data[1]);
            }
            //По правило от задачата, X<=Y<1000
            
             int[,] A = new int[W, H];
             Console.WriteLine("Въведете матрицата:");
             for (int i = 0; i < W; i++)
             {
                 var lineinput = Console.ReadLine();
                 var dataMatrix = lineinput.Split(' ');
                 for (int j = 0; j < H; j++)
                 {
                     A[i, j] = int.Parse(dataMatrix[j]);
                 }
             }
             Console.WriteLine("Въведете X,Y координати на клетка за проверка и брой итерации:");
             var line2 = Console.ReadLine();
             var data2 = line2.Split(' ');
             var chosenX = int.Parse(data2[0]);
             var chosenY = int.Parse(data2[1]);
             var K = int.Parse(data2[2]);

             int[,] b = new int[W, H];
             
             Matrix m = new Matrix(A, W, H, chosenX, chosenY, K, b);
             m.nextIteration();
             Console.WriteLine();         
        }
    }
}
