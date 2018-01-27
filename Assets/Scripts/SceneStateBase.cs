public abstract class SceneStateBase
{
    public static SceneStateController Controller { get; set; }

    public static SceneStateBase CreateSceneState(string sceneName)
    {
        SceneStateBase sceneState = null;
        switch (sceneName)
        {
            case GlobalDefine.LAUNCH_SCENE:
                sceneState = new LaunchSceneState();
                break;
            case GlobalDefine.MENU_SCENE:
                sceneState = new MainMenuSceneState();
                break;
            case GlobalDefine.LEVEL_SCENE_1:
                sceneState = new Level1_SceneState();
                break;
        }

        return sceneState;
    }

    public virtual void Init()
    {

    }

    public virtual void Reclaim()
    {

    }

    public virtual void Update()
    {

    }
}