using System;
using System.Drawing; //Need to implement this- No graphics as of yet...

namespace MineSweeperMap
{
    class Program
    {
        public static void Main()
        {
            //System.Drawing.Rectangle rectangle = new Rectangle(10, 10, 10, 10);

            Random rand = new Random();

            //Get Random Bit
            int gRB()
            {
                //This favors 0, to cut down a bit on bombs
                int bit = 0;

                if (rand.Next(0,2) == 1)
                {
                    if (rand.Next(0, 2) == 1)
                    {
                        bit = 1;                        
                    }
                }

                return bit;
            }

            // Simplify this bit- loop through elements, inserting bits (Also: take height, width as params)
            int[,] matrix = new int[20, 20] {
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()},
                      {gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB(),gRB()}
                    };

            int totalRowCount = matrix.GetLength(0);
            int totalColCount = matrix.GetLength(1);

            // NOTE:  2D_Array[3,7] = [DOWN 3, RIGHT 7] = [ROWS: 3, COLS: 7]

            int getAdjacencyCount(int[] node)
            {
                int matrixBaseNode = matrix[node[0], node[1]];

                //Adjacencies
                int adjCount = 0;
                int adjN = 0;
                int adjE = 0;
                int adjS = 0;
                int adjW = 0;
                int adjNE = 0;
                int adjSE = 0;
                int adjSW = 0;
                int adjNW = 0;

                // N, NE, NW
                if (node[0] > 0)
                {
                    adjN = matrix[(node[0] - 1), (node[1])];
                    if (node[1] < totalColCount - 1)
                    {
                        adjNE = matrix[(node[0] - 1), (node[1] + 1)];
                    }
                    if (node[1] > 0)
                    {
                        adjNW = matrix[(node[0] - 1), (node[1] - 1)];
                    }
                };

                // S, SE, SW
                if (node[0] < totalRowCount - 1)
                {
                    adjS = matrix[(node[0] + 1), (node[1])];
                    if (node[1] < totalColCount - 1)
                    {
                        adjSE = matrix[(node[0] + 1), (node[1] + 1)];
                    }
                    if (node[1] > 0)
                    {
                        adjSW = matrix[(node[0] + 1), (node[1] - 1)];
                    }
                };

                // E
                if (node[1] < totalColCount - 1)
                {
                    adjE = matrix[(node[0]), (node[1] + 1)];
                };

                // W
                if (node[1] > 0)
                {
                    adjW = matrix[(node[0]), (node[1] - 1)];
                };

                adjCount = adjN + adjNE + adjE + adjSE + adjS + adjSW + adjW + adjNW;
                return adjCount;
            }

            int[,] resultMatrix = new int[totalRowCount, totalColCount];
            
            for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
            {
                for (int colCount = 0; colCount < totalColCount; colCount++)
                {
                    int[] node = { rowCount, colCount };
                    int result = getAdjacencyCount(node);
                    
                    resultMatrix[rowCount, colCount] = result;
                }
            }

            //PRINT BOMB MAP TO CONSOLE

            Console.Write(Environment.NewLine + Environment.NewLine + "BOMB MAP" + Environment.NewLine);
            for (int i = 0; i < totalRowCount; i++)
            {
                for (int j = 0; j < totalColCount; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            //Console.ReadLine();

            //PRINT ADJACENCY MAP (resultMatrix) TO CONSOLE
            Console.Write(Environment.NewLine + Environment.NewLine + "ADJACENCY MAP" + Environment.NewLine);
            for (int i = 0; i < totalRowCount; i++)
            {
                for (int j = 0; j < totalColCount; j++)
                {
                    Console.Write(string.Format("{0} ", resultMatrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }
    };

}
