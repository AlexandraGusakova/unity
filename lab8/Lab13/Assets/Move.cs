using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public float MaxSpeed = 17000f, DrivingSpeed = 0f, TurningSpeed = 0.5f, Acceleration = 20f, Decceleration = 10f;

	public Rigidbody SelfRigidbody;
	public AudioSource SelfAudioSource;
	public AudioClip Idle, Start, Drive, Stop, Village;

	public KeyCode[] Keys = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };
	public Dictionary<KeyCode, bool> Directions = new Dictionary<KeyCode, bool>();

	public bool IsDriving = false, WasDriving = false, PanelVisible = true, LightsEnabled = false;

	public Light[] Lights;
	
	public Transform child;
	
	public GameObject[] levels;

	void OnGUI()
	{
		if (PanelVisible)
		{
			GUI.Box(new Rect(50, 50, 200, 150), GUIContent.none);
			GUI.Label(new Rect(100, 75, 100, 20), "Скорость");
			MaxSpeed = GUI.HorizontalSlider(new Rect(100, 100, 100, 10), MaxSpeed, 0f, 7000f);
			DrivingSpeed = Mathf.Clamp(DrivingSpeed, -MaxSpeed, MaxSpeed);
			LightsEnabled = GUI.Toggle(new Rect(100, 130, 100, 20), LightsEnabled, "Свет");
			GUI.Label(new Rect(100, 150, 100, 20), "Громкость");
			SelfAudioSource.volume = GUI.HorizontalSlider(new Rect(100, 170, 100, 10), SelfAudioSource.volume, 0f, 1f);
		}
	}
	
	void OnTriggerEnter(Collider col){
        if (col.gameObject.name == "village")
            SelfAudioSource.loop = true;
			SelfAudioSource.clip = Village;
			SelfAudioSource.Play();
    }

    void OnTriggerExit(Collider col){
        if (col.gameObject.name == "village")
            SelfAudioSource.loop = true;
			SelfAudioSource.clip = Village;
			SelfAudioSource.Stop();
    }

	void Awake()
	{
		/*
		levels = GameObject.FindGameObjectsWithTag("house");

			foreach (GameObject level in levels)
			{			
						
						level.gameObject.SetActive(false);
			}*/
		foreach (var key in Keys)
			Directions.Add(key, false);

		SelfRigidbody = GetComponent<Rigidbody>();
		SelfAudioSource = GetComponent<AudioSource>();

		SelfAudioSource.loop = true;
		SelfAudioSource.clip = Idle;
		SelfAudioSource.Play();
	}
	
		/*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "huts")
        {
		
			levels = GameObject.FindGameObjectsWithTag("huts");

			foreach (GameObject level in levels)
			{
				foreach (Transform childs in level.transform)
				{
					
						Transform house = childs.Find("house");
						house.gameObject.SetActive(false);
					
				}
			}
			col.gameObject.transform.GetChild(1).gameObject.SetActive(true);
			col.gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
        if (col.gameObject.name == "car")
        { //col.gameObject.GetComponent<Renderer>().material.color = color2; 
	}
    }	*/

	void Update()
	{
		foreach (var light in Lights)
			light.enabled = LightsEnabled;

		IsDriving = false;
		WasDriving = false;

		foreach (var key in Keys)
		{
			if (Directions[key])
				WasDriving = true;
			if (Input.GetKey(key))
			{
				IsDriving = true;
				Directions[key] = true;
			}
			else
				Directions[key] = false;
		}

		if (Directions[KeyCode.W])
		{
			if (DrivingSpeed < MaxSpeed)
				DrivingSpeed += Acceleration;
		}
		else
		{
			if (DrivingSpeed > 0f)
				DrivingSpeed -= Decceleration;
		}
		if (Directions[KeyCode.S])
		{
			if (DrivingSpeed > -MaxSpeed)
				DrivingSpeed -= Acceleration;
		}
		else
		{
			if (DrivingSpeed < 0f)
				DrivingSpeed += Decceleration;
		}

		SelfRigidbody.AddRelativeForce(Vector3.forward * DrivingSpeed * Time.deltaTime, ForceMode.Acceleration);

		if (Directions[KeyCode.A])
			transform.Rotate(Vector3.up, -TurningSpeed);
		if (Directions[KeyCode.D])
			transform.Rotate(Vector3.up, TurningSpeed);
		
		if (!WasDriving && IsDriving)
		{
			SelfAudioSource.Stop();

			SelfAudioSource.clip = Drive;
			SelfAudioSource.Play();

			SelfAudioSource.PlayOneShot(Start);
		}
		else if (WasDriving && !IsDriving)
		{
			SelfAudioSource.Stop();

			SelfAudioSource.clip = Idle;
			SelfAudioSource.Play();

			SelfAudioSource.PlayOneShot(Stop);
		}

		if (Input.GetKeyDown(KeyCode.Tab))
			PanelVisible = !PanelVisible;
	}
}