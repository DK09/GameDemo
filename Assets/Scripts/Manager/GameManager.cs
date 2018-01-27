using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int level;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField] private int arriveCount = 0;

    public bool pause = true;
    public GameObject loadingPrefab, canvasPrefab, pausePrefab;
    private Animation loadingAnim;
    private GameObject loading;
    private AsyncOperation op;

	// Use this for initialization
	void Awake() {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        GameObject canvas = Instantiate(canvasPrefab);
        loading = Instantiate(loadingPrefab);
        DontDestroyOnLoad(canvas);
        loading.transform.SetParent(canvas.transform);
        loadingAnim = loading.GetComponentInChildren<Animation>();
        loading.GetComponent<RectTransform>().localPosition = new Vector3(0, 450, 0);
        loading.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        GameObject pause = Instantiate(pausePrefab);
        pause.transform.SetParent(canvas.transform);
        pause.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
	}

    public void PlayerArrive()
    {
        arriveCount++;
        if (arriveCount == 2)
        {
            LoadNextLevel(level);
        }
    }

    public void Playerleave()
    {
        arriveCount--;
    }

    public void GamePause()
    {
        pause = true;
    }

    public void GameResume()
    {
        pause = false;
    }

    public void LoadNextLevel(int nowLevel)
    {
        pause = true;
        level = nowLevel + 1;
        if (level != 0) PlayerPrefs.SetInt("Level", level);
        if (level < SceneManager.sceneCountInBuildSettings)
        {
            loading.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 1);
            switch (level)
            {
                case 1:
                    loading.GetComponent<LoadingAnimation>().LoadChapter(0);
                    Invoke("LoadingWithOutAnim", 1f);
                    break;
                case 4:
                    loading.GetComponent<LoadingAnimation>().LoadChapter(1);
                    Invoke("LoadingWithOutAnim", 1f);
                    break;
                default:
                    loading.GetComponent<LoadingAnimation>().Loading();
                    Invoke("LoadingOn", 1f);
                    break;
            }
            loadingAnim.PlayQueued("FadeIn");
            op = SceneManager.LoadSceneAsync(level);
            op.allowSceneActivation = false;
        }
        else
        {
            LoadNextLevel(-1);
        }
    }

    private void LoadingOn()
    {
        if (op.isDone)
        {         
            loadingAnim.PlayQueued("FadeOut");
            if (level != 0) pause = false;
            Invoke("FinishLoad", 1f);
            arriveCount = 0;
        }
        else
        { 
            op.allowSceneActivation = true;
            loadingAnim.PlayQueued("Loading");
            Invoke("LoadingOn", 1.2f);
        }
    }

    private void LoadingWithOutAnim()
    {
        if (op.isDone)
        {         
            loadingAnim.PlayQueued("FadeOut");
            pause = false;
            Invoke("FinishLoad", 1f);
            arriveCount = 0;
        }
        else
        {
            op.allowSceneActivation = true;
            Invoke("LoadingWithOutAnim", 1f);         
        }
    }

    private void FinishLoad()
    {
        loading.GetComponent<RectTransform>().localPosition = new Vector3(0, 450, 0);
        switch (level)
        {
            case 0:
                BGMManager.Instance.ChangeBGM(0);
                break;
            default:
                BGMManager.Instance.ChangeBGM(1);
                break;
        }
    }
}
