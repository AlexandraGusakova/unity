using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script5a : MonoBehaviour {
    public Rigidbody SelfRigidBody;
    // Use this for initialization
    void Start()
    {
        SelfRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(Vector3.back * 3f);
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(Vector3.forward * 3f);
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down * 3f);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * 3f);
    }
}
