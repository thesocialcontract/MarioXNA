using Game1.Input.Commands;
using Game1.WorldLoading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Input
{
    public class CheatHandler
    {
        private Queue<string> keySequence;
        private Dictionary<string[], ICommand> cheats;
        private IWorld world;

        public CheatHandler(IWorld world)
        {
            this.world = world;
            ClearKeySequence();
            RegisterCheats();
        }

        public void ClearKeySequence()
        {
            keySequence = new Queue<string>();
            for (int i = 0; i < 8; i++)
            {
                keySequence.Enqueue("");
            }
        }

        public void Enter(string key)
        {
            keySequence.Dequeue();
            keySequence.Enqueue(key);
            CheckForCheat();
        }

        public void CheckForCheat()
        {
            string[] keyArray = keySequence.ToArray();
            if (cheats.ContainsKey(keyArray))
            {
                cheats[keyArray].Execute();
            }
        }

        private void RegisterCheats()
        {
            cheats = new Dictionary<string[], ICommand>(new StringArrayComparer());
            string[] sequence;

            //Cheat 1 - Star Mario
            sequence = new string[] { "T", "T", "G", "G", "F", "H", "F", "H"};
            cheats.Add(sequence, new StarCheatCommand(world));

            //Cheat 2 - Extra Life
            sequence = new string[] { "T", "G", "F", "H", "H", "F", "G", "T" };
            cheats.Add(sequence, new ExtraLifeCheatCommand(world));

            //Cheat 3 - Take Damage
            sequence = new string[] { "T", "F", "G", "H", "T", "F", "G", "H" };
            cheats.Add(sequence, new TakeDamageCheatCommand(world));

            //Cheat 4 - Set Big
            sequence = new string[] { "T", "H", "G", "F", "T", "H", "G", "F" };
            cheats.Add(sequence, new SetBigCheatCommand(world));

            //Cheat 5 - Set Fire
            sequence = new string[] { "G", "G", "F", "H", "T", "T", "H", "F" };
            cheats.Add(sequence, new SetFireCheatCommand(world));

            //Cheat 6 - Win Level
            sequence = new string[] { "T", "H", "F", "G", "T", "T", "T", "T" };
            cheats.Add(sequence, new WinCheatCommand(world));
        }

        internal class StringArrayComparer : IEqualityComparer<string[]>
        {
            public bool Equals(string[] x, string[] y)
            {
                int length = x.Length;
                if (length != y.Length)
                {
                    return false;
                }
                for(int i = 0; i < length; i++)
                {
                    if(x[i] != y[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            public int GetHashCode(string[] obj)
            {
                return 0;
            }
        }
    }
}
