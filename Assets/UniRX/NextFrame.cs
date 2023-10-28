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
            Debug.Log("1�t���[����Ɏ��s");
        }).AddTo(this);

        //�ۑ�1
        Observable.Timer(TimeSpan.FromMilliseconds(500)).Subscribe(_ =>
        Debug.Log("500�~���Z�J���h�o����")).AddTo(this);

        Observable.Interval(TimeSpan.FromMilliseconds(80)).Subscribe(_ =>
        Debug.Log("80�~���Z�J���h")).AddTo(this);


        this.UpdateAsObservable().Subscribe(_ => { });
        //���������̂��\�@https://github.com/taninon/linqTest/blob/master/Assets/TestUniRxUpdate.cs

        //�ۑ�2 �{�^�����N���b�N���ꂽ��A���̐����v���X�����

        _count
          .Subscribe(count => Debug.Log(count))
          .AddTo(gameObject);
        _count.Value = 1;
        _count.Value = 5;
        _count.Value = 10;



        //�ۑ�3-1 �N���b�N���{�b�N�X�ړ�/0.3�b�̓N���b�N����
        /*0.3�b����
        this.OnMouseDownAsObservable()
           .ThrottleFirst(TimeSpan.FromSeconds(0.3f))
            .Subscribe(_=> OnMouseDown());*/
        
        this.OnMouseDownAsObservable()
        .Where(_ => Input.GetKeyDown(KeyCode.Space))
        .ThrottleFirst(TimeSpan.FromSeconds(2))
        .Subscribe(_ => Debug.Log("�X�y�[�X�L�[�������ꂽ�I"));
        //�ۑ�3-2 0.5�b��ɃN���b�N���ꂽ�ƕ\��

        //�ۑ�4
        var testA = Observable.Timer(TimeSpan.FromSeconds(1.0f)).Do(_ => Debug.Log("1�b�҂���"));
        var testB = Observable.Timer(TimeSpan.FromSeconds(2.0f)).Do(_ => Debug.Log("2�b�҂���"));
        var testC = Observable.Timer(TimeSpan.FromSeconds(3.0f)).Do(_ => Debug.Log("3�b�҂���"));
        Observable.WhenAll(testA, testB, testC).Subscribe(_ =>
        {
            Debug.Log("�S�ďI��");
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
