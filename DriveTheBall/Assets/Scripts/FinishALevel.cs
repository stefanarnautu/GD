using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishALevel : MonoBehaviour
{
    

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.name == "Ball")
        {

            Invoke("CompleteLevel", 0.5f);
        }  
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(2);
    }
}
