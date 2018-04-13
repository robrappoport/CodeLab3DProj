using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score;
    public int scoreMax;
    private float timePassed;
    public float timeTillSpawn;
    public GameObject scoreBall;
    private int spawnIndex;
    public Text scoreText;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= timeTillSpawn)
        {
            CreateBalls();
        }
        score = Mathf.Clamp(score, 0, scoreMax);
        UpdateScore();
        if (score >= scoreMax)
        {
            SceneManager.LoadScene("WinScene");
        }
       
    }

    private void CreateBalls()
    {
            Vector3 position = new Vector3(Random.Range(-3, 3), 5, Random.Range(-3, 3));
            timePassed = 0f;
            timeTillSpawn = Random.Range(2f-(spawnIndex/10f), 4f - (spawnIndex / 10f));
            Instantiate(scoreBall, position, Quaternion.identity);
            spawnIndex++;
        
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
