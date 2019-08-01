using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Scenes.MenuSceneStates
{
    public interface IMenuSceneState
    {
        MenuScene MenuScene { get; set; }
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Select();
        void GoBack();
        void Draw();
        void Update();
    }
}
