using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) : base(player) {}

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        { 
            var currentPosition = board.FindPiece(this);
            var availableMoves = new List<Square>();
            if (Player == Player.Black )
            {
                availableMoves.Add(Square.At(currentPosition.Row + 1, currentPosition.Col));
                if (currentPosition.Row == 1)
                {
                    availableMoves.Add(Square.At(currentPosition.Row + 2, currentPosition.Col));
                }
            }
            else
            {
                availableMoves.Add(Square.At(currentPosition.Row - 1, currentPosition.Col));
                if (currentPosition.Row == 7)
                {
                    availableMoves.Add(Square.At(currentPosition.Row - 2, currentPosition.Col));
                }
            }
            return availableMoves;
        }
    }
}