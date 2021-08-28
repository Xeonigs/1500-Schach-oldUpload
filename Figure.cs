using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1500_Schach
{
    enum FigureType { Pawn, Rook, Bishop, Knight, Queen, King };
    enum FigureColor { White, Black };
    class Figure
    {
        //properties
        public FigureType Type
        { get; set; }
        public FigureColor Color
        { get; }
        public int PosX
        { get; set; }
        public int PosY
        { get; set; }
        public int id
        { get; set; }
        public bool moved
        { get; set; }

        //Constructor
        public Figure(FigureType type, FigureColor color, int positionX, int positionY, int idNumber)
        {
            Type = type;
            Color = color;
            PosX = positionX;
            PosY = positionY;
            id = idNumber;
            moved = false;
        }
    }
}
