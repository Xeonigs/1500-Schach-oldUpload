using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1500_Schach
{
    class ChessSystem
    {
        public List<int[]> possibleMoves = new List<int[]>();

        public List<Figure> figureList = new List<Figure>();
        public FigureColor whoseMove;
        public int[] posOfSelectedFigure;

        public ChessSystem()
        {
            whoseMove = FigureColor.White;

            figureList.Add(new Figure(FigureType.Rook, FigureColor.White, 0, 0, 1));
            figureList.Add(new Figure(FigureType.Knight, FigureColor.White, 1, 0, 2));
            figureList.Add(new Figure(FigureType.Bishop, FigureColor.White, 2, 0, 3));
            figureList.Add(new Figure(FigureType.King, FigureColor.White, 4, 0, 4));
            figureList.Add(new Figure(FigureType.Queen, FigureColor.White, 3, 0, 5));
            figureList.Add(new Figure(FigureType.Bishop, FigureColor.White, 5, 0, 6));
            figureList.Add(new Figure(FigureType.Knight, FigureColor.White, 6, 0, 7));
            figureList.Add(new Figure(FigureType.Rook, FigureColor.White, 7, 0, 8));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.White, 0, 1, 9));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.White, 1, 1, 10));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.White, 2, 1, 11));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.White, 3, 1, 12));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.White, 4, 1, 13));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.White, 5, 1, 14));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.White, 6, 1, 15));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.White, 7, 1, 16));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.Black, 0, 6, 17));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.Black, 1, 6, 18));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.Black, 2, 6, 19));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.Black, 3, 6, 20));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.Black, 4, 6, 21));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.Black, 5, 6, 22));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.Black, 6, 6, 23));
            figureList.Add(new Figure(FigureType.Pawn, FigureColor.Black, 7, 6, 24));
            figureList.Add(new Figure(FigureType.Rook, FigureColor.Black, 0, 7, 25));
            figureList.Add(new Figure(FigureType.Knight, FigureColor.Black, 1, 7, 26));
            figureList.Add(new Figure(FigureType.Bishop, FigureColor.Black, 2, 7, 27));
            figureList.Add(new Figure(FigureType.King, FigureColor.Black, 4, 7, 28));
            figureList.Add(new Figure(FigureType.Queen, FigureColor.Black, 3, 7, 29));
            figureList.Add(new Figure(FigureType.Bishop, FigureColor.Black, 5, 7, 30));
            figureList.Add(new Figure(FigureType.Knight, FigureColor.Black, 6, 7, 31));
            figureList.Add(new Figure(FigureType.Rook, FigureColor.Black, 7, 7, 32));
        }

        public void MoveFigure(int col, int row, int indexOfSelectedFigure)
        {
            if (figureList[indexOfSelectedFigure].Type == FigureType.King && posOfSelectedFigure[0] + 2 == col)
            {
                figureList[indexOfSelectedFigure].PosX = col;

                for (int colCounter = posOfSelectedFigure[0] + 3; true; colCounter++)
                    if (IsFigureAtPos(colCounter, posOfSelectedFigure[1]))
                    {
                        figureList[GetFigureListIndexFromPos(colCounter, posOfSelectedFigure[1])].PosX = col - 1;
                        break;
                    }

                figureList[indexOfSelectedFigure].moved = true;

                if (whoseMove == FigureColor.White) { whoseMove = FigureColor.Black; }
                else if (whoseMove == FigureColor.Black) { whoseMove = FigureColor.White; }
            }
            else if (figureList[indexOfSelectedFigure].Type == FigureType.King && posOfSelectedFigure[0] - 2 == col)
            {
                figureList[indexOfSelectedFigure].PosX = col;

                for (int colCounter = posOfSelectedFigure[0] - 3; true; colCounter--)
                    if (IsFigureAtPos(colCounter, posOfSelectedFigure[1]))
                    {
                        figureList[GetFigureListIndexFromPos(colCounter, row)].PosX = col + 1;
                        break;
                    }

                figureList[indexOfSelectedFigure].moved = true;

                if (whoseMove == FigureColor.White) { whoseMove = FigureColor.Black; }
                else if (whoseMove == FigureColor.Black) { whoseMove = FigureColor.White; }
            }
            else
            {
                figureList[indexOfSelectedFigure].PosX = col;
                figureList[indexOfSelectedFigure].PosY = row;
                figureList[indexOfSelectedFigure].moved = true;
                if (whoseMove == FigureColor.White) { whoseMove = FigureColor.Black; }
                else if (whoseMove == FigureColor.Black) { whoseMove = FigureColor.White; }
            }
            possibleMoves.Clear();
        }

        public void BeatFigure(int col, int row, int indexOfSelectedFigure)
        {
            figureList.RemoveAt(GetFigureListIndexFromPos(col, row));
            indexOfSelectedFigure = GetFigureListIndexFromPos(posOfSelectedFigure[0], posOfSelectedFigure[1]);
            figureList[indexOfSelectedFigure].PosX = col;
            figureList[indexOfSelectedFigure].PosY = row;
            figureList[indexOfSelectedFigure].moved = true;
            if (whoseMove == FigureColor.White) { whoseMove = FigureColor.Black; }
            else if (whoseMove == FigureColor.Black) { whoseMove = FigureColor.White; }
            possibleMoves.Clear();
        }

        public List<int[]> SelectFigure(int col, int row)
        {
            List<int[]> value = new List<int[]>();
            switch (GetFigureType(col, row))
            {
                case FigureType.Pawn:
                    if (whoseMove == FigureColor.White)
                    {
                        if (!IsFigureAtPos(col, row + 1))
                            value.Add(new int[2] { col, row + 1 });
                        if (!figureList[GetFigureListIndexFromPos(col, row)].moved && !IsFigureAtPos(col, row + 2))
                            value.Add(new int[2] { col, row + 2 });
                        if (IsFigureAtPos(col + 1, row + 1) && !IsAllyFigure(col + 1, row + 1))
                            value.Add(new int[2] { col + 1, row + 1 });
                        if (IsFigureAtPos(col - 1, row + 1) && !IsAllyFigure(col - 1, row + 1))
                            value.Add(new int[2] { col - 1, row + 1 });
                    }
                    else if (whoseMove == FigureColor.Black)
                    {
                        if (!IsFigureAtPos(col, row - 1))
                            value.Add(new int[2] { col, row - 1 });
                        if (!figureList[GetFigureListIndexFromPos(col, row)].moved && !IsFigureAtPos(col, row - 2))
                            value.Add(new int[2] { col, row - 2 });
                        if (IsFigureAtPos(col + 1, row - 1) && !IsAllyFigure(col + 1, row - 1))
                            value.Add(new int[2] { col + 1, row - 1 });
                        if (IsFigureAtPos(col - 1, row - 1) && !IsAllyFigure(col - 1, row - 1))
                            value.Add(new int[2] { col - 1, row - 1 });
                    }
                    break;


                case FigureType.Rook:
                    for (int up = row - 1; up > -1; up--)
                        if (!IsFigureAtPos(col, up))
                            value.Add(new int[2] { col, up });
                        else
                        {
                            if (!IsAllyFigure(col, up))
                                value.Add(new int[2] { col, up });
                            break;
                        }
                    for (int right = col + 1; right < 8; right++)
                        if (!IsFigureAtPos(right, row))
                            value.Add(new int[2] { right, row });
                        else
                        {
                            if (!IsAllyFigure(right, row))
                                value.Add(new int[2] { right, row });
                            break;
                        }
                    for (int down = row + 1; down < 8; down++)
                        if (!IsFigureAtPos(col, down))
                            value.Add(new int[2] { col, down });
                        else
                        {
                            if (!IsAllyFigure(col, down))
                                value.Add(new int[2] { col, down });
                            break;
                        }
                    for (int left = col - 1; left > -1; left--)
                        if (!IsFigureAtPos(left, row))
                            value.Add(new int[2] { left, row });
                        else
                        {
                            if (!IsAllyFigure(left, row))
                                value.Add(new int[2] { left, row });
                            break;
                        }
                    break;


                case FigureType.Bishop:
                    for (int upright = 1; col - upright > -1 || row + upright < 8; upright++)
                        if (!IsFigureAtPos(col - upright, row + upright))
                            value.Add(new int[2] { col - upright, row + upright });
                        else if (!IsAllyFigure(col - upright, row + upright))
                        {
                            value.Add(new int[2] { col - upright, row + upright });
                            break;
                        }
                    for (int downright = 1; col + downright < 8 || row + downright < 8; downright++)
                        if (!IsFigureAtPos(col + downright, row + downright))
                            value.Add(new int[2] { col + downright, row + downright });
                        else if (!IsAllyFigure(col + downright, row + downright))
                        {
                            value.Add(new int[2] { col + downright, row + downright });
                            break;
                        }
                    for (int downleft = 1; col + downleft < 8 || row - downleft > -1; downleft++)
                        if (!IsFigureAtPos(col + downleft, row - downleft))
                            value.Add(new int[2] { col + downleft, row - downleft });
                        else if (!IsAllyFigure(col + downleft, row - downleft))
                        {
                            value.Add(new int[2] { col + downleft, row - downleft });
                            break;
                        }
                    for (int downleft = 1; col - downleft > -1 || row - downleft > -1; downleft++)
                        if (!IsFigureAtPos(col - downleft, row - downleft))
                            value.Add(new int[2] { col - downleft, row - downleft });
                        else if (!IsAllyFigure(col - downleft, row - downleft))
                        {
                            value.Add(new int[2] { col - downleft, row - downleft });
                            break;
                        }
                    break;


                case FigureType.Knight:
                    if (!IsFigureAtPos(col + 2, row + 1) || !IsAllyFigure(col + 2, row + 1))
                        value.Add(new int[2] { col + 2, row + 1 });
                    if (!IsFigureAtPos(col + 2, row - 1) || !IsAllyFigure(col + 2, row - 1))
                        value.Add(new int[2] { col + 2, row - 1 });
                    if (!IsFigureAtPos(col - 2, row + 1) || !IsAllyFigure(col - 2, row + 1))
                        value.Add(new int[2] { col - 2, row + 1 });
                    if (!IsFigureAtPos(col - 2, row - 1) || !IsAllyFigure(col - 2, row - 1))
                        value.Add(new int[2] { col - 2, row - 1 });
                    if (!IsFigureAtPos(col + 1, row + 2) || !IsAllyFigure(col + 1, row + 2))
                        value.Add(new int[2] { col + 1, row + 2 });
                    if (!IsFigureAtPos(col - 1, row + 2) || !IsAllyFigure(col - 1, row + 2))
                        value.Add(new int[2] { col - 1, row + 2 });
                    if (!IsFigureAtPos(col + 1, row - 2) || !IsAllyFigure(col + 1, row - 2))
                        value.Add(new int[2] { col + 1, row - 2 });
                    if (!IsFigureAtPos(col - 1, row - 2) || !IsAllyFigure(col - 1, row - 2))
                        value.Add(new int[2] { col - 1, row - 2 });
                    break;


                case FigureType.Queen:
                    for (int up = row - 1; up > -1; up--)
                        if (!IsFigureAtPos(col, up))
                            value.Add(new int[2] { col, up });
                        else
                        {
                            if (!IsAllyFigure(col, up))
                                value.Add(new int[2] { col, up });
                            break;
                        }
                    for (int right = col + 1; right < 8; right++)
                        if (!IsFigureAtPos(right, row))
                            value.Add(new int[2] { right, row });
                        else
                        {
                            if (!IsAllyFigure(right, row))
                                value.Add(new int[2] { right, row });
                            break;
                        }
                    for (int down = row + 1; down < 8; down++)
                        if (!IsFigureAtPos(col, down))
                            value.Add(new int[2] { col, down });
                        else
                        {
                            if (!IsAllyFigure(col, down))
                                value.Add(new int[2] { col, down });
                            break;
                        }
                    for (int left = col - 1; left > -1; left--)
                        if (!IsFigureAtPos(left, row))
                            value.Add(new int[2] { left, row });
                        else
                        {
                            if (!IsAllyFigure(left, row))
                                value.Add(new int[2] { left, row });
                            break;
                        }
                    for (int upright = 1; col - upright > -1 || row + upright < 8; upright++)
                        if (!IsFigureAtPos(col - upright, row + upright))
                            value.Add(new int[2] { col - upright, row + upright });
                        else if (!IsAllyFigure(col - upright, row + upright))
                        {
                            value.Add(new int[2] { col - upright, row + upright });
                            break;
                        }
                    for (int downright = 1; col + downright < 8 || row + downright < 8; downright++)
                        if (!IsFigureAtPos(col + downright, row + downright))
                            value.Add(new int[2] { col + downright, row + downright });
                        else if (!IsAllyFigure(col + downright, row + downright))
                        {
                            value.Add(new int[2] { col + downright, row + downright });
                            break;
                        }
                    for (int downleft = 1; col + downleft < 8 || row - downleft > -1; downleft++)
                        if (!IsFigureAtPos(col + downleft, row - downleft))
                            value.Add(new int[2] { col + downleft, row - downleft });
                        else if (!IsAllyFigure(col + downleft, row - downleft))
                        {
                            value.Add(new int[2] { col + downleft, row - downleft });
                            break;
                        }
                    for (int downleft = 1; col - downleft > -1 || row - downleft > -1; downleft++)
                        if (!IsFigureAtPos(col - downleft, row - downleft))
                            value.Add(new int[2] { col - downleft, row - downleft });
                        else if (!IsAllyFigure(col - downleft, row - downleft))
                        {
                            value.Add(new int[2] { col - downleft, row - downleft });
                            break;
                        }
                    break;


                case FigureType.King:
                    if (!IsFigureAtPos(col, row + 1) || !IsAllyFigure(col, row + 1))
                        value.Add(new int[2] { col, row + 1 });
                    if (!IsFigureAtPos(col, row - 1) || !IsAllyFigure(col, row - 1))
                        value.Add(new int[2] { col, row - 1 });
                    if (!IsFigureAtPos(col + 1, row) || !IsAllyFigure(col + 1, row))
                        value.Add(new int[2] { col + 1, row });
                    if (!IsFigureAtPos(col - 1, row) || !IsAllyFigure(col - 1, row))
                        value.Add(new int[2] { col - 1, row });

                    if (!IsFigureAtPos(col + 1, row + 1) || !IsAllyFigure(col + 1, row + 1))
                        value.Add(new int[2] { col + 1, row + 1 });
                    if (!IsFigureAtPos(col + 1, row - 1) || !IsAllyFigure(col + 1, row - 1))
                        value.Add(new int[2] { col + 1, row - 1 });
                    if (!IsFigureAtPos(col - 1, row + 1) || !IsAllyFigure(col - 1, row + 1))
                        value.Add(new int[2] { col - 1, row + 1 });
                    if (!IsFigureAtPos(col - 1, row - 1) || !IsAllyFigure(col - 1, row - 1))
                        value.Add(new int[2] { col - 1, row - 1 });


                    if (!figureList[GetFigureListIndexFromPos(col, row)].moved)
                    {
                        for (int colCounter = col + 1; colCounter < 8; colCounter++)
                        {
                            if (IsFigureAtPos(colCounter, row))
                            {
                                if (GetFigureType(colCounter, row) == FigureType.Rook && IsAllyFigure(colCounter, row) && !figureList[GetFigureListIndexFromPos(colCounter, row)].moved)
                                {
                                    possibleMoves.Add(new int[2] { col + 2, row });
                                }
                                break;
                            }
                        }
                        for (int colCounter = col - 1; colCounter > -1; colCounter--)
                        {
                            if (IsFigureAtPos(colCounter, row))
                            {
                                if (GetFigureType(colCounter, row) == FigureType.Rook && IsAllyFigure(colCounter, row) && !figureList[GetFigureListIndexFromPos(colCounter, row)].moved)
                                {
                                    possibleMoves.Add(new int[2] { col - 2, row });
                                }
                                break;
                            }
                        }
                    }
                    break;
            }
            return value;
        }

        public bool IsPossibleMove(int col, int row, bool boolValue = false)
        {
            for (int times = 0; times < possibleMoves.Count; times++)
                if (possibleMoves[times][0] == col && possibleMoves[times][1] == row)
                    boolValue = true;
            return boolValue;
        }

        public bool IsAllyFigure(int col, int row)
        {
            return whoseMove == GetFigureColor(col, row);
        }

        public bool IsFigureAtPos(int col, int row)
        {
            return GetFigureListIndexFromPos(col, row) != -1;
        }

        FigureColor GetFigureColor(int col, int row)
        {
            return figureList[GetFigureListIndexFromPos(col, row)].Color;
        }

        FigureType GetFigureType(int col, int row)
        {
            return figureList[GetFigureListIndexFromPos(col, row)].Type;
        }

        public System.Windows.Forms.TableLayoutPanelCellPosition GetTableLayoutPanelCellPositionFromIndex(int indexNumber)
        {
            return new System.Windows.Forms.TableLayoutPanelCellPosition(figureList[indexNumber].PosX, figureList[indexNumber].PosY);
        }

        public bool IsIdOnChessBoard(int idNumber)
        {
            for (int times = 0; times < figureList.Count; times++)
            {
                if (figureList[times].id == idNumber)
                    return true;
            }
            return false;
        }

        public int GetFigureListIndexFromPos(int col, int row)
        {
            for (int times = 0; times < figureList.Count; times++)
            {
                if (figureList[times].PosX == col && figureList[times].PosY == row)
                    return times;
            }
            return -1;
        }
    }
}
