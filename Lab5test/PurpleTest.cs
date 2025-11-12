using System.Transactions;

namespace Lab5test
{
    [TestClass]
    public sealed class PurpleTest
    {
        Lab5.Purple _main = new Lab5.Purple();
        const double E = 0.0001;
        Data _data = new Data();

        [TestMethod]
        public void Test01()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][] {
                new int[] { 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 0 },
                new int[] { 1, 1, 1, 1, 2, 1, 2 },
                new int[] { 0, 1, 2 },
                new int[] { 1, 1, 1, 1, 1, 0 },
                new int[] { 3, 3, 4, 3, 5, 3, 2 },
                new int[] { 3, 4, 7, 4, 7, 3, 3 },
                new int[] { 2, 3, 4, 3, 4 }
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
                    {-6, 5, 7, 11},
                    {-5, -1, 4, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {-9, 5, 6, 7, 8, 10, 11},
                    {-15, 9, 10, -11, -12, -13, -14},
                    {-19, -13, -14, 15, 16, 17, 18},
                },
                new int[,] {
                    {1, 2, 3},
                    {-17, 5, 11},
                    {-3, 0, -2},
                },
                new int[,] {
                    {-15, -9, -10, -11, -14, 6},
                },
                new int[,] {
                    {-7, 1, 2, 3, 4, -5, -6},
                    {-17, 5, 11, 11, -10, 6, 5},
                    {-16, -9, -10, -11, -14, -15, 1},
                    {-15, -9, -10, -11, -14, -6, -2},
                    {-15, -9, -10, -11, -14, 6, 4},
                },
                new int[,] {
                    {-7, 1, 2, 3, 4, -5, -6},
                    {-17, 5, 11, 11, -10, 6, 5},
                    {-16, -9, -10, -11, -14, -15, 1},
                    {-14, -9, -10, -11, 15, -6, -2},
                    {-15, -9, -10, -11, -14, 6, 4},
                    {-17, 5, 11, 11, -10, 6, -5},
                    {-4, 1, 1, -2, 3, 0, 0},
                    {-5, 0, -2, -3, -4, 0, 5},
                },
                new int[,] {
                    {-5, 1, 2, 3, 4},
                    {-17, 5, 11, 11, 7},
                    {-15, -9, -10, -11, -14},
                    {-14, -9, -10, -11, -6},
                    {-5, 0, -2, -3, -4},
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
                    {1, 2, 3, 4, 5, 6, 7, 7},
                    {5, 6, 7, 8, 9, 10, 11, 11},
                    {9, 10, 11, 12, 13, 14, 15, 15},
                    {13, 14, 15, 16, 17, 18, 19, 19},
                    {0, 1, 2, 3, 4, 5, 6, 6},
                },
                new int[,] {
                    {1, 1},
                    {5, 5},
                    {9, 9},
                    {13, 13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 6},
                    {5, 6, 7, 8, 9, 11, 11},
                    {0, 2, 3, 4, 5, 6, 6},
                },
                new int[,] {
                    {1, 2, 4, 6, 6},
                    {5, -6, 7, 11, 11},
                    {-1, 4, -5, 6, 6},
                    {1, 4, 5, 6, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7, 7},
                    {5, 6, 7, 8, -9, 10, 11, 11},
                    {9, 10, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, 18, -19},
                },
                new int[,] {
                    {1, 2, 3, 3},
                    {5, 11, 11, -17},
                    {0, 0, -2, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 4, -5, -6, -7},
                    {5, 11, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1, 1},
                    {-9, -10, -11, -14, -15, -6, -2, -2},
                    {-9, -10, -11, -14, -15, 6, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, 4, -5, -6, -7},
                    {5, 11, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1, 1},
                    {-9, -10, -11, -14, 15, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 6, 4},
                    {5, 11, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5, 5},
                },
                new int[,] {
                    {1, 2, 3, 4, 4, -5},
                    {5, 11, 11, -17, 11, 7},
                    {-9, -9, -10, -11, -14, -15},
                    {-9, -10, -11, -14, -6, -6},
                    {0, 0, -2, -3, -4, -5},
                }
            };
            var test = new int[answer.Length][,];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task3(input[i]);
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
                    {1, 2, 3},
                    {5, 11, -17},
                    {0, -2, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {4, 4, 4, 4, 4, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {4, 4, 4, 4, 4, 6, 4},
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
            var inputk = new int[10] { 1, 2, 3, 4, 5, 0, 1, 3, 5, 7 };
            var answer = new int[][,] {
                new int[,] {
                    {1, 6, 3, 4, 5, 6, 7},
                    {5, 19, 7, 8, 9, 10, 11},
                    {9, 15, 11, 12, 13, 14, 15},
                    {13, 11, 15, 16, 17, 18, 19},
                    {0, 7, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 6, 5, 6},
                    {5, 6, 7, 11, 9, 11},
                    {0, 2, 3, 6, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 6},
                    {5, -6, 7, 11},
                    {-1, 4, -5, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 18, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, 11, -15},
                    {-13, -14, 15, 16, 17, 7, -19},
                },
                new int[,] {
                    {0, 2, 3},
                    {11, 11, -17},
                    {3, -2, -3},
                },
                new int[,] {
                    {-9, 6, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 6, -5, -6, -7},
                    {5, 11, -17, -2, -10, 6, 5},
                    {-9, -10, -11, 1, -15, -16, 1},
                    {-9, -10, -11, 11, -15, -6, -2},
                    {-9, -10, -11, 4, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, 5, -7},
                    {5, 11, -17, 11, -10, 3, 5},
                    {-9, -10, -11, -14, -15, 11, 1},
                    {-9, -10, -11, -14, 15, 6, -2},
                    {-9, -10, -11, -14, -15, 15, 4},
                    {5, 11, -17, 11, -10, 1, -5},
                    {1, 1, -2, 3, -4, 11, 0},
                    {0, -2, -3, -4, -5, 4, 5},
                },
                new int[,] {
                    {1, 2, 3, 4, -5},
                    {5, 11, -17, 11, 7},
                    {-9, -10, -11, -14, -15},
                    {-9, -10, -11, -14, -6},
                    {0, -2, -3, -4, -5},
                }
            };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task5(input[i], inputk[i]);
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
        public void Test06()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var inputArray = new int[][] {
                new int[] { 12, 13, 5, 6, 4 },
                new int[] { 5, 9, 4, 6, 0 },
                new int[] { 5, 9, 7, 4, 6, 10 },
                new int[] { 9, 3, 7, 4, 6 },
                new int[] { 12, 5, 6, 3, 4 },
                new int[] { 12, 11, 3, 4, 9 },
                new int[] { 12, 11, 3, 4, 9 },
                new int[] { 0, 2, 4, 6, 8 },
                new int[] { 12, 11, 3, 4, 9 },
                new int[] { 12, 11, 3, 4, 9 }
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
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 9, 7, 8, 9, 11},
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
                    {1, 2, 3},
                    {5, 11, -17},
                    {0, -2, -3},
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
                    {12, 11, -17, 11, 9},
                    {-9, -10, -11, -14, -15},
                    {-9, -10, -11, -14, -6},
                    {0, -2, -3, -4, -5},
                }
            };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task6(input[i], inputArray[i]);
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
            var answer = new int[][,] {
                new int[,] {
                    {13, 14, 15, 16, 17, 18, 19},
                    {9, 10, 11, 12, 13, 14, 15},
                    {5, 6, 7, 8, 9, 10, 11},
                    {1, 2, 3, 4, 5, 6, 7},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {13},
                    {9},
                    {5},
                    {1},
                },
                new int[,] {
                    {5, 6, 7, 8, 9, 11},
                    {1, 2, 3, 4, 5, 6},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 6},
                    {1, 4, 5, 6},
                    {-1, 4, -5, 6},
                    {5, -6, 7, 11},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {1, 2, 3},
                    {0, -2, -3},
                    {5, 11, -17},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {5, 11, -17, 11, -10, 6, 5},
                },
                new int[,] {
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                    {1, 2, 3, 4, -5, -6, -7},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {5, 11, -17, 11, -10, 6, 5},
                    {5, 11, -17, 11, -10, 6, -5},
                }
                };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task7(input[i]);
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
        public void Test08()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][] {
                null,
                null,
                null,
                new int[] { 1, 3, 14, -4, 15, 15, 6 },
                null,
                new int[] { 0, 3, 9, -15, 3 },
                null,
                null,
                null,
                new int[] { 0, -11, -22, -20, -18, -35, -1, 11, -5 }
                };
            var test = new int[answer.Length][];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task8(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == null)
                {
                    Assert.IsNull(test[i]);
                    continue;
                }
                Assert.AreEqual(answer[i].Length, test[i].Length);
                for (int j = 0; j < answer[i].Length; j++)
                {
                    Assert.AreEqual(answer[i][j], test[i][j]);
                }
            }
        }
        [TestMethod]
        public void Test09()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var inputk = new int[10] { 1, 2, 3, 1, 2, 0, 1, 3, 1, 2 };
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
                    {1, 6, 2, 4},
                    {5, 11, -6, 7},
                    {-1, 6, 4, -5},
                    {1, 6, 4, 5},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {-17, 5, 11},
                    {3, 1, 2},
                    {-3, 0, -2},
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
                    {-9, -10, -11, -14, -15},
                    {5, 11, -17, 11, 7},
                    {-9, -10, -11, -14, -6},
                    {0, -2, -3, -4, -5},
                }
            };
            var test = new int[answer.Length][];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task9(input[i], inputk[i]);
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
            var answer = new int[][,] {
                null,
                null,
                null,
                new int[,] {
                    {-31, -30, 63, 68, 37, 78, -145},
                    {-105, -110, 61, 64, 175, 70, -345},
                    {-104, -112, 170, 184, 126, 212, -2},
                    {-12, -8, 66, 72, 6, 84, -138},
                },
                null,
                null,
                null,
                null,
                null,
                new int[,] {
                    {90, 95, 100, 105, 110, 115, 120},
                    {50, 67, 84, 101, 118, 135, 152},
                    {-340, -399, -458, -517, -576, -635, -694},
                    {-340, -390, -440, -490, -540, -590, -640},
                    {-89, -103, -117, -131, -145, -159, -173},
                }
                };
            var test = new int[answer.Length][,];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task10(input[i], input[(i + 1) % input.Length]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == null)
                {
                    Assert.IsNull(test[i]);
                    continue;
                }
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
        public void Test11()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][][] {
                new int[][] {
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int[] { 5, 6, 7, 8, 9, 10, 11 },
                new int[] { 9, 10, 11, 12, 13, 14, 15 },
                new int[] { 13, 14, 15, 16, 17, 18, 19 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                },
                new int[][] {
                new int[] { 1 },
                new int[] { 5 },
                new int[] { 9 },
                new int[] { 13 },
                },
                new int[][] {
                new int[] { 1, 2, 3, 4, 5, 6 },
                new int[] { 5, 6, 7, 8, 9, 11 },
                new int[] { 2, 3, 4, 5, 6 },
                },
                new int[][] {
                new int[] { 1, 2, 4, 6 },
                new int[] { 5, 7, 11 },
                new int[] { 4, 6 },
                new int[] { 1, 4, 5, 6 },
                },
                new int[][] {
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int[] { 5, 6, 7, 8, 10, 11 },
                new int[] { 9, 10 },
                new int[] { 15, 16, 17, 18 },
                }
            };
            var test = new int[answer.Length][][];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task11(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].Length, test[i].Length);
                for (int j = 0; j < answer[i].Length; j++)
                {
                    Assert.AreEqual(answer[i][j].Length, test[i][j].Length);
                    for (int k = 0; k < answer[i][j].Length; k++)
                    {
                        Assert.AreEqual(answer[i][j][k], test[i][j][k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test12()
        {
            // Arrange
            var input = _data.GetArrayArrays();
            var answer = new int[][,] {
                new int[,] {
                    {2, 1, 3, 3, 5, 6, 3, 4, 5},
                    {2, 8, 1, 9, 3, 7, 4, 6, 0},
                    {5, 2, 8, 1, 9, 0, 7, 4, 6},
                    {10, 5, 2, -8, 1, 9, 3, 7, 4},
                    {6, 12, 1, 3, 3, 5, 6, 3, 4},
                    {2, 1, 3, 4, -2, -1, -3, -4, 5},
                    {0, 0, 0, 0, 0, 1, 1, 1, -5},
                    {-2, -8, -1, -9, -3, -7, -4, -6, -2},
                    {0, 2, 4, 6, 8, 0, 0, 0, 0},
                },
                new int[,] {
                    {2, 1, 3, 3, 5, 5, 2, 8},
                    {1, 9, 5, 2, 8, 1, 9, 5},
                    {2, -8, 1, 9, 12, 1, 3, 0},
                    {5, 2, 1, 3, 4, 5, -2, -1},
                    {-3, -4, -5, 0, 0, 0, 0, 0},
                    {-5, 2, -8, 1, -9, 0, 2, 4},
                    {6, 8, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0},
                },
                new int[,] {
                    {-2, 1, 3},
                    {3, 0, 5},
                    {-6, 3, 4},
                },
                new int[,] {
                    {2, -2},
                    {5, 0},
                },
                new int[,] {
                    {2, 1, 3, 3, 5, 6, 3, 4},
                    {5, 2, 8, 1, 9, 3, 7, 4},
                    {6, 0, 5, 2, 8, 1, 9, 0},
                    {7, 4, 6, 10, 5, 2, -8, 1},
                    {9, 3, 7, 4, 6, 12, 1, 3},
                    {3, 5, 6, 3, 4, -5, -2, -8},
                    {-1, -9, -3, -7, -4, -6, -2, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0},
                }
                };
            var test = new int[answer.Length][,];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task12(input[i]);
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
    }
}
