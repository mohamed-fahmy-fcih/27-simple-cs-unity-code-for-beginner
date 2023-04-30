using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject textShow;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += VideoPlayer_seekCompleted;
        textShow.SetActive(false);
    }

    private void VideoPlayer_seekCompleted(VideoPlayer source)
    {
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        if (textShow.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            NextLevel();
        }

        if (Input.anyKeyDown)
        {
            StartCoroutine(SetActiveSkipText(true));
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator SetActiveSkipText(bool value)
    {
        textShow.SetActive(value);
        yield return new WaitForSeconds(2.5f);
        textShow.SetActive(!value);
    }
}
