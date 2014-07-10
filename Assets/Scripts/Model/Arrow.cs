using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public GameObject Body;

	private bool _Enabled = false;

	public ArrowDirection Direction;
	
	public void SetColor(Color color)
	{
		Body.GetComponent<SpriteRenderer>().color = color;
		//		Debug.Log(color);
	}

	public void Enable()
	{
		_Enabled = true;
	}

	public void ArrowAnimationDown()
	{
		//iTween.MoveBy(Body , iTween.Hash("y" , -0.08f , "time" , 0.1f));
		iTween.ScaleTo(Body , iTween.Hash("x" , 1.2f , "y" , 1.2f , "time" , 0.1f));
	}

	public void ArrowAnimationReverseUP()
	{
		//iTween.MoveBy(Body , iTween.Hash("y" , 0.08f , "time" , 0.1f ));
		iTween.ScaleTo(Body , iTween.Hash("x" , 1f , "y" , 1f , "time" , 0.1f));
	}

}


public enum ArrowDirection{

	LeftArrow ,
	RightArrow
}
