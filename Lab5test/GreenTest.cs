using System.Transactions;

namespace Lab5test
{
    [TestClass]
    public sealed class GreenTest
    {
        Lab5.Green _main = new Lab5.Green();
        const double E = 0.0001;
        Data _data = new Data();

        [TestMethod]
        public void Test01()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][] {
                new int[] { 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 0 },
                new int[] { 0, 1, 2, 0 },
                new int[] { 0, 4, 6, 6 },
                new int[] { 0, 2, 2 },
                new int[] { 4 },
                new int[] { 6, 2, 5, 4, 4 },
                new int[] { 6, 2, 5, 3, 4, 2, 4, 4 },
                new int[] { 4, 2, 4, 3, 4 },
                };
            var test = new int[answer.Length][];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task1(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].Length, test[i].Length);
                for (int j = 0; j < answer[i].Length; j++)
                {
                    Assert.AreEqual(answer[i][j], test[i][j]);
                }
            }
        }
        [TestMethod]
        public void Test02()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 6},
                    {5, -1, 7, 11},
                    {-1, 4, -1, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -1, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-1, -1, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {1, 2, 3},
                    {5, 11, -17},
                    {0, -2, -3},
                },
                new int[,] {
                    {-2, -2, -2, -3, -3, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {4, 5, 5, 7, 7, 3, -2},
                    {-2, -2, -2, -3, -3, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-1, -1, -1, -1, 15, -6, -2},
                    {-2, -2, -2, -3, -3, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -1, 3, -4, 0, 0},
                    {0, -1, -1, -1, -1, 0, 5},
                },
                new int[,] {
                    {1, 2, 3, 4, -5},
                    {5, 11, -17, 11, 7},
                    {-9, -10, -11, -14, -15},
                    {1, 1, 1, 2, -6},
                    {0, -2, -3, -4, -5},
                }
            };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task2(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test03()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var inputk = new int[10] { 1, 2, 3, 4, 5, 0, 1, 3, 5, 7 };
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 6},
                    {5, -6, 7, 11},
                    {-1, 4, -5, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {2, 1, 3},
                    {11, 5, -17},
                    {-2, 0, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                },
                new int[,] {
                    {1, 2, 3, 4, -5},
                    {5, 11, -17, 11, 7},
                    {-9, -10, -11, -14, -15},
                    {-9, -10, -11, -14, -6},
                    {0, -2, -3, -4, -5},
                }
            };
            var test = new int[answer.Length][,];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task3(input[i], inputk[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test04()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 1},
                    {5, -6, 7, 4},
                    {-1, 4, -5, 5},
                    {6, 11, 6, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {1, 5, 3},
                    {2, 11, -2},
                    {0, -17, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                },
                new int[,] {
                    {1, 5, 3, 4, -5},
                    {2, 11, -10, -10, -2},
                    {-9, -17, -11, -14, -15},
                    {-9, 11, -11, -14, -6},
                    {0, 7, -3, -4, -5},
                }
            };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task4(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test05()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 6},
                    {-1, 4, -5, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                },
                new int[,] {
                    {1, 2, 3},
                    {0, -2, -3},
                },
                new int[,] {
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                },
                new int[,] {
                    {1, 2, 3, 4, -5},
                    {-9, -10, -11, -14, -15},
                    {-9, -10, -11, -14, -6},
                    {0, -2, -3, -4, -5},
                }
            };
            var test = new int[answer.Length][,];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task5(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), test[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), test[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], test[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test06()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {-1, 4, -5, 6},
                    {5, -6, 7, 11},
                    {1, 2, 4, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {9, 10, -11, -12, -13, -14, -15},
                    {5, 6, 7, 8, -9, 10, 11},
                    {1, 2, 3, 4, 5, 6, 7},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {0, -2, -3},
                    {5, 11, -17},
                    {1, 2, 3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15},
                    {5, 11, -17, 11, 7},
                    {1, 2, 3, 4, -5},
                    {-9, -10, -11, -14, -6},
                    {0, -2, -3, -4, -5},
                }
            };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task6(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test07()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var inputArray = new int[][] {
                new int[] { -6, -6, -1, -5 },
                new int[] { -6, -6, -1, -5 },
                new int[] { -6, -6, -1, -5 },
                new int[] { -6, -6, -1, -5 },
                new int[] { -9, -11, -12, -13, -14, -15, -13, -14, -19 },
                new int[] { -17, -2, -3 },
                new int[] { -9, -10, -11, -14, -15 },
                new int[] { -5, -6, -7, -17, -10, -9, -10, -11, -14, -15, -16, -9, -10, -11, -14, -15, -6, -2, -9, -10, -11, -14, -15 },
                new int[] { -5 },
                new int[] { -5 }
                };
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, -6},
                    {5, -6},
                    {9, -1},
                    {13, -5},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, -6, 4, 6},
                    {5, -6, -6, 7, 11},
                    {-1, 4, -1, -5, 6},
                    {1, 4, -5, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {1, 2, 3, -17},
                    {5, 11, -17, -2},
                    {0, -2, -3, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                }
                };
            var test = new int[answer.Length][,];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task7(input[i], inputArray[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), test[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), test[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], test[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test08()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {0, 0, 0, 0, 0, 0, 0},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {0},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {0, 0, 0, 0, 0, 0},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 6},
                    {0, -6, 0, 0},
                    {-1, 0, -5, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {0, 0, -11, -12, -13, -14, -15},
                    {-13, -14, 0, 0, 17, 0, -19},
                },
                new int[,] {
                    {1, 2, 0},
                    {0, 0, -17},
                    {0, -2, -3},
                },
                new int[,] {
                    {0, 0, 0, 0, 0, 0},
                },
                new int[,] {
                    {1, 2, 0, 4, 0, -6, -7},
                    {1, 1, -17, 1, -10, 1, 0},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 0, 4, -5, -6, -7},
                    {0, 11, -17, 11, -10, 6, 0},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 3, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                }
            };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task8(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test09()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {0, 0, 0, 0},
                    {0, -6, 7, 0},
                    {0, 4, -5, 0},
                    {0, 0, 0, 0},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {0, 0, 0},
                    {0, 11, 0},
                    {0, 0, 0},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                },
                new int[,] {
                    {0, 0, 0, 0, 0},
                    {0, 11, -17, 11, 0},
                    {0, -10, -11, -14, 0},
                    {0, -10, -11, -14, 0},
                    {0, 0, 0, 0, 0},
                }
                };
            var test = new int[answer.Length][,];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task9(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test10()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new (int[], int[])[] {
                (null, null),
                (null, null),
                (null, null),
                (new int[] { 1, 2, 4, 6, -6, 7, 11, -5, 6, 6 }, new int[] { 5, -1, 4, 1, 4, 5 }),
                (null, null),
                (new int[] { 1, 2, 3, 11, -17, -3 }, new int[] { 5, 0, -2 }),
                (null, null),
                (null, null),
                (null, null),
                (new int[] { 1, 2, 3, 4, -5, 11, -17, 11, 7, -11, -14, -15, -14, -6, -5 }, new int[] { 5, -9, -10, -9, -10, -11, 0, -2, -3, -4 })
            };
            var test = new (int[], int[])[answer.Length];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task10(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i].Item1 == null)
                {
                    Assert.IsNull(test[i].Item1);
                    Assert.IsNull(test[i].Item2);
                    continue;
                }
                Assert.AreEqual(answer[i].Item1.Length, test[i].Item1.Length);
                for (int j = 0; j < answer[i].Item1.Length; j++)
                {
                        Assert.AreEqual(answer[i].Item1[j], test[i].Item1[j]);
                }
                Assert.AreEqual(answer[i].Item2.Length, test[i].Item2.Length);
                for (int j = 0; j < answer[i].Item2.Length; j++)
                {
                    Assert.AreEqual(answer[i].Item2[j], test[i].Item2[j]);
                }
            }
        }
        [TestMethod]
        public void Test11()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {13, 1, 15, 3, 17, 5, 19},
                    {9, 2, 11, 4, 13, 6, 15},
                    {5, 6, 7, 8, 9, 10, 11},
                    {1, 10, 3, 12, 5, 14, 7},
                    {0, 14, 2, 16, 4, 18, 6},
                },
                new int[,] {
                    {13},
                    {9},
                    {5},
                    {1},
                },
                new int[,] {
                    {5, 2, 7, 4, 9, 6},
                    {1, 2, 3, 4, 5, 6},
                    {0, 6, 3, 8, 5, 11},
                },
                new int[,] {
                    {5, -6, 7, 6},
                    {1, 2, 5, 6},
                    {1, 4, 4, 6},
                    {-1, 4, -5, 11},
                },
                new int[,] {
                    {9, -14, 15, -12, 17, -14, 11},
                    {5, 2, 7, 4, 5, 6, 7},
                    {1, 6, 3, 8, -9, 10, -15},
                    {-13, 10, -11, 16, -13, 18, -19},
                },
                new int[,] {
                    {5, -2, 3},
                    {1, 2, -3},
                    {0, 11, -17},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {5, -10, 3, -14, -5, -16, 5},
                    {1, -10, -11, -14, -10, -6, 4},
                    {-9, -10, -11, -14, -15, -6, 1},
                    {-9, 2, -11, 4, -15, 6, -2},
                    {-9, 11, -17, 11, -15, 6, -7},
                },
                new int[,] {
                    {5, -10, 3, -14, 15, -16, 5},
                    {5, -10, -2, -14, -4, -6, 5},
                    {1, -10, -3, -14, -5, -6, 4},
                    {1, -2, -11, -4, -5, 0, 1},
                    {0, 1, -11, 3, -10, 0, 0},
                    {-9, 2, -11, 4, -10, 6, -2},
                    {-9, 11, -17, 11, -15, 6, -5},
                    {-9, 11, -17, 11, -15, 6, -7},
                },
                new int[,] {
                    {5, -10, 3, -14, 7},
                    {1, -10, -3, -14, -5},
                    {0, -2, -11, -4, -5},
                    {-9, 2, -11, 4, -6},
                    {-9, 11, -17, 11, -15},
                }
            };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task11(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test12()
        {
            // Arrange
            var input = _data.GetArrayArrays();
            var answer = new int[][][] {
                new int[][] {
                new int[] { 5, 2, 8, 1, 9, 0, 7, 4, 6, 10 },
                new int[] { 5, 2, 8, 1, 9, 3, 7, 4, 6, 0 },
                new int[] { -5, -2, -8, -1, -9, -3, -7, -4, -6, -2 },
                new int[] { 5, 2, -8, 1, 9, 3, 7, 4, 6 },
                new int[] { 12, 1, 3, 3, 5, 6, 3, 4 },
                new int[] { 2, 1, 3, 3, 5, 6, 3, 4 },
                new int[] { 0, 2, 4, 6, 8 },
                new int[] { 0, 0, 0, 0, 0 },
                new int[] { 2, 1, 3, 4 },
                new int[] { -2, -1, -3, -4 },
                new int[] { 1, 1, 1 },
                new int[] { 5 },
                },
                new int[][] {
                new int[] { 5, 2, 8, 1, 9 },
                new int[] { 5, 2, 8, 1, 9 },
                new int[] { 12, 1, 3, 0, 5 },
                new int[] { 0, 2, 4, 6, 8 },
                new int[] { 2, 1, 3, 4, 5 },
                new int[] { 2, 1, 3, 3, 5 },
                new int[] { 5, 2, -8, 1, 9 },
                new int[] { 0, 0, 0, 0, 0 },
                new int[] { -2, -1, -3, -4, -5 },
                new int[] { -5, 2, -8, 1, -9 },
                },
                new int[][] {
                new int[] { -2, 1, 3, 3, 0, 5, -6, 3, 4 },
                },
                new int[][] {
                new int[] { 5 },
                new int[] { 2 },
                new int[] { 0 },
                new int[] { -2 },
                },
                new int[][] {
                new int[] { 5, 2, 8, 1, 9, 0, 7, 4, 6, 10 },
                new int[] { 5, 2, 8, 1, 9, 3, 7, 4, 6, 0 },
                new int[] { -5, -2, -8, -1, -9, -3, -7, -4, -6, -2 },
                new int[] { 5, 2, -8, 1, 9, 3, 7, 4, 6 },
                new int[] { 12, 1, 3, 3, 5, 6, 3, 4 },
                new int[] { 2, 1, 3, 3, 5, 6, 3, 4 },
                }
            };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task12(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].Length, input[i].Length);
                for (int j = 0; j < answer[i].Length; j++)
                {
                    Assert.AreEqual(answer[i][j].Length, input[i][j].Length);
                    for (int k = 0; k < answer[i][j].Length; k++)
                    {
                        Assert.AreEqual(answer[i][j][k], input[i][j][k]);
                    }
                }
            }
        }
    }
}
