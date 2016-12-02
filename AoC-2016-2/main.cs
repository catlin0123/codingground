using System.IO;
using System;

class Program {
    //TODO(caitlin): Read keypad and start numbers from file to make it easier to change.
    static char[,] keypad = { {'X', 'X', 'X', 'X', 'X'}, 
                              {'X', '1', '2', '3', 'X'}, 
                              {'X', '4', '5', '6', 'X'}, 
                              {'X', '7', '8', '9', 'X'},
                              {'X', 'X', 'X', 'X', 'X'}};
    // static char[,] keypad = {  {'X', 'X', 'X', 'X', 'X', 'X', 'X'},
    //                           {'X', 'X', 'X', '1', 'X', 'X', 'X'},
    //                           {'X', 'X', '2', '3', '4', 'X', 'X'},
    //                           {'X', '5', '6', '7', '8', '9', 'X'},
    //                           {'X', 'X', 'A', 'B', 'C', 'X', 'X'},
    //                           {'X', 'X', 'X', 'D', 'X', 'X', 'X'},
    //                           {'X', 'X', 'X', 'X', 'X', 'X', 'X'}};
    static int x = 2;
    //static int x = 1;
    static int y = 2;
    //static int y = 3;
    
    static void Main()
    {
        Console.WriteLine(FindCode(GetInput()));
    }
    
    static String[] GetInput() {
        using (StreamReader sr = new StreamReader("day2.txt"))
        {
            String line = sr.ReadToEnd();
            return line.Split(Environment.NewLine.ToCharArray());
        }
    }
    
    static String FindCode(String[] input) {
        String sequence = String.Empty;
        foreach (String s in input) {
            foreach(char c in s) {
                MoveOnce(c);
            }
            sequence = sequence + keypad[y, x];
        }
        return sequence;
    }
    
    static void MoveOnce(char c) {
        switch(c) {
            case 'L':
                MoveTo(y, x - 1);
                break;
            case 'R':
                MoveTo(y, x + 1);
                break;
            case 'U':
                MoveTo(y - 1, x);
                break;
            case 'D':
                MoveTo(y + 1, x);
                break;
        }
    }
    
    static void MoveTo(int y_val , int x_val) {
        if (keypad[y_val, x_val] != 'X') {
            x = x_val;
            y = y_val;
        }
    }
}
