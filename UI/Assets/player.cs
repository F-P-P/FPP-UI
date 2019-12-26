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

    [Header("END")]
    public GameObject final;
    public Text textBest;
    public Text textCurrent;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "trap")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
            hpSlider.value = hp;
            if (hp <= 0) Dead();
        }

        if (other.tag == "Coconut")
        {
            CoconutCount++;
            textCoconut.text = "Coconut:" + CoconutCount + " / " + CoconutTotal;
            Destroy(other.gameObject);
        }

        if (other.name == "終點" && CoconutCount == CoconutTotal)
        {
            GameOver();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "trap")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
            hpSlider.value = hp;
            if (hp <= 0) Dead();
        }
    }
    private void Start()
    {
        if (PlayerPrefs.GetFloat("最佳紀錄") == 0)
        {
            PlayerPrefs.SetFloat("最佳紀錄", 99999);
        }
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

    private void Dead()
    {
        final.SetActive(true);
        textCurrent.text = "TIME :" + gameTime.ToString("F2");
        textBest.text = "BEST :" + PlayerPrefs.GetFloat("最佳紀錄").ToString("F2");
        Cursor.lockState = CursorLockMode.None;

        GetComponent<FPSControllerLPFP.FpsControllerLPFP>().enabled = false;
        this.enabled = false;

    }

    private void GameOver()
    {
        final.SetActive(true);
        textCurrent.text = "TIME :" + gameTime.ToString("F2");

        if (gameTime < PlayerPrefs.GetFloat("最佳紀錄"))
        {
            PlayerPrefs.SetFloat("最佳紀錄",gameTime);
        }
        textBest.text = "BEST :" + PlayerPrefs.GetFloat("最佳紀錄").ToString("F2");

        Cursor.lockState = CursorLockMode.None;
    }
}