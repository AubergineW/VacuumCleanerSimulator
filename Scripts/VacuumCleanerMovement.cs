using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleanerMovement : MonoBehaviour
{
    public static Vector3 Direction;
    Rigidbody rb;
    [SerializeField] private float _slowness;
    public float Speed => _slowness;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move(Direction);
    }
    private void Move(Vector3 direction)
    {
        transform.position += direction / _slowness;
    }
}
