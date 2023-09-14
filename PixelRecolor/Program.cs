using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterMappings
{
    class Program
    {
        static void Main(string[] args)
        {
            var pixelMatrix = new string[][]
            {
                 new string[] {"B", "B", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"B", "B", "B" }
            };
            DisplayResults(pixelMatrix, 2, 2, "G");

            pixelMatrix = new string[][]
            {
                 new string[] {"B", "B", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"B", "B", "B" }
            };
            DisplayResults(pixelMatrix, 1, 1, "G");

            pixelMatrix = new string[][]
            {
                 new string[] {"B", "B", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"B", "B", "B" }
            };            DisplayResults(pixelMatrix, 3, 1, "G");

            pixelMatrix = new string[][]
            {
                 new string[] {"B", "B", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"B", "B", "B" }
            };
            DisplayResults(pixelMatrix, 1, 4, "G");

            pixelMatrix = new string[][]
            {
                 new string[] {"B", "B", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"B", "B", "B" }
            };
            DisplayResults(pixelMatrix, 3, 4, "R");

            pixelMatrix = new string[][]
            {
                 new string[] {"B", "B", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"B", "B", "B" }
            };
            DisplayResults(pixelMatrix, 3, 5, "R");

            pixelMatrix = new string[][]
            {
                 new string[] {"B", "B", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"W", "W", "W" },
                 new string[] {"B", "B", "B" }
            };
            DisplayResults(pixelMatrix, 3, 4, "foo");
        }

        static void DisplayResults(string[][] pixelMatrix, int x, int y, string color)
        {
            Console.WriteLine($"Replacing pixels around ({x}, {y}) with '{color}'\n");
            Console.WriteLine($"Original Matrix:\n");
            foreach (var row in pixelMatrix)
            {
                Console.WriteLine($"{string.Join(" ", row)}");
            }

            try
            {
                var recoloredMatrix = GetRecoloredPixelMatrix(pixelMatrix, x, y, color);
                Console.WriteLine("\n");
                Console.WriteLine($"Recolored Matrix:\n");
                foreach (var row in recoloredMatrix)
                {
                    Console.WriteLine($"{string.Join(" ", row)}");
                }
                Console.WriteLine("\n_______________________________________\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Recolor all pixels around the center pixel that match the center pixel's original color
        static string[][] GetRecoloredPixelMatrix(string[][] pixelMatrix, int x, int y, string color)
        {
            // Error checking
            if (pixelMatrix == null || pixelMatrix.Length == 0 || pixelMatrix.Any(x => x.Length == 0))
            {
                throw new ArgumentException("Invalid pixel matrix");
            }
            if (x <= 0 || y <= 0 || x > pixelMatrix[0].Length || y > pixelMatrix.Length)
            {
                throw new ArgumentException($"Invalid coordinates: ({x}, {y})");
            }
            if (string.IsNullOrWhiteSpace(color) || color.Length > 1)
            {
                throw new ArgumentException($"Invalid color: {color}");
            }

            // Get minimum and maximum coordinates to check - cannot be out of bounds of the matrix, must be within 1 of the center coordinates
            var minimumX = Math.Max(x - 1, 1);
            var maximumX = Math.Min(x + 1, pixelMatrix[0].Length);
            var minimumY = Math.Max(y - 1, 1);
            var maximumY = Math.Min(y + 1, pixelMatrix.Length);
            var originalColor = pixelMatrix[y - 1][x - 1];

            // Loop through the 3x3 grid around the center pixel
            for (int horizontalCoordinate = minimumX; horizontalCoordinate <= maximumX; horizontalCoordinate++)
            {
                for (int verticalCoordinate = minimumY; verticalCoordinate <= maximumY; verticalCoordinate++)
                {
                    // Account for 0-based array index
                    var xCoordinateArray = horizontalCoordinate - 1; 
                    var yCoordinateArray = verticalCoordinate - 1;

                    // Replace color if it matches the original color of the center pixel
                    if (pixelMatrix[yCoordinateArray][xCoordinateArray] == originalColor)
                    {
                        pixelMatrix[yCoordinateArray][xCoordinateArray] = color;
                    }
                }
            }

            return pixelMatrix;
        }

    }
}
