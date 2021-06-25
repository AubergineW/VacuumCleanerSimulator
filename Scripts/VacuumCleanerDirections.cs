using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleanerDirections : MonoBehaviour
{
    public static Dictionary<Vector3, int> Directions;
    private Vector3 _currentDirection;

    private const int NOT_AVAILABLE_DIRECTION = 0;
    private const int AVAILABLE_DIRECTION = 1;
    private const int WANTED_DIRECTION = 2;
    private void Awake()
    {
        Directions = new Dictionary<Vector3, int>();
    }
    private void Start()
    {
        Debug.Log(Directions.Keys.Count);
        ChooseDirection();
    }
    private void Update()
    {
        if (Directions[_currentDirection] != WANTED_DIRECTION && Directions[_currentDirection] != AVAILABLE_DIRECTION)
        {
            ChooseDirection();
        }
    }
    private void ChooseDirection()
    {
        List<Vector3> availableDirections = GetAvailableDirections();
        Vector3 wantedDirection = WantedDirection();
        Debug.Log(availableDirections.Count);
        if (wantedDirection == Vector3.zero)
        {
            int directionIndex = Random.Range(0, availableDirections.Count);
            Vector3 direction = availableDirections[directionIndex];
            SetDirection(direction);
        }
        else
        {
            Vector3 direction = wantedDirection;
            SetDirection(direction);
        }
    }
    private List<Vector3> GetAvailableDirections()
    {
        List<Vector3> availableDirections = new List<Vector3>();
        foreach (Vector3 direction in Directions.Keys)
        {
            if (Directions[direction] != NOT_AVAILABLE_DIRECTION)
            {
                availableDirections.Add(direction);
            }
        }
        Debug.Log(availableDirections);
        return availableDirections;
    }
    private Vector3 WantedDirection()
    {
        foreach (Vector3 direction in Directions.Keys)
        {
            if (Directions[direction] == WANTED_DIRECTION)
            {
                return direction;
            }
        }

        return Vector3.zero;
    }

    private void SetDirection(Vector3 direction)
    {
        VacuumCleanerMovement.Direction = direction;
        _currentDirection = direction;
    }
}