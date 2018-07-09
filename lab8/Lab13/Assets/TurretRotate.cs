using UnityEngine;

public class TurretRotate : MonoBehaviour
{
	public AudioClip TurretSound;
	public AudioSource SelfAudioSource;
	public float RotationSpeed = .1f;
	
	void Awake()
	{
		SelfAudioSource = GetComponent<AudioSource>();
		SelfAudioSource.PlayOneShot(TurretSound);
	}
	
	void Update()
	{
		transform.Rotate(new Vector3(0f, 0f, Input.GetAxis("Mouse X")) * RotationSpeed * Time.deltaTime);
		
	}
}