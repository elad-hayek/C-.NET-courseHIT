using System;

namespace Ex04.Menus.Interfaces
{
    public class MenuItemWithAction : MenuItem
    {
        private readonly IMenuItemActionProvider r_ActionProvider;

        public MenuItemWithAction(string i_Title, IMenuItemActionProvider i_ActionProvider) : base(i_Title)
        {
            r_ActionProvider = i_ActionProvider;
        }

        public override void Activate(bool i_ClearConsole = true)
        {
            if (r_ActionProvider != null)
            {
                r_ActionProvider.OnMenuItemSelected();
            }

            const bool v_ClearConsole = false;
            GoBack(v_ClearConsole);
        }
    }
}
