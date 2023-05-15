using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public int Score { get; set; }　//値scoreに代入

    void Update()
    {
        scoreText.text = "現在スコア\n" + Score.ToString() + "pt";
    }
}
