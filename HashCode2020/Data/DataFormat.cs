using System;

namespace HashCode2020.Data
{
    public abstract class DataFormat<T>
    {
        string _rawData;
        public readonly string separator = " ";

        public DataFormat(string rawData)
        {
            _rawData = rawData;
        }

        protected string GetDataFromLine(int line, int nb)
        {
            string[] lines = _rawData.Split(Environment.NewLine);
            return lines[line].Split(separator)[nb];
        }

        protected abstract T CreateFromRawData(string rawData);
    }
}
