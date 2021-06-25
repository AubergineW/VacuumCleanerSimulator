using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageClean : MonoBehaviour
{
    [SerializeField] private float _range;
    private void Update()
    {
        DestroyGarbage();
    }
    private void DestroyGarbage()
    {
        GameObject garbage = DetectGarbage();
        if (garbage != null)
        {
            Destroy(garbage);
        }
    }
    private GameObject DetectGarbage()
    {
        Collider[] objectsAround = Physics.OverlapSphere(transform.position, _range);
        foreach (Collider obj in objectsAround)
        {
            if (obj.GetComponent<Garbage>())
            {
                Destroy(obj.gameObject);
            }
        }
        return null;
    }
}
