using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnemyMotion : MonoBehaviour
{

    public SpriteRenderer thisEnemy;
    [SerializeField] GameObject caraAdvencher;
    private GameObject CaraAdvencher;
    public Text Serif;
    

    public void EnemyOKMove()
    {

        thisEnemy.transform.DOMove(new Vector3(-30f, 0, 0), 0.5f).SetLink(gameObject);
        Debug.Log("できたOK");
        
    }
    public void EnemyNOMove()
    {
        //CaraAdvencher= Instantiate(caraAdvencher, new Vector3(1f, 1f, 0.0f), Quaternion.identity);//スポーンエリアに吹き出しを生成
       thisEnemy.transform.DOMove(new Vector3(30f, 0, 0), 0.5f).SetRelative(true).SetLink(gameObject);
        Debug.Log("できたNO");    
    }
    private void OnBecameInvisible()
    {
        Destroy(thisEnemy);
    }
}
