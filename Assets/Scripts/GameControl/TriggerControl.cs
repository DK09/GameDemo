using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour {

    public SwitchControl[] switchControls;
    private Animation anim;
    private bool isTriggerOn = false; //是否与玩家接触
    private bool isTurn = false;  //是否已经触发

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !isTriggerOn)
        {
            if (isTurn)
            {
                anim.PlayQueued("TriggerTurn2");
            }
            else
            {
                anim.PlayQueued("TriggerTurn");
            }
            isTurn = !isTurn;
            Invoke("Turn", 0.25f);
            isTriggerOn = false;
        }
    }

    void OnTriggerLExit2D(Collider2D collider)
    {
        if (collider.tag == "Player" && isTriggerOn)
        {            
            isTriggerOn = true;
        }
    }

    void Turn()
    {
        foreach (SwitchControl switchControl in switchControls)
            switchControl.Turn();
    }
    
}
