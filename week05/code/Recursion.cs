using System.Collections;
using System.Diagnostics;

public static class Recursion
{
    // ##################
    // Problem 1: Sum of squares
    // ##################
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0; // Base case
        return n * n + SumSquaresRecursive(n - 1);
    }

    // ##################
    // Problem 2: Permutations choose
    // ##################
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    // ##################
    // Problem 3: Climbing stairs with memoization
    // ##################
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) remember = new Dictionary<int, decimal>();

        // Base cases
        if (s <= 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        if (remember.ContainsKey(s)) return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // ##################
    // Problem 4: Wildcard binary
    // ##################
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int idx = pattern.IndexOf('*');
        if (idx == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace '*' with '0' and '1' and recurse
        string zero = pattern.Substring(0, idx) + "0" + pattern.Substring(idx + 1);
        string one  = pattern.Substring(0, idx) + "1" + pattern.Substring(idx + 1);

        WildcardBinary(zero, results);
        WildcardBinary(one, results);
    }

    // ##################
    // Problem 5: Solve Maze
    // ##################
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null) currPath = new List<ValueTuple<int, int>>();

        if (!maze.IsValidMove(currPath, x, y)) return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Move in 4 directions: right, left, down, up
            SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath));
            SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath));
            SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath));
            SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath));
        }
    }
}
