// Необходимо реализовать метод разворота связного списка (двухсвязного или односвязного на выбор).

TwoWaySet node1 = new TwoWaySet(15, null);
TwoWaySet node2 = new TwoWaySet(34, node1);
TwoWaySet node3 = new TwoWaySet(8, node2);
TwoWaySet node4 = new TwoWaySet(3, node3);
TwoWaySet node5 = new TwoWaySet(19, node4);

TwoWaySet.Print(node1);    // 15, 34, 8, 3, 19
TwoWaySet.Reversal(node1); // 19, 3, 8, 34, 15


class TwoWaySet
{
    int data;
    TwoWaySet? before;
    TwoWaySet? after;

    public TwoWaySet(int data, TwoWaySet? before)
    {
        this.data = data;
        this.before = before;
        after = null;
        if (before != null)
            before.after = this;
    }
    public static void Reversal(TwoWaySet head)
    {
        int count = head.Count(head);
        for (int i = 0; i < count; i++)
        {
            TwoWaySet containerBefore = head.before;
            TwoWaySet containerAfter = head.after;
            
            head.before = containerAfter;
            head.after = containerBefore;

            if(containerAfter == null)
            {
                TwoWaySet.Print(head);
                break;
            }

            head = containerAfter;
        }
    }
    public static void Print(TwoWaySet head)
    {
        int count = head.Count(head);
        for(int i = 0; i < count; i++)
        {
            Console.Write($"{head.data} ");
            head = head.after;
        }
        Console.Write("\n");
    }
    private int Count(TwoWaySet head)
    {
        if (head == null)
            return 0;
        int count = 1;
        while(true)
        {
            if(head.after != null)
                head = head.after;
            else
                break;
            count++;
        }
        return count;
    }
    /// <summary>
    /// Возвращает true, если найдет петлю
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool IsLoop(TwoWaySet head)
    {
        if (head.before == null)
        {
            TwoWaySet[]? links = new TwoWaySet[Count(head) * 2];
            for(int i = 0; i < links.Length;)
            {
                links[i] = head.before;
                links[i + 1] = head.after;
                head = head.after;
                i = i + 2;
            }
            for (int i = 1; i < links.Length - 1;)
            {
                if (i == links.Length - 3)
                    break;
                if (links[i] == links[i + 3])
                    i = i + 2;
                else
                    return true;
            }
            for (int i = 1; i < links.Length - 1; i++)
            {
                if (links[2] == links[i] || links[links.Length - 3] == links[i])
                {
                    if(i == 2 || i == links.Length - 3)
                        continue;
                    return true;
                }
            }
        }
        else
            throw new Exception("Метод требует первый элемент списка");
        return false;
    }
}
