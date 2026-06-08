using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;

    [SerializeField] private TextMeshProUGUI bulletsShot;
    [SerializeField] private TextMeshProUGUI maxBulletsShot;
    
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        bulletsShot.text = score.ToString();

        maxBulletsShot.text = PlayerPrefs.GetInt("Record", 0).ToString();
        RecordUpdate();
    }

    // Update is called once per frame
    private void RecordUpdate()
    {
        if (score > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", score);
            maxBulletsShot.text = score.ToString();   
        }
    }

    public void ScoreUpdate()
    {
        score++;
        bulletsShot.text = score.ToString();
        RecordUpdate();
    }
}
