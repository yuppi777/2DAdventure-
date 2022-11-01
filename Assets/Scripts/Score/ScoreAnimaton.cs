using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreAnimaton : MonoBehaviour
{
    [SerializeField] Text rightPointText;
    [SerializeField] Text incorePointText;
    [SerializeField] Text totalPointText;
    [SerializeField] private Image shutter;
    [SerializeField] private int _plusPoint ;
    [SerializeField] private int _minusPoint;
                     private int _totalPotint =0;

    [SerializeField] AudioClip closeSound;
    private AudioSource audioSource;

    private float closeShutterSpeed = 0.1f;

   
    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        CloseShutter();
    }
    private void CloseShutter()
    {
        //Shutterの位置をCloseShutterSpeedの値の速度で指定した座標に移動する
        shutter.rectTransform.DOAnchorPosY(0, closeShutterSpeed)
            .SetLink(gameObject)
            .SetEase(Ease.Linear).OnComplete(() => { ScoreUpdate(); });
        audioSource.PlayOneShot(closeSound);
    }

    private void ScoreUpdate()
    {
        rightPointText.gameObject.SetActive(true);
        incorePointText.gameObject.SetActive(true);

        //RightPointText.text =("RightPoint")+(" ")+("×")+ ScoreView.Instance._rightCount.ToString();
        NumAnimation(ScoreView.Instance._rightCount);
        NumAnimation(ScoreView.Instance._incoreCount);
        TotalCalculation();
        
        //IncorePointText.text = ("IncorePoint") + (" ") + ("×") + ScoreView.Instance._incoreCount.ToString();
    }
    private void TotalCalculation()
    {
        _totalPotint = ScoreView.Instance._rightCount * _plusPoint - ScoreView.Instance._incoreCount * _minusPoint;
        NumAnimation(_totalPotint);
       
    }



    private Tween T_Score = null;
    private int DisplayScore = 0;
    private int NowScore;
    private float Speed = 0.001f;

    private void NumAnimation(int num)
    {
        DOTween.Kill(T_Score);
        T_Score = DOTween.To(() => DisplayScore, Display, num, Speed);
    }

    private void Display(int valu)
    {
        DisplayScore = valu;


        rightPointText.text = ("Point") + ("  ") +  ScoreView.Instance._rightCount.ToString() + ("×") + ("200pt");
        incorePointText.text = ("Miss") + ("  ")  + ScoreView.Instance._incoreCount.ToString() + ("×") + ("100pt");
        totalPointText.text = "Total" + "  " + _totalPotint.ToString() + "pt";
    }
  
}

