using System.Collections;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = ArrayManager<int>.CreateMassive(10);
            ManagersArray<int> managersArray = new(new ArrayManager<int>[]
            {
                new ArrayManager<int>(),
                new ArrayManager<int>(),
                new ArrayManager<int>(),
                new ArrayManager<int>(),
                new ArrayManager<int>(),
                new ArrayManager<int>(),
            });

            foreach (var item in managersArray)
            {
                Console.WriteLine(item);
            }

        }
    }
}


class ArrayManager<T>
{
    public ArrayManager() { }

    static public T[] CreateMassive(int size)
    {
        return new T[size];
    }

    static public void RandomNumberArray(ref T[] massive)
    {
        Random random = new Random();

        if (massive is int[] masInt)
        {
            for (int i = 0; i < massive.Length; i++) {
                masInt[i] = random.Next(0, 100);
            }

        }else if(massive is string[] masStr)
        {
            Console.WriteLine("Not working now");
        }
    }

    static public void DisplayArray(T[] array, bool Numeration)
    {
        if (Numeration)
        {
            int temp= 1;
            foreach (var item in array)
            {
                Console.WriteLine(temp+ ": " + item);
                temp++;
            }
            return;
        }
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }

    static public float GetMiddleNum(T[] array)
    {
        if (array is int[] arrayInt)
        {
            int sum = 0;
            foreach (int item in arrayInt)
            {
                sum+= item;
            }
            return sum/arrayInt.Length;
        }
        else if (array is float[] arrayFloat)
        {
            float sum = 0;
            foreach (int item in arrayFloat)
            {
                sum += item;
            }
            return sum/arrayFloat.Length;
        }
        else
        {
            Console.WriteLine("Cant.");
            return -1;
        }
    }

    static public T LowerNumber(T[] array)
    {
        T min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (((IComparable)array[i]).CompareTo(min) < 0) min = array[i];
        }
        return min;
    }

    static public T HigherNumber(T[] array)
    {
        T high = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (((IComparable)array[i]).CompareTo(high) > 0) high = array[i];
        }
        return high;
    }


    static public void SortArray(ref T[] array)
    {
        Array.Sort(array);
    }
}

class ManagersArray<T> : IEnumerable
{
    ArrayManager<T>[] arrayManager;
    public ManagersArray(ArrayManager<T>[] arrayManagers)
    {
        this.arrayManager = arrayManagers;
    }
    public IEnumerator GetEnumerator()
    {
        return new ManagersArrayHelper<T>(arrayManager);
    }
}

class ManagersArrayHelper<T> : IEnumerator
{
    ArrayManager<T>[] arrayManagers;
    int pos = -1;
    public object Current {
        get {
            if (pos >= arrayManagers.Length  || pos == -1) throw new InvalidOperationException();
            return arrayManagers[pos];
        }
    }

    public ManagersArrayHelper(ArrayManager<T>[] arrayManager)
    {
        this.arrayManagers=arrayManager;
    }

    public bool MoveNext()
    {
        if(pos < arrayManagers.Length-1) {
            pos++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        pos = -1;
    }
}
