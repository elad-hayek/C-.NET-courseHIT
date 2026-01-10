using System;

namespace Ex04.Menus.Events
{
    public abstract class MenuItem
    {
        private readonly string r_Title;
        public event Action<bool> GoBackSelected;
        public event Action ExitProgram;
        private bool m_IsMenuRoot;

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }

        public bool IsMenuRoot
        {
            get
            {
                return m_IsMenuRoot;
            }
            set
            {
                m_IsMenuRoot = value;
            }
        }

        public string Title
        {
            get 
            { 
                return r_Title;
            }
        }

        public abstract void Activate(bool i_ClearConsole = true);

        protected void GoBack(bool i_ClearConsole)
        {
            if(m_IsMenuRoot)
            {
                OnExitProgram();
            }
            else
            {
                OnGoBackSelected(i_ClearConsole);
            }
        }

        protected virtual void OnGoBackSelected(bool i_ClearConsole)
        {
            if(GoBackSelected != null)
            {
                GoBackSelected.Invoke(i_ClearConsole);
            }
        }

        protected virtual void OnExitProgram()
        {
            if(ExitProgram != null)
            {
                ExitProgram.Invoke();
            }
        }
    }
}
