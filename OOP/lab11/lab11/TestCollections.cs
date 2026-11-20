using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using lab10.classes;

namespace lab11
{
    public class MammalComparer : IComparer<Mammal>
    {
        public int Compare(Mammal? x, Mammal? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int byName = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            if (byName != 0) return byName;

            return x.Weight.CompareTo(y.Weight);
        }
    }

    public class TestCollections
    {
        public LinkedList<Artiodactyl> Collection1 { get; } = new LinkedList<Artiodactyl>();
        public LinkedList<string> Collection1String { get; } = new LinkedList<string>();

        public SortedDictionary<Mammal, Artiodactyl> Collection2 { get; }
        public SortedDictionary<string, Artiodactyl> Collection2String { get; }

        public TestCollections(int count = 1000)
        {
            Collection2 = new SortedDictionary<Mammal, Artiodactyl>(new MammalComparer());
            Collection2String = new SortedDictionary<string, Artiodactyl>();

            for (int i = 0; i < count; i++)
            {
                Artiodactyl a = new Artiodactyl();
                a.RandomInit();
                a.Name = $"Animal{i}";
                Add(a);
            }
        }

        public void Add(Artiodactyl a)
        {
            Mammal key = a.BaseMammal;
            string strKey = a.ToString();

            Collection1.AddLast(a);
            Collection1String.AddLast(strKey);

            if (!Collection2.ContainsKey(key))
                Collection2.Add(key, a);

            if (!Collection2String.ContainsKey(strKey))
                Collection2String.Add(strKey, a);
        }

        public void Remove(Artiodactyl a)
        {
            Mammal key = a.BaseMammal;
            string strKey = a.ToString();

            Collection1.Remove(a);
            Collection1String.Remove(strKey);
            Collection2.Remove(key);
            Collection2String.Remove(strKey);
        }

        private Artiodactyl Copy(Artiodactyl a)
        {
            return new Artiodactyl(a.Name, a.Weight, a.Age, a.FurColor, a.IsPredator, a.HoofCount, a.HasHorns);
        }

        public void MeasureSearch()
        {
            if (Collection1.Count == 0) return;

            Artiodactyl first = Collection1.First!.Value;
            Artiodactyl middle = Collection1.ElementAt(Collection1.Count / 2);
            Artiodactyl last = Collection1.Last!.Value;

            Artiodactyl notIn = new Artiodactyl("NotInCollection", 999.99, 99, "None", false, 2, false);

            Artiodactyl[] elements = { first, middle, last, notIn };
            string[] names = { "первый", "центральный", "последний", "отсутствующий" };

            for (int i = 0; i < elements.Length; i++)
            {
                Artiodactyl a = elements[i];
                Artiodactyl copy = Copy(a);
                Mammal keyCopy = a.BaseMammal;
                string strCopy = a.ToString();

                Console.WriteLine($"\nПоиск {names[i]} элемента: {a.Name}");

                Stopwatch sw = Stopwatch.StartNew();
                bool found1 = Collection1.Contains(copy);
                sw.Stop();
                Console.WriteLine($"  LinkedList<Artiodactyl>.Contains: {found1}, тиков: {sw.ElapsedTicks}");

                sw.Restart();
                bool found1s = Collection1String.Contains(strCopy);
                sw.Stop();
                Console.WriteLine($"  LinkedList<string>.Contains: {found1s}, тиков: {sw.ElapsedTicks}");

                sw.Restart();
                bool found2 = Collection2.ContainsKey(keyCopy);
                sw.Stop();
                Console.WriteLine($"  SortedDictionary<Mammal,Artiodactyl>.ContainsKey: {found2}, тиков: {sw.ElapsedTicks}");

                sw.Restart();
                bool found2s = Collection2String.ContainsKey(strCopy);
                sw.Stop();
                Console.WriteLine($"  SortedDictionary<string,Artiodactyl>.ContainsKey: {found2s}, тиков: {sw.ElapsedTicks}");

                sw.Restart();
                bool foundV = Collection2.ContainsValue(copy);
                sw.Stop();
                Console.WriteLine($"  SortedDictionary<Mammal,Artiodactyl>.ContainsValue: {foundV}, тиков: {sw.ElapsedTicks}");
            }
        }
    }
}