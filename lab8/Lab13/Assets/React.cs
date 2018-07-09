using UnityEngine;

public class React : MonoBehaviour
{
	public MeshRenderer SelfRenderer;

	public void Awake()
	{
		SelfRenderer = GetComponent<MeshRenderer>();
	}

	public void Change()
	{
		SelfRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
	}
}