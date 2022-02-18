using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimovUnityVR
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _obstacles;
        [SerializeField] private float _spawnStep;
        [SerializeField] private float _spawnDistance;
        [SerializeField] private Transform _obstacleParent;

        [SerializeField] private Vector2 _segmentWidth;

        private Transform _myTrans;
        private Vector3 _lastPos;

        private List<Transform> _spawnedObstacles = new List<Transform>();
        public List<Transform> SpawnedObstacles 
        { 
            get 
            { 
                _spawnedObstacles.RemoveAll(TransformIsNull); 
                return _spawnedObstacles; 
            } 
        }


        private void Start()
        {
            _myTrans = transform;
            _lastPos = _myTrans.position;
        }

        private void Update()
        {
            if(_myTrans.position.z > _lastPos.z + _spawnStep)
            {
                _lastPos.z += _spawnStep;

                Transform newObstacle = _obstacles[Random.Range(0, _obstacles.Length)];

                _spawnedObstacles.Add
                (
                    Instantiate
                    (
                        newObstacle, 
                        new Vector3(Random.Range(_segmentWidth.x, _segmentWidth.y), 0, _lastPos.z + _spawnDistance), 
                        Quaternion.identity,
                        _obstacleParent
                    )
                );
            }
        }

        private bool TransformIsNull(Transform transform)
        {
            return transform == null;
        }
    }
}