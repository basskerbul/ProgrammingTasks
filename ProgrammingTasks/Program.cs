//Реализуйте метод для выполнения простейшего сжатия строк с использованием
//счетчика повторяющихся символов. Например, строка ааbсссссааа превращается в
//а2b1с5а3. Если сжатая строка не становится короче исходной, то метод возвращает
//исходную строку. Предполагается, что строка состоит только из букв верхнего
//и нижнего регистра (a-z).

string vs1 = "ааbсссссааа";
Console.WriteLine(vs1);
string vs2 = CompressionString.GetString(vs1);
Console.WriteLine(vs2);

vs1 = "aaaRRRRRrrrrdddddeo";
Console.WriteLine(vs1);
vs2 = CompressionString.GetString(vs1);
Console.WriteLine(vs2); 

static class CompressionString
{
    static public string GetString(string text)
    {
        int count = 1;
        string result = "";
        for(int i = 0; i < text.Length; i++)
        {
            if ((i + 1) >= text.Length )
                result += $"{text[i]}{count}";
            else if (text[i] == text[i + 1])
                count++;
            else
            {
                result += $"{text[i]}{count}";
                count = 1;
            }
        }
        return result;
    }
}
