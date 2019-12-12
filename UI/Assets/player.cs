using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    public int hp = 100;
    public Slider hpSlider;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "trap")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
            hpSlider.value = hp;
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "trap")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
            hpSlider.value = hp;
        }
    }
}