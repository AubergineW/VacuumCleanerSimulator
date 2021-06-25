using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : ObstacleToDetect
{
    private const int WANTED_DIRECTION = 2;
    public override void TellVacuumCleanerWhatToDo(Vector3 direction)
    {
        VacuumCleanerDirections.Directions[direction] = WANTED_DIRECTION;
    }
}