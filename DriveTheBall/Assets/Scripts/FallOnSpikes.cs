using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallOnSpikes : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject ball;
    private Rigidbody2D rb;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            gameOverUI.SetActive(true);
            Vector3 newPosition = new Vector3(-5.81f, -3.00f, 0f);
            ball.transform.position = newPosition;
            rb = ball.GetComponent<Rigidbody2D>();
            rb.velocity = transform.forward * 0;
           
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
