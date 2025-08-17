namespace SpellCheckerApp_Assignment.SpellCheckerApp
{
    public class LevenshteinDistance
    {
        public int CalculateDistance(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1)) return str2.Length;
            if (string.IsNullOrEmpty(str2)) return str1.Length;

            int[,] matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
                matrix[i, 0] = i;
            for (int j = 0; j <= str2.Length; j++)
                matrix[0, j] = j;

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;
                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost
                    );
                }
            }
            return matrix[str1.Length, str2.Length];
        }
    }
} 