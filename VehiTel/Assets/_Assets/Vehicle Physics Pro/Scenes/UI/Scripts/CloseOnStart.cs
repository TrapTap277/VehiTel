//--------------------------------------------------------------
//      Vehicle Physics Pro: advanced vehicle physics kit
//          Copyright © 2011-2019 Angel Garcia "Edy"
//        http://vehiclephysics.com | @VehiclePhysics
//--------------------------------------------------------------

// CloseOnStart: Simply disables this GameObject on start


using UnityEngine;

namespace _Assets.Vehicle_Physics_Pro.Scenes.UI.Scripts
{

public class CloseOnStart : MonoBehaviour
	{
    void Start()
		{
        this.gameObject.SetActive(false);
		}
    }

}
