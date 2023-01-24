using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<GameObject> targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;

   

    private float _spawnRate;
    private int _score;

    private void Awake()
    {
        _spawnRate = 1f;
        //UpdateScore(0);
    }

    void Start()
    {
        StartCoroutine(SpawnTarget());
       // gameOverText.gameObject.SetActive(true);

    }
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Update is called once per frame
  
    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score :" + _score;
    }
    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
