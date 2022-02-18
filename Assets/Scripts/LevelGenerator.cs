using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimovUnityVR
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private List<Transform> _segments;
        [SerializeField] private float _minDistance;
        [SerializeField] private Transform _player;

        
        private void Update()
        {
            Transform lastObj = _segments[_segments.Count - 1];
            float dis = Vector3.Distance(lastObj.position, _player.position);

            if(dis < _minDistance)
            {
                Transform firstObj = _segments[0];
                firstObj.position = lastObj.position;

                Vector3 offset = lastObj.GetComponent<Collider>().bounds.extents + firstObj.GetComponent<Collider>().bounds.extents;
                firstObj.position += Vector3.forward * offset.z;

                _segments.Remove(firstObj);
                _segments.Add(firstObj);
            }
        }
    }
}