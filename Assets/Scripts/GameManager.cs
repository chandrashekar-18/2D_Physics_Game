using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource _playCoinSound;

    public Text scoreText;
    public GameObject playButton;
    public GameObject backButton;
    public GameObject gameOver;
    public PlayerController player;

    private int _score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Play();
    }

    public void Play()
    {
        _score = 0;
        scoreText.text = _score.ToString();

        playButton.SetActive(false);
        backButton.SetActive(false);
        gameOver.SetActive(false);

        player.enabled = true;
        Time.timeScale = 1f;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for(int pipeIndex=0;pipeIndex<pipes.Length;pipeIndex++)
        {
            Destroy(pipes[pipeIndex].gameObject);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }


    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        backButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        _score++;
        scoreText.text = _score.ToString();
        _playCoinSound.Play();
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
