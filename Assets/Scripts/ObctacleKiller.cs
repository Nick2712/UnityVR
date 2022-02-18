using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimovUnityVR
{
    public class ObctacleKiller : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private ObstacleSpawner _spawner;
        [SerializeField] private float _killDistance;


        private void Update()
        {
            List<Transform> obstacles = _spawner.SpawnedObstacles;
            for(int i = 0; i < obstacles.Count; i++)
            {
                if(_player.position.z > obstacles[i].position.z + _killDistance)
                {
                    Destroy(obstacles[i].gameObject);
                }
            }
        }
    }
}