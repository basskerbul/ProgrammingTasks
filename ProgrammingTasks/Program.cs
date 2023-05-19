//Факториалом числа натурального числа n называется произведение чисел от 1 до n включительно. 
//Факториалом нуля называют единицу. Написать программу нахождения факториала данного числа. 
//Реализовать через рекурсию и без рекурсии. Вывести на экран факториалы от десяти первых чисел.


static class Factorial
{
    public static int Factorial1(int n)
    {
        if (n < 0)
            return -1;
        if (n == 0)
            return 1;
        int result = 1;
        for (int i = 1; i <= n; i++)
            result *= i;
        return result;
    }
    public static int Factorial2(int n)
    {
        if (n < 0)
            return -1;
        if (n == 0)
            return 1;
        return n * Factorial2(--n);
    }
}
