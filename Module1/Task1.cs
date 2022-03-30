using System;

namespace Module1;

public class Task1
{
    public int F1 { get; init; }

    public Task1 ChangeF1(int newVal) => new Task1(){ F1 = newVal };
}