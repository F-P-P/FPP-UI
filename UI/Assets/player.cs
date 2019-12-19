using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    [Header("血量與血條")]
    public int hp = 100;
    public Slider hpSlider;

    [Header("Coconut區域")]
    public Text textCoconut;
    public int CoconutCount;
    public int CoconutTotal;
    [Header("時間區域")]
    public Text textTime;
    public float gameTime;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "trap")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
            hpSlider.value = hp;
        }

        if (other.tag == "Coconut")
        {
            CoconutCount++;
            textCoconut.text = "Coconut:" + CoconutCount + " / " + CoconutTotal;
            Destroy(other.gameObject);
        }

        if (other.name == "end" && CoconutCount == CoconutTotal)
        {
            print("end");
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
    private void Start()
    {
        CoconutTotal = GameObject.FindGameObjectsWithTag("Coconut").Length;
        textCoconut.text = "Coconut : 0 / " + CoconutTotal;
    }

    private void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        gameTime += Time.deltaTime;
        textTime.text = gameTime.ToString("F2");
    }
}