using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameHandler : MonoBehaviour {

	public static GameHandler Instance;

	public List<Pencil> Pencils;
	public List<Slot> Slots; 
	public List<ColorSlot> ColorSlots;

	public int numberOfPencils;

	public GameObject pencilPrefab;
	public GameObject ColorSlotPrefab;
	public GameObject SlotPrefab;


	public Arrow LeftArrow;
	public Arrow RightArrow;


	public Camera MainCamera;



	void Awake()
	{
		Instance = this;
		ColorSlots = new List<ColorSlot>();
		Pencils = new List<Pencil>();
		Slots = new List<Slot>();

		InitializeSlots();
		InitializePencils();
		InitializeColorSlots();
		InitializeArrows();
	}



	void InitializeSlots()
	{
		float slotStep = 1f / (numberOfPencils - 2 + 1);

//		Debug.Log("SS : " + slotStep);
		for (int i = 2; i < numberOfPencils; i++) {
			GameObject g = Instantiate(SlotPrefab) as GameObject;
			Vector3 colSize = new Vector3( slotStep * 9 , 9.94f , 1);
//			Debug.Log("colSize.x : " + colSize.x);
			g.GetComponent<BoxCollider>().size = colSize;
			g.name = "Slot_" + i;
		//	g.transform.position = MainCamera.ViewportToWorldPoint(new Vector3(i * slotStep, 0.5f, 1));
		 	g.transform.position =	MainCamera.ScreenToWorldPoint(new Vector3((i -2 +1)* slotStep * Screen.width
			                                                                 , 0.5f * Screen.height 
			                                                                 , 1));
			Slots.Add(g.GetComponent<Slot>());
				//new Vector3( i * slotStep, 0 , 1);
		}
	} 

	void InitializePencils()
	{
		float colorStep = (float) 6 / (float)(numberOfPencils - 2 + 1);
//		Debug.Log("colorStep : " + colorStep);
		for (int i = 1; i < numberOfPencils - 1; i++) {

			GameObject gb = Instantiate(pencilPrefab) as GameObject;

			//gb.transform.position = new Vector3(3 * i - 3 , 0 , 0);

			Pencils.Add(gb.GetComponent<Pencil>());

			gb.name = "Pencil_" + i;

			if ( (i * colorStep) < 1) {
				float temp = (i * colorStep);
				gb.GetComponent<Pencil>().SetColor(new Color(1 ,0 ,temp));
			}
			else if ((i * colorStep) >= 1 && (i * colorStep) < 2) {
				float temp = 1 - (i * colorStep - 1);
				gb.GetComponent<Pencil>().SetColor(new Color(temp,0 ,1));
			}
			else if ((i * colorStep) >= 2 && (i * colorStep) < 3) {
				float temp = (i * colorStep - 2);
				gb.GetComponent<Pencil>().SetColor(new Color(0 ,temp , 1 ));
			}
			else if ((i * colorStep) >= 3 && (i * colorStep) < 4) {
				float temp = 1 - (i * colorStep - 3);
				gb.GetComponent<Pencil>().SetColor(new Color(0 , 1 ,temp));
			}
			else if ((i * colorStep) >= 4 && (i * colorStep) < 5) {
				float temp = (i * colorStep - 4);
				gb.GetComponent<Pencil>().SetColor(new Color(temp , 1 ,0));
			}
			else if ((i * colorStep) >= 5 && (i * colorStep) < 6) {
				float temp = 1 - (i * colorStep - 5);
				gb.GetComponent<Pencil>().SetColor(new Color(1 ,temp, 0));
			}

		}

		// put in random slot
		RandomizePencils();
	}



	public void RandomizePencils()
	{
//Debug.Log("SC : " + Slots.Count);
//		Debug.Log("PC : " + Pencils.Count);
		for (int slotsCount = Slots.Count - 1 ; slotsCount >= 0;) 
		{
			int random =  Random.Range(0 , Slots.Count);
			 if (!Pencils[random].IsInASlot) {
				Slots[slotsCount].AddPencil(Pencils[random] , 2);
				Pencils[random].slot = Slots[slotsCount];
//				Debug.Log( Slots[slotsCount].gameObject.name);
				slotsCount--;
			 }
		}
	}

	void InitializeColorSlots()
	{
		float colorStep = (float) 6 / (float)(numberOfPencils - 2 + 1);
		for (int i = 1; i < numberOfPencils - 1; i++) {
			GameObject gb = Instantiate(ColorSlotPrefab) as GameObject;
			ColorSlots.Add(gb.GetComponent<ColorSlot>());
			gb.name = "ColorSlot_" + i;
			if ( (i * colorStep) < 1) {
				float temp = (i * colorStep);
				gb.GetComponent<ColorSlot>().SetColor(new Color(1 ,0 ,temp));
			}
			else if ((i * colorStep) >= 1 && (i * colorStep) < 2) {
				float temp = 1 - (i * colorStep - 1);
				gb.GetComponent<ColorSlot>().SetColor(new Color(temp,0 ,1));
			}
			else if ((i * colorStep) >= 2 && (i * colorStep) < 3) {
				float temp = (i * colorStep - 2);
				gb.GetComponent<ColorSlot>().SetColor(new Color(0 ,temp , 1 ));
			}
			else if ((i * colorStep) >= 3 && (i * colorStep) < 4) {
				float temp = 1 - (i * colorStep - 3);
				gb.GetComponent<ColorSlot>().SetColor(new Color(0 , 1 ,temp));
			}
			else if ((i * colorStep) >= 4 && (i * colorStep) < 5) {
				float temp = (i * colorStep - 4);
				gb.GetComponent<ColorSlot>().SetColor(new Color(temp , 1 ,0));
			}
			else if ((i * colorStep) >= 5 && (i * colorStep) < 6) {
				float temp = 1 - (i * colorStep - 5);
				gb.GetComponent<ColorSlot>().SetColor(new Color(1 ,temp, 0));
			}
		}

		float slotStep = 1f / (numberOfPencils - 2 + 1);
		for (int i = 0; i < ColorSlots.Count ; i++) {

			ColorSlots[i].transform.position =  MainCamera.ScreenToWorldPoint(new Vector3((i+1)* slotStep * Screen.width 
			         , 1f * Screen.height - ColorSlots[i].Body.GetComponent<SpriteRenderer>().bounds.max.y * 1.5f , 1));
			//new Vector3( i * slotStep, 0 , 1);
		}

		// put in random slot
	}


	void InitializeArrows()
	{
		Debug.Log("LeftArrow.Body.GetComponent<SpriteRenderer>().bounds.max.x : " +
		          LeftArrow.Body.GetComponent<SpriteRenderer>().bounds.size.x);
		LeftArrow.transform.position =  MainCamera.ScreenToWorldPoint(new Vector3(0, 0 , 20));
		LeftArrow.transform.position = new Vector3(LeftArrow.transform.position.x +
		                                           LeftArrow.Body.GetComponent<SpriteRenderer>().bounds.size.x
		                                           ,LeftArrow.transform.position.y +
		                                           LeftArrow.Body.GetComponent<SpriteRenderer>().bounds.size.y * 0.5f
		                                            ,4);
		RightArrow.transform.position =  MainCamera.ScreenToWorldPoint(new Vector3(Screen.width , 0 , 20));
		RightArrow.transform.position = new Vector3(RightArrow.transform.position.x - 
		                                            RightArrow.Body.GetComponent<SpriteRenderer>().bounds.size.x
		                                            ,RightArrow.transform.position.y +
		                                            RightArrow.Body.GetComponent<SpriteRenderer>().bounds.size.y * 0.5f
		                                           ,4);
	
	}


	

	public void MovePencilLeft (Pencil pen)
	{
		// check can move left	
		int activeSlotIndex =  Slots.IndexOf(pen.slot);
		if (activeSlotIndex == 0) {
			return;
		}
		Pencil pen2 = Slots[activeSlotIndex - 1].pencil;
		Slots[activeSlotIndex].RemovePencil();
		Slots[activeSlotIndex - 1 ].RemovePencil();
		//animations
		///this part should be changed
		/// 
		Slots[activeSlotIndex].AddPencil(pen2 , 0.2f);
		pen2.slot = Slots[activeSlotIndex];
		Slots[activeSlotIndex - 1 ].AddPencil(pen , 0.2f);
		pen.slot = Slots[activeSlotIndex - 1];
		/// 
		/// 
		//win Condition

		Debug.Log("CheckWin() : " + CheckWin());
	}
	
	public void MovePencilRight (Pencil pen)
	{
		// check can move right
		int activeSlotIndex =  Slots.IndexOf(pen.slot);
		if (activeSlotIndex == Slots.Count) {
			return;
		}
		Pencil pen2 = Slots[activeSlotIndex + 1].pencil;
		Slots[activeSlotIndex].RemovePencil();
		Slots[activeSlotIndex + 1 ].RemovePencil();
		//animations
		///this part should be changed
		/// 
		Slots[activeSlotIndex].AddPencil(pen2 , 0.2f);
		pen2.slot = Slots[activeSlotIndex];
		Slots[activeSlotIndex + 1 ].AddPencil(pen , 0.2f);
		pen.slot = Slots[activeSlotIndex + 1];
		//win condition
		Debug.Log("CheckWin() : " + CheckWin());
	}

	bool CheckWin()
	{
		for (int i = 0; i < ColorSlots.Count; i++) {
			if (!Slots[i].pencil.GetColor().Equals(ColorSlots[i].GetColor())) {
				return false;
			}
		}
		MainCamera.backgroundColor = Pencils[0].GetColor();
		return true;
	}
}
