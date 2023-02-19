using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
	public GameObject gameOverScreen;
    public AudioSource scoreSFX;
    public AudioSource gameOverSFX;
    
    // Start is called before the first frame update
    void Start()
    {
    scoreSFX = GetComponentInChildren<AudioSource>();
    gameOverSFX = GetComponentsInChildren<AudioSource>()[1];
    }

	[ContextMenu("Add Score")]
    public void addScore(int scoreToAdd) 
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
		scoreSFX.PlayOneShot(scoreSFX.clip);
    }

	public void restartGame() {
		//this is looking for the name of the scene (and we give the current scene)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void gameOver(){
		gameOverScreen.SetActive(true);
		gameOverSFX.PlayOneShot(gameOverSFX.clip);
	}
}
