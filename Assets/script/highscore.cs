using TMPro;
using UnityEngine;

public class highscore : MonoBehaviour
{
    private TextMeshProUGUI score;
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        score.text = PlayerPrefs.GetInt("number", 0).ToString();
    }

    
    void Update()
    {
        score.text = PlayerPrefs.GetInt("number", 0).ToString();
    }
}
