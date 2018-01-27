using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnimation : MonoBehaviour {

    private Image image;
    public Sprite[] sprites;
    public Sprite[] chapters;

    void Start() {
        image = GetComponent<Image>();
    }

    public void Loading()
    {
        image.sprite = sprites[0];
    }

    public void Loading1()
    {
        image.sprite = sprites[1];
    }

    public void Loading2()
    {
        image.sprite = sprites[2];
    }

    public void Loading3()
    {
        image.sprite = sprites[3];
    }

    public void LoadChapter(int index)
    {
        image.sprite = chapters[index];
    }

}
