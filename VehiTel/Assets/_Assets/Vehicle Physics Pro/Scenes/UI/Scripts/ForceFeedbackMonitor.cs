//--------------------------------------------------------------
//      Vehicle Physics Pro: advanced vehicle physics kit
//          Copyright © 2011-2019 Angel Garcia "Edy"
//        http://vehiclephysics.com | @VehiclePhysics
//--------------------------------------------------------------

// ForceFeedbackMonitor: displays live force feedback values


using EdyCommonTools;
using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics;

namespace _Assets.Vehicle_Physics_Pro.Scenes.UI.Scripts
{

public class ForceFeedbackMonitor : MonoBehaviour
	{
	public VehicleBase vehicle;

	// These bars will be controlled via Image.fillAmount

	public Image steeringForceBar;
	public Image steeringFrictionBar;

	public Color saturationColor = GColor.accentRed;
	}
}