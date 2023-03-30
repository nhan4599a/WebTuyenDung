using System;
using System.Collections.Generic;

namespace WebTuyenDung.Helper
{
    public static class DictionaryHelper
    {
        public static void AddOrUpdate<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value,
            Func<TValue, TValue> updateFunc) where TKey : struct
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = updateFunc(dictionary[key]);
            }
            else
            {
                dictionary[key] = value;
            }
        }
    }
}
