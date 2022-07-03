using System.Collections.Generic;
using System.Linq;

namespace TypeAutoCHAMP {
    public class DataContext {

        readonly DataSet dataSet = new DataSet();

        public ICollection<TypeClass> TypeClasss {
            get { return dataSet.TypeClass; }
        }
        public ICollection<Class> Class {
            get { return dataSet.Class; }
        }

        XmlFileIoController xmlFileIoController = new XmlFileIoController();

        public static string fileName = "TypeClasssInfo.xml";

        public void Save() {
            xmlFileIoController.Save(dataSet, fileName);
        }

        public void Load() {
            xmlFileIoController.Load(dataSet, fileName);
        }

        public override string ToString() {
            return string.Concat("Інформація про Класс Авто \"Класс Авто\"\n",
                TypeClasss.ToLineList("Класс Авто"),
                Class.ToLineList("Класс Авто"));
        }

        public void Clear() {
            TypeClasss.Clear();
            Class.Clear();
        }

        public void CreateTestingData() {
            CreateClass();
            CreateTypeClass();
        }

        private void CreateClass() {
            Class.Add(new Class("C") { Id = 1 });
            Class.Add(new Class("S") { Id = 2 });
            Class.Add(new Class("D") { Id = 3 });
        }

        private void CreateTypeClass() {
            TypeClasss.Add(new TypeClass("Reno",
                Class.First(e => e.name == "C"), "І.В.Горденко", 3,"BlackAvatar") {
                Id = 1,
            });
            TypeClasss.Add(new TypeClass("Matiz",
            Class.First(e => e.name == "S"), "М.В.Максюк", 2,"WhiteAvatar") {
                Id = 2,
            });
            TypeClasss.Add(new TypeClass("Matiz",
                Class.First(e => e.name == "S"), "Д.О.Дикий", 1,"GreenAvatar") {
                Id = 3,
            });
            TypeClasss.Add(new TypeClass("Subaru",
                Class.First(e => e.name == "D"), "Е.О.Романенко", 2,"YellowAvatar") {
                Id = 4,
            });
            TypeClasss.Add(new TypeClass("BMX",
                Class.First(e => e.name == "S"), "P.L.LANSER", 0.1, "BMXAvatar")
            {
                Id = 5,
            });

        }
    }
}
