using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	void FixedUpdate()
	{
		bool HaveInput = false;
		Vector2 FinalInput = new Vector2(-100,-100);
		SelectionType Stype  = SelectionType.ButtonUP;

		if (Input.touchCount > 0) 
		{
			HaveInput = true;
			Touch touch = Input.GetTouch(0);

			switch (touch.phase) {
			case TouchPhase.Began :
				Stype = SelectionType.ButtonDown;
				FinalInput = touch.position;
				break;
			case TouchPhase.Ended :
				Stype = SelectionType.ButtonUP;
				FinalInput = touch.position;
				break;
			case TouchPhase.Moved :
				Stype = SelectionType.ButtonDrag;
				FinalInput = touch.position;
				break;
			default:
				HaveInput = false;
			break;
			}
		}
		else {		//mouse
			if (Input.GetMouseButtonDown(0)) {
				FinalInput = Input.mousePosition;
				Stype = SelectionType.ButtonDown;
				HaveInput = true;
			}		
		}


		if (HaveInput) 
		{
			SelectionPositionandType(Stype , FinalInput);
		}

	}


	void SelectionPositionandType(SelectionType selection, Vector2 InputVector)
	{
		Ray ray = Camera.main.ScreenPointToRay(InputVector);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			Debug.DrawLine(ray.origin, hit.point);
//			Debug.Log("haha" + hit.transform.name);
			GameView.Instance.SelectedItem(hit , selection);
			//hit.transform.GetComponent<Slot>().ActivatePencil();
		}
	}
}


public enum SelectionType
{
	ButtonDown , 
	ButtonUP, //dar 2 soorate avval InputVector hamoon position hastesh
	ButtonDrag // dar in soorat InputVector hamoon deltaPosition hastesh
}
