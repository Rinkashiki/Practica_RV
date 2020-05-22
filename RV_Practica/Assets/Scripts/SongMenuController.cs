using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongMenuController : MonoBehaviour
{
    public GameObject progressBar;
    public GameObject songText;

    float barTimer;
    Slider slider;
    List<AudioClip> songs;
    bool isInside;
    int songChoice;
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

        barTimer += Time.deltaTime;
        progressBar.SetActive(barTimer > 2.0f ? true : false);
        slider.value = progressBar.activeSelf ? slider.value + 0.005f : 0.0f;

        if (slider.value == 1)
        {
            SceneParams.song2play = songs[songChoice];
            SceneManager.LoadScene("VR_Game 1");
        }

        if(!isInside)
        {
            barTimer = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInside = true;
        if (other.gameObject.CompareTag("Song1"))
        {
            songChoice = 0;
        }
        else if (other.gameObject.CompareTag("Song2"))
        {
            songChoice = 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isInside = false;
    }
}
