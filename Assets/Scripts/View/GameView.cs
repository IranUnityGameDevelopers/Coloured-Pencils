using UnityEngine;
using System.Collections;

public class GameView : MonoBehaviour
{

		public static GameView Instance;
		public BackGroundEffects Background;
		public Pencil ActivePencil;

		void Awake ()
		{
				Instance = this;
		}

		public void Init ()
		{
				GameHandler.Instance.LeftArrow.Enable ();
				GameHandler.Instance.RightArrow.Enable ();
		}

		public void RenewColorSlots ()
		{

		}

		public void RenewPencils ()
		{

		}

		public void SelectedItem (RaycastHit hit, SelectionType Stype)
		{
				// to Do Somthing
				switch (hit.collider.gameObject.tag) {
				case "Pencil":
						break;
				case "Slot":
						SetActivePencil (hit.collider.gameObject.GetComponent<Slot> ().pencil);
						break;
				case "Arrow":
						ArrowMove (hit.collider.gameObject.GetComponent<Arrow> () , Stype);
						break;
				case "ColorSlot":
						break;
				default:
						break;
				}
		}

		public void SetActivePencil (Pencil pen)
		{
				if (ActivePencil == pen) {
						return;
				}
				if (ActivePencil != null) {
						ActivePencil.Deactivate ();
				}
				ActivePencil = pen;
				SetArrowsColors(pen.GetColor());
				pen.Activate ();
		}

	void ArrowMove (Arrow arrow , SelectionType stype)
	{
		Debug.Log(arrow.Direction);
		if (stype == SelectionType.ButtonDown) {
			if (arrow.Direction == ArrowDirection.LeftArrow) {
				Debug.Log("HAHAHAHHa Left Arrow");
				arrow.ArrowAnimationDown();
				GameHandler.Instance.MovePencilLeft (ActivePencil);
			} else {
				arrow.ArrowAnimationDown();
				GameHandler.Instance.MovePencilRight (ActivePencil);
			}
		}
		else if (stype == SelectionType.ButtonUP) {
			if (arrow.Direction == ArrowDirection.LeftArrow) {
				arrow.ArrowAnimationReverseUP();
				GameHandler.Instance.MovePencilLeft (ActivePencil);
				Debug.Log("HAHAHAHHa Left Arrow");
			} else if (arrow.Direction == ArrowDirection.RightArrow) {
				arrow.ArrowAnimationReverseUP();
				GameHandler.Instance.MovePencilRight (ActivePencil);
				Debug.Log("HAHAHAHHa Right Arrow");
			}
				
			
		}


	}

	void SetArrowsColors(Color color)
	{
		GameHandler.Instance.LeftArrow.SetColor(color);
		GameHandler.Instance.RightArrow.SetColor(color);
	}



}
