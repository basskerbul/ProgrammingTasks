//Напишите функцию, которая переставляет значения переменных без использования временных переменных.

int x = 5;
int y = 2;

Console.WriteLine($"x: {x}\ny: {y}\n"); // x = 5, y = 2
Replacement.Method(ref x, ref y);
Console.WriteLine($"x: {x}\ny: {y}\n"); // x = 2, y = 5

static class Replacement
{
    public static void Method(ref int a, ref int b)
    {
        a += b;
        b = a - b;
        a -= b;
    }
}