using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastGun : MonoBehaviour
{
    void Update()
    {
        RayCastSystem();
    }

    void RayCastSystem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name + hit.transform.position);
            }
            Debug.DrawRay(transform.position, transform.forward * 60, Color.red);
        }
    }
}
