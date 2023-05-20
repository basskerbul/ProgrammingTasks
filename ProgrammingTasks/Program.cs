//Последовательность 0,1,1,2,3,5,8,... состоит из чисел Фибоначчи. 
//Каждый элемент, начиная с третьего, равен сумме двух предыдущих. Найдите n-е число Фибоначчи. 
//Реализовать вариант с рекурсией и вариант без рекурсии. Вывести на экран n строк из символов "*". 

static class Fibonacci
{
    public static int Method1(int n)
    {
        if (n == 0)
            return 0;
        int[] numbers = new int[n];
        numbers[0] = 0;
        numbers[1] = 1;
        for (int i = 2; i < n; i++)
            numbers[i] = numbers[i-1] + numbers[i-2];
        return numbers[--n];
    }
    public static int Method2(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        int result = Method2(n - 1) + Method2(n - 2);
        return result;
    }
    public static void Method3(int n)
    {
        if (n == 0)
            Console.WriteLine("-");
        else
        {
            string[] icons = new string[n];
            icons[0] = "*"; icons[1] = "*";
            for (int i = 2; i < n; i++)
            {
                int strLeng = icons[i - 1].Length + icons[i - 2].Length;
                for (int j = 0; j < strLeng; j++)
                    icons[i] += "*";
            }
            for (int i = 0; i < n; i++)
                Console.WriteLine(icons[i]);
        }
    }
}