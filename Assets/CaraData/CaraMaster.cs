using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/CreateAsset")]
public class CaraMaster : ScriptableObject
{
    public List<CaraMasterRecord> Sheet => _sheet;

    [SerializeField]
    [Header("データ")]
    List<CaraMasterRecord> _sheet;

    public enum JobPost
    {
        Programer,
        Modeler,
        Motion,
        Director
    }

    public enum Rarity
    {
        N = 0,
        R = 1,
        SR = 2,
        SSR = 3
    }
    public enum Nationality
    {
        Japan,
        Jamaica,
        Coria,
    }


    [Serializable]
    public class CaraMasterRecord
    {
        public string Name => _name;
        public SpriteRenderer SpriteRenderer => spriteRenderer;
        public Sprite Sprite => sprite;
        public Sprite FakeSprite => fakeSprite;
        public CaraMaster.Nationality Nationality => nationality;
        public string CaraSelif => caraselif;

        [SerializeField]
        private string _name;

        [SerializeField]
        [Header("キャラのSpriteRenderer")]
        private SpriteRenderer spriteRenderer;
        
        [SerializeField]
        [Header("キャラのSprite")]
        private Sprite sprite;

        [SerializeField]
        [Header("IDに載せるキャラのSprite")]
        private Sprite fakeSprite;     

        [SerializeField]
        [Header("国籍")]
        private CaraMaster.Nationality nationality;

        [SerializeField]
        [Header("NOと言われた時のセリフ")]
        private string caraselif;
    }
}
