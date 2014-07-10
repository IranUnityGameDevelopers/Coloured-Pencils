using UnityEngine;
using System.Collections;

public class Pencil : MonoBehaviour {

	public bool IsActive;

	public GameObject Body;

	public bool IsInASlot = false;

	public Slot slot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate()
	{
		if (!IsActive) {
			iTween.ScaleTo(gameObject , iTween.Hash("x" , 1.2f , "y" , 1.2f , "easetype" , iTween.EaseType.easeInOutElastic));
			IsActive = true;
		}

	}

	public void Deactivate()
	{
		if (IsActive) {
			iTween.ScaleTo(gameObject , iTween.Hash("x" , 1f , "y" , 1f , "easetype" , iTween.EaseType.linear));
			IsActive = false;
		}

	}

	public void SetColor(Color color)
	{
		Body.GetComponent<SpriteRenderer>().color = color;
//		Debug.Log(color);
	}

	public Color GetColor()
	{
		return Body.GetComponent<SpriteRenderer>().color;
	}
}
