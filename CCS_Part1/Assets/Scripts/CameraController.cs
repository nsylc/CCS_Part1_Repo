using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, player.transform.position.x, GetComponent<MainCamera>().cameraFollowSpeed * Time.deltaTime),
            transform.position.y, transform.position.z);
    }
}
