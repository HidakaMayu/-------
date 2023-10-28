using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;
using UnityEngine.UI;
using Unity.VisualScripting;

public class NextFrame : MonoBehaviour
{
    [SerializeField]
    private Text uiText;
    Button oneBtn;
    Button fiveBtn;
    Button tenBtn;

    int count = 0;

    private ReactiveProperty<int> _count = new ReactiveProperty<int>();

    private void Start()
    {
        /*
        _count
            .Subscribe(count => Debug.Log(count))
            .AddTo(gameObject);
        _count.Value = 1;
        */

        Observable.NextFrame().Subscribe(_ =>
        {
            Debug.Log("1フレーム後に実行");
        }).AddTo(this);

        //課題1
        Observable.Timer(TimeSpan.FromMilliseconds(500)).Subscribe(_ =>
        Debug.Log("500ミリセカンド経った")).AddTo(this);

        Observable.Interval(TimeSpan.FromMilliseconds(80)).Subscribe(_ =>
        Debug.Log("80ミリセカンド")).AddTo(this);


        this.UpdateAsObservable().Subscribe(_ => { });
        //こういうのも可能　https://github.com/taninon/linqTest/blob/master/Assets/TestUniRxUpdate.cs

        //課題2 ボタンがクリックされたら、その数分プラスされる

        _count
          .Subscribe(count => Debug.Log(count))
          .AddTo(gameObject);
        _count.Value = 1;
        _count.Value = 5;
        _count.Value = 10;



        //課題3-1 クリック時ボックス移動/0.3秒はクリック無視
        /*0.3秒無視
        this.OnMouseDownAsObservable()
           .ThrottleFirst(TimeSpan.FromSeconds(0.3f))
            .Subscribe(_=> OnMouseDown());*/
        
        this.OnMouseDownAsObservable()
        .Where(_ => Input.GetKeyDown(KeyCode.Space))
        .ThrottleFirst(TimeSpan.FromSeconds(2))
        .Subscribe(_ => Debug.Log("スペースキーが押された！"));
        //課題3-2 0.5秒後にクリックされたと表示

        //課題4
        var testA = Observable.Timer(TimeSpan.FromSeconds(1.0f)).Do(_ => Debug.Log("1秒待った"));
        var testB = Observable.Timer(TimeSpan.FromSeconds(2.0f)).Do(_ => Debug.Log("2秒待った"));
        var testC = Observable.Timer(TimeSpan.FromSeconds(3.0f)).Do(_ => Debug.Log("3秒待った"));
        Observable.WhenAll(testA, testB, testC).Subscribe(_ =>
        {
            Debug.Log("全て終了");
        }).AddTo(this);
    }
}
/*
    void OnClick()
    {
        if(gameObject.name == "1") { count++; }
        else if(gameObject.name == "5") { count += 5; }
        else { count += 10; }
    }
*/
