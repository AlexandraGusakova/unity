using UnityEngine;

public class Rotate : MonoBehaviour
{
	public float speedH = 1f;
	public float speedV = 1f;

	private float yaw = 0f;
	private float pitch = 0f;

	void Update()
	{
		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0f);
	}
}