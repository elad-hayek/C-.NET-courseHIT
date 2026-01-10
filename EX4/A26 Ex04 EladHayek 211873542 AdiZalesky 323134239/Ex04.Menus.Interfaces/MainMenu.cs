
using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IProgramExitable
    {
        private bool m_IsRunning = true;
        private MenuItem m_MenuItem;

        public MainMenu()
        {
        }

        public void Show()
        {
           while(m_IsRunning)
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
            i_RootMenuItem.ProgeamExitable = this;
            m_MenuItem = i_RootMenuItem;
        }

        void IProgramExitable.Exit()
        {
            m_IsRunning = false;
        }
    }
}
