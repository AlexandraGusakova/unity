using UnityEngine;
using UnityEngine.EventSystems;

public class Boxclick : MonoBehaviour, IPointerClickHandler
{
    public MeshRenderer SelfRenderer;
    public Rigidbody SelfRigidbody;
    public float HitForce = 1000f;

    public void Awake()
    {
        SelfRenderer = GetComponent<MeshRenderer>();
        SelfRigidbody = GetComponent<Rigidbody>();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        SelfRenderer.material.color = new Color(Random.Range(0f, 1f),
                                                Random.Range(0f, 1f),
                                                Random.Range(0f, 1f));

        var hitPosition = eventData.pointerPressRaycast.worldPosition;
        var cameraPosition = Camera.main.transform.position;

        var distance = (hitPosition - cameraPosition).normalized;

        SelfRigidbody.AddForceAtPosition(distance * HitForce, hitPosition);
    }
}