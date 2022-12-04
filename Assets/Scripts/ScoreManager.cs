using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreText2;

    public static ScoreManager Instance;

    public float score = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        score += 20 * Time.deltaTime;
        scoreText.text = ((int)score).ToString();
        scoreText2.text = ((int)score).ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void AddScore(float points)
    {
        score += points;
    }
}
