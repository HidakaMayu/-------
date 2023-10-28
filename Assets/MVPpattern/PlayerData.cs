using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public IntReactiveProperty Life = new IntReactiveProperty(5);
    [SerializeField]Text text;
    public int coin = 0;
    public GameObject shop;

    private void Start()
    {
        shop.SetActive(false);
    }
    public void Damage(int value)
    {
        Life.Value -= value;
    }

    // Update is called once per frame
    public void OnDestroy()
    {
        Life.Dispose();
    }

    public void ItemCare(int value)
    {
        Life.Value += value;
    }
    publicÅ@void GetCoin(int value)
    {
        coin += value;
        text.text = "Coin:" + coin;
    }
}
