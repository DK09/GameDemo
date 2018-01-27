public class LaunchSceneState : SceneStateBase
{
    public override void Init()
    {
        base.Init();

        Controller.SetState(GlobalDefine.MENU_SCENE);
    }
}