using System;
using System.Collections.Generic;
using System.Text;

namespace Knight_sTourConsole
{
    public class Board
    {
        private int rows;
        private int cols;
        private int startX;
        private int startY;
        private bool isValidDimensions = true;
        private bool isValidStartXY = true;
        private int moveCounter;
        private int maxMoves;
        private int[,] board;
        public Board()
        {
               
        }
        public void getDimensions()
        {
            do
            {
                isValidDimensions = true;
                Console.WriteLine("Enter the board dimensions. Example --> 3 4 for width of 3 and height of 4");
                string dimensions = Console.ReadLine();
                if (Int32.TryParse(dimensions[0].ToString(), out rows))
                {
                }
                else
                {
                    isValidDimensions = false;

                }
                if (Int32.TryParse(dimensions[2].ToString(), out cols))
                {
                }
                else
                {
                    isValidDimensions = false;

                }
            } while (!isValidDimensions);
            Console.WriteLine();
            Console.WriteLine();
        }
        public void getXY()
        {
            do
            {
                isValidStartXY = true;
                Console.WriteLine("Please enter the starting x-y position of the Knight. Example --> 2 3");
                string dimensions = Console.ReadLine();
                if (Int32.TryParse(dimensions[0].ToString(), out startX))
                {
                }
                else
                {
                    isValidStartXY = false;

                }
                if (Int32.TryParse(dimensions[2].ToString(), out startY))
                {
                }
                else
                {
                    isValidStartXY = false;

                }
            } while (!isValidStartXY);
            Console.WriteLine();
            Console.WriteLine();
        }
        public void newBoard()
        {
            rows = 0;
            cols = 0;
            startX = 0;
            startY = 0;
            moveCounter = 0;
            maxMoves = 0;
            getDimensions();
            getXY();
            maxMoves = (rows * cols) - 1;
            board = new int[rows,cols];
            //set all indices to -1, a default value that is acceptable to reset to
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    board[i, j] = -1;
                }
            }
            //set start space to 0
            board[startX, startY] = 0;
            
        }
        public bool solve()
        {
            knightsTour(board, startX, startY, moveCounter, maxMoves, rows, cols);
            return false;
        }
        public bool isValid(int[,] board, int curRow, int curCol, int nextRow, int nextCol, int rowBound, int colBound)
        {
            if(nextRow>=0 && nextRow<rowBound && nextCol>=0 && nextCol<colBound && board[nextRow,nextCol] < 0)
            {
                return true;
            }
            return false;
        }
        public bool knightsTour(int[,] board, int curRow, int curCol, int moveCounter, int maxMoves, int rowBound, int colBound)
        {
            if(moveCounter == maxMoves)
            {
                return true;
            }
            //up 2 right 1
            int nextRow = curRow;
            int nextCol = curCol;
            if(isValid(board, curRow, curCol, nextRow- 2, nextCol + 1, rowBound, colBound))
            {
                moveCounter++;
                board[nextRow-2, nextCol+1] = moveCounter;
                if(knightsTour(board, nextRow-2, nextCol+1, moveCounter, maxMoves, rowBound, colBound))
                {
                    return true;
                }
                board[curRow - 2, curCol + 1] = -1;
                moveCounter--;
            }
            //up 2 left 1
            if (isValid(board, curRow, curCol, nextRow-2, nextCol-1, rowBound, colBound))
            {
                moveCounter++;
                board[nextRow-2, nextCol-1] = moveCounter;
                if (knightsTour(board, nextRow-2, nextCol-1, moveCounter, maxMoves, rowBound, colBound))
                {
                    return true;
                }
                board[curRow - 2, curCol - 1] = -1;
                moveCounter--;
            }
            //up 1 left 2
            if (isValid(board, curRow, curCol, nextRow - 1, nextCol - 2, rowBound, colBound))
            {
                moveCounter++;
                board[nextRow - 1, nextCol - 2] = moveCounter;
                if (knightsTour(board, nextRow - 1, nextCol - 2, moveCounter, maxMoves, rowBound, colBound))
                {
                    return true;
                }
                board[curRow - 1, curCol - 2] = -1;
                moveCounter--;
            }
            //down 1 left 2
            if (isValid(board, curRow, curCol, nextRow + 1, nextCol - 2, rowBound, colBound))
            {
                moveCounter++;
                board[nextRow + 1, nextCol - 2] = moveCounter;
                if (knightsTour(board, nextRow +1, nextCol - 2, moveCounter, maxMoves, rowBound, colBound))
                {
                    return true;
                }
                board[curRow + 1, curCol - 2] = -1;
                moveCounter--;
            }
            //up 1 right 2
            if (isValid(board, curRow, curCol, nextRow - 1, nextCol + 2, rowBound, colBound))
            {
                moveCounter++;
                board[nextRow - 1, nextCol + 2] = moveCounter;
                if (knightsTour(board, nextRow - 1, nextCol + 2, moveCounter, maxMoves, rowBound, colBound))
                {
                    return true;
                }
                board[curRow - 1, curCol + 2] = -1;
                moveCounter--;
            }
            //down 1 right 2
            if (isValid(board, curRow, curCol, nextRow + 1, nextCol + 2, rowBound, colBound))
            {
                moveCounter++;
                board[nextRow + 1, nextCol + 2] = moveCounter;
                if (knightsTour(board, nextRow + 1, nextCol + 2, moveCounter, maxMoves, rowBound, colBound))
                {
                    return true;
                }
                board[curRow + 1, curCol + 2] = -1;
                moveCounter--;
            }
            //down 2 right 1
            if (isValid(board, curRow, curCol, nextRow + 2, nextCol + 1, rowBound, colBound))
            {
                moveCounter++;
                board[nextRow + 2, nextCol + 1] = moveCounter;
                if (knightsTour(board, nextRow + 2, nextCol + 1, moveCounter, maxMoves, rowBound, colBound))
                {
                    return true;
                }
                board[curRow + 2, curCol + 1] = -1;
                moveCounter--;
            }
            //down 2 left 1
            if (isValid(board, curRow, curCol, nextRow + 2, nextCol - 1, rowBound, colBound))
            {
                moveCounter++;
                board[nextRow + 2, nextCol - 1] = moveCounter;
                if (knightsTour(board, nextRow + 2, nextCol - 1, moveCounter, maxMoves, rowBound, colBound))
                {
                    return true;
                }
                board[curRow + 2, curCol - 1] = -1;
                moveCounter--;
            }
            return false;
        }
        public void printBoard()
        {
            for(int i = 0; i <rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(board[i,j] == -1)
                    {
                        Console.Write("[ X]");
                    }
                    else if(board[i,j] < 10)
                    {
                        Console.Write("[ ");
                        Console.Write(board[i, j]);
                        Console.Write("]");
                    }
                    else
                    {
                        Console.Write("[");
                        Console.Write(board[i, j]);
                        Console.Write("]");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
