using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class soundManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource bowSound;
	public AudioSource bowShoot;
	public AudioSource closeDoor;
	public AudioSource lifeUp;
	public AudioSource monsterGroan;
	public AudioSource BossGroan;
	public AudioSource openDoor;
	public AudioSource chestOpen;
	public AudioSource MusicSource;
	public AudioSource BossMusic;
	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;
	// Singleton instance.
	public static soundManager Instance = null;
	
	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}
	// Play a single clip through the sound effects source.
	public void Play(int audio)
	{
		if (audio==1)bowSound.Play();
		if (audio==2)bowShoot.Play();
		if (audio==3)closeDoor.Play();
		if (audio==4)lifeUp.Play();
		if (audio==5)monsterGroan.Play();
		if (audio==6)BossGroan.Play();
		if (audio==7)openDoor.Play();
		if (audio==8)chestOpen.Play();
	}
	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}
	public void BossFigth()
	{
		MusicSource.Stop();
		BossMusic.Play();
	}
	// Play a random clip from an array, and randomize the pitch slightly.
	
}