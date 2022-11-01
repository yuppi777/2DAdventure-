using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UniRx;

public class NowTimeUpdate : MonoBehaviour
{
    DateTime NowTime;
    [SerializeField] Text nowTimeText;
    [SerializeField] Text nowDay;
    [SerializeField] Text iDTiketDay;

    public bool isStop = false;
    void Start()
    {
        Observable.EveryUpdate()
            .Subscribe(x => TimeDisplay()).AddTo(this);
    }

    private void Update()
    {
        if (isStop == false)
        {
            iDTiketDay.text = nowDay.text;
        }
       
    }
    private void TimeDisplay()
    {
        NowTime = DateTime.Now;
        nowTimeText.text = NowTime.ToShortTimeString();
        nowDay.text = NowTime.ToShortDateString();
       
    }
}
