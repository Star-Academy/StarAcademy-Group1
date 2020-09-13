// In The Name Of GOD

namespace Analysis
{
    public class Pair<T, V>
    {
        public T First { get; set; }

        public V Second { get; set; }

        public Pair(T t, V v)
        {
            First = t;
            Second = v;
        }

    }
}
