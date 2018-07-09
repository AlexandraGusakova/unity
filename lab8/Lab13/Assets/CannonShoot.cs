using UnityEngine;

public class CannonShoot : MonoBehaviour
{
	public AudioSource SelfAudioSource;
	public GameObject Explosion;
	public AudioClip ShotSound, ExplosionSound;
	
	void Awake()
	{
		SelfAudioSource = GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SelfAudioSource.PlayOneShot(ShotSound);

			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit))
			{
				Instantiate(Explosion, hit.point, Quaternion.identity);
				SelfAudioSource.PlayOneShot(ExplosionSound);
			}
		}
	}
}