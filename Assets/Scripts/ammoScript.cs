using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoScript : MonoBehaviour
{
    public float force;
    void Start()
    {
        transform.GetComponent<Rigidbody>().AddForce(Vector3.forward*force,ForceMode.Acceleration);
        Destroy(gameObject, 3);
    }

    
}
