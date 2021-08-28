using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Bauern schlag nachfügen
 * Darstellung (welche Objekte wo ohne, dass sie sich vermischen wegen dem Index)
*/

namespace _1500_Schach
{
    public partial class Form1 : Form
    {
        ChessSystem chessSystem = new ChessSystem();
        public List<PictureBox> picBoxList = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int times = 0; times < 32; times++)
            {
                picBoxList.Add(AddPictureBox());
                ChessBoard.Controls.Add(picBoxList[times], chessSystem.figureList[times].PosX, chessSystem.figureList[times].PosY);
                switch (chessSystem.figureList[times].Type)
                {
                    case FigureType.Pawn:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whitePawn);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackPawn);
                        break;
                    case FigureType.Rook:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whiteRook);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackRook);
                        break;
                    case FigureType.Bishop:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whiteBishop);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackBishop);
                        break;
                    case FigureType.Knight:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whiteKnight);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackKnight);
                        break;
                    case FigureType.Queen:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whiteQueen);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackQueen);
                        break;
                    case FigureType.King:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whiteKing);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackKing);
                        break;
                }
            }
        }

        private void ChessBoard_Click(object sender, EventArgs e)
        {
            var cursorPos = GetRowColIndex(ChessBoard, ChessBoard.PointToClient(Cursor.Position));

            // Ist eine Figur auf dem angeklickten Feld?
            if (chessSystem.IsFigureAtPos(cursorPos[0], cursorPos[1])) // Es ist eine Figur auf dem Feld
            {
                // Ist es deine Figur?
                // Es ist meine Figur
                if (chessSystem.IsAllyFigure(cursorPos[0], cursorPos[1])) // Ist es ein Verbündeter
                {
                    chessSystem.posOfSelectedFigure = new int[] { cursorPos[0], cursorPos[1] };
                    chessSystem.possibleMoves.AddRange(chessSystem.SelectFigure(cursorPos[0], cursorPos[1]));
                }
                // Es ist eine gegnerische Figur
                else if (chessSystem.IsPossibleMove(cursorPos[0], cursorPos[1])) // Ist dies ein möglicher Zug
                {
                    ChessBoard.Controls.Remove(picBoxList[chessSystem.GetFigureListIndexFromPos(cursorPos[0], cursorPos[1])]);
                    picBoxList.Remove(picBoxList[chessSystem.GetFigureListIndexFromPos(cursorPos[0], cursorPos[1])]);
                    chessSystem.BeatFigure(cursorPos[0], cursorPos[1], chessSystem.GetFigureListIndexFromPos(chessSystem.posOfSelectedFigure[0], chessSystem.posOfSelectedFigure[1]));
                }
            }
            else // Es ist keine Figur auf dem Feld
            {
                if (chessSystem.IsPossibleMove(cursorPos[0], cursorPos[1])) // Ist dies ein möglicher Zug
                {
                    // Führt den Zug aus
                    chessSystem.MoveFigure(cursorPos[0], cursorPos[1], chessSystem.GetFigureListIndexFromPos(chessSystem.posOfSelectedFigure[0], chessSystem.posOfSelectedFigure[1]));
                }
                chessSystem.possibleMoves.Clear();
            }

            if (!chessSystem.figureList.Exists(x => x.Type == FigureType.King && x.Color == FigureColor.White))
            {
                MessageBox.Show("Color black has won!");
                RestartChess();
            }
            else if (!chessSystem.figureList.Exists(x => x.Type == FigureType.King && x.Color == FigureColor.Black))
            {
                MessageBox.Show("Color white has won!");
                RestartChess();
            }


            for (int times = 0; times < chessSystem.figureList.Count; times++)
            {
                if (chessSystem.figureList[times].Type == FigureType.Pawn && ((chessSystem.figureList[times].Color == FigureColor.White && chessSystem.figureList[times].PosY == 7) || (chessSystem.figureList[times].Color == FigureColor.Black && chessSystem.figureList[times].PosY == 0)))
                {
                    ChessBoard.Enabled = false;
                    changePawnTo_Title.Visible = true;
                    pawnChangeToBishop.Visible = true;
                    pawnChangeToKnight.Visible = true;
                    pawnChangeToQueen.Visible = true;
                    pawnChangeToRook.Visible = true;

                    if (chessSystem.figureList[times].Color == FigureColor.White)
                    {
                        pawnChangeToBishop.BackgroundImage = Properties.Resources.whiteBishop;
                        pawnChangeToKnight.BackgroundImage = Properties.Resources.whiteKnight;
                        pawnChangeToQueen.BackgroundImage = Properties.Resources.whiteQueen;
                        pawnChangeToRook.BackgroundImage = Properties.Resources.whiteRook;
                    }
                    else if (chessSystem.figureList[times].Color == FigureColor.Black)
                    {
                        pawnChangeToBishop.BackgroundImage = Properties.Resources.blackBishop;
                        pawnChangeToKnight.BackgroundImage = Properties.Resources.blackKnight;
                        pawnChangeToQueen.BackgroundImage = Properties.Resources.blackQueen;
                        pawnChangeToRook.BackgroundImage = Properties.Resources.blackRook;
                    }
                }
            }


            RefreshChessBoard();
        }

        private void ChessBoard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if ((e.Column + e.Row) % 2 == 1)
                e.Graphics.FillRectangle(Brushes.SaddleBrown, e.CellBounds);
            else
                e.Graphics.FillRectangle(Brushes.Beige, e.CellBounds);
        }

        int[] GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Height || point.Y > tlp.Width)
                return null;

            int w = tlp.Height;
            int h = tlp.Width;
            int[] heights = tlp.GetRowHeights();

            int i;
            for (i = heights.Length - 1; i >= 0 && point.X < w; i--)
                w -= heights[i];
            int col = i + 1;

            int[] widths = tlp.GetColumnWidths();
            for (i = widths.Length - 1; i >= 0 && point.Y < h; i--)
                h -= widths[i];

            int row = i + 1;

            return new int[2] { col, row };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chessSystem.whoseMove = FigureColor.Black;
        }

        PictureBox AddPictureBox()
        {
            PictureBox picBox = new PictureBox();
            picBox.BackColor = Color.Transparent;
            picBox.Dock = DockStyle.Fill;
            picBox.BackgroundImageLayout = ImageLayout.Zoom;
            picBox.Enabled = false;
            return picBox;
        }

        void RefreshChessBoard()
        {
            ChessBoard.SuspendLayout();

            for (int times = 0; times < picBoxList.Count; times++)
            {
                switch (chessSystem.figureList[times].Type)
                {
                    case FigureType.Pawn:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whitePawn);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackPawn);
                        break;
                    case FigureType.Rook:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whiteRook);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackRook);
                        break;
                    case FigureType.Bishop:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whiteBishop);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackBishop);
                        break;
                    case FigureType.Knight:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whiteKnight);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackKnight);
                        break;
                    case FigureType.Queen:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whiteQueen);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackQueen);
                        break;
                    case FigureType.King:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.whiteKing);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(Properties.Resources.blackKing);
                        break;
                }
                ChessBoard.SetCellPosition(picBoxList[times], chessSystem.GetTableLayoutPanelCellPositionFromIndex(times));
            }

            ChessBoard.ResumeLayout();
        }

        void RestartChess()
        {
            chessSystem = new ChessSystem();
            picBoxList.Clear();
            ChessBoard.Controls.Clear();

            for (int times = 0; times < 32; times++)
            {
                picBoxList.Add(AddPictureBox());
                ChessBoard.Controls.Add(picBoxList[times], chessSystem.figureList[times].PosX, chessSystem.figureList[times].PosY);
                switch (chessSystem.figureList[times].Type)
                {
                    case FigureType.Pawn:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.whitePawn);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.blackPawn);
                        break;
                    case FigureType.Rook:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.whiteRook);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.blackRook);
                        break;
                    case FigureType.Bishop:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.whiteBishop);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.blackBishop);
                        break;
                    case FigureType.Knight:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.whiteKnight);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.blackKnight);
                        break;
                    case FigureType.Queen:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.whiteQueen);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.blackQueen);
                        break;
                    case FigureType.King:
                        if (chessSystem.figureList[times].Color == FigureColor.White)
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.whiteKing);
                        else
                            picBoxList[times].BackgroundImage = new Bitmap(_1500_Schach.Properties.Resources.blackKing);
                        break;
                }
            }
        }

        private void pawnChangeToQueen_Click(object sender, EventArgs e)
        {
            for (int times = 0; times < chessSystem.figureList.Count; times++)
            {
                if (chessSystem.figureList[times].Type == FigureType.Pawn && ((chessSystem.figureList[times].Color == FigureColor.White && chessSystem.figureList[times].PosY == 7) || (chessSystem.figureList[times].Color == FigureColor.Black && chessSystem.figureList[times].PosY == 0)))
                {
                    chessSystem.figureList[times].Type = FigureType.Queen;
                    ChessBoard.Enabled = true;
                    changePawnTo_Title.Visible = false;
                    pawnChangeToBishop.Visible = false;
                    pawnChangeToKnight.Visible = false;
                    pawnChangeToQueen.Visible = false;
                    pawnChangeToRook.Visible = false;
                }
            }
            RefreshChessBoard();
        }

        private void pawnChangeToRook_Click(object sender, EventArgs e)
        {
            for (int times = 0; times < chessSystem.figureList.Count; times++)
            {
                if (chessSystem.figureList[times].Type == FigureType.Pawn && ((chessSystem.figureList[times].Color == FigureColor.White && chessSystem.figureList[times].PosY == 7) || (chessSystem.figureList[times].Color == FigureColor.Black && chessSystem.figureList[times].PosY == 0)))
                {
                    chessSystem.figureList[times].Type = FigureType.Rook;
                    ChessBoard.Enabled = true;
                    changePawnTo_Title.Visible = false;
                    pawnChangeToBishop.Visible = false;
                    pawnChangeToKnight.Visible = false;
                    pawnChangeToQueen.Visible = false;
                    pawnChangeToRook.Visible = false;
                }
            }
            RefreshChessBoard();
        }

        private void pawnChangeToBishop_Click(object sender, EventArgs e)
        {
            for (int times = 0; times < chessSystem.figureList.Count; times++)
            {
                if (chessSystem.figureList[times].Type == FigureType.Pawn && ((chessSystem.figureList[times].Color == FigureColor.White && chessSystem.figureList[times].PosY == 7) || (chessSystem.figureList[times].Color == FigureColor.Black && chessSystem.figureList[times].PosY == 0)))
                {
                    chessSystem.figureList[times].Type = FigureType.Bishop;
                    ChessBoard.Enabled = true;
                    changePawnTo_Title.Visible = false;
                    pawnChangeToBishop.Visible = false;
                    pawnChangeToKnight.Visible = false;
                    pawnChangeToQueen.Visible = false;
                    pawnChangeToRook.Visible = false;
                }
            }
            RefreshChessBoard();
        }

        private void pawnChangeToKnight_Click(object sender, EventArgs e)
        {
            for (int times = 0; times < chessSystem.figureList.Count; times++)
            {
                if (chessSystem.figureList[times].Type == FigureType.Pawn && ((chessSystem.figureList[times].Color == FigureColor.White && chessSystem.figureList[times].PosY == 7) || (chessSystem.figureList[times].Color == FigureColor.Black && chessSystem.figureList[times].PosY == 0)))
                {
                    chessSystem.figureList[times].Type = FigureType.Knight;
                    ChessBoard.Enabled = true;
                    changePawnTo_Title.Visible = false;
                    pawnChangeToBishop.Visible = false;
                    pawnChangeToKnight.Visible = false;
                    pawnChangeToQueen.Visible = false;
                    pawnChangeToRook.Visible = false;
                }
            }
            RefreshChessBoard();
        }
    }
}
