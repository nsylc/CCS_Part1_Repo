using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float cameraDistance = -15f;
    public float cameraHeight = 0f;
    public float cameraFollowSpeed = 15f;
    float cameraZ;

    void LateUpdate()
    {
        cameraZ = GetComponent<CameraController>().player.transform.position.z - cameraDistance;

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, cameraHeight, cameraZ), cameraFollowSpeed * Time.deltaTime);
    }

}
