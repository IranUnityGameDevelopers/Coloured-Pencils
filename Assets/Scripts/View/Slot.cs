using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour
{
	public bool IsEmpty = true;

	public Pencil pencil;


	public void AddPencil(Pencil pen , float animationSpeed)
	{
		pencil = pen;
		pen.IsInASlot = true;
		//pen.gameObject.transform.position = transform.position;
		iTween.MoveTo(pen.gameObject , iTween.Hash("x" , transform.position.x ,
		                                           "y" , transform.position.y ,
		                                           "z" , transform.position.z , 
		                                           "time" , animationSpeed));

		IsEmpty = false;
	}

	public void RemovePencil()
	{
		IsEmpty = true;
		pencil.IsInASlot = false;
		iTween.PunchScale(pencil.gameObject , iTween.Hash("x" , 0.5f , "y" , 0.5f ));
		pencil = null;
	}
}

