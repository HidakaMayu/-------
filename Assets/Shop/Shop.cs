﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //int money = 1000;
    List<string> shopAItem = new List<string>() { "やくそう","どくけしそう","せいすい" };
    List<string> shopBItem = new List<string>(){ "つるぎ","よろい" };
    Dictionary<string, int> nowItems = new Dictionary<string, int>(); //所持品

    [SerializeField] GameObject btn;//表示されるボタン
    [SerializeField] object parent;


    // Update is called once per frame
    void Update()
    {
        /*if(tag"firstscene")
        {
            firstscene =false
        }
        
         if(back)
        {
            firstscene =true
            secondScene =false
        }*/


    }
    //shopA 陳列。買われてたら表示しない✖　List内存在してるのをボタン化
    //調べていいのか否か...私の調方はよくないため

    public void LoadBtn(GameObject parent, string name, float pos_x, float pos_y)　//ボタンを並べる処理
    {
        GameObject uiBtn = Instantiate(this.btn, new Vector3(pos_x, pos_y, 0), Quaternion.identity);
        int a = 0;

        List<string> num = (a == 0) ? shopAItem : shopBItem;
        foreach (var i in num)
        {
            uiBtn.name = i;
            
        }
        
    }

    void Shops()
    {
        /*ShopA = true　List並べる
        横に値段もかく
        並べるInstantiateUIBtn(GameObject parent, string name, float pos_x, float pos_y)

        if(GetBttonDown(backButton))
        {
            firstscene = true
            nowScene = false
        }*/
    }

    void Items()
    {

    }

}
