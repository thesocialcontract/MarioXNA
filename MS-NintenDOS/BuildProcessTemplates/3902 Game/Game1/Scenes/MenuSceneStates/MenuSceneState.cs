using Game1.Rendering.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Scenes.MenuSceneStates
{
    public abstract class MenuSceneState : IMenuSceneState
    {
        public MenuScene MenuScene { get; set; }
        protected List<Button> Buttons { get; set; }
        protected int HoveredButtonIndex { get; set; }

        public MenuSceneState(MenuScene menuScene)
        {
            MenuScene = menuScene;
            HoveredButtonIndex = -1;
            Buttons = new List<Button>();
        }
        public virtual void Draw()
        {

            foreach(Button button in Buttons)
            {
                button.Draw(MenuScene.Game.spriteBatch, MenuScene.MenuText);
            }
        }

        public virtual void GoBack() { }

        public virtual void MoveDown()
        {
            if(HoveredButtonIndex >= 0 && HoveredButtonIndex < Buttons.Count)
            {
                Buttons[HoveredButtonIndex].IsHovered = false;
            }
            HoveredButtonIndex++;
            if (HoveredButtonIndex >= Buttons.Count())
            {
                HoveredButtonIndex = 0;
            } 
            Buttons[HoveredButtonIndex].IsHovered = true;
        }

        public virtual void MoveLeft() { }

        public virtual void MoveRight() { }

        public virtual void MoveUp()
        {
            if (HoveredButtonIndex >= 0 && HoveredButtonIndex < Buttons.Count)
            {
                Buttons[HoveredButtonIndex].IsHovered = false;
            }
            HoveredButtonIndex--;
            if(HoveredButtonIndex < 0)
            {
                HoveredButtonIndex = Buttons.Count()-1;
            }
            Buttons[HoveredButtonIndex].IsHovered = true;
        }

        public virtual void Select()
        {
            if (HoveredButtonIndex >= 0 && HoveredButtonIndex < Buttons.Count)
            {
                Buttons[HoveredButtonIndex].Select();
            }
        }

        public virtual void Update() { }
    }
}
