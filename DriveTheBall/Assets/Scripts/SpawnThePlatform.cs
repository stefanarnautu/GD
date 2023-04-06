using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThePlatform : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject currentInstance;
    private float rotationSpeed = 100f;
    private float rotation = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = new Vector3(0, -0.5f, 10);
            if (GameObject.Find("PlatformToSpawn(Clone)") != null)
            {
                Destroy(currentInstance);
                currentInstance = Instantiate(spawnObject, pos + offset, Quaternion.identity);
                currentInstance.transform.eulerAngles = new Vector3(0, 0, rotation);
            }
            else
            {
                currentInstance = Instantiate(spawnObject, pos + offset, Quaternion.identity);
                currentInstance.transform.eulerAngles = new Vector3(0, 0, rotation);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotation += rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotation -= rotationSpeed * Time.deltaTime;
        }

        

    }
}