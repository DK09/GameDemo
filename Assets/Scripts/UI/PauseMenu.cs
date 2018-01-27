using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void GamePause()
    {
        anim.PlayQueued("UIEnlarge");
        GameManager.Instance.GamePause();
    }

    public void GameResume()
    {
        anim.PlayQueued("UIShrink");
        GameManager.Instance.GameResume();
        Invoke("PauseShrink", 0.4f);
    }

    private void PauseShrink()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
    }

    public void GameRestart()
    {
        GameManager.Instance.LoadNextLevel(PlayerPrefs.GetInt("Level") - 1);
        PauseShrink();
    }

    public void ReturnTitle()
    {
        GameManager.Instance.LoadNextLevel(-1);
        PauseShrink();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.pause)
        {
            GamePause();
        }
    }

}
