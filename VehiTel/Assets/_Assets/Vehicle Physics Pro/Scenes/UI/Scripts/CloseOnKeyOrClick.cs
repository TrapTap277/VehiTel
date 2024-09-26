//--------------------------------------------------------------
//      Vehicle Physics Pro: advanced vehicle physics kit
//          Copyright © 2011-2019 Angel Garcia "Edy"
//        http://vehiclephysics.com | @VehiclePhysics
//--------------------------------------------------------------

// CloseOnKeyOrClick: Disables this GameObject when pressing a key or clicking an UI item


using UnityEngine;
using UnityEngine.EventSystems;

namespace _Assets.Vehicle_Physics_Pro.Scenes.UI.Scripts
{

public class CloseOnKeyOrClick : MonoBehaviour,
		IPointerClickHandler
	{
	public GameObject closeItem;
	public KeyCode closeKey = KeyCode.Escape;


	void Update()
		{
		if (Input.GetKeyDown(closeKey))
			this.gameObject.SetActive(false);
		}


	public void OnPointerClick (PointerEventData eventData)
		{
		if (eventData.button == PointerEventData.InputButton.Left)
			{
			if (eventData.pointerCurrentRaycast.gameObject == closeItem)
				this.gameObject.SetActive(false);
			}
		}
	}
}