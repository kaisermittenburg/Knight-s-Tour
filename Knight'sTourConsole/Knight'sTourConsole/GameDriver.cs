using System;
using System.Collections.Generic;
using System.Text;

namespace Knight_sTourConsole
{
    public class GameDriver
    {
		public GameDriver()
		{
			board = new Board();
			Menu();
		}

        #region Member Variables
        Board board;
        #endregion

        #region Private Methods
        private void ResetBoard()
        {
            board.NewBoard();
        }
        private void Solve()
        {
            board.Solve();
        }
        private void Menu()
        {
            ResetBoard();
            DateTime start = DateTime.Now;
            Solve();
            DateTime end = DateTime.Now;
            TimeSpan span = end.Subtract(start);
            PrintBoard();
            DisplayTimer(span);
            PlayAgain();
        }
        private void PrintBoard()
        {
            board.PrintBoard();
        }
        private void DisplayTimer(TimeSpan span)
        {
            if (span.TotalSeconds > 60)
                Console.WriteLine("Solved in " + span.TotalMinutes + " minutes");
            else
                Console.WriteLine("Solved in " + span.TotalSeconds + " seconds");
        }
        private void PlayAgain()
        {
            char response = ' ';
            Console.WriteLine("Would you like to reset? (y/n)");
            string read = Console.ReadLine();
            response = read[0];
            if (response == 'y')
            {
                Menu();
            }
        }
        #endregion
    }
}
