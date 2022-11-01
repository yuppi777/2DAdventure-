using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    public void AddDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
    void Start()
    {
        if (TryGetComponent(out IEnemy enemy))//これはどこでも書ける判断できる
        {
            enemy.AddDamage(5);
        }
    }

}
