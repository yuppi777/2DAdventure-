using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class ScoreData : MonoBehaviour
{
    public IntReactiveProperty RightPoint = new IntReactiveProperty();
    public IntReactiveProperty IncorePoint = new IntReactiveProperty();

    public void PlusRitPoint(int value)
    {
        RightPoint.Value += value;
    }
    public void PlusIncorePoint(int value)
    {
        IncorePoint.Value += value;
    }
    private void OnDestroy()
    {
        RightPoint.Dispose();
        IncorePoint.Dispose();
    }
}
