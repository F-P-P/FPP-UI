using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour{

   public AudioMixer mixer;

   public void SetVBGM(float value)
    {
        mixer.SetFloat("VBGM", value);
    }

}
