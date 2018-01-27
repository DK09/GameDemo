using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuSceneState : SceneStateBase
{
    private Button _startBtn;
    private Button _continueBtn;
    private Button _settingBtn;
    private Button _exitBtn;

    public override void Init()
    {
        base.Init();

        RectTransform _buttonRoot = UITools.FindByPath("Button");
        var _startBtnRT = UITools.FindByPath(_buttonRoot, "StartButton");
        _startBtn = UITools.FindByPath(_buttonRoot, "StartButton").GetComponent<Button>();
        
        _startBtn.onClick.AddListener(() => 
            {
                Controller.SetState(GlobalDefine.LEVEL_SCENE_1);
            }
        );

        _continueBtn = UITools.FindByPath(_buttonRoot, "ContinueButton").GetComponent<Button>();
        _settingBtn = UITools.FindByPath(_buttonRoot, "SettingButton").GetComponent<Button>();
        _exitBtn = UITools.FindByPath(_buttonRoot, "ExitButton").GetComponent<Button>();
    }
}