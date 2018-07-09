using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Script : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData eventData) {
		float red = Random.Range (.0f, 1.0f);
		float green = Random.Range (.0f, 1.0f);
		float blue = Random.Range (.0f, 1.0f);

		Color col1 = new Color(red, green, blue);

		gameObject.GetComponent<Renderer>().material.color = col1;
		// col1 - объектная перменная типа color из одноименного класса, принимающая 3 параметра: red, green, blue.

		// вектор определяет напарвление щелчка мышью по объекту
		Vector3 target = eventData.pointerPressRaycast.worldPosition;
		// pointerPressRaycast - задаёт направление на точку удара в глобальных координатах worldPositionсцены

		// вектор определяет направление удара как направление от камеры
		Vector3 collid = Camera.main.transform.position;

		int fors = 500;

		Vector3 direction = target - collid;
		direction = direction.normalized;

		// переменная определяющая силу удара
		collid = direction*fors;
		// вектор distance, forse задаёт силу удара

		gameObject.GetComponent<Rigidbody> ().AddForceAtPosition (collid, target);

	}

	// Use this for initialization
	//void Start () {}
	
	// Update is called once per frame
	//void Update () {}
}
