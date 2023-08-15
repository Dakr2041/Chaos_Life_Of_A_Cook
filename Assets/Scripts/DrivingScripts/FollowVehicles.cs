using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVehicles : MonoBehaviour
{
    [SerializeField] private GameObject vehicle;
    private Vector3 camOffset = new Vector3(0,5,-7);

    private void LateUpdate()
    {
        transform.position = vehicle.transform.position + camOffset;
    }

    
}
