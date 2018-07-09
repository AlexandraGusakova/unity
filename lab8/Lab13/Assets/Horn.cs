using UnityEngine;

public class Horn : MonoBehaviour
{
	public AudioClip HornSound;
	public AudioSource SelfAudioSource;

	void Awake()
	{
		SelfAudioSource = GetComponent<AudioSource>();
		SelfAudioSource.clip = HornSound;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.H))
			SelfAudioSource.Play();
		else if (Input.GetKeyUp(KeyCode.H))
			SelfAudioSource.Stop();
	}
}