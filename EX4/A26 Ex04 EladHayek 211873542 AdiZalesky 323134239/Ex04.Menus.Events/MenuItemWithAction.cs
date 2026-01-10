using System;

namespace Ex04.Menus.Events
{
    public class MenuItemWithAction : MenuItem
    {
        public event Action Selected;

        public MenuItemWithAction(string i_Title) : base(i_Title)
        {
        }

        public override void Activate(bool i_ClearConsole = true)
        {
            OnSelected();
            const bool v_ClearConsole = false;
            GoBack(v_ClearConsole);
        }

        protected virtual void OnSelected()
        {
            if (Selected != null)
            {
                Selected.Invoke();
            }
        }
    }
}
