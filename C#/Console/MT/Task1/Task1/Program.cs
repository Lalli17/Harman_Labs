using System.Diagnostics;

namespace Task1
{
    internal class Program
    {
        static int ROWS = 9000;
        static int COL = 9000;
        static void Main(string[] args)
        {       
                int[,] matrix1 = new int[ROWS, COL];
                int[,] matrix2 = new int[ROWS, COL];

                InitializeMatrix(matrix1);
                InitializeMatrix(matrix2);

                // Parallel.For
                Stopwatch sw1 = Stopwatch.StartNew();
                var resultParallel = MultiplyMatrixParallel(matrix1, matrix2);
                sw1.Stop();
                Console.WriteLine($"Using Parallel.For - Time taken: {sw1.ElapsedMilliseconds} ms");

                // Tasks
                Stopwatch sw2 = Stopwatch.StartNew();
                var resultTasks = MultiplyMatrixUsingTasks(matrix1, matrix2);
                sw2.Stop();
                Console.WriteLine($"Using Tasks         - Time taken: {sw2.ElapsedMilliseconds} ms");

                // Threads
                Stopwatch sw3 = Stopwatch.StartNew();
                var resultThreads = MultiplyMatrixUsingThreads(matrix1, matrix2);
                sw3.Stop();
                Console.WriteLine($"Using Threads       - Time taken: {sw3.ElapsedMilliseconds} ms");
            }

            static void InitializeMatrix(int[,] matrix)
            {
                Random rnd = new Random();
                for (int i = 0; i < ROWS; i++)
                {
                    for (int x = 0; x < COL; x++)
                    {
                        matrix[i, x] = rnd.Next(1, 99);
                    }
                }
            }

            static int[,] MultiplyMatrixParallel(int[,] m1, int[,] m2)
            {
                int[,] result = new int[ROWS, COL];

                Parallel.For(0, ROWS, r =>
                {
                    for (int c = 0; c < COL; c++)
                    {
                        result[r, c] = m1[r, c] * m2[r, c];
                    }
                });

                return result;
            }

            static int[,] MultiplyMatrixUsingTasks(int[,] m1, int[,] m2)
            {
                int[,] result = new int[ROWS, COL];
                int numTasks = Environment.ProcessorCount;
                int rowsPerTask = ROWS / numTasks;

                Task[] tasks = new Task[numTasks];

                for (int t = 0; t < numTasks; t++)
                {
                    int startRow = t * rowsPerTask;
                    int endRow = (t == numTasks - 1) ? ROWS : startRow + rowsPerTask;

                    tasks[t] = Task.Run(() =>
                    {
                        for (int r = startRow; r < endRow; r++)
                        {
                            for (int c = 0; c < COL; c++)
                            {
                                result[r, c] = m1[r, c] * m2[r, c];
                            }
                        }
                    });
                }

                Task.WaitAll(tasks);
                return result;
            }

            static int[,] MultiplyMatrixUsingThreads(int[,] m1, int[,] m2)
            {
                int[,] result = new int[ROWS, COL];
                int numThreads = Environment.ProcessorCount;
                int rowsPerThread = ROWS / numThreads;

                Thread[] threads = new Thread[numThreads];

                for (int t = 0; t < numThreads; t++)
                {
                    int startRow = t * rowsPerThread;
                    int endRow = (t == numThreads - 1) ? ROWS : startRow + rowsPerThread;

                    threads[t] = new Thread(() =>
                    {
                        for (int r = startRow; r < endRow; r++)
                        {
                            for (int c = 0; c < COL; c++)
                            {
                                result[r, c] = m1[r, c] * m2[r, c];
                            }
                        }
                    });

                    threads[t].Start();
                }

                foreach (var thread in threads)
                {
                    thread.Join();
                }

                return result;
            }
        }
    }
