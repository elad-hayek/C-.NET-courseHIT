using System;

namespace Ex04.Menus.Interfaces
{
    public class MenuItemWithAction : MenuItem
    {
        private readonly IMenuItemActionProvider r_ActionProvider;

        public MenuItemWithAction(string i_Title, IMenuItemActionProvider i_ActionProvider) : base(i_Title)
        {
            if (i_ActionProvider == null)
            {
                throw new ArgumentNullException("Action provider cannot be null");
            }

            r_ActionProvider = i_ActionProvider;
        }

        public override void Activate(bool i_ClearConsole = false)
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
