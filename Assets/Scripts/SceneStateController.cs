using System;
using System.Collections;

public class SceneStateController
{
    private GameLoop _gameLoop;
    private SceneStateBase _state;
    private bool _isLoadingScene = false;

    public SceneStateController(GameLoop gameLoop)
    {
        SceneStateBase.Controller = this;

        _gameLoop = gameLoop;
        _state = SceneStateBase.CreateSceneState(GlobalDefine.LAUNCH_SCENE);
        _state.Init();
    }

    public void Update()
    {
        if (_isLoadingScene) return;
        _state.Update();
    }

    public void SetState(string sceneName)
    {
        _gameLoop.StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        var asyncOp = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        _isLoadingScene = true;

        while (!asyncOp.isDone)
        {
            yield return null;
        }

        _state.Reclaim();

        var nextState = SceneStateBase.CreateSceneState(sceneName);

        nextState.Init();
        _state = nextState;
        _isLoadingScene = true;
    }
}
