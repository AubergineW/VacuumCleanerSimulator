using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    [SerializeField] private float _range;
    public float Range => _range;

    public static Vector3[] RayDirections = new Vector3[8];
    private const int AVAILABLE_DIRECTION = 1;
    private void Awake()
    {
        for (int i = 0; i < RayDirections.Length; i++)
        {
            GetCommand(DetectObstacle(RayDirections[i]), RayDirections[i]);
        }
    }
    private void Start()
    {
        Debug.Log(RayDirections.Length);
    }
    private void Update()
    {
        for (int i = 0; i < RayDirections.Length; i++)
        {
            GetCommand(DetectObstacle(RayDirections[i]), RayDirections[i]);
        }
    }
    private ObstacleToDetect DetectObstacle(Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, direction, out hit, _range);
        Debug.DrawRay(transform.position, direction * _range, Color.green);
        if (hit.transform != null)
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(transform.position, direction * _range, Color.red);
            ObstacleToDetect obstacle = hit.transform.GetComponent<ObstacleToDetect>();
            return obstacle;
        }

        return null;
    }
    private void GetCommand(ObstacleToDetect obstacle, Vector3 direction)
    {
        if (obstacle != null)
        {
            obstacle.TellVacuumCleanerWhatToDo(direction);
        }
        else
        {
            VacuumCleanerDirections.Directions[direction] = AVAILABLE_DIRECTION;
        }
    }
}