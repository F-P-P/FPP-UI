using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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
    

}
