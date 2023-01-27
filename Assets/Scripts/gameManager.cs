using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField] private List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    //[SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    private float _spawnRate = 1.0f;
    private int _score;
    public bool isGameActive;

    void Start()
    {
        StartCoroutine(SpawnTarget());
        
       
        _score = 0;
        scoreText.text = "Score: " + _score;
        UpdateScore(0);
        _spawnRate = 1f;
        isGameActive = true;
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {


            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Update is called once per frame

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score :" + _score;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

}

