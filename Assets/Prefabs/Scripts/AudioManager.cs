using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
	
	[SerializeField] AudioSource audioSource;
	
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}
	void Start()
	{
		DontDestroyOnLoad(audioSource.gameObject);
		audioSource.Play();
	}

	private bool isAudioMuted;
	public void MuteAudio()
    {
		isAudioMuted = !isAudioMuted;
		Toggler();
	}

	private void Toggler()
	{
		if (isAudioMuted)
		{
			audioSource.Stop();
		}
		else
		{
			audioSource.Play();
		}
	}


}
