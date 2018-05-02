using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script5 : MonoBehaviour {
    public GameObject Cube;
    private Bounds SelfBounds;

    // Use this for initialization
    void Start()
    {
        SelfBounds = GetComponent<MeshRenderer>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var x = Random.Range(SelfBounds.min.x, SelfBounds.max.x);
            var y = 6f;
            var z = Random.Range(SelfBounds.min.z, SelfBounds.max.z);

            Instantiate(Cube, new Vector3(x, y, z), new Quaternion());
        }
    }
}
