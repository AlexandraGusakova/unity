using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_object : MonoBehaviour {
	
	public AudioClip DestroySound;
	public AudioSource SelfAudioSource;
	
	public GameObject ObjectNew;
	public GameObject ObjectOld;
	// Use this for initialization
	
	void Awake()
	{
		SelfAudioSource = GetComponent<AudioSource>();
	}
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//SelfAudioSource.Stop();
	}
	
	void OnCollisionEnter(Collision col){
		
		if (col.collider.tag == "Destroy"){
			SelfAudioSource.PlayOneShot(DestroySound);
			ObjectNew.SetActive(true);
			ObjectOld.SetActive(false);
			
		}
	}	
}
