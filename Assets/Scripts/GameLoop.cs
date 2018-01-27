using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private SceneStateController _sceneController;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _sceneController = new SceneStateController(this);
    }

    private void Update()
    {
        _sceneController.Update();
    }
}