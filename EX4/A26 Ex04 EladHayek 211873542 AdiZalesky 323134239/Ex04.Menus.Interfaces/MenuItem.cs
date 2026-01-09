using System;

namespace Ex04.Menus.Interfaces
{

    public abstract class MenuItem
    {
        private readonly string r_Title;
        protected MenuItem m_ParentMenuItem;
        private IProgramExitable r_ProgeamExitable;

        protected MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }

        public IProgramExitable ProgeamExitable
        {
            set 
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Program exitable cannot be null");
                }

                r_ProgeamExitable = value;
            }
        }

        public MenuItem ParentMenuItem
        {
            get 
            { 
                return m_ParentMenuItem;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Parent menu item cannot be null");
                }

                m_ParentMenuItem = value;
            }
        }

        public string Title
        {
            get { return r_Title; }
        }

        public abstract void Activate(bool i_ClearConsole = true);

        protected void GoBack(bool i_ClearConsole = true)
        {
            if(m_ParentMenuItem != null)
            {
                m_ParentMenuItem.Activate(i_ClearConsole);
            }
            else
            {
                r_ProgeamExitable.Exit();
            }
        }
    }
}
