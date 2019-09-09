using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player thisPiecesPlayer)
            : base(thisPiecesPlayer) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            var availableMoves = new List<Square>();
            availableMoves.Add(currentPosition + new Direction(-1, 2));
            availableMoves.AddRange(AvailableSquares(currentPosition, ));
            var totalMoves = availableMoves.Take(1);
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-2, 1)));
            totalMoves = 
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-2, -1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(-1, -2)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, -2)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(+2, -1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(2, 1)));
            availableMoves.AddRange(AvailableSquares(currentPosition, new Direction(1, 2)));

            return availableMoves;
        }

    }
}