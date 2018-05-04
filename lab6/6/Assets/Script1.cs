using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour {
    float radius = 1.5f; // радиус зоны обработки

    public float Speed = 5f;

    public float speedH = 4f;
    public float speedV = 4f;

    private float x = 0f;
    private float y = 0f;

    public Light l1;
    public Light l2;

    public bool window = false;

    public GameObject stavnay;

    void OnTriggerEnter(Collider col){
        if (col.name == "Trigger")
        {
            l1.enabled = true;
            l1.color = Color.blue;
            l2.color = Color.red;
        }
        else if (col.name == "Window")
        {
            window = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.name == "Trigger")
        {   l1.enabled = false;
            l2.color = Color.green;
            l2.transform.position = new Vector3(51, 3, 20);
        }
        else if (col.name == "Window")
        {
            window = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.name == "Trigger")
        {
            l2.transform.position += new Vector3(0.1f, 0, 0);
        }
    }


    void Awake(){
        l1.enabled = false;
        Cursor.visible = false;
        l2.color = Color.green;
    }

    void OnCollisionEnter(Collision col)
    {
        Color color1 = new Color(1, 0, 0);
        Color color2 = new Color(0, 0, 1);
        if (col.gameObject.name == "Cube1")
        { col.gameObject.GetComponent<Renderer>().material.color = color1; }
        if (col.gameObject.name == "Cube2")
        { col.gameObject.GetComponent<Renderer>().material.color = color2; }
    }

    void OnCollisionExit(Collision col)
    {
        Color color = new Color(1, 1, 1);
        if (col.gameObject.name == "Cube1")
        { col.gameObject.GetComponent<Renderer>().material.color = color; }
        if (col.gameObject.name == "Cube2")
        { col.gameObject.GetComponent<Renderer>().material.color = color; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x += speedH * Input.GetAxis("Mouse X");
        y -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(Mathf.Clamp(y, -45f, 0f), x, 0f);

        if (Input.GetKey(KeyCode.E) && window == true)
        {
            stavnay.transform.position = new Vector3(26, 1, 23);
        }
        else if (Input.GetKey(KeyCode.Q) && window == true)
        {
            stavnay.transform.position = new Vector3(26, 3, 23);
        }
        else if (Input.GetKey(KeyCode.D))
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
