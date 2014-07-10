using UnityEngine;
using System.Collections;

public class MusicView : MonoBehaviour {

	public static MusicView Instance;

	void Awake()
	{
		Instance = this;
	}


	public AudioClip MainMusic;



	public void PlayMusic()
	{

	}
}
