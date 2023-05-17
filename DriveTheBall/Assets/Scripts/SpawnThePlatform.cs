using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnThePlatform : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject currentInstance;
    public GameObject tabelForCount;
    public GameObject howManyMax;
    private float rotationSpeed = 100f;
    private float rotation = 0f;
    private int counter = 0;
    private MemoriseTheLevel mLevel;
    void Start()
    {
        mLevel = FindObjectOfType<MemoriseTheLevel>();
        if (mLevel == null)
        {
            Debug.LogError("MemoriseTheLevel script not found in the scene.");
        }
        TextMeshProUGUI textComponent = howManyMax.GetComponent<TextMeshProUGUI>();
        int maxPlatforms = mLevel.getLevelData(mLevel.Level - 3).maxPlatformFor100;
        textComponent.text = "MAX " + maxPlatforms;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mLevel.Platforms = mLevel.Platforms + 1;
            TextMeshProUGUI textComponent = tabelForCount.GetComponent<TextMeshProUGUI>();
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = new Vector3(0, -0.5f, 10);
            if (GameObject.Find("PlatformToSpawn(Clone)") != null)
            {
                counter++;
                textComponent.text = counter + " USED";
                Destroy(currentInstance);
                currentInstance = Instantiate(spawnObject, pos + offset, Quaternion.identity);
                currentInstance.transform.eulerAngles = new Vector3(0, 0, rotation);
            }
            else
            {
                counter++;
                textComponent.text = counter + " PLATFORMS";
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