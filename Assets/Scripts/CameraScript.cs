using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    GameObject seguir;
    [SerializeField]
    Vector3 offset;

    void LateUpdate()
    {
        transform.position = seguir.transform.position + offset;
    }
}
