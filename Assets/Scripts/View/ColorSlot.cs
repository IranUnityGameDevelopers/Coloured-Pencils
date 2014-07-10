using UnityEngine;
using System.Collections;

public class ColorSlot : MonoBehaviour {

	public GameObject Body;

	public void SetColor(Color color)
	{
		Body.GetComponent<SpriteRenderer>().color = color;
	}

	public Color GetColor()
	{
		return Body.GetComponent<SpriteRenderer>().color;
	}

	public void MoveIn()
	{

	}

	public void MoveOut()
	{

	}
}
