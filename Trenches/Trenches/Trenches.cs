using System.Collections.Generic;
using System.Linq;

namespace Trenches
{
    public class Trenches
    {
        private const int Objective = 2;
        private const int Trench = 1;
        private const int Error = -1;

        private const int NotVisited = int.MaxValue;
        private const int NotVisitable = int.MaxValue - 1;

        public static int MinimumPathLength(int[,] terrain)
        {
            if (terrain == null)
            {
                return Error;
            }

            int numRows = terrain.GetLength(0);
            int numCols = terrain.GetLength(1);

            if (numRows <= 0 || numCols <= 0)
            {
                return Error;
            }

            int[,] alreadyVisitedTerrain = InitializeAlreadyVisitedTerrain(numRows, numCols);

            return CalculateMinimumPathLength(0, 0, terrain, numRows, numCols, 0, alreadyVisitedTerrain);
        }

        private static int[,] InitializeAlreadyVisitedTerrain(int numRows, int numCols)
        {
            int[,] result = new int[numRows, numCols];

            for (int i = 0; i < numRows; ++i)
            {
                for (int j = 0; j < numCols; ++j)
                {
                    result[i, j] = NotVisited;
                }
            }

            return result;
        }

        private static bool IsInsideTerrain(int row, int col, int numRows, int numCols)
        {
            return 0 <= row && row < numRows && 0 <= col && col < numCols;
        }

        private static int CalculateMinimumPathLength(int row, int col, int[,] terrain, int numRows, int numCols,
            int currentPathLength, int[,] alreadyVisitedTerrain)
        {
            if (!IsInsideTerrain(row, col, numRows, numCols))
            {
                return Error;
            }

            if (terrain[row, col] == Objective)
            {
                return currentPathLength;
            }

            if (terrain[row, col] == Trench)
            {
                alreadyVisitedTerrain[row, col] = NotVisitable;

                return Error;
            }

            if (alreadyVisitedTerrain[row, col] == NotVisited || alreadyVisitedTerrain[row, col] > currentPathLength)
            {
                alreadyVisitedTerrain[row, col] = currentPathLength;

                List<int> candidates = new List<int>();

                int candidate = CalculateMinimumPathLength(row + 1, col, terrain, numRows, numCols,
                    currentPathLength + 1, alreadyVisitedTerrain);

                if (candidate != Error)
                {
                    candidates.Add(candidate);
                }

                candidate = CalculateMinimumPathLength(row - 1, col, terrain, numRows, numCols,
                    currentPathLength + 1, alreadyVisitedTerrain);

                if (candidate != Error)
                {
                    candidates.Add(candidate);
                }

                candidate = CalculateMinimumPathLength(row, col + 1, terrain, numRows, numCols,
                    currentPathLength + 1, alreadyVisitedTerrain);

                if (candidate != Error)
                {
                    candidates.Add(candidate);
                }

                candidate = CalculateMinimumPathLength(row, col - 1, terrain, numRows, numCols,
                    currentPathLength + 1, alreadyVisitedTerrain);

                if (candidate != Error)
                {
                    candidates.Add(candidate);
                }

                if (candidates.Any())
                {
                    candidates.Sort();
                    return candidates.First();
                }
            }

            return Error;
        }
    }
}