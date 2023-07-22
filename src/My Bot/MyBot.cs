/**

MyBot (class)
Type	Definition	Notes
Move	Think(Board board, Timer timer)	This is the function you need to implement for this challenge.
Board (class)
Type	Definition	Notes
void	MakeMove(Move move)	Updates the board state with the given move. The move is assumed to be legal, and may result in errors if it is not. Can be undone with the UndoMove() method
void	UndoMove(Move move)	Undo a move that was made with the MakeMove method. Moves must be undone in reverse order, so for example, if moves A, B, C are made, they must be undone in the order C, B, A
bool	TrySkipTurn()	Try skip the current turn. This will fail and return false if the player is currently in check. Note that skipping a turn is not allowed during an actual game, but can be used as a search technique.
void	UndoSkipTurn()	Undo a turn that was succesfully skipped with TrySkipTurn()
Move[]	GetLegalMoves(bool capturesOnly)	Gets an array of the legal moves in the current position. Can choose to get only capture moves with the optional 'capturesOnly' parameter.
bool	IsInCheck()	
bool	IsInCheckmate()	
bool	IsDraw()	Test if the current position is a draw due stalemate, repetition, insufficient material, or 50-move rule.
bool	HasKingsideCastleRight(bool white)	Does the given player still have the right to castle kingside? Note that having the right to castle doesn't necessarily mean castling is legal right now (for example, a piece might be in the way, or player might be in check, etc).
bool	HasQueensideCastleRight(bool white)	Does the given player still have the right to castle queenside? Note that having the right to castle doesn't necessarily mean castling is legal right now (for example, a piece might be in the way, or player might be in check, etc).
bool	SquareIsAttackedByOpponent(Square square)	Is the given square attacked by the opponent? (opponent being whichever player doesn't currently have the right to move).
Square	GetKingSquare(bool white)	Gets the square that the king (of the given colour) is currently on.
Piece	GetPiece(Square square)	Gets the piece on the given square. If the square is empty, the piece will have a PieceType of None.
PieceList	GetPieceList(PieceType type, bool white)	Gets a list of pieces of the given type and colour
PieceList[]	GetAllPieceLists()	Gets an array of all the piece lists. In order these are: Pawns(white), Knights (white), Bishops (white), Rooks (white), Queens (white), King (white), Pawns (black), Knights (black), Bishops (black), Rooks (black), Queens (black), King (black).
string	GetFenString()	FEN representation of the current position.
ulong	GetPieceBitboard(PieceType type, bool white)	64-bit number where each bit set to 1 represents a square that contains a piece of the given type/colour.
ulong	WhitePiecesBitboard	64-bit number where each bit set to 1 represents a square that contains a white piece.
ulong	BlackPiecesBitboard	64-bit number where each bit set to 1 represents a square that contains a black piece.
ulong	AllPiecesBitboard	64-bit number where each bit set to 1 represents a square that contains a piece.
bool	IsWhiteToMove	
int	PlyCount	Number of ply (a single move by either white or black) played so far.
ulong	ZobristKey	64-bit hash of the current position.
Board	Board.CreateBoardFromFEN(string fen)	Creates a board from the given fen string. Please note that this is quite slow, and so it is advised to use the board given in the Think function, and update it using MakeMove and UndoMove instead.
Move (struct)
Type	Definition	Notes
Move	new Move(string name, Board board)	Constructor for creating a move from its name (in UCI format). For example, to move from the square b1 to c3, the move string would be "b1c3". If the move is a pawn promotion, the promotion type must be added to the end: 'q' = queen, 'r' = rook, 'n' = knight, 'b' = bishop. So an example move would be "e7e8q". You'll typically want to get legal moves from the board, rather than creating them yourself.
Square	StartSquare	The square that this move is moving the piece from.
Square	TargetSquare	The square that this move is moving the piece to.
PieceType	MovePieceType	The type of piece that is being moved.
PieceType	CapturePieceType	If this is a capture move, the type of piece that is being captured.
PieceType	PromotionPieceType	If this is a pawn promotion, the type of piece that the pawn is being promoted to.
bool	IsCapture	
bool	IsEnPassant	
bool	IsPromotion	
bool	IsCastles	
bool	IsNull	
bool	Equals(Move otherMove)	Tests if two moves are the same. This is true if they move to/from the same square, and move/capture/promote the same piece type.
Move	Move.NullMove	Represents a null/invalid move, which can be used as a placeholder until a valid move has been found.
Square (struct)
Type	Definition	Notes
Square	new Square(string name)	Constructor for creating a square from its algebraic name (e.g. "e4")
int	File	Value from 0 to 7 representing files 'a' to 'h'
int	Rank	Value from 0 to 7 representing ranks '1' to '8'
int	Index	Value from 0 to 63. The values map to the board like so:
0 – 7 : a1 – h1
8 – 15 : a2 – h2
...

56 – 63 : a8 – h8
string	Name	The algebraic name of the square, e.g. "e4"
Piece (struct)
Type	Definition	Notes
Piece	new Piece(PieceType type, bool isWhite, Square square)	Constructor for creating a new piece. You'll typically want to get pieces from the board, rather than constructing them yourself.
bool	IsWhite	
PieceType	PieceType	
Square	Square	The square that the piece is on. Note: this value will not be updated if the piece is moved (it is a snapshot of the state of the piece when it was looked up).
bool	IsPawn	
bool	IsKnight	
bool	IsBishop	
bool	IsRook	
bool	IsQueen	
bool	IsKing	
bool	IsNull	This will be true if the piece was retrieved from an empty square on the board
PieceType (enum)
None = 0, Pawn = 1, Knight = 2, Bishop = 3, Rook = 4, Queen = 5, King = 6
PieceList (class)
Type	Definition	Notes
int	Count	The number of pieces in the list
bool	IsWhitePieceList	True if the pieces in this list are white, false if they are black
PieceType	TypeOfPieceInList	The type of piece stored in this list (a PieceList always contains only one type and colour of piece)
Piece	GetPiece(int index)	Get the i-th piece in the list.
Timer (class)
Type	Definition	Notes
int	MillisecondsRemaining	Amount of time left on clock for current player (in milliseconds)
int	MillisecondsElapsedThisTurn	Amount of time elapsed since current player started thinking (in milliseconds)
BitboardHelper (static class)
Type	Definition	Notes
void	SetSquare(ref ulong bitboard, Square square)	Set the given square on the bitboard to 1.
void	ClearSquare(ref ulong bitboard, Square square)	Clear the given square on the bitboard to 0.
void	ToggleSquare(ref ulong bitboard, Square square)	Toggle the given square on the bitboard between 0 and 1.
bool	SquareIsSet(ulong bitboard, Square square)	Returns true if the given square is set to 1 on the bitboard, otherwise false.
int	ClearAndGetIndexOfLSB(ref ulong bitboard)	Returns index of the first bit that is set to 1. The bit will also be cleared to zero. This can be useful for iterating over all the set squares in a bitboard
int	GetNumberOfSetBits(ulong bitboard)	Returns the number of bits that set to 1 in the given bitboard.
ulong	GetSliderAttacks(PieceType type, Square square, Board board)	Gets a bitboard where each bit that is set to 1 represents a square that the given sliding piece type is able to attack. These attacks are calculated from the given square, and take the given board state into account (so attacks will be blocked by pieces that are in the way). Valid only for sliding piece types (queen, rook, and bishop).
ulong	GetSliderAttacks(PieceType type, Square square, ulong blockers)	Gets a bitboard where each bit that is set to 1 represents a square that the given sliding piece type is able to attack. These attacks are calculated from the given square, and take the given blocker bitboard into account (so attacks will be blocked by pieces that are in the way). Valid only for sliding piece types (queen, rook, and bishop).
ulong	GetKnightAttacks(Square square)	Gets a bitboard of squares that a knight can attack from the given square.
ulong	GetKingAttacks(Square square)	Gets a bitboard of squares that a king can attack from the given square.
ulong	GetPawnAttacks(Square square, bool isWhite)	Gets a bitboard of squares that a pawn (of the given colour) can attack from the given square.
**/


using ChessChallenge.API;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

public class MyBot : IChessBot
{

    Random rng = new Random();

    public Move Think(Board board, Timer timer)
    {
        Move move = CalculateMove(board, 2, board.IsWhiteToMove);
        CurrentEvaluation(board);
        return move;
    }

    // Minimax algorithm
    public Move CalculateMove(Board board_, int depth, bool isWhite)
    {
        var possible_moves_ = board_.GetLegalMoves();
        Move bestMove = possible_moves_[rng.Next(possible_moves_.Length - 1)];


        if (depth == 0)
        {
            return bestMove;
        }

        if (isWhite)
        {
            float maxEval = -1000000.0f;
            for (int j = 0; j < possible_moves_.Length; j++)
            {
                board_.MakeMove(possible_moves_[j]);
                float eval = CurrentEvaluation(board_);
                CalculateMove(board_, depth - 1, false);
                if (eval > maxEval)
                {
                    maxEval = eval;
                    bestMove = possible_moves_[j];
                }
                board_.UndoMove(possible_moves_[j]);
            }

            return bestMove;
        }

        else
        {
            float minEval = 1000000.0f;
            for (int j = 0; j < possible_moves_.Length; j++)
            {
                board_.MakeMove(possible_moves_[j]);
                float eval = CurrentEvaluation(board_);
                CalculateMove(board_, depth - 1, true);
                if (eval < minEval)
                {
                    minEval = eval;
                    bestMove = possible_moves_[j];
                }
                board_.UndoMove(possible_moves_[j]);
            }
            
            return bestMove;
        }




        /**
        for(int i = 0; i < possible_moves_.Length; i++)
        {
            board_.MakeMove(possible_moves_[i]);
            float eval = CurrentEvaluation(board_);
            Console.WriteLine("Move: " + possible_moves_[i].ToString() + " Eval: " + eval.ToString());
            if(eval < bestEval)
            {
                bestEval = eval;
                bestMove = possible_moves_[i];
            }

            if(board_.IsInCheckmate())
            {
                board_.UndoMove(possible_moves_[i]);
                return possible_moves_[i];
            }

            board_.UndoMove(possible_moves_[i]);
            
        }
        **/
        // return new Move();
    }



    // Evaluation function
    public float CurrentEvaluation(Board board_)
    {
        float eval = 0.0f;

        // Get all the pieces on the board
        int whitePawn = board_.GetPieceList(PieceType.Pawn, true).Count;
        int whiteKnight = board_.GetPieceList(PieceType.Knight, true).Count;
        int whiteBishop = board_.GetPieceList(PieceType.Bishop, true).Count;
        int whiteRook = board_.GetPieceList(PieceType.Rook, true).Count;
        int whiteQueen = board_.GetPieceList(PieceType.Queen, true).Count;
        int whiteKing = board_.GetPieceList(PieceType.King, true).Count;
        int blackPawn = board_.GetPieceList(PieceType.Pawn, false).Count;
        int blackKnight = board_.GetPieceList(PieceType.Knight, false).Count;
        int blackBishop = board_.GetPieceList(PieceType.Bishop, false).Count;
        int blackRook = board_.GetPieceList(PieceType.Rook, false).Count;
        int blackQueen = board_.GetPieceList(PieceType.Queen, false).Count;
        int blackKing = board_.GetPieceList(PieceType.King, false).Count;

        if (board_.IsInCheckmate())
        {
            return -1000000.0f;
        }

        float inCheck = 0.0f;

        if (board_.IsInCheck())
        {
            inCheck = 6.5f;
        }


        // Calculate the evaluation
        eval = 200.0f * (whiteKing - blackKing) +
               9.0f * (whiteQueen - blackQueen) +
               5.0f * (whiteRook - blackRook) +
               3.0f * (whiteBishop - blackBishop) +
               3.0f * (whiteKnight - blackKnight) +
               1.0f * (whitePawn - blackPawn) +
               inCheck;

        // Console.WriteLine("EVALUATION: " + eval);

        return eval;
    }

}