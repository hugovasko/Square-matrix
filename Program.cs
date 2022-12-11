namespace Square_matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Read the size of the matrix from the console
            Console.WriteLine("Enter the size of the matrix: ");
            int size = int.Parse(Console.ReadLine());

            // 2. Create a matrix of integers of size N x N
            int[,] matrix = new int[size, size];

            // 3. Initialize the matrix elements from a text file
            string path = @"C:\Users\hugovasko\repos\Square-matrix\resources\test.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] values = line.Split('\t');
                int row = int.Parse(values[0]);
                int col = int.Parse(values[1]);
                int value = int.Parse(values[2]);
                matrix[row, col] = value;
            }

            //if there is no row with a value for an element, the value of the element is -1
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, j] = -1;
                    }
                }
            }

            // 4. Display the matrix on the console
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            // 5. Find the sum of the even and the sum of the odd elements of the matrix
            int sumEven = 0;
            int sumOdd = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] % 2 == 0)
                    {
                        sumEven += matrix[row, col];
                    }
                    else
                    {
                        sumOdd += matrix[row, col];
                    }
                }
            }

            Console.WriteLine("Sum of even elements: " + sumEven);
            Console.WriteLine("Sum of odd elements: " + sumOdd);

            // 6. Find the sum of the elements of the even rows of the matrix and the sum of the elements of the odd columns
            int sumEvenRows = 0;
            int sumOddCols = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        sumEvenRows += matrix[row, col];
                    }
                    if (col % 2 != 0)
                    {
                        sumOddCols += matrix[row, col];
                    }
                }
            }

            Console.WriteLine("Sum of even rows: " + sumEvenRows);
            Console.WriteLine("Sum of odd columns: " + sumOddCols);
        }
    }
}