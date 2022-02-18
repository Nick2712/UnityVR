using UnityEngine;


namespace NikolayTrofimovUnityVR
{
    public class CharController : MonoBehaviour
    {
        [SerializeField] private float _speed = 6.0f;
        [SerializeField] private float _sideSpeed = 2.0f;
        [SerializeField] private float _deadZoneRotation = 10.0f;

        [SerializeField] private GameObject _healthBar;
        [SerializeField] private int _health = 10;

        private Rigidbody _rbPlayer;
        private float _healthVizualSize;

        private void Start()
        {
            _rbPlayer = GetComponent<Rigidbody>();
            _healthVizualSize = _healthBar.transform.localScale.x / _health;
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

        public void OnPlayerTouched()
        {
            Debug.Log("touch");

            if(_health - 1 > 1)
            {
                _health--;
                var healthScale = _healthBar.transform.localScale;
                var healthPosition = _healthBar.transform.position;
                healthScale.x -= _healthVizualSize;
                _healthBar.transform.localScale = healthScale;
                healthPosition.x -= _healthVizualSize / 2;
                _healthBar.transform.position = healthPosition;
            }
            else
            {
                _healthBar.gameObject.SetActive(false);
            }
        }
    }
}