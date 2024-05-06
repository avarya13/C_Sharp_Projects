using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class Dice
    {
        public int FirstCube { get; set; }

        public int SecondCube { get; set; }

        public bool RolledDouble { get; set; }

        private static Random rand = new Random();

        public void RollDice()
        {
            FirstCube = rand.Next(1, 7);
            SecondCube = rand.Next(1, 7);

            if (FirstCube == SecondCube)
            {
                RolledDouble = true;
            }
            else
            {
                RolledDouble = false;
            }
        }

        public void ResetFirstCube()
        {
            FirstCube = 0;
        }

        public void ResetSecondCube()
        {
            SecondCube = 0;
        }
    }
    public class Bar
    {
        public int NumOfRedCheckers { get; set; }

        public int NumOfBlackCheckers { get; set; }

        public void AddRedCheckerToBar()
        {
            NumOfRedCheckers++;
        }

        public void AddBlackCheckerToBar()
        {
            NumOfBlackCheckers++;
        }

        public void RemoveRedCheckerFromBar()
        {
            NumOfRedCheckers--;
        }

        public void RemoveBlackCheckerFromBar()
        {
            NumOfBlackCheckers--;
        }
    }
    public enum CheckerColor
    {
        Red,
        Black
    }
    public class Triangle
    {
        public int NumOfCheckers { get; set; }

        public CheckerColor? CheckersColor { get; set; }

        public Triangle()
        {

        }

        public Triangle(int numOfCheckers, CheckerColor color)
        {
            NumOfCheckers = numOfCheckers;
            CheckersColor = color;
        }
    }
    public class Board
    {
        public List<Triangle> Triangles { get; set; }

        public Bar GameBar { get; set; }

        public Board()
        {
            Triangles = new List<Triangle>(new Triangle[24]);
            GameBar = new Bar();

            InitializeBoard();
        }

        public void AddCheckerToTriangle(int triangleNumber, CheckerColor checkerColor)
        {
            if (checkerColor != Triangles[triangleNumber].CheckersColor)
            {
                Triangles[triangleNumber].NumOfCheckers++;
            }
        }

        public void RemoveCheckerFromTriangle(int triangleNumber, CheckerColor checkerColor)
        {
            if (checkerColor != Triangles[triangleNumber].CheckersColor)
            {
                Triangles[triangleNumber].NumOfCheckers--;
            }
        }

        private void InitializeBoard()  // Player1 = Red. zero-based index.
        {
            for (int i = 0; i < 24; i++)
            {
                switch (i)
                {
                    case 0:
                        Triangles[i] = new Triangle(2, CheckerColor.Red);
                        break;

                    case 5:
                        Triangles[i] = new Triangle(5, CheckerColor.Black);
                        break;

                    case 7:
                        Triangles[i] = new Triangle(3, CheckerColor.Black);
                        break;

                    case 11:
                        Triangles[i] = new Triangle(5, CheckerColor.Red);
                        break;

                    case 12:
                        Triangles[i] = new Triangle(5, CheckerColor.Black);
                        break;

                    case 16:
                        Triangles[i] = new Triangle(3, CheckerColor.Red);
                        break;

                    case 18:
                        Triangles[i] = new Triangle(5, CheckerColor.Red);
                        break;

                    case 23:
                        Triangles[i] = new Triangle(2, CheckerColor.Black);
                        break;

                    default:
                        Triangles[i] = new Triangle();
                        break;
                }
            }
        }
    }
    public abstract class Player
    {
        public bool IsMyTurn { get; set; }

        public int CheckersAtHome { get; set; }

        public CheckerColor PlayerColor { get; private set; }

        public string Name { get; private set; }

        public Player(string name, CheckerColor color)
        {
            Name = name;
            PlayerColor = color;
        }

        public bool HasAvailableMoves(Board gameBoard, Dice gameDice)
        {
            return GetAvailableMoves(gameBoard, gameDice).ToList().Count + GetAvailableMovesEat(gameBoard, gameDice).ToList().Count > 0 ? true : false;
        }

        public bool HasAvailableBearOffMoves(Board gameBoard, Dice gameDice)
        {
            return GetAvailableBearOffMoves(gameBoard, gameDice).ToList().Count > 0 ? true : false;
        }

        public abstract IEnumerable<KeyValuePair<int, int>> GetAvailableMoves(Board gameBoard, Dice gameDice);

        public abstract IEnumerable<KeyValuePair<int, int>> GetAvailableMovesFromBar(Board gameBoard, Dice gameDice);

        public abstract IEnumerable<KeyValuePair<int, int>> GetAvailableMovesEat(Board gameBoard, Dice gameDice);

        public abstract IEnumerable<KeyValuePair<int, int>> GetAvailableMovesEatFromBar(Board gameBoard, Dice gameDice);

        public abstract IEnumerable<KeyValuePair<int, int>> GetAvailableBearOffMoves(Board gameBoard, Dice gameDice);

        public abstract bool IsLegalPlayerInitialMove(Board gameBoard, int index);

        public abstract bool IsLegalPlayerFinalMove(Board gameBoard, int fromIndex, int toIndex, int cubeNumber);

        public abstract bool IsLegalPlayerFinalMoveEat(Board gameBoard, int fromIndex, int toIndex, int cubeNumber);

        public abstract bool IsLegalPlayerBearOffMove(int fromIndex, int cubeNumber);

        public abstract bool CanBearOffCheckers(Board gameBoard);

        public abstract void UpdateCheckersAtHome(Board gameBoard);
    }
    class Program
    {
        
        public class RedPlayer : Player
        {
            public RedPlayer(string name, CheckerColor playerColor) : base(name, playerColor)
            {

            }

            public override IEnumerable<KeyValuePair<int, int>> GetAvailableMoves(Board gameBoard, Dice gameDice)
            {
                if (gameBoard.GameBar.NumOfRedCheckers == 0)  // if he's stuck on the bar, no point counting his normal moves
                {
                    List<KeyValuePair<int, int>> AvailableMoves = new List<KeyValuePair<int, int>>();

                    for (int i = 0; i < gameBoard.Triangles.Count; i++)
                    {
                        if (!gameDice.RolledDouble)  // not double. if double - only check once (next if)
                        {
                            //if (i + gameDice.FirstCube <= 23 && gameDice.FirstCube != 0)
                            if (i + gameDice.FirstCube <= 23 && gameDice.FirstCube != 0)  // don't step out of array boundries, check if cube was not 'reset' to 0
                            {
                                //if (IsLegalPlayerInitialMove(gameBoard, i) && IsLegalPlayerFinalMove(gameBoard, i, i + 1, 1))
                                if (IsLegalPlayerInitialMove(gameBoard, i) && IsLegalPlayerFinalMove(gameBoard, i, i + gameDice.FirstCube, gameDice.FirstCube))
                                {
                                    //AvailableMoves.Add(new KeyValuePair<int, int>(i, i + 1));
                                    AvailableMoves.Add(new KeyValuePair<int, int>(i, i + gameDice.FirstCube));
                                }
                            }
                        }


                        //if (i + 1 <= 23 && gameDice.SecondCube != 0)
                        if (i + gameDice.SecondCube <= 23 && gameDice.SecondCube != 0)  // don't step out of array boundries, check if cube was not 'reset' to 0)
                        {
                            // 2nd cube can also be an available 'move' (if he hasn't rolled double)
                            //if (IsLegalPlayerInitialMove(gameBoard, i) && IsLegalPlayerFinalMove(gameBoard, i, i + 1, 1))
                            if (IsLegalPlayerInitialMove(gameBoard, i) && IsLegalPlayerFinalMove(gameBoard, i, i + gameDice.SecondCube, gameDice.SecondCube))
                            {
                                //AvailableMoves.Add(new KeyValuePair<int, int>(i, i + 1));
                                AvailableMoves.Add(new KeyValuePair<int, int>(i, i + gameDice.SecondCube));
                            }
                        }
                    }

                    return AvailableMoves;
                }
                else
                {
                    return GetAvailableMovesFromBar(gameBoard, gameDice);
                }
            }

            public override IEnumerable<KeyValuePair<int, int>> GetAvailableMovesFromBar(Board gameBoard, Dice gameDice)
            {
                List<KeyValuePair<int, int>> AvailableMoves = new List<KeyValuePair<int, int>>();

                if (gameDice.FirstCube != 0)  // check if that cube wasn't reset
                {
                    if (IsLegalPlayerFinalMove(gameBoard, -1, -1 + gameDice.FirstCube, gameDice.FirstCube))
                    {
                        AvailableMoves.Add(new KeyValuePair<int, int>(-1, -1 + gameDice.FirstCube));
                    }
                }

                if (gameDice.SecondCube != 0)
                {
                    if (IsLegalPlayerFinalMove(gameBoard, -1, -1 + gameDice.SecondCube, gameDice.SecondCube))
                    {
                        AvailableMoves.Add(new KeyValuePair<int, int>(-1, -1 + gameDice.SecondCube));
                    }
                }

                return AvailableMoves;
            }

            public override IEnumerable<KeyValuePair<int, int>> GetAvailableMovesEat(Board gameBoard, Dice gameDice)
            {
                if (gameBoard.GameBar.NumOfRedCheckers == 0)  // if he's stuck on the bar, no point counting his normal moves
                {
                    List<KeyValuePair<int, int>> AvailableMovesEat = new List<KeyValuePair<int, int>>();

                    for (int i = 0; i < gameBoard.Triangles.Count; i++)
                    {
                        if (!gameDice.RolledDouble)  // not double. if double - only check once (next if)
                        {
                            if (i + gameDice.FirstCube <= 23 && gameDice.FirstCube != 0)  // don't step out of array boundries, check if cube was not 'reset' to 0
                            {
                                if (IsLegalPlayerInitialMove(gameBoard, i) && IsLegalPlayerFinalMoveEat(gameBoard, i, i + gameDice.FirstCube, gameDice.FirstCube))
                                {
                                    AvailableMovesEat.Add(new KeyValuePair<int, int>(i, i + gameDice.FirstCube));
                                }
                            }
                        }

                        if (i + gameDice.SecondCube <= 23 && gameDice.SecondCube != 0)  // don't step out of array boundries, check if cube was not 'reset' to 0
                        {
                            // 2nd cube can also be an available 'eat move'
                            if (IsLegalPlayerInitialMove(gameBoard, i) && IsLegalPlayerFinalMoveEat(gameBoard, i, i + gameDice.SecondCube, gameDice.SecondCube))
                            {
                                AvailableMovesEat.Add(new KeyValuePair<int, int>(i, i + gameDice.SecondCube));
                            }
                        }
                    }

                    return AvailableMovesEat;
                }
                else
                {
                    return GetAvailableMovesEatFromBar(gameBoard, gameDice);
                }
            }

            public override IEnumerable<KeyValuePair<int, int>> GetAvailableMovesEatFromBar(Board gameBoard, Dice gameDice)
            {
                List<KeyValuePair<int, int>> AvailableMoves = new List<KeyValuePair<int, int>>();

                if (gameDice.FirstCube != 0)  // check if that cube wasn't reset
                {
                    if (IsLegalPlayerFinalMoveEat(gameBoard, -1, -1 + gameDice.FirstCube, gameDice.FirstCube))
                    {
                        AvailableMoves.Add(new KeyValuePair<int, int>(-1, -1 + gameDice.FirstCube));
                    }
                }
                if (gameDice.SecondCube != 0)  // check if that cube wasn't reset
                {
                    if (IsLegalPlayerFinalMoveEat(gameBoard, -1, -1 + gameDice.SecondCube, gameDice.SecondCube))
                    {
                        AvailableMoves.Add(new KeyValuePair<int, int>(-1, -1 + gameDice.SecondCube));
                    }
                }

                return AvailableMoves;
            }

            public override IEnumerable<KeyValuePair<int, int>> GetAvailableBearOffMoves(Board gameBoard, Dice gameDice)
            {
                List<KeyValuePair<int, int>> AvailableMoves = new List<KeyValuePair<int, int>>();

                for (int i = 18; i <= 23; i++)
                {
                    if (!gameDice.RolledDouble)  // not double. if double - only check once (next if)
                    {
                        if (gameDice.FirstCube != 0)  // check if cube was not 'reset' to 0
                        {
                            if (IsLegalPlayerInitialMove(gameBoard, i) && IsLegalPlayerBearOffMove(i, gameDice.FirstCube))
                            {
                                AvailableMoves.Add(new KeyValuePair<int, int>(i, gameDice.FirstCube));
                            }
                        }
                    }

                    if (gameDice.SecondCube != 0)  // check if cube was not 'reset' to 0
                    {
                        // 2nd cube can also be an available 'move' (if he hasn't rolled double)
                        if (IsLegalPlayerInitialMove(gameBoard, i) && IsLegalPlayerBearOffMove(i, gameDice.SecondCube))
                        {
                            AvailableMoves.Add(new KeyValuePair<int, int>(i, gameDice.SecondCube));
                        }
                    }
                }

                return AvailableMoves;
            }

            public override bool IsLegalPlayerInitialMove(Board gameBoard, int index)
            {
                if (gameBoard.Triangles[index].CheckersColor == CheckerColor.Red && gameBoard.GameBar.NumOfRedCheckers == 0)
                {
                    return true;
                }

                return false;
            }

            public override bool IsLegalPlayerFinalMove(Board gameBoard, int fromIndex, int toIndex, int cubeNumber) // check if came from bar? -1...
            {
                if (toIndex - fromIndex == cubeNumber)
                {
                    if (gameBoard.Triangles[toIndex].CheckersColor == null || gameBoard.Triangles[toIndex].CheckersColor == CheckerColor.Red)  // 2nd condition ?
                    {
                        return true;
                    }
                }

                return false;
            }

            public override bool IsLegalPlayerFinalMoveEat(Board gameBoard, int fromIndex, int toIndex, int cubeNumber) // check if came from bar? -1...
            {
                if (toIndex - fromIndex == cubeNumber)
                {
                    if (gameBoard.Triangles[toIndex].CheckersColor == CheckerColor.Black && gameBoard.Triangles[toIndex].NumOfCheckers == 1)
                    {
                        return true;
                    }
                }

                return false;
            }

            public override bool IsLegalPlayerBearOffMove(int fromIndex, int cubeNumber)
            {
                if (fromIndex + cubeNumber >= 24)
                {
                    return true;
                }

                return false;
            }

            public override bool CanBearOffCheckers(Board gameBoard)
            {
                int NumOfCheckersOutsideHome = gameBoard.GameBar.NumOfRedCheckers;

                for (int i = 0; i <= 17; i++)
                {
                    if (gameBoard.Triangles[i].CheckersColor == CheckerColor.Red)
                    {
                        NumOfCheckersOutsideHome += gameBoard.Triangles[i].NumOfCheckers;
                    }
                }

                if (NumOfCheckersOutsideHome > 0)
                {
                    return false;
                }

                return true;
            }

            public override void UpdateCheckersAtHome(Board gameBoard)
            {
                CheckersAtHome = 0;

                for (int i = 18; i <= 23; i++)
                {
                    if (gameBoard.Triangles[i].CheckersColor == CheckerColor.Red)
                    {
                        CheckersAtHome += gameBoard.Triangles[i].NumOfCheckers;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Dice dice1 = new Dice();
            Board board1 = new Board();
            Board board2 = new Board();
            RedPlayer red = new RedPlayer("Red Player", CheckerColor.Red);
            //board1.GameBar.AddRedCheckerToBar();
            board1.GameBar.NumOfRedCheckers = 1;
            dice1.FirstCube = 1;
            dice1.SecondCube = 1;
            Dice dice2 = new Dice();
            dice2.FirstCube = 0;
            dice2.SecondCube = 0;
            IEnumerable<KeyValuePair<int, int>> a = red.GetAvailableMoves(board2, dice2);
            foreach (var i in a)
                Console.WriteLine(i.ToString() + ' ');
            Console.WriteLine(a);
            Console.ReadKey();
            
        }
    }
}
