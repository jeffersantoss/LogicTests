// See https://aka.ms/new-console-template for more information

//5
//4
//2 1 3 2 4
//2 0 2 0 1
//6 2 1 3 0
//3 1 0 4 3

using LogicTests.Questions;

List<List<int>> forest = new()
{
    new () { 2, 1, 3, 2, 4},
    new () { 2, 0, 2, 0, 1},
    new () { 6, 2, 1, 3, 0},
    new () { 3, 1, 0, 4, 3},
};

// Sould return 12
Console.WriteLine($"The busy beaver collected {BusyBeaver.LogsCalculate(forest)} logs.");