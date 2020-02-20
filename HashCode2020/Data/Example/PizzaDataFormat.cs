using System;

namespace HashCode2020.Data.Example
{
    public class PizzaDataFormat : DataFormat<PizzaModel>
    {
        public override PizzaModel CreateFromRawData()
        {
            string firstLine = rawData.Substring(0, rawData.IndexOf(Environment.NewLine));
            string data = rawData.Substring(rawData.IndexOf(Environment.NewLine));

            return new PizzaModel()
            {
                PizzaNb = firstLine
            };
        }
    }
}
