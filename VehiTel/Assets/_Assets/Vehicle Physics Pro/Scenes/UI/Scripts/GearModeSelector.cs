//--------------------------------------------------------------
//      Vehicle Physics Pro: advanced vehicle physics kit
//          Copyright © 2011-2019 Angel Garcia "Edy"
//        http://vehiclephysics.com | @VehiclePhysics
//--------------------------------------------------------------

// GearModeSelector: Shows current gear mode and allows selecting it

using EdyCommonTools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VehiclePhysics;

namespace _Assets.Vehicle_Physics_Pro.Scenes.UI.Scripts
{
    public class GearModeSelector : MonoBehaviour, IPointerDownHandler
    {
        public static Graphic CurrentGear;
        
        public VehicleBase vehicle;

        public Color selectedColor = GColor.ParseColorHex("#E6E6E6");
        public Color unselectedColor = GColor.ParseColorHex("#999999");
        public Transform selector;

        [Header("Gear elements")] public Graphic gearM;

        public Graphic gearP;
        public Graphic gearR;
        public Graphic gearN;
        public Graphic gearD;
        public Graphic gearL;

        private int m_prevGearMode = -1;
        private int m_prevGearInput = -1;
        private int m_newGearMode = -1;

        private void OnEnable()
        {
            m_prevGearMode = -1;
            m_prevGearInput = -1;
            m_newGearMode = -1;
        }

        private void FixedUpdate()
        {
            if (vehicle == null) return;

            var gearInput = vehicle.data.Get(Channel.Input, InputData.AutomaticGear);
            var gearMode = vehicle.data.Get(Channel.Vehicle, VehicleData.GearboxMode);

            if (gearMode != m_prevGearMode)
            {
                HighlightGear(gearMode);
                m_prevGearMode = gearMode;
            }

            if (gearInput != m_prevGearInput)
            {
                MoveGearSelector(gearInput);
                m_prevGearInput = gearInput;
            }

            if (m_newGearMode >= 0)
            {
                vehicle.data.Set(Channel.Input, InputData.AutomaticGear, m_newGearMode);
                m_newGearMode = -1;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (vehicle == null || eventData.button != PointerEventData.InputButton.Left) return;

            var pressed = eventData.pointerCurrentRaycast.gameObject;
            var graphic = pressed.GetComponentInChildren<Graphic>();

            if (graphic != null) m_newGearMode = GraphicToGear(graphic);
        }

        private void HighlightGear(int gearMode)
        {
            ClearEngagedGearMode();
            SetGraphicColor(GearToGraphic(gearMode), selectedColor);
        }

        private void MoveGearSelector(int gearInput)
        {
            if (selector != null)
            {
                var targetGraphic = GearToGraphic(gearInput);

                if (targetGraphic != null) selector.position = targetGraphic.transform.position;
            }
        }

        private void ClearEngagedGearMode()
        {
            SetGraphicColor(gearM, unselectedColor);
            SetGraphicColor(gearP, unselectedColor);
            SetGraphicColor(gearR, unselectedColor);
            SetGraphicColor(gearN, unselectedColor);
            SetGraphicColor(gearD, unselectedColor);
            SetGraphicColor(gearL, unselectedColor);
        }

        private Graphic GearToGraphic(int gearMode)
        {
            CurrentGear = gearMode switch
            {
                0 => gearM,
                1 => gearP,
                2 => gearR,
                3 => gearN,
                4 => gearD,
                5 => gearL,
                _ => CurrentGear
            };

            return CurrentGear;

            return null;
        }

        private int GraphicToGear(Graphic graphic)
        {
            if (graphic == gearM) return 0;
            if (graphic == gearP) return 1;
            if (graphic == gearR) return 2;
            if (graphic == gearN) return 3;
            if (graphic == gearD) return 4;
            if (graphic == gearL) return 5;

            return -1;
        }

        private void SetGraphicColor(Graphic graphic, Color color)
        {
            if (graphic != null) graphic.color = color;
        }
    }
}