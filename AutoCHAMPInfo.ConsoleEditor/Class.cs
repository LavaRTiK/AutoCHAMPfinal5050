namespace TypeAutoCHAMP {
    public class Class : Entity {

        public string name;

        public Class(string name) {
            this.name = name;
        }

        public Class() { }

        public override string ToString() {
            return string.Format("{0,7} {1}", Id, name);
        }
    }
}
