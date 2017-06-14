using System;
using System.Collections.Generic;
using System.Text;

namespace Knight_sTourConsole
{
    public class GameDriver
    {
        Board board;
        public GameDriver()
        {
            board = new Board();
            menu();
        }
        private void resetBoard()
        {
            board.newBoard();
        }
        private void solve()
        {
            board.solve();
        }
        private void menu()
        {
            resetBoard();
            DateTime start = DateTime.Now;
            solve();
            DateTime end = DateTime.Now;
            TimeSpan span = end.Subtract(start);
            printBoard();
            Console.WriteLine("Solved in " +span.TotalSeconds);
            char response = ' ';
            Console.WriteLine("Would you like to reset? (y/n)");
            string read = Console.ReadLine();
            response = read[0];
            if(response =='y')
            {
                menu();
            }
        }
        private void printBoard()
        {
            board.printBoard();
        }
    }
}
