using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Data.HashCode2020
{
    public class BookDataFormat : DataFormat<GlobalData>
    {
        public BookDataFormat(string rawData) : base(rawData)
        {
        }

        protected override GlobalData CreateFromRawData(string rawData)
        {
            return null;
        }
    }
}
