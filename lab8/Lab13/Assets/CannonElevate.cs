using UnityEngine;

public class CannonElevate : MonoBehaviour
{
	public float ElevationSpeed = 50f;
	void Update()
	{
		transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0f, 0f) * ElevationSpeed * Time.deltaTime);

		if (transform.localRotation.x < -0.1f)
		{
			var temp = transform.localRotation;
			temp.x = -0.1f;
			transform.localRotation = temp;
		}
		else if (transform.localRotation.x > 0.1f)
		{
			var temp = transform.localRotation;
			temp.x = 0.1f;
			transform.localRotation = temp;
		}
	}
}