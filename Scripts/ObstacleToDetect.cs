using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleToDetect : MonoBehaviour
{
    public abstract void TellVacuumCleanerWhatToDo(Vector3 direction);
}
