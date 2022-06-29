using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamestatus : MonoBehaviour
{
    [Range(0.1f,10f)] [SerializeField] float Gamespeed = 1f;
    [SerializeField] int CurrentScore = 0;
    [SerializeField] int PointsPerBlocksDestroyed = 10;
    [SerializeField] TextMeshProUGUI ScoreText;
    
    [SerializeField] bool isAutoPlayEnabled;

    
    private void Awake()
    {
        int gamestatuscount = FindObjectsOfType<Gamestatus>().Length;
        if (gamestatuscount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        ScoreText.text = CurrentScore.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Gamespeed;
    }

    public void AddToScore()
    {
        CurrentScore += PointsPerBlocksDestroyed;
        ScoreText.text = CurrentScore.ToString();
        

    }

   
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

}
