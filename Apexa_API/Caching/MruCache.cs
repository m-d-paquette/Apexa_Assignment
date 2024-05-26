namespace Apexa_API.Caching
{
    public class MruCache<TKey, TValue> where TKey : notnull
    {
        private readonly int _capacity;
        private readonly LinkedList<TKey> _mruList;
        private readonly Dictionary<TKey, TValue> _cache;

        public MruCache(int capacity = 5)
        {
            _capacity = capacity;
            _mruList = new LinkedList<TKey>();
            _cache = new Dictionary<TKey, TValue>(capacity);
        }
        public TValue Get(TKey key)
        {
            if (_cache.TryGetValue(key, out var value))
            {
                Touch(key);
                return value;
            }

            return default;
        }
        public void Put(TKey key, TValue value)
        {
            if (_cache.ContainsKey(key))
            {
                Touch(key);
                _cache[key] = value;
            }
            else
            {
                if (_cache.Count >= _capacity)
                {
                    var leastRecentKey = _mruList.Last.Value;
                    _mruList.RemoveLast();
                    _cache.Remove(leastRecentKey);
                }

                _cache.Add(key, value);
                _mruList.AddFirst(key);
            }

        }
        public void Delete(TKey key)
        {
            if (_cache.ContainsKey(key))
            {
                _mruList.Remove(key);
                _cache.Remove(key);
            }
        }

        private void Touch(TKey key)
        {
            _mruList.Remove(key);
            _mruList.AddFirst(key);
        }
    }
}
