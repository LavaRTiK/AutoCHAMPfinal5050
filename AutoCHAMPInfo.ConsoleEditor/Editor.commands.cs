using System;
using System.Linq;

namespace TypeAutoCHAMP
{
    partial class Editor
    {

        private void OutData() {
            OutClassData();
            OutTypeClassData();
        }

        private void OutClassData() {
            Console.WriteLine("  Класс Авто:");
            foreach (var obj in sortingClass) {
                Console.WriteLine("{0,5} {1,-17}", obj.Id, obj.name);
            }
        }

        private void OutTypeClassData() {
            Console.WriteLine("\n  Спикок :");
            foreach (var obj in sortingTypeClass) {
                string ClassName = obj.Class == null ? ""
                    : obj.Class.name;
                Console.WriteLine("{0,5} {1,-15} Клас: {2,-4}, Імя Гощика: {3,15}, Місце: {4,3}  НазваК:{5,10}",
                    obj.Id, obj.Carmodel, ClassName, obj.nameperson, obj.prize,obj.Commandname);
            }
        }

        public void AddClass() {
            Class inst = new Class();
            inst.name = Entering.EnterString("\nКласс Авто");
            if (dataContext.Class.Count == 0)
            {
                inst.Id = 1;

            }
            else
            {

                inst.Id = dataContext.Class.Select(e => e.Id).Max() + 1;
                
            }
            dataContext.Class.Add(inst);
        }

        public void AddClssType() {
            TypeClass inst = new TypeClass();
            inst.Carmodel = Entering.EnterString("\nМодель Авто");
            inst.Class = SlectClss();
            inst.nameperson = Entering.EnterStringOrNull("Ініціали гонщика");
            inst.prize = Entering.EnterNullableDouble("Місце:");
            inst.Commandname = Entering.EnterString("Назва Команди");
            inst.Id = dataContext.TypeClasss.Select(e => e.Id).Max() + 1;
            dataContext.TypeClasss.Add(inst);
        }

        private Class SlectClss() {
            string ClassName = Entering.EnterString("\nКлас Авто");
            return dataContext.Class.First(e => e.name == ClassName);
        }


        public void RemoveClass() {
            int id = Entering.EnterInt32("\nВведіть числовий ідентифікатор типу Класс Авто");
            Class inst = dataContext.Class.FirstOrDefault(e => e.Id == id);
            dataContext.Class.Remove(inst);
        }

        public void RemoveTypeClass() {
            int id = Entering.EnterInt32("\nВведіть числовий ідентифікатор Класс Авто");
            TypeClass inst = dataContext.TypeClasss.FirstOrDefault(e => e.Id == id);
            dataContext.TypeClasss.Remove(inst);
        }


        private void SortClassByName() {
            sortingClass = sortingClass.OrderBy(e => e.name);
        }

        private void StorTypeClassByName() {
            sortingTypeClass = sortingTypeClass.OrderBy(e => e.Carmodel);
        }

        private void SortClasssByClass() {
            sortingTypeClass = sortingTypeClass.OrderBy(e => e.Class.name);
        }

        private void SortTypeNames() {
            sortingTypeClass = sortingTypeClass.OrderBy(e => e.nameperson);
        }

        private void SoryTypeClssPOs() {
            sortingTypeClass = sortingTypeClass.OrderBy(e => e.prize);
        }

    }
}
