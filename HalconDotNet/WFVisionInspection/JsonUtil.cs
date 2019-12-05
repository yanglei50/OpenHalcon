using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFVisionInspection
{
    class JsonUtil
    {
        public class POI
        {
            public double row1;
            public double column1;
            public double row2;
            public double column2;
        }
        public class Image_Resource
        {
            public int id;
            public int number;
            public string name;
            public string path;
            public string prefix;
            public double row1;
            public double column1;
            public double row2;
            public double column2;

            public override string ToString()
            {
                return string.Format("Id:{0},Number:{1},Name:{2},Path:{3},Prefix:{4},POI:({5},{6})-({7},{8})", id, number, name, path, prefix, row1, column1,row2,column2);
            }
        }
    }
}
