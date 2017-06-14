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
            solve();
            printBoard();
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
