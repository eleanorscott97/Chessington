using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player thisPiecesPlayer) : base(thisPiecesPlayer) {}
        public bool HasMoved;

        public override void MoveTo(Board board, Square newSquare)
        {
            base.MoveTo(board, newSquare);
            HasMoved = true;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        { 
            var currentPosition = board.FindPiece(this);
            var potentialAvailableMoves = new List<Square>();
            var actualAvailableMoves = new List<Square>();
            var direction = GetDirection();
            var oneSquare = currentPosition + direction;
            var twoSquare = oneSquare + direction;

            potentialAvailableMoves.AddRange(AvailableSquares(currentPosition, direction));
            if (board.GetPiece(oneSquare) != null) return actualAvailableMoves;
            actualAvailableMoves.Add(potentialAvailableMoves[0]);
            if (!HasMoved && board.GetPiece(twoSquare) == null)
            {
                actualAvailableMoves.Add(potentialAvailableMoves[1]);
            }
            return actualAvailableMoves;
        }

        private Direction GetDirection()
        {
            var direction = ThisPiecesPlayer == Player.Black ? new Direction(1, 0) : new Direction(-1, 0);
            return direction;
        }
    }
}