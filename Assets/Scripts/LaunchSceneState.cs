using DG.Tweening;
using UnityEngine.UI;

public class LaunchSceneState : SceneStateBase
{
    public override void Init()
    {
        base.Init();

        UITools.FindByPath("Logo").GetComponent<Image>()
            .DOFade(0f, 1f).From()
            .OnComplete(()=> Controller.SetState(GlobalDefine.MENU_SCENE));
    }
}