using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shops : MonoBehaviour
{
    PlayerData playerData;
    
    public void OpenShop()
    {
       playerData.shop.SetActive(true);
    }
    public void OnClickP()
    {
        playerData.coin -= 8;
    }
    public void OnClickD()
    {
        playerData.coin -= 5;
    }
    public void OnClickB()
    {
        playerData.shop.SetActive(false);
    }
}
//‰Û‘è3‚ÌƒVƒ‡ƒbƒv