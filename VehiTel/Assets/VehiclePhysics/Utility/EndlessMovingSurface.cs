//--------------------------------------------------------------
//      Vehicle Physics Pro: advanced vehicle physics kit
//          Copyright © 2011-2019 Angel Garcia "Edy"
//        http://vehiclephysics.com | @VehiclePhysics
//--------------------------------------------------------------

using UnityEngine;

namespace VehiclePhysics.Utility
{
    [RequireComponent(typeof(Rigidbody))]
    public class EndlessMovingSurface : MonoBehaviour
    {
        public bool move;
        public float velocity = 1.0f;
        public float deltaVelocityOnKey = 1.0f;
        public float maxVelocity = 20.0f;
        public float positionLimit = 400.0f;

        private new Rigidbody _rigidbody;

        private VPResetVehicle _resetVehicle;

        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadPlus)) velocity += deltaVelocityOnKey;

            if (Input.GetKeyDown(KeyCode.KeypadMinus)) velocity -= deltaVelocityOnKey;

            if (Input.GetKeyDown(KeyCode.KeypadMultiply)) move = !move;
        }

        private void FixedUpdate()
        {
            if (move)
            {
                if (transform.localPosition.z > positionLimit)
                {
                    var localPos = transform.localPosition;
                    localPos.z = -positionLimit;
                    transform.localPosition = localPos;
                }

                velocity = Mathf.Clamp(velocity, -maxVelocity, maxVelocity);

                Debug.Log(_rigidbody.velocity);
                
                _rigidbody.MovePosition(_rigidbody.position + velocity * Time.deltaTime * Vector3.forward);
            }
            
            Debug.Log(move);
        }
    }
}