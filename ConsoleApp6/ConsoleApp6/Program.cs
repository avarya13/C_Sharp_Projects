using System.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp6
{

    
    class MyList
    {
        private int[] m;
        private int _count;
        public MyList(int Capacity)
        {
            m = new int[Capacity];
            _count = 0;
        }
        public MyList()
        {
            _count = 0;
            
        }
        public int Capacity
        {
            get { return m.Length; }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public int this[int i]
        {
            get { return m[i]; }
            set { m[i] = value; }
        }

        public void Add(int item)
        {
            if (m!=null && Count == m.Length)
            {
                
                int[] temp = new int[m.Length + 1];
                Array.Copy(m, temp, m.Length);
                m = temp;
            }
            else if (m == null)
            {
                m = new int[1];
            }
            m[Count] = item;
            Count++;
        }
        public IEnumerator GetEnumerator()
        {

            for (int i = 0; i < Count; i++)
            {
                yield return m[i];
            }

        }

        public IEnumerator GetEnumerator(int a, int b)
        {

            for (int i = a; i < a + b + 1; i++)
            {
                yield return m[i];
            }

        }
        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (m[i] == item)
                    return true;
            }
            return false;
        }

        public void AddRange(int[] items)
        {
            if (m!=null && Count == m.Length)
            {

                int[] temp = new int[m.Length + items.Length];
                Array.Copy(m, temp, m.Length);
                m = temp;
            }
            else if (m == null)
            {
                m = new int[items.Length];
                
            }
            for (int j = 0; j < items.Length; j++)
            {
                m[Count] = items[j];
                Count++;
            }
        }


        public int[] GetRange(int index, int amount)
        {

            int[] temp = new int[amount];
            int k = 0;
            if (index + amount < m.Length)
            {
                for (int i = index; i < amount; i++)
                {
                    temp[k] = m[i];
                    k++;
                }
            }
            return temp;
        }

       
        public void SetRange(int index, ICollection c)
        {
            if (m.Length > c.Count - index)
            {
                int k = 0;
                while (k <= c.Count)
                {

                    if (k >= index)
                    {
                        foreach (var item in c)
                        {
                            m[index] = (int)item;
                            index++;
                        }
                    }
                    k++;
                }
            }
        }

        public int IndexOf(int value, int a, int b)
        {
            int index = -1;
            for (int i = a; i < a + b; i++)
            {
                if (m[i] == value)
                    index = i;
            }

            return index;
        }

        public void Insert(int index, int value)
        {
            if (m != null)
            {
                int[] temp;
                if (Count == m.Length)
                {
                    temp = new int[m.Length + 1];
                }
                else 
                {
                    temp = new int[m.Length+1];
                }
                    for (int i = 0; i < m.Length + 1; i++)
                    {
                        
                        if (i < index)
                            temp[i] = m[i];
                        else if (i == index)
                            temp[i] = value;
                        else
                            temp[i] = m[i - 1];
                    }
                    m = temp;
                
                Count++;
            }

            else if (m == null)
            {
                m = new int[index+1];
                
                m[index] = value;
                Count = index + 1;
            }
            
        }

        //public void InsertRange(int a, int[] people)
        //{
        //    int j = 0;

        //    int[] temp = new int[m.Length + people.Length];
        //    if (Count + people.Length > m.Length)
        //    {
        //        for (int i = 0; i < m.Length + people.Length; i++)
        //        {
        //            if (i < a)
        //                temp[i] = m[i];
        //            else if (i >= a && i < a + people.Length)

        //            {
        //                temp[i] = people[j];
        //                j++;
        //            }
        //            else
        //            {
        //                temp[i] = m[i - people.Length];
        //            }
        //        }
        //        m = temp;

        //    }
        //    else
        //    {
        //        j = 0;
        //        for (int i = Count; i < m.Length + people.Length - 1; i++)
        //        {
        //            m[i] = people[j];
        //        }
        //    }
        //    Count = Count + people.Length;
        //}


        public void RemoveAt(int index)
        {
            Array.Copy(m, index + 1, m, index, Count - index - 1);

            
            m[Count-1] = 0;
            Count--;

        }

        public void Remove(int a)
        {
            int i;
            for (i = 0; i < Count; i++)
            {
                if (m[i] == a)
                    break;
            }
            Array.Copy(m, i + 1, m, i, Count - i - 1);

            Count--;
            m[Count] = 0;
        }




        public void RemoveRange(int a, int amount)
        {


            Array.Copy(m, a + amount, m, a, Count - a - amount);


            for (int i = a; i < a + amount; i++)
            {
                Count--;
                m[Count] = 0;
            }

          
        }

        public void Reverse()
        {
            int[] tmp = new int[Count];
            int j = 0;
            for (int i = 0; i < Count; i++)
            {
                tmp[j] = m[i];
                j++;
            }
            Array.Reverse(tmp);
            Array.Copy(tmp, m, Count);

       
        }
        
        public void Reverse(int a, int b)
        {
            int[] tmp = new int[b];
            int j = 0;
            for (int i = a; i < a + b; i++)
            {
                tmp[j] = m[i];
                j++;
            }
            Array.Reverse(tmp);
            Array.Copy(tmp, 0, m, a, tmp.Length);


        }


        public Object[] ToArray()
        {
            Object[] tmp = new Object[m.Length];
            Array.Copy(m, tmp, m.Length);
            return tmp;

        }

        public Array ToArray(Type t)

        {
            if (t == typeof(int))
            {
                int[] tmp = new int[Count];
                Array.Copy(m, tmp, Count);
                return tmp;
            }
            else throw new InvalidCastException();


        }
    }

   
    class Program
    {
        public static void Show(MyList lst)
        {
            foreach (var item in lst)
                Console.Write(item.ToString() + " ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            MyList lst = new MyList();
            
            while(true)
            {
                Console.WriteLine("a - добавить в конец,  " +
                    "i - вставить в любое место в список по индексу, " +
                    "d - удалить элемент, " +
                    "r - удалить по индексу, " +
                    "f - проверить наличие элемента ");
                switch(Console.ReadLine())
                {
                    case "a":
                        Console.Write("Введите число: ");
                        try
                        {
                            lst.Add(int.Parse(Console.ReadLine()));
                            Show(lst);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Повторите попытку!");
                        }
                        break;
                    case "i":
                       
                        try
                        {
                            Console.Write("Введите индекс: ");
                            string ind = Console.ReadLine();
                            Console.Write("Введите число: ");
                            string num = Console.ReadLine();
                            lst.Insert(int.Parse(ind), int.Parse(num));
                            Show(lst);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Повторите попытку!");
                        }
                        break;
                    case "d":
                        Console.Write("Введите число: ");
                        try
                        {
                            lst.Remove(int.Parse(Console.ReadLine()));
                            Show(lst);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Повторите попытку!");
                        }
                        break;
                    case "r":
                        Console.Write("Введите число: ");
                        try
                        {
                            lst.RemoveAt(int.Parse(Console.ReadLine()));
                            Show(lst);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Повторите попытку!");
                        }
                        break;
                    case "f":
                        Console.Write("Введите число: ");
                        try
                        {
                            Console.WriteLine(lst.Contains(int.Parse(Console.ReadLine())));
                            Show(lst);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Повторите попытку!");
                        }
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода!");
                        break;

                }
            }




            //Console.WriteLine("Содержится ли в списке элемент 1?");
            //Console.WriteLine(lst.Contains(1));
            //Console.WriteLine("Добавление элемента 31:");
            //lst.Add(31);
            //Show(lst); 
            //Console.WriteLine("Добавление значений 11, 23, 64, 56, 98, 34, 28 в конец:");
            //lst.AddRange(new int[7] { 11, 23, 64, 56, 98, 34, 28 });
            //Show(lst);
            //Console.WriteLine("Удаление элемента с индексом 1:");
            //lst.RemoveAt(1);
            //Show(lst);
            //Console.WriteLine("Удаление 2-х элементов, начиная с индекса 2:");
            //lst.RemoveRange(2, 2);
            //Show(lst);
            //Console.WriteLine("Удаление элемента 34:");
            //lst.Remove(34);
            //Show(lst);
            //Console.WriteLine("Вставка элемента 6 на позицию 1:");
            //lst.Insert(1, 6);
            //Show(lst);
            //Console.WriteLine("Содержится ли в списке элемент 23?");
            //Console.WriteLine(lst.Contains(23));
            //Console.WriteLine("Индекс 23:");
            //Console.WriteLine(lst.IndexOf(23,0,lst.Count));
            
            Console.ReadKey();
        }
    }
}

