using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script2a : MonoBehaviour {
    public Quaternion startPosition;
    public float delta;
    public Transform cube;

    // Use this for initialization
    void Start () {
        transform.rotation = Quaternion.identity;
    }
	
	// Update is called once per frame
	void Update () {
        delta = 1;
        transform.Rotate(new Vector3(delta, 0, delta), Space.Self);
    }
}
