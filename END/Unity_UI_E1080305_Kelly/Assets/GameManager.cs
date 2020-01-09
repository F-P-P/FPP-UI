using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour{

   public AudioMixer mixer;

   public Text loadingText;
   public Slider loading;

   public void SetVBGM(float value)
    {
        mixer.SetFloat("VBGM", value);
    }
   public void SetVSFX(float value)
    {
        mixer.SetFloat("VSFX", value);
    }

    public void Play()
    {
        // SceneManager.LoadScene("AK47");
        StartCoroutine(Loading());

    }


    private IEnumerator Loading()
    {
        // print("測驗 1");
        //     yield return new WaitForSeconds(2);
        //print("測驗 2");

        AsyncOperation ao = SceneManager.LoadSceneAsync("Game");
        ao.allowSceneActivation = false;
        while (ao.isDone == false)
        {
            loadingText.text = ((ao.progress / 0.9f) * 100).ToString();
            loading.value = ao.progress / 0.9f;
            yield return new WaitForSeconds(0.0001f);

            if (ao.progress == 0.9f && Input.anyKey) 
            {
                ao.allowSceneActivation = true;
            }
        }  
    }


    public void Replay()
    {
        SceneManager.LoadScene("UI_01");
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
