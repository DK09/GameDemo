using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndControl : MonoBehaviour {

    public Sprite[] sprites;
    private bool isActive = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !isActive)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            isActive = true;
            GameManager.Instance.PlayerArrive();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player" && isActive)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
            isActive = false;
            GameManager.Instance.Playerleave();
        }
    }
}
