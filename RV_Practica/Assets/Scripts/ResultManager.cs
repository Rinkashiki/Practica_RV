using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public TextMeshPro textMesh;
    float time2menu;
    // Start is called before the first frame update
    void Start()
    {
        textMesh.text = SceneParams.resultText;
        time2menu = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time2menu -= Time.deltaTime;
        if(time2menu <= 0.0f)
        {
            SceneManager.LoadScene("SongMenu");
        }
    }
}
