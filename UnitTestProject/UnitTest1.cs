using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfChess.ChessModel;
using WpfChess.ChessModel.Figures;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        Field board = new Field();

        [TestMethod]
        public void BoardIsProper()
        {
            bool Rooks = board[0, 0].Figure.GetType() == typeof(RookFigure) && board[0, 7].Figure.GetType() == typeof(RookFigure);
            bool Knights = board[0, 1].Figure.GetType() == typeof(KnightFigure) && board[0, 6].Figure.GetType() == typeof(KnightFigure);
            bool Bishops = board[0, 2].Figure.GetType() == typeof(BishopFigure) && board[0, 5].Figure.GetType() == typeof(BishopFigure);
            bool Queen = board[0, 3].Figure.GetType() == typeof(QueenFigure);
            bool King = board[0, 4].Figure.GetType() == typeof(KingFigure);
            
            Assert.IsTrue(Rooks && Knights && Bishops & Queen && King);
        }

        [TestMethod]
        public void BoardCreation()
        {
            board.Make960();
            Assert.IsTrue(true);
        }
        

        [TestMethod]
        public void TestQueenPlaced()
        {
            bool good = false;
            for (int i = 0; i < 8; i++)
            {
                if (board[0, i].Figure.GetType() == typeof(QueenFigure))
                {
                    good = true;
                    break;
                }
            }
            Assert.IsTrue(good);
        }

        [TestMethod]
        public void TestDuplicateQueen()
        {
            bool good = false;
            for (int i = 0; i < 8; i++)
            {
                if (board[0, i].Figure.GetType() == typeof(QueenFigure))
                {
                    if (!good)
                        good = true;
                    else if (good == true)
                    {
                        good = false;
                        break;
                    }
                }
            }
            Assert.IsTrue(good);
        }

        [TestMethod]
        public void TestBishopPlaced()
        {
            int BishopsFound = 0;
            for (int i = 0; i < 8; i++)
            {
                if (board[0, i].Figure.GetType() == typeof(BishopFigure))
                    BishopsFound++;
            }
            Assert.IsTrue(BishopsFound == 2);
        }
        [TestMethod]
        public void TestRooksPlaced()
        {
            int RooksFound = 0;
            for (int i = 0; i < 8; i++)
            {
                if (board[0, i].Figure.GetType() == typeof(RookFigure))
                    RooksFound++;
            }
            Assert.IsTrue(RooksFound == 2);
        }
        [TestMethod]
        public void TestKnightsPlaced()
        {
            int KnightsFound = 0;
            for (int i = 0; i < 8; i++)
            {
                if (board[0, i].Figure.GetType() == typeof(RookFigure))
                    KnightsFound++;
            }
            Assert.IsTrue(KnightsFound== 2);
        }

        [TestMethod]
        public void TestRookAndKingPlacementRule()
        {
            List<int> Figures = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                if (board[0, i].Figure.GetType() == typeof(RookFigure))
                    Figures.Add(1);
                else if (board[0, i].Figure.GetType() == typeof(KingFigure))
                    Figures.Add(0);
            }

            if(Figures.Count == 3)
            {
                Assert.IsTrue((Figures[0] > Figures[1]) && (Figures[1] < Figures[2]));
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
    }
}
