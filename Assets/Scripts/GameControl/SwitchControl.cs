using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour {

    public bool isTurned = false;

    public void Turn()
    {
        if (isTurned)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
        isTurned = !isTurned;
    }
}
