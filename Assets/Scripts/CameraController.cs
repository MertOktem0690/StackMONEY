using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPosition;

    void Update()
    {
        //kameranýn player'ý takip etmesi
        transform.position = Vector3.Lerp(transform.position,cameraPosition.position,1f);
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraPosition.rotation, 1f);
    }
}