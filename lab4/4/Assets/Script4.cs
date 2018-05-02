using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script4 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var currentRotation = new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0f);
        //фиксируем угол поворота по вертикали в диапозоне (заданным мин и мак значением)
        currentRotation.y = Mathf.Clamp(currentRotation.y, -1000, 1000);
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}