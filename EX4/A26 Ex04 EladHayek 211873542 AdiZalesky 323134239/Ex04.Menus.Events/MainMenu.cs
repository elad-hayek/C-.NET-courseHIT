using System;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private bool m_IsRunning = true;
        private MenuItem m_MenuItem;

        public MainMenu()
        {
        }

        public void Show()
        {
            while (m_IsRunning)
            {
                if (m_MenuItem != null)
                {
                    m_MenuItem.Activate();
                }
                else
                {
                    throw new NullReferenceException("Menu item is not initialized. Please create the menu before showing it.");
                }
            }
        }

        public void CreateMenu(MenuItem i_RootMenuItem)
        {
            m_MenuItem = i_RootMenuItem;
            m_MenuItem.IsMenuRoot = true;
            m_MenuItem.ExitProgram += menuItem_ExitRequested;
        }


        private void menuItem_ExitRequested()
        {
            exit();
        }

        private void exit()
        {
            m_IsRunning = false;
        }
    }
}
