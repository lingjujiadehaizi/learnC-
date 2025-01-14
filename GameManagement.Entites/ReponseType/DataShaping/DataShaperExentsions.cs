using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagement.Entites.ReponseType.DataShaping
{
    public static class DataShaperExentsions
    {
        public static IEnumerable<dynamic> ShapeData<T>(this IEnumerable<T> sources, string fileds)
        {
            var dataShaper = new DataShaper<T>(fileds);
            return dataShaper.FetchData(sources);
        }

        public static dynamic ShapeData<T>(this T source, string fileds)
        {
            var dataShaper = new DataShaper<T>(fileds);
            return dataShaper.FetchData(source);
        }
    }
}
