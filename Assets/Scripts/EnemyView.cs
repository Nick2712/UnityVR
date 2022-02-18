using UnityEngine;


namespace NikolayTrofimovUnityVR
{
    public class EnemyView : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent<CharController>(out CharController charController))
            {
                charController.OnPlayerTouched();
            }

            Destroy(gameObject);
        }
    }
}