using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItemWithSubMenu : MenuItem
    {
        private readonly List<MenuItem> r_SubMenuItems = new List<MenuItem>();

        public MenuItemWithSubMenu(string i_Title) : base(i_Title)
        {
        }

        public void AddSubMenuItem(MenuItem i_SubMenuItem)
        {
            i_SubMenuItem.ParentMenuItem = this;
            r_SubMenuItems.Add(i_SubMenuItem);
        }

        private string getBackOptionTitle()
        {
            return m_ParentMenuItem == null ? "Exit" : "Back";
        }

        private string getPromptBackOptionTitle()
        {
            return m_ParentMenuItem == null ? "exit" : "go back";
        }

        public override void Activate(bool i_ClearConsole = true)
        {
            if(i_ClearConsole)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"** {Title} **");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', Title.Length + 6));

            for (int i = 0; i < r_SubMenuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {r_SubMenuItems[i].Title}");
            }

            Console.WriteLine($"0. {getBackOptionTitle()}");

            int userChoice = getUserChoice();
            if (userChoice == 0)
            {
                const bool v_ClearConsole = true;
                GoBack(v_ClearConsole);
            }
            else
            {
                r_SubMenuItems[userChoice - 1].Activate();
            }
        }

        private int getUserChoice()
        {
            int choice;
            choice = 0;
            bool isValidChoice = false;

            while (!isValidChoice)
            {
                Console.WriteLine($"Please enter your choice (1-{r_SubMenuItems.Count} or 0 to {getPromptBackOptionTitle()}):");
                Console.Write(">> ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) && choice >= 0 && choice <= r_SubMenuItems.Count)
                {
                    isValidChoice = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }

            return choice;
        }
    }
}
