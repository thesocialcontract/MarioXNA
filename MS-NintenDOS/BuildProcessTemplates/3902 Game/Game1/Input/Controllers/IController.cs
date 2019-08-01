using Microsoft.Xna.Framework.Input;
using Game1.Input.Commands;

namespace Game1.Input.Controllers
{
    interface IController : IUpdatable
    {
        void RegisterCommand(Keys keyPress, ICommand command);
        void RegisterReleaseCommand(Keys keyPress, ICommand command);
        void SetDisabled(bool Disability);
    }
}
