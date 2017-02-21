using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : TravelingPieces
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
            var actualAvailableMoves = new List<Square>();
            var direction = GetDirection();
            var potentialAvailableMoves = AvailableSquares(currentPosition, direction, board).Take(2).ToList();
            if (IsFirstMoveValid(potentialAvailableMoves, board))
            {
                actualAvailableMoves.Add(potentialAvailableMoves[0]);
                if (IsSecondMoveValid(potentialAvailableMoves, board))
                {
                    actualAvailableMoves.Add(potentialAvailableMoves[1]);
                }
            }
            return actualAvailableMoves;
        }

        private Direction GetDirection()
        {
            var direction = ThisPiecesPlayer == Player.Black ? new Direction(1, 0) : new Direction(-1, 0);
            return direction;
        }

        private bool IsFirstMoveValid(List<Square> potentialSquares, Board board)
        {
            return potentialSquares.Count > 0 && board.GetPiece(potentialSquares[0]) == null;
        }

        private bool IsSecondMoveValid(List<Square> potentialSquares, Board board)
        {
            return !HasMoved && potentialSquares.Count > 1 && board.GetPiece(potentialSquares[1]) == null;
        }
    }
}