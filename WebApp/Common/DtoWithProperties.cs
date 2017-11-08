
using System;
using System.Collections.Generic;

namespace WebApp.Common
{
    public class DtoWithProperties<T>
    {
        public object Data { get; private set; }        

        public DtoWithProperties(object obj)
        {
            Data = obj;

            // Можно какие-то сведения об ошибках доставить, но нт необходимости
        }
    }
}