using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public Animator animator;
	public GameObject startButton;
	public GameObject quitButton;

	public void Quit()
	{
		Debug.Log("QUITTING");
		Application.Quit();
	}
	public void LoadLevel()
	{
		StartCoroutine(PlayButton());
	}

	public void	ReturnMainMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
	IEnumerator PlayButton()
	{
		animator.SetTrigger("Start");
		startButton.SetActive(false);
		quitButton.SetActive(false);
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
