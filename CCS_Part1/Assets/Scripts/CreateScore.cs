using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScore : MonoBehaviour
{
    /*
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("ScoreItem", transform.position, Quaternion.identity);
    }
    */
    public int controllerInt = 0;
    public GameObject prefab;

    private void Update()
    {
        if(controllerInt < 5)
        {
            Instantiate(prefab);
        }
    }
}
