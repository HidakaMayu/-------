using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public int Score { get; set; }�@//�lscore�ɑ��

    void Update()
    {
        scoreText.text = "���݃X�R�A\n" + Score.ToString() + "pt";
    }
}
