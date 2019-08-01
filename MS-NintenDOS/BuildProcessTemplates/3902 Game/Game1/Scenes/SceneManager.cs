namespace Game1.Scenes
{
    public class SceneManager
    {
        public IScene CurrentScene { get; set; }
        public IScene PreviousScene { get; set; }
        public static SceneManager Instance { get; } = new SceneManager();
        public Game1 Game { get; set; }

        private SceneManager()
        {

        }
        public void LoadScene(IScene scene)
        {
            PreviousScene = CurrentScene;
            CurrentScene?.UnloadScene();
            scene.LoadScene();
            CurrentScene = scene;
        }
        public void Draw()
        {
            CurrentScene.Draw();
        }
        public void Update()
        {
            CurrentScene.Update();
        }
        public void ReloadScene()
        {
            CurrentScene.UnloadScene();
            CurrentScene.LoadScene();
        }
        public void LoadPreviousScene()
        {
            CurrentScene.UnloadScene();
            CurrentScene = PreviousScene;
            CurrentScene.LoadScene();
        }
    }
}
