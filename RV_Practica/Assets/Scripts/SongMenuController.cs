using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongMenuController : MonoBehaviour
{
    public GameObject playerBall;
    public GameObject progressBar;
    public GameObject songText;

    float barTimer;
    Slider slider;
    float ballHeight;
    List<AudioClip> songs;
    // Start is called before the first frame update
    void Start()
    {
        slider = progressBar.GetComponent<Slider>();
        songs = new List<AudioClip>();

        foreach(SongText s in songText.GetComponentsInChildren<SongText>())
        {
            songs.Add(s.song);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ballHeight = playerBall.transform.position.y;

        barTimer += Time.deltaTime;
        progressBar.SetActive(barTimer > 2.0f ? true : false);
        slider.value = progressBar.activeSelf ? slider.value + 0.005f : 0.0f;

        if (ballHeight > 0.15f && ballHeight < 0.35f)
        {
            if (slider.value == 1)
            {
                SceneParams.song2play = songs[0];
                SceneManager.LoadScene("VR_Game 1");
            }
        }
        else if(ballHeight > -0.4f && ballHeight < -0.2f)
        {
            if (slider.value == 1)
            {
                SceneParams.song2play = songs[1];
                SceneManager.LoadScene("VR_Game 1");
            }
        }
        else
        {
            barTimer = 0.0f;
        }
    }
}
