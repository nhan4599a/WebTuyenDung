namespace WebTuyenDung.ViewModels
{
    public class GroupByToCountQueryResult<TKey> where TKey : struct
    {
        public TKey Key { get; set; }

        public int Count { get; set; }
    }
}
