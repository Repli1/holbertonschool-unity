using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public float speed = 10f;
	private int score = 0;
	public int health = 5;
	public Text scoreText;
	public Text healthText;
	public GameObject winLoseBG;
	public Text winLoseText;
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -speed * Time.deltaTime);
		}
		if (Input.GetKey("d"))
		{
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("menu");
		}
		if (health == 0)
		{
			winLoseText.text = "Game Over!";
			winLoseText.color = Color.white;
			winLoseBG.GetComponent<Image>().color = Color.red;
			winLoseBG.SetActive(true);
			StartCoroutine(LoadScene(3));
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
        }
		if (other.CompareTag("Trap"))
		{
			health--;
			SetHealthText();
		}
		if (other.CompareTag("Goal"))
		{
			winLoseText.text = "You Win!";
			winLoseText.color = Color.black;
			winLoseBG.GetComponent<Image>().color = Color.green;
			winLoseBG.SetActive(true);
			StartCoroutine(LoadScene(3));
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}
	void SetHealthText()
	{
		healthText.text = "Health: " + health;
	}
	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene("maze");
		//health = 5;
		//score = 0;
	}
}
