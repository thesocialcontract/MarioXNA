using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class RisingTextManager
    {
        

        int CurrentText;
        SpriteFont RisingTextFont;
        

        private IRisingText[] TextList;
        
        
        public RisingTextManager()
        {
                        
            TextList = new IRisingText[5];
            CurrentText = 0;


        }
        public static RisingTextManager Instance { get; set; } = new RisingTextManager();

        public static RisingTextManager ResetTEXT(SpriteFont InputSpriteFont)
        {
            
            Instance.RisingTextFont = InputSpriteFont;
            
            
            Instance.TextList = new IRisingText[5];
            Instance.CurrentText = 0;
            for (int i = 0; i < 5; i++)
            {
                Instance.TextList[i] = new RisingText(Instance.RisingTextFont);
            }
            return Instance;
        }
                

        public void Update()
        {

            foreach(IRisingText item in TextList)
            {
                item.Update();
            }
                        
        }

        public void Draw()
        {
            
            foreach (IRisingText item in TextList)
            {
                item.Draw();
            }

           
        }

        public void AddRisingText(int Value, Vector2 TextPosition)
        {
            
            TextList[CurrentText] = new RisingText(RisingTextFont, TextPosition, Value);
            CurrentText++;
            if(CurrentText > 4)
            {
                CurrentText = 0;
            }
        }

    }
}
