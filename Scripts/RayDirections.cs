using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDirections : MonoBehaviour
{
    [SerializeField] private Detector[] _detectors;
    private const int AVAILABLE_DIRECTION = 1;
    void Awake()
    {
        for (int i = 0; i < _detectors.Length; i++)
        {
            Vector3 directionToDetector = (_detectors[i].transform.position - transform.position).normalized;
            ObstacleDetection.RayDirections[i] = directionToDetector;
            VacuumCleanerDirections.Directions.Add(directionToDetector, AVAILABLE_DIRECTION);
            Debug.Log(VacuumCleanerDirections.Directions.Count);
        }
    }
}
