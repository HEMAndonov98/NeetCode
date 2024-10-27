bool IsValidSudoku(char[][] board)
{
    Dictionary<int, HashSet<char>> sudokuColMap = new Dictionary<int, HashSet<char>>();
    Dictionary<int, HashSet<char>> sudokuRowMap = new Dictionary<int, HashSet<char>>();
    Dictionary<int, HashSet<char>> sudokuSubSetMap = new Dictionary<int, HashSet<char>>();

    for (int row = 0; row < 9; row++)
    {
        for (int col = 0; col < 9; col++)
        {
            char currentChar = board[row][col];

            if (currentChar == '.') continue;
            int subSetIndex = (row / 3) * 3 + (col / 3);
            
            if (!sudokuColMap.ContainsKey(col)) sudokuColMap.TryAdd(col, new HashSet<char>());
            if (!sudokuRowMap.ContainsKey(row)) sudokuRowMap.TryAdd(row, new HashSet<char>());
            if (!sudokuSubSetMap.ContainsKey(subSetIndex)) sudokuSubSetMap.TryAdd(subSetIndex, new HashSet<char>());
            
            
            if (sudokuColMap[col].Contains(currentChar)) return false;
            if (sudokuRowMap[row].Contains(currentChar)) return false;
            if (sudokuSubSetMap[subSetIndex].Contains(currentChar)) return false;
            
            sudokuColMap[col].Add(currentChar);
            sudokuRowMap[row].Add(currentChar);
            sudokuSubSetMap[subSetIndex].Add(currentChar);
        }
    }
    return true;
}

char[][] board = new char[][]
{
    new char[] { '.', '.', '4', '.', '.', '.', '6', '3', '.' },
    new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
    new char[] { '5', '.', '.', '.', '.', '.', '.', '9', '.' },
    new char[] { '.', '.', '.', '5', '6', '.', '.', '.', '.' },
    new char[] { '4', '.', '3', '.', '.', '.', '.', '.', '1' },
    new char[] { '.', '.', '.', '7', '.', '.', '.', '.', '.' },
    new char[] { '.', '.', '.', '5', '.', '.', '.', '.', '.' },
    new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
    new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' }
};

Console.WriteLine(IsValidSudoku(board));
