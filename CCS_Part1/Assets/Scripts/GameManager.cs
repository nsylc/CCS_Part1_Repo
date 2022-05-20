using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public int scoreInt = 0;

    /*void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }*/

    void Update()
    {
        scoreText.text = "Score: " + scoreInt.ToString();

        if (scoreInt >= 100)
        {
            FindObjectOfType<SceneController>().Finish();
        }
    }
}
