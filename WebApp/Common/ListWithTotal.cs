using System.Collections.Generic;

namespace WebApp.Common
{
    public class ListWithTotal<T>
    {     
        public List<T> Data { get; private set; }

        public int RecordTotal { get; private set; }

        public ListWithTotal(IEnumerable<T> items, int recordTotal)
        {
            Data = new List<T>(items);
            RecordTotal = recordTotal;
        }
    }
}