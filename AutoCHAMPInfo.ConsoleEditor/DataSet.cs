using System.Collections.Generic;

namespace TypeAutoCHAMP
{
    public class DataSet
    {
        public List<Class> Class { get; private set; }
        public List<TypeClass> TypeClass { get; private set; }

        public DataSet() {
            Class = new List<Class>();
            TypeClass = new List<TypeClass>();
        }
    }
}
