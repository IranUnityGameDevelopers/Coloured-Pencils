using UnityEngine;
using System.Collections;

public class TextView : MonoBehaviour {
	public static TextView Instance;
		
	void Awake()
	{
		Instance = this;
	}

	public void ShowText()
	{

	}
}
