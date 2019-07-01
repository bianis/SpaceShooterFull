using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Enemy enemy;
    public Vector2 spawnPos;
    public float spawnWait;

    private bool gameOver;
    private bool restart;

    public Text restart_text;
    public Text gameover_text;

    public Text score_text;
    public int score;           // di private boleh

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        restart = false;
        score = 0;                          // masih awal score nya 0
        StartCoroutine(SpawnEnemy());
        restart_text.text = "";
        gameover_text.text = "";
        StartCoroutine(SpawnEnemy());
        ScoreUpdate();
}

    // Update is called once per frame
    void Update()
    {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnEnemy() {
        while (true)
        {
            Vector3 pos= new Vector3(Random.Range(-spawnPos.x, spawnPos.x), spawnPos.y, 0);
            // Spawn Enemy
            Instantiate(enemy, pos, Quaternion.identity);
            // Nunggu sekian detik sebelum looping lagi
            yield return new WaitForSeconds(spawnWait);

            if (gameOver) {
                restart_text.text = "Press 'R' to restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore() {
        score++;
        ScoreUpdate();
    }

    public void ScoreUpdate() {
        score_text.text = "Score : " + score.ToString();
    }

    public void game_over() {
        gameover_text.text = "Game Over";
        gameOver = true;
    }
    
}
