//Реализовать алгоритм пирамидальной сортировки (сортировка кучей).

int[] vs = new int[] { 32, 15, 1, 47, 6, 98, 7 };
ArrayMod.Print(vs); // 32, 15, 1, 47, 6, 98, 7
vs = HeapSort.Sort(vs);
ArrayMod.Print(vs); // 1, 6, 7, 15, 32, 47, 98

public static class HeapSort
{
    public static int[] Sort(int[] datas)
    {
        Heap heap = new Heap(datas[0]);
        for(int i = 1; i < datas.Length; i++)
            heap.Add(datas[i]);
        int[] result = {};
        while (!heap.Empty())
        {
            result = ArrayMod.Push(result, heap.Top());
            heap.Erase();
        }
        return result;
    }
}

public class Heap
{
    int[] heap = new int[] {0};

    public Heap(int data)
    {
        Add(data);
    }
    /// <summary>
    /// Добавляет в кучу новое значение
    /// </summary>
    /// <param name="data"></param>
    public void Add(int data)
    {
        heap = ArrayMod.Push(heap, data);
        int index = heap.Length - 1;
        while (index != 1 && heap[index] < heap[index / 2])
        {
            heap = ArrayMod.Swap(heap, index, index / 2);
            index /= 2;
        }
    }
    /// <summary>
    /// Удаляет верхушку кучи
    /// </summary>
    public void Erase()
    {
        heap = ArrayMod.Swap(heap, 1, heap.Length - 1);
        heap = ArrayMod.Pop(heap, heap.Length - 1);
        int index = 1;
        while (index * 2 < heap.Length && heap[index] > heap[index * 2] ||
            index * 2 + 1 < heap.Length && heap[index] > heap[index * 2 + 1])
        {
            if (index * 2 + 1 >= heap.Length || heap[index * 2] < heap[index * 2 + 1])
            {
                ArrayMod.Swap(heap, index, index * 2);
                index *= 2;
            }
            else
            {
                ArrayMod.Swap(heap, index, index * 2 + 1);
                index = index * 2 + 1;
            }
        }
    }
    public int[] GetHeap()
    {
        int[] heapArr = heap.ToArray();
        return heapArr;
    }
    public int Top()
    {
        int[] heapArr = heap.ToArray();
        return heapArr[1];
    }
    public bool Empty()
    {
        return heap.Length == 1;
    }
}

public static class ArrayMod
{
    /// <summary>
    /// Добавляет в конец массива
    /// </summary>
    /// <param name="arr">Изменяемый массив</param>
    /// <param name="data">Добавляемое значение</param>
    /// <returns></returns>
    public static int[] Push(int[] arr, int data)
    {
        int[] newArr = new int[arr.Length + 1];
        newArr[arr.Length] = data;
        for(int i = 0; i < arr.Length; i++)
            newArr[i] = arr[i];
        return newArr;
    }
    /// <summary>
    /// Удаляет по индексу
    /// </summary>
    /// <param name="arr">Изменяемый массив</param>
    /// <param name="index">Индекс удаляемого элемента</param>
    /// <returns></returns>
    public static int[] Pop(int[] arr, int index)
    {
        if (arr.Length - 1 < index)
            throw new IndexOutOfRangeException("Индекс вне границ"); //и правил
        int[] newArr = new int[arr.Length - 1];
        for(int i = 0; i < newArr.Length; i++)
        {
            if (i < index)
                newArr[i] = arr[i];
            else if (i >= index)
                newArr[i] = arr[i + 1];
        }
        return newArr;
    }
    /// <summary>
    /// Меняет местами по индексу
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    /// <returns></returns>
    public static int[] Swap(int[] arr, int index1, int index2)
    {
        arr[index1] += arr[index2];
        arr[index2] = arr[index1] - arr[index2];
        arr[index1] -= arr[index2];
        return arr;
    }
    public static void Print(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
            Console.Write($"{arr[i]} ");
        Console.Write("\n");
    }
}