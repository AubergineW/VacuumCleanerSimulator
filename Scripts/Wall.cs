using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : ObstacleToDetect
{
    private const int NOT_AVAILABLE_DIRECTION = 0;
    public override void TellVacuumCleanerWhatToDo(Vector3 direction)
    {
        VacuumCleanerDirections.Directions[direction] = NOT_AVAILABLE_DIRECTION;
    }
}