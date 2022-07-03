
namespace TypeAutoCHAMP {
    public class TypeClass : Entity {

        public string Carmodel;
        public string Commandname;
        public Class Class;
        public string nameperson;
        public double? prize;

        public override string ToString() {
            return string.Format(
                "{0,7} Машина:{1}, {2},  Імя Гощика: {3},  Місце: {4},  НазваК:{5}" ,
                Id, Carmodel, Class == null ? "" : Class.name,
                nameperson, prize,Commandname);
        }

        public TypeClass(string Carmodel, Class Class,
                    string nameperson, double? prize,string Commandname) {
            this.Carmodel = Carmodel;
            this.Class = Class;
            this.nameperson = nameperson;
            this.prize = prize;
            this.Commandname = Commandname;
        }

        public TypeClass() { }

        public TypeClass(string Carmodel, Class Class)
            : this(Carmodel, Class, null, null,null) { }

    }
}
