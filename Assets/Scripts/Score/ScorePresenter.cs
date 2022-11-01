using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] ScoreData scoreData;
    [SerializeField] ScoreView scoreView;
    void Start()
    {
        scoreData.RightPoint.Subscribe(score =>
        {
            scoreView.SetRightPoint(score);
        }).AddTo(this);

        scoreData.IncorePoint.Subscribe(score =>
        {
            scoreView.SetIncorePoint(score);
        }).AddTo(this);
    }

    // Update is called once per frame
   
}
