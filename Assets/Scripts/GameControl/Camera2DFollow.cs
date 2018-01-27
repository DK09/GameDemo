using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camera2DFollow : MonoBehaviour
{
    public Transform[] focuses;
    public Camera theOtherCamera;
    private Camera thisCamera;
    public float maxsize = 10;
    private float size = 6;
    private Transform target;
    public float damping = 1;
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;

    private float m_OffsetZ;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;
    private Vector3 m_LookAheadPos;

    // Use this for initialization
    private void Start()
    {
        target = focuses[0];
        m_LastTargetPosition = target.position;
        m_OffsetZ = (transform.position - target.position).z;
        transform.parent = null;
        thisCamera = GetComponent<Camera>();
    }


    // Update is called once per frame
    private void Update()
    {
        if (GameManager.Instance.pause) return;
        thisCamera.orthographicSize = Vector3.Slerp(new Vector3(0, 0, thisCamera.orthographicSize), new Vector3(0, 0, size), Time.deltaTime).z;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (target == focuses[0])
            {
                target = focuses[1];
                size = maxsize;
            }
            else
            {
                target = focuses[0];
                size = 6;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            theOtherCamera.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        // only update lookahead pos if accelerating or changed direction
        float xMoveDelta = (target.position - m_LastTargetPosition).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
        }
        else
        {
            m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

        transform.position = newPos;

        m_LastTargetPosition = target.position;
    }
}

