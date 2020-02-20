namespace HashCode2020.Data
{
    public abstract class DataFormat<T>
    {
        string _rawData;
        readonly string separator = " ";

        public DataFormat(string rawData)
        {
            _rawData = rawData;
        }

        protected string GetDataFromLine(int line, int nb)
        {
            //todo
            return null;
        }

        protected abstract T CreateFromRawData(string rawData);
    }
}
