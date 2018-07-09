using UnityEngine;

public class Shutter : MonoBehaviour
{
	public void Rotate()
	{
		transform.Rotate(Vector3.up, 30f);
	}
}