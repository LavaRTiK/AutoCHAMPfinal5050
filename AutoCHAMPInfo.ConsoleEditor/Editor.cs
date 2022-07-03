using System;
using System.Collections.Generic;
using System.Text;

namespace TypeAutoCHAMP { 


    public partial class Editor {
        static string[] items = new string[] {
            "вийти",
            "створити тестові дані",
            "зберегти дані",
            "додати запис про тип Класс Авто",
            "додати запис про МодельАвто",
            "видалити запис про Класс Авто",
            "видалити запис про Модель Авто",
            "видалити усі записи",
            "сорт тип Класс Авто за назвою",
            "сорт Класс Авто за назвою",
            "сорт Класс Авто за Комнадую",
            "сорт Гонщика за назвую",
            "сорт список за міцем команнди",
        };

        static SimpleSelector selector;

        private DataContext dataContext;

        IEnumerable<Class> sortingClass;
        IEnumerable<TypeClass> sortingTypeClass;
        public Editor(DataContext dataContext) {
            this.dataContext = dataContext;
            sortingClass = dataContext.Class;
            sortingTypeClass = dataContext.TypeClasss;
            IniCommandsInfo();
        }

        private CommandInfo[] commandsInfo;

        private void IniCommandsInfo() {
            commandsInfo = new CommandInfo[] {
                new CommandInfo("вийти",  null),
                new CommandInfo("створити тестові дані",  dataContext.CreateTestingData),
                new CommandInfo("зберегти дані",  dataContext.Save),
                new CommandInfo("додати запис про тип Класс Авто", AddClass),
                new CommandInfo("додати запис про МодельАвто", AddClssType),
                new CommandInfo("видалити запис про Класс Авто", RemoveClass),
                new CommandInfo("видалити запис про Модель Авто", RemoveTypeClass),
                new CommandInfo("видалити усі записи", dataContext.Clear),
                new CommandInfo("сорт тип Класс Авто за назвою", SortClassByName),
                new CommandInfo("сорт Класс Авто за назвою", StorTypeClassByName),
                new CommandInfo("сорт Класс Авто за Комнадую", SortClasssByClass),
                new CommandInfo("сорт Гонщика за назвую ", SortTypeNames),
                new CommandInfo("cорт список за міцем команнди", SoryTypeClssPOs),
            };
        }

        public void Run() {
            dataContext.Load();
            while (true) {
                Console.Clear();
                OutData();
                Console.WriteLine();
                Console.OutputEncoding = Encoding.Unicode;
                Console.Write("\nОберіть команду: ");
                selector = new SimpleSelector(Console.CursorLeft,
                    Console.CursorTop, 30, items);
                selector.Focus();
                //string text = selector.Text;

                //ShowCommandsMenu();
                Command command = commandsInfo[selector.selectedIndex].command;
                if (command == null)
                {
                    return;
                }
                command();
                //Test(text);
            }
        }

        private void ShowCommandsMenu() {
            Console.WriteLine("  Список команд меню:");
            for (int i = 0; i < commandsInfo.Length; i++) {
                Console.WriteLine("\t{0,2} - {1}",
                    i, commandsInfo[i].name);
            }
        }

        private Command EnterCommand() {
            Console.WriteLine();
            int number = Entering.EnterInt32(
                "Введіть номер команди меню");
            return commandsInfo[number].command;
        }
        private string Test(string text) 
        {
            switch (text)
            {
                case "вийти":
                    Console.WriteLine("Выйти");
                    System.Environment.Exit(0);
                    break;
                case "створити тестові дані":
                    dataContext.CreateTestingData();
                    Console.WriteLine();
                    break;
                case "зберегти дані":
                    Console.WriteLine();
                    dataContext.Save();
                    break;
                case "додати запис про тип Класс Авто":
                    Console.WriteLine();
                    AddClass();
                    break;
                case "додати запис про МодельАвто":
                    Console.WriteLine();
                    AddClssType();
                    break;
                case "видалити запис про Класс Авто":
                    Console.WriteLine();
                    RemoveClass();
                    break;
                case "видалити запис про Модель Авто":
                    Console.WriteLine();
                    RemoveTypeClass();
                    break;
                case "видалити усі записи":
                    dataContext.Clear();
                    break;
                case "сорт тип Класс Авто за назвою":
                    SortClassByName();
                    break;
                case "сорт Класс Авто за назвою":
                    StorTypeClassByName();
                    Console.WriteLine("\n");
                    break;
                case "сорт Класс Авто за Комнадую":
                    SortClasssByClass();
                    break;
                case "сорт Гонщика за назвую":
                    SortTypeNames();
                    break;
                case "сорт список за міцем команнди":
                    SoryTypeClssPOs();
                    break;
            }
            return "";
        }

    }
}
