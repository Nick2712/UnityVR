using UnityEngine;


namespace NikolayTrofimovUnityVR
{
    public class CharController : MonoBehaviour
    {
        [SerializeField] private float _speed = 6.0f;
        [SerializeField] private float _sideSpeed = 2.0f;
        [SerializeField] private float _deadZoneRotation = 10.0f;

        private Rigidbody _rbPlayer;
        
        private void Start()
        {
            _rbPlayer = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Vector3 dir = _rbPlayer.velocity;

            if(transform.rotation.eulerAngles.z > _deadZoneRotation 
                && transform.rotation.eulerAngles.z <= 180)
            {
                dir.x = transform.rotation.eulerAngles.z * -1 * Time.deltaTime * _sideSpeed;
            }

            if (transform.rotation.eulerAngles.z > 180
                && transform.rotation.eulerAngles.z <= 360 - _deadZoneRotation)
            {
                dir.x = transform.rotation.eulerAngles.z * Time.deltaTime * _sideSpeed;
            }

            dir.x = Input.GetAxis("Horizontal") * _sideSpeed;

            dir.z = _speed;

            _rbPlayer.velocity = dir;
        }
    }
}