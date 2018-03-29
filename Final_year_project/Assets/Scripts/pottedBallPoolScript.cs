using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pottedBallPoolScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GameObject colObject = other.gameObject;

        colObject.GetComponent<Rigidbody>().isKinematic = true;
        //colObject.GetComponent<Collider>().enabled = false;
        colObject.GetComponent<MeshRenderer>().enabled = false;
        colObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        colObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
