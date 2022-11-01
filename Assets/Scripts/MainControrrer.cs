using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class MainControrrer : MonoBehaviour
{


    [SerializeField]
    [Header("キャラクターのデータ")]
    CaraMaster _data;

    [SerializeField]
    [Header("IDに書かれるキャラの名前のテキスト")]
    Text _enemyName;

    [SerializeField]
    [Header("チケットの日付")]
    Text _tiketDay;

    [SerializeField] 
    [Header("敵の顔写真")]
    Image _enemyidface;
    
    [SerializeField] 
    [Header("okボタン")]
    Button _okbuttun;

    [SerializeField] Button _nobuttun;
    [SerializeField] Button _nextCharabuttun;
    private  SpriteRenderer _nowEnemy;
    [SerializeField] TimerMaster _timerMaster;
    private EnemyMotion _enemyMotion;
    [SerializeField] NowTimeUpdate _nowTimeUpdate;
    [SerializeField] ScoreData _scoreData;
    [SerializeField] TimerTranceChange _timerTranceChange;
    [SerializeField] Transform _spwnArea;
    [SerializeField] GameObject _advencher;
    [SerializeField] Text _dialogText;


   

    private bool wrongdecision = false;//間違った決断をしたか否か
    private bool froudoccurred = false;//不正発生したか否か
    private bool isGameOver = false;

    List<CaraMaster.CaraMasterRecord> myCara = new List<CaraMaster.CaraMasterRecord>();

    private void Start()
    {
        SelectCaracter();
        //_gameOverButtun.SetActive(false);
    }
    /// <summary>
    /// 審査するキャラとIDを出す
    /// </summary>
    public void SelectCaracter()
    {
        /* 初期値入力*/
        InitalValueInput();
      

        var query = _data.Sheet
            .OrderBy(i => Guid.NewGuid())//シャッフル
            .ToList();
        var nowcara = query.FirstOrDefault();

        //myCara.Add(_data.Sheet[random]);
        query.Remove(nowcara);
        //enemy.sprite = nowcara.sprite;
        _nowEnemy = Instantiate(nowcara.SpriteRenderer, _spwnArea.position, Quaternion.identity);//スポーンエリアにスプライトを生成
        _enemyMotion = _nowEnemy.GetComponent<EnemyMotion>();//このスクリプトのenemyMotionにNowEnemyのスクリプトを代入
        _enemyMotion.thisEnemy = _nowEnemy;

        _enemyidface.sprite = nowcara.FakeSprite;
        _enemyName.text = nowcara.Name;
        _dialogText.text = nowcara.CaraSelif;

        if (RandomX())//ランダムでキャラクターの情報と違うものを身分証(ID)に書き込む
        {

            var fakecara = query.OrderBy(i => Guid.NewGuid())//シャッフル
                                .First();
            _enemyidface.sprite = fakecara.FakeSprite;
            Debug.Log("不正なID発生");
            froudoccurred = true;//不正が発生している
        }
        if (RandomY())//ランダムでチケットの日付を書き換える
        {
            _nowTimeUpdate.isStop = true;
            froudoccurred = true;//不正が発生している
            Debug.Log("不正なチケット期限発生");
            int rndDay = UnityEngine.Random.Range(1, 31);
            _tiketDay.text = "2022" + "/" + "09" + "/"+rndDay.ToString();
        }
        if (RandomZ())//ランダムで酒気帯びランプを光らす
        {
            froudoccurred = true;//不正が発生している
            _timerTranceChange.isFlash = true;
            Debug.Log("ランプ店頭中");
        }
    }
    public void OnclickOK()
    {
        _enemyMotion.EnemyOKMove();

        _okbuttun.interactable = false;
        _nobuttun.interactable = false;

        _nextCharabuttun.interactable = true;
        if (froudoccurred)
        {
            Debug.Log("不正解");
            _scoreData.PlusIncorePoint(1);
        }
        else
        {
            Debug.Log("正解");
            wrongdecision = true;
            _scoreData.PlusRitPoint(1);
        }
        if (isGameOver)
        {
            SceneManager.LoadScene("GameOver");
            _nextCharabuttun.interactable = false;
        }
    }
    public void OnclickNO()
    {
        StartCoroutine(AdvencherMove());
        

        /*初期値入力*/
        _nobuttun.interactable = false;
        _okbuttun.interactable = false;
        //_nextCharabuttun.interactable = true;

        if (froudoccurred)
        {
            Debug.Log("正解");
            wrongdecision = true;
            _scoreData.PlusRitPoint(1);
        }
        else
        {
            Debug.Log("不正解");
            _scoreData.PlusIncorePoint(1);

        }
        if (isGameOver)
        {
            SceneManager.LoadScene("GameOver");
            _nextCharabuttun.interactable = false; 

        }

    }
    bool RandomX()//ただの抽選
    {

        float randomPosX = UnityEngine.Random.Range(0, 7);
        if (randomPosX == 0)
        {
            return true;
        }
        else return false;

    }
    bool RandomY()
    {
        float randomPosX = UnityEngine.Random.Range(0, 7);
        if (randomPosX == 0)
        {
            return true;
        }
        else return false;
    }
    bool RandomZ()
    {
        float randomPosX = UnityEngine.Random.Range(0, 15);
        if (randomPosX == 0)
        {
            return true;
        }
        else return false;
    }
    private void InitalValueInput()
    {
        /* 初期値入力*/
        wrongdecision = false;//間違った決断をしたか
        froudoccurred = false;//不正発生したか否か
        _okbuttun.interactable = true;
        _nobuttun.interactable = true;
        _nextCharabuttun.interactable = false;
        _nowTimeUpdate.isStop = false;
        _timerTranceChange.isFlash = false;
    }
    IEnumerator AdvencherMove()
    {
        _nextCharabuttun.interactable = false;
        _advencher.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _advencher.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        _enemyMotion.EnemyNOMove();
        yield return new WaitForSeconds(0.1f);
        Destroy(_enemyMotion.thisEnemy);
        _nextCharabuttun.interactable = true;
    }
    void Update()
    {

        //時間を計算する
        if (!_timerMaster.TimeController(Time.deltaTime))
        {
            //_nextCharabuttun.interactable = false;
            isGameOver = true;
        }
    }
}
