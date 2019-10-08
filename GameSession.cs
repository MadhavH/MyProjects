using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
    [Range(.1f,10f)][SerializeField] float gameSpeed;
    [SerializeField] int pointsperBlockDestroyed = 15;
    [SerializeField] int currentScore;
    [SerializeField] TextMeshProUGUI scoretext;

    // Use this for initialization
    private void Awake()
    {
        int gamestatusnum = FindObjectsOfType<GameSession>().Length;
        if (gamestatusnum > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        scoretext.text = currentScore.ToString();
    }
    public void Destroy()
    {
        
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}
    public void addToScore()
    {

        currentScore += pointsperBlockDestroyed;
        scoretext.text = currentScore.ToString();
    }
}
