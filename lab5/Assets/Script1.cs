using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour {
    public float Speed = 5f;

    public float speedH = 4f;
    public float speedV = 4f;

    private float x = 0f;
    private float y = 0f;

    public Light l1;
    public Light l2;

    void OnTriggerEnter(Collider col){
        if (col.gameObject.name == "Trigger")
            l1.enabled = true;
            l2.color = Color.red;
    }

    void OnTriggerExit(Collider col){
        if (col.gameObject.name == "Trigger")
            l1.enabled = false;
            l2.color = Color.green;
    }

    void Awake(){
        l1.enabled = false;
        Cursor.visible = false;
        l2.color = Color.green;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x += speedH * Input.GetAxis("Mouse X");
        y -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(Mathf.Clamp(y, -45f, 0f), x, 0f);



        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }
    }
}
