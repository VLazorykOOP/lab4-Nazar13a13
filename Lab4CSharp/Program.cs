using System;


namespace Lab3
{
    
    //1.1. У клас Point додати індексатор, перевантаження операцій
    class Point
    {
        private int x, y;
        private readonly int c;

        public Point()
        {
            x = 0;
            y = 0;
            c = 0;
        }

        public Point(int x_, int y_, int c_)
        {
            x = x_;
            y = y_;
            c = c_;
        }

        public void Print()
        {
            Console.WriteLine($"x: {x}, y: {y}, color: {c}");
        }

        public double Distance()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public void Move(int x1, int y1)
        {
            x = x + x1;
            y = y + y1;
        }

        public void setX(int newX)
        {
            x = newX;
        }

        public int getX()
        {
            return x;
        }

        public void setY(int newY)
        {
            y = newY;
        }

        public int getY()
        {
            return y;
        }

        public int getColor()
        {
            return c;
        }

        public string this[int index]
        {
            get
            {
                if (index == 0) return x.ToString();
                else if (index == 1) return y.ToString();
                else if (index == 2) return c.ToString();
                else return "Error";
            }
            set
            {
                if (index == 0) x = int.Parse(value);
                else if (index == 1) y = int.Parse(value);
               // else if (index == 2) c = int.Parse(value); //-read only
            }
        }

        public static Point operator++(Point point)
        {
            point.x++;
            point.y++;
            return point;
        }

        public static Point operator--(Point point)
        {
            point.x--;
            point.y--;
            return point;
        }
        public static bool operator true(Point point)
        {
            if (point.x == point.y)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(Point point)
        {
            if (point.x == point.y)
            {
                return true;
            }
            return false;
        }
        public static Point operator*(Point point, int num)
        {
            point.x *= num;
            point.y *= num;
            return point;
        }

        public override string ToString()
        {
            return $"X: {x}, Y: {y}, Color: {c}";
        }


        

    }
    
    //2.1. Створити клас VectorInt (вектор цілих чисел).
        class VectorInt
    {
        private int[] intArray;
        private uint size;
        private int codeError;
        private static uint num_vec;

        public VectorInt()
        {
            intArray = new int[1];
            intArray[0] = 0;
            size = 1;
            codeError = 0;
            num_vec++;
        }

        public VectorInt(uint size)
        {
            intArray = new int[size];
            for (var i = 0; i < size; i++)
            {
                intArray[i] = 0;
            }

            this.size = size;
            num_vec++;
            codeError = 0;
        }

        public VectorInt(uint size, int num)
        {
            intArray = new int[size];
            for (var i = 0; i < size; i++)
            {
                intArray[i] = num;
            }

            this.size = size;
            num_vec++;
            codeError = 0;
        }

        ~VectorInt()
        {
            Console.WriteLine("Destructor");
        }

        public void inputArr()
        {
            for (var i = 0; i < size; i++)
            {
                int.TryParse(Console.ReadLine(), out intArray[i]);
            }
        }

        public void printArr()
        {
            for (var i = 0; i < size; i++)
            {
                Console.Write($"{intArray[i]} ");
            }
            Console.WriteLine();
        }

        public void setArr(int num)
        {
            for (var i = 0; i < size; i++)
            {
                intArray[i] = num;
            }
        }

        public uint getSize()
        {
            return size;
        }
        public int this[uint index]
        {
            get
            {
                if (index > size)
                {
                    codeError = -1;
                    return 0;
                }
                return intArray[index];
            }
            set
            {
                if (index > size)
                {
                    codeError = -1;
                }
                else
                {
                    intArray[index] = value;
                }
            }
        }
        public static VectorInt operator ++(VectorInt vectorint)
        {
            for (var i = 0; i < vectorint.size; i++)
            {
                vectorint.intArray[i]++;
            }
            return vectorint;
        }

        public static VectorInt operator --(VectorInt vectorint)
        {
            for (var i = 0; i < vectorint.size; i++)
            {
                vectorint.intArray[i]--;
            }
            return vectorint;
        }
        public static bool operator true(VectorInt vectorint)
        {
            if (vectorint.size != 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(VectorInt vectorint)
        {
            if (vectorint.size != 0)
            {
                return false;
            }
            return true;
        }
        public static VectorInt operator +(VectorInt vectorint, int num)
        {
            for (var i = 0; i < vectorint.size; i++)
            {
                vectorint.intArray[i] += + num;
            }
            return vectorint;
        }

        public static VectorInt operator +(VectorInt a, VectorInt b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.intArray[i] += b.intArray[i];
            }
            return a;
        }
        public static VectorInt operator -(VectorInt vectorint, int num)
        {
            for (var i = 0; i < vectorint.size; i++)
            {
                vectorint.intArray[i] = Convert.ToInt32(vectorint.intArray[i] - num);
            }
            return vectorint;
        }

        public static VectorInt operator -(VectorInt a, VectorInt b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.intArray[i] -= b.intArray[i];
            }
            return a;
        }
        public static VectorInt operator *(VectorInt vectorint, int num)
        {
            for (var i = 0; i < vectorint.size; i++)
            {
                vectorint.intArray[i] = Convert.ToInt32(vectorint.intArray[i] * num);
            }
            return vectorint;
        }

        public static VectorInt operator *(VectorInt a, VectorInt b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.intArray[i] *= b.intArray[i];
            }
            return a;
        }
        public static VectorInt operator /(VectorInt vectorint, int num)
        {
            for (var i = 0; i < vectorint.size; i++)
            {
                vectorint.intArray[i] = Convert.ToInt32(vectorint.intArray[i] / num);
            }
            return vectorint;
        }

        public static VectorInt operator /(VectorInt a, VectorInt b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.intArray[i] /= b.intArray[i];
            }
            return a;
        }

        public static VectorInt operator %(VectorInt vectorint, int num)
        {
            for (var i = 0; i < vectorint.size; i++)
            {
                vectorint.intArray[i] = Convert.ToInt32(vectorint.intArray[i] % num);
            }
            return vectorint;
        }

        public static VectorInt operator %(VectorInt a, VectorInt b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.intArray[i] %= b.intArray[i];
            }
            return a;
        }
        
        public static VectorInt operator |(VectorInt vectorint, int num)
        {
            for (var i = 0; i < vectorint.size; i++)
            {
                vectorint.intArray[i] = Convert.ToInt32(vectorint.intArray[i] | num);
            }
            return vectorint;
        }

        public static VectorInt operator |(VectorInt a, VectorInt b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.intArray[i] |= b.intArray[i];
            }
            return a;
        }
        public static VectorInt operator ^(VectorInt vectorint, int num)
        {
            for (var i = 0; i < vectorint.size; i++)
            {
                vectorint.intArray[i] = Convert.ToInt32(vectorint.intArray[i] ^ num);
            }
            return vectorint;
        }

        public static VectorInt operator ^(VectorInt a, VectorInt b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.intArray[i] ^= b.intArray[i];
            }
            return a;
        }
    }

        
    //Створити клас MatrixInt (матриця цілих чисел). 
class MatrixInt
    {
        private int[,] IntArray;
        private uint n,m;
        private int codeError;
        private static uint num_m;

        public MatrixInt()
        {
            IntArray = new int[1,1];
            IntArray[0,0] = 0;
            n = 1;
            m = 1;
            codeError = 0;
            num_m++;
        }

        public MatrixInt(uint n, uint m)
        {
            IntArray = new int[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    IntArray[i, c] = 0;
                }
            }
            this.n = n;
            this.m = m;
            num_m++;
            codeError = 0;
        }

        public MatrixInt(uint n, uint m, int num)
        {
            IntArray = new int[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    IntArray[i, c] = num;
                }
            }
            this.n = n;
            this.m = m;
            num_m++;
            codeError = 0;
        }

        ~MatrixInt()
        {
            Console.WriteLine("Destructor");
        }

        public void inputMat()
        {
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    int.TryParse(Console.ReadLine(), out IntArray[i,c]);
                }
            }
        }

        public void PrintMat()
        {
            for (var i = 0; i < n; i++) 
            {
                    for (var c = 0; c < m; c++)
                    {
                        Console.Write($"{IntArray[i,c]} ");
                    }
                    Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void SetMat(int num)
        {
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    IntArray[i, c] = num;
                }
            }
        }
        
        public int this[uint i, uint j]
        {
            get
            {
                if (i > n || j > m)
                {
                    codeError = -1;
                    return 0;
                }
                return IntArray[i,j];
            }
            set
            {
                if (i > n || j > m)
                {
                    codeError = -1;
                }
                else
                {
                    IntArray[i, j] = value;
                }
            }
        }
        
        public int this[int index]
        {
            //rown = n, column = m
            get
            {
                if (index < n * m - 1)
                {

                    return IntArray[index / m, (int)(index % m)];
                }
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (index < n * m - 1)
                {
                    IntArray[index / m, (int)(index % m)] = value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }
        
        public static MatrixInt operator++(MatrixInt MatrixInt)
        {
            for (var i = 0; i < MatrixInt.n; i++)
            {
                for (var c = 0; c < MatrixInt.m; c++)
                {
                    MatrixInt.IntArray[i, c]++;
                }
            }

            return MatrixInt;
        }
        
        public static MatrixInt operator--(MatrixInt MatrixInt)
        {
            for (var i = 0; i < MatrixInt.n; i++)
            {
                for (var c = 0; c < MatrixInt.m; c++)
                {
                    MatrixInt.IntArray[i, c]--;
                }
            }
            return MatrixInt;
        }
        public static bool operator true(MatrixInt MatrixInt)
        {
            if(MatrixInt.n != 0 && MatrixInt.m != 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(MatrixInt MatrixInt)
        {
            if(MatrixInt.n != 0 && MatrixInt.m != 0)
            {
                return false;
            }
            return true;
        }
        public static MatrixInt operator+(MatrixInt MatrixInt, int num)
        {
            for (var i = 0; i < MatrixInt.n; i++)
            {
                for (var c = 0; c < MatrixInt.m; c++)
                {
                    MatrixInt.IntArray[i, c] = Convert.ToInt32(MatrixInt.IntArray[i, c] + num);
                }
            }

            return MatrixInt;
        }

        public static MatrixInt operator+(MatrixInt a, MatrixInt b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.IntArray[i, c] += b.IntArray[i, c];
                }
            }
            return a;
        }
        public static MatrixInt operator-(MatrixInt MatrixInt, int num)
        {
            for (var i = 0; i < MatrixInt.n; i++)
            {
                for (var c = 0; c < MatrixInt.m; c++)
                {
                    MatrixInt.IntArray[i, c] = Convert.ToInt32(MatrixInt.IntArray[i,c] - num);
                }
            }

            return MatrixInt;
        }

        public static MatrixInt operator-(MatrixInt a, MatrixInt b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.IntArray[i, c] -= b.IntArray[i, c];
                }
            }
            return a;
        }
        public static MatrixInt operator*(MatrixInt matrixUint, int num)
        {
            for (var i = 0; i < matrixUint.n; i++)
            {
                for (var c = 0; c < matrixUint.m; c++)
                {
                    matrixUint.IntArray[i, c] = Convert.ToInt32(matrixUint.IntArray[i,c] * num);
                }
            }
            return matrixUint;
        }

        public static MatrixInt operator*(MatrixInt a, MatrixInt b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.IntArray[i, c] *= b.IntArray[i, c];
                }
            }
            return a;
        }
        public static MatrixInt operator/(MatrixInt matrixUint, int num)
        {
            for (var i = 0; i < matrixUint.n; i++)
            {
                for (var c = 0; c < matrixUint.m; c++)
                {
                    matrixUint.IntArray[i, c] = Convert.ToInt32(matrixUint.IntArray[i, c] / num);
                }
            }

            return matrixUint;
        }

        public static MatrixInt operator/(MatrixInt a, MatrixInt b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.IntArray[i, c] /= b.IntArray[i, c];
                }
            }
            return a;
        }
    }

    
    static class Program
    {
        static void Main()
        {
            Point a = new Point();
            Point b = new Point(2, 3, 4);
            Console.Write("A: ");
            a.Print();
            Console.Write("B: ");
            b.Print();
            Console.WriteLine($"B-0: {b.Distance()}");
            a.Move(3,5);
            Console.Write("A moved to 3,5: ");
            a.Print();
            a.setX(10);
            Console.Write("A x set to 10: ");
            a.Print();
            //-----------------
            var arrA = new VectorInt();
            var arrB = new VectorInt(5, 3);
            Console.WriteLine($"Index[1]: {arrB[1]}");
            Console.WriteLine("Array A: ");
            arrA.printArr();
            Console.WriteLine("Array B: ");
            arrB.printArr();
            arrA++;
            Console.WriteLine("A++: ");
            arrA.printArr();
            arrA--;
            Console.WriteLine("A--: ");
            arrA.printArr();
            Console.WriteLine(arrA ? "Array A exists" : "Array A does not exists");
            Console.WriteLine(arrB ? "Array B exists" : "Array B does not exists");
            Console.WriteLine("Array B: ");
            arrB.printArr();
            arrB = arrB * 3;
            Console.WriteLine("Array B * 3: ");
            arrB.printArr();
            //----------------
            var matA = new MatrixInt();
            var matB = new MatrixInt(3, 3, 1);
            Console.WriteLine($"Index[1]: {matB[1]}");
            Console.WriteLine("Matrix A: ");
            matA.PrintMat();
            Console.WriteLine("Matrix B: ");
            matB.PrintMat();
            matB++;
            Console.WriteLine("Matrix B++: ");
            matB.PrintMat();
            Console.WriteLine(matA ? "Matrix A exists" : "Matrix A does not exists");
            Console.WriteLine(matB ? "Matrix B exists" : "Matrix B does not exists");
            Console.WriteLine("Matrix B: ");
            matB.PrintMat();
            matB = matB * 4;
            Console.WriteLine("Matrix B * 4: ");
            matB.PrintMat();
        }
    }
    
}