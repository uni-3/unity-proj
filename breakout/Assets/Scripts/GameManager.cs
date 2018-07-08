using System.Linq;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BlockProvider BlockProvider { get; private set; }
    public GameObject BlocksArea { get; private set; }
    public ScoreManager ScoreManager { get; private set; }
    public GameObject Ground { get; private set; }
    public GameObject GameoverText { get; private set; }
    // ブロックの数
    public int row = 1;
    public int column = 2;
    private bool isGameover = false;
    private bool isGameclear = false;

    void Start()
    {
        this.BlockProvider = GetComponent<BlockProvider>();
        this.BlocksArea = GameObject.Find("Blocks");
        this.ScoreManager = GetComponent<ScoreManager>();
        this.Ground = GameObject.Find("Bottom");
        this.GameoverText = GameObject.Find("Gameover");

        // 配置の初期化
        InitializeStage();

        // objectの非表示   
        this.GameoverText.SetActive(false);
    }

    // gameoverになったらテキストを表示して再スタートできるようにする
    void Update () {
        if (isGameover) {
            this.GameoverText.SetActive(true);
            //マウス左クリック、スペースキー、Aボタン、ジャンプボタンを押した場合
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) {
                SceneManager.LoadScene("GameScene");
            }
        }

        if (isGameclear) {
            SceneManager.LoadScene("GameClearScene");
        }

    }


    /// <summary>
    /// ブロック配置の初期化
    /// </summary>
    private void InitializeStage()
    {
        var blocks = new List<Block>();

        // 開始位置とブロックのサイズ
        var startPosX = -160;
        var startPosY = -80;
        var width = 70;
        var height = 20;

        // ブロックを生成
        // 各ブロックのポジションは開始位置からブロックサイズ分右下にずらす
        for (int i = 0; i < row; i++)
        {
            var posY = startPosY - height * i;
            for (int j = 0; j < column; j++)
            {
                var posX = startPosX + width * j;
                var position = new Vector2(posX, posY);
                if (row % 2 == 0) {
                    var color = Color.gray;
                } else {
                    var color = Color.red;
                }
                var block = BlockProvider.Create(this.BlocksArea.GetComponent<RectTransform>(), position, Color.gray);
                blocks.Add(block);

                // ブロックがこわれたとき
                block.OnBroken.Subscribe(
                    score => {
                        this.ScoreManager.UpdateScore(score);
                        // ブロック全部壊したらクリア
                        if (this.ScoreManager.Score == block.Score * row * column) {
                            GameClear();
                        }
                    }).AddTo(block);
            }
        }

        // ゲームオーバ処理
        this.Ground.OnTriggerEnter2DAsObservable()
            .Subscribe(
                collider => {
                    Destroy(collider.gameObject);
                    GameOver();
                }
            );
    }
    private void GameClear () {
		isGameclear = true;
        Debug.Log("game clear...");
    }

    private void GameOver () {
        isGameover = true;
        Debug.Log("game over...");
    }

    // 動かない
    private void CheckBlockCount() {
		if(GameObject.FindWithTag("block1") == null) {
			isGameclear = true;
		}
	}
}