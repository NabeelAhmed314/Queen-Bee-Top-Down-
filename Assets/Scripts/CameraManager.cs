using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCam;
    public Camera miniCam;
    public Transform player;
    void LateUpdate()
    {
            Vector3 newPosition = player.position;
            newPosition.z = mainCam.transform.position.z;
            mainCam.transform.position = newPosition;
            newPosition.z = miniCam.transform.position.z;
            miniCam.transform.position = newPosition;
    }
}
