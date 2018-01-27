using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour {

    public Button btnContinue;
    public Slider sliderBGM;
    public Animation startCheckAnim;
    public Animation settingAnim;

    private int level;

    void Start()
    {
        level = PlayerPrefs.GetInt("Level", 0);
        sliderBGM.value = PlayerPrefs.GetFloat("BGMValue", 1);
        if (level == 0 || level >= SceneManager.sceneCountInBuildSettings)
        {
            btnContinue.interactable = false;
        }
    }

    public void GameStart()
    {
        if (level != 0 && level < SceneManager.sceneCountInBuildSettings)
        {
            startCheckAnim.PlayQueued("UIEnlarge");
        }
        else
        {
            GameManager.Instance.LoadNextLevel(0);
        }
    }

    public void YesClick()
    {
        GameManager.Instance.LoadNextLevel(0);
    }

    public void NoClick()
    {
        startCheckAnim.PlayQueued("UIShrink");
        Invoke("StartCheckShrink", 0.4f);
    }

    private void StartCheckShrink()
    {
        startCheckAnim.GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
    }

    public void GameSetting()
    {
        settingAnim.Stop();
        settingAnim.PlayQueued("UIEnlarge");
    }

    public void ReturnClick()
    {
        settingAnim.PlayQueued("UIShrink");
        Invoke("SettingShrink", 0.4f);
    }

    private void SettingShrink()
    {
        settingAnim.Stop();
        settingAnim.GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
    }

    public void ChangeBGMValue()
    {
        BGMManager.Instance.SetValue(sliderBGM.value);
        PlayerPrefs.SetFloat("BGMValue", sliderBGM.value);
    }

    public void ContinueGame()
    {
        GameManager.Instance.LoadNextLevel(level - 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
