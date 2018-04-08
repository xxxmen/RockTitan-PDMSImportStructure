using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDMSImportStructure
{
    public class BindingSourceClass
    {
        //public int MyProperty { get; set; }
        //public int MyProperty2 { get; set; }
        public static List<MajorProperties> PropertiesList = ReadMDT.PropertiesList;
        
    }
}
