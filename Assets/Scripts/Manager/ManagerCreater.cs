using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCreater : MonoBehaviour {

    public GameObject gameManagerPrefab, bgmManagerPrefab;
    private static bool haveManagers = false;

	// Use this for initialization
	void Awake() {
        if (!haveManagers)
        {
            GameObject gameManager = Instantiate(gameManagerPrefab);
            GameObject bgmManager = Instantiate(bgmManagerPrefab);
            haveManagers = true;
        }
	}
}
