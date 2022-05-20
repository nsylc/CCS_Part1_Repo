using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<CreateScore>().controllerInt++;
        Vector3 pos = new Vector3(Random.Range(-9, 9), -23, Random.Range(1, 44));
        transform.position = pos;
        //FindObjectOfType<CreateScore>().obj.Add(gameObject);
    }
}
