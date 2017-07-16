namespace WebCache.Models
{
    public class CacheFactoryResponse<TDeserializedObject>
    {
        public string CachedJsonContent;

        public TDeserializedObject DeserializedCachedContent;

        public long ElapsedMilliseconds;

        public string DataLoadType;

    }
}
