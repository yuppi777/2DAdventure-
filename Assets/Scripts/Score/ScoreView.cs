using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : SingletonMonoBehaviour<ScoreView>
{
    public int _rightCount;
    public int _incoreCount;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetRightPoint(int rightCount)
    {
        Debug.Log(rightCount);
        _rightCount = rightCount;
    }
    public void SetIncorePoint(int incoreCount)
    {
        Debug.Log(incoreCount);
        _incoreCount = incoreCount;

    }
}
