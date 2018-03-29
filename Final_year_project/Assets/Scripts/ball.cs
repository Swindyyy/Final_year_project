using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ball : NetworkBehaviour {
	public Rigidbody rb;
    //float i = 1;

    private NetworkIdentity theNetID;

    [SerializeField]
    Vector3 startTurnPosition;

    bool stopMovement;
    Vector3 prevPosition;
    Vector3 prevRotation;

    void start(){
        //startTurnPosition = transform.position;
	}

    private void Update()
    {
        if ((transform.position.y - startTurnPosition.y) > 0.1f)
        {
            transform.position = new Vector3(transform.position.x, startTurnPosition.y + 0.045f, transform.position.z);
        }

        if (stopMovement)
        {
            if (prevPosition != null)
            {
                transform.position = prevPosition;
            }

            if(prevRotation != null)
            {
                transform.eulerAngles = prevRotation;
            }

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }

        prevPosition = transform.position;
        prevRotation = transform.eulerAngles;
    }

    public void SetStartTurnPosition(Vector3 _pos)
    {
        startTurnPosition = _pos;
    }

    public Vector3 GetStartTurnPosition()
    {
        //Debug.Log("Returning : " + startTurnPosition);
        return startTurnPosition;
    }

    public void SetStopMovement(bool _value)
    {
        stopMovement = _value;
    }

}
