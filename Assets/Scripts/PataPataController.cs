using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PataPataController : MonoBehaviour
{
    [SerializeField]
    private Clear clear;

    public int width=5;
    public int max_color=2;
    public int tekazu = 3;
    public GameObject pataPrefab;

    private int[,] board;
    private int[,] hozonBoard;
    private GameObject[,] pataList;
    //色変える各方向
    private Vector2Int[] Directions
        = {
            new Vector2Int(-1,0),
            new Vector2Int(1,0),
            new Vector2Int(0,-1),
            new Vector2Int(0,1)
        };

    ////仮
    private void Start()
    {
        pataList = new GameObject[this.width, this.width];
        //  // hozonBoard = new int[width, width];
        //    SetBoard(width, max_color);
        //    //Array.Copy( board, hozonBoard , width);
        //    // board.CopyTo(hozonBoard, 0);
        //    // hozonBoard= CopyMatrix(board);
        //    hozonBoard = CopyMatrix(board);
    }
    //ボードその他設定の初期化
    //とりあえず全部赤（正解色）
    public void SetBoard(int width, int max_color)
    {
        this.width = width;
        this.max_color = max_color;
        board = new int[this.width, this.width];
        pataList = new GameObject[this.width, this.width];
        for (int j = 0; j < this.width; j++)
        {
            for (int i = 0; i < this.width; i++)
            {
                board[i, j] = 0;
                GameObject obj = Instantiate(pataPrefab, new Vector3(i, 0, j), Quaternion.identity, transform);
                obj.GetComponent<PataMaterial>().Init(0,new Vector2Int(i,j));
                pataList[i, j] = obj;
                //Pataオブジェクト生成のコード書く
            }
        }
    }

    public void ClickPanel(Vector2Int position , int muki=1)
    {
        //クリックしたときの処理を書く
        //--↓クリックした座標
        board[position.x, position.y]+=muki;
        if(board[position.x, position.y] >= max_color)
        {
            board[position.x, position.y] = 0;
            
        }else if (board[position.x, position.y] <0)
        {
            board[position.x, position.y] = max_color-1;
        }
       
        pataList[position.x, position.y].GetComponent<PataMaterial>().ChangeMaterial(board[position.x, position.y] , muki==1);

        //--↑クリックした座標

        ////--↓周囲４方向
        for (int i_w = 0; i_w < width; i_w++)
        {
            for (int j_d = 0; j_d < Directions.Length; j_d++)
            {
                Vector2Int checkPosition = position + Directions[j_d]*(i_w+1);
                Debug.Log(checkPosition);
                bool borderCheck = BorderCheck(checkPosition);//範囲内チェック
                if (borderCheck)
                {
                    board[checkPosition.x, checkPosition.y]+=muki;
                    if (board[checkPosition.x, checkPosition.y] >= max_color )
                    {
                        board[checkPosition.x, checkPosition.y] = 0;

                    }else if (board[checkPosition.x, checkPosition.y] < 0)
                    {
                        board[checkPosition.x, checkPosition.y] = max_color-1;
                    }
                    pataList[checkPosition.x, checkPosition.y].GetComponent<PataMaterial>().ChangeMaterial(board[checkPosition.x, checkPosition.y],muki == 1);
                }
            }
            
        }
        //向きが１のとき（クリックしたとき）クリア判定する
        if (muki == 1)
        {
            bool isClear=ClearCheck();
            if (isClear)
            {
                Debug.Log("くりあ");
                //ここにクリアしたときの処理を書く
                clear.gameObject.SetActive(true);
                clear.ClearMovie();
            }
        }
    }
    private bool BorderCheck(Vector2Int checkPosition)
    {
        bool check1 = checkPosition.x >= 0 && checkPosition.x < width;
        bool check2= checkPosition.y >= 0 && checkPosition.y < width;
        return ( check1==true && check2==true);
    }
    private Vector2Int[] HintVectors=new Vector2Int[0];
    public void CreateMondai()
    {
        HintVectors = new Vector2Int[tekazu];
        //this.tekazu = tekazu;
        for (int i = 0; i < tekazu; i++)
        {
            Vector2Int changePosition = new Vector2Int(UnityEngine.Random.Range(0, width), UnityEngine.Random.Range(0, width));
            HintVectors[i] = changePosition;
            ClickPanel(changePosition, -1);
        }
        //問題つくったときのボードの状態を保存
        //Array.Copy(board, hozonBoard, width);
        //board.CopyTo(hozonBoard, 0);
        hozonBoard = CopyMatrix(board);
    }

    //パネルの初期化
    public void InitPanel()
    {
        
        board = new int[width, width];
        for (int j = 0; j < this.width; j++)
        {
            for (int i = 0; i < this.width; i++)
            {
                board[i, j] = 0;
                pataList[i, j].GetComponent<PataMaterial>().ChangeMaterial(0);
            }
        }
    }

    //クリアチェック
    public bool ClearCheck()
    {
        for (int j = 0; j < width; j++)
        {
            for (int i = 0; i < width; i++)
            {
               if(board[i, j] != 0) { return false; }
            }
        }
        return true;
    }
    
    public void ClickResetButton()
    {
        //Array.Copy(hozonBoard,board, width);
        //  hozonBoard.CopyTo(board, 0);
        board = CopyMatrix(hozonBoard);
        for (int j = 0; j < width; j++)
        {
            for (int i = 0; i < width; i++)
            {
                pataList[i, j].GetComponent<PataMaterial>().ChangeMaterial(board[i, j], false);
            }
        }
        Debug.Log(board);
    }
    public int[,] CopyMatrix(int[,] sourceArray)
    {
       // int width = sourceArray.Length;
        //Debug.Log(width);
        int[,] distinationArray = new int[width, width];
        for (int j = 0; j < width; j++)
        {
            for (int i = 0; i < width; i++)
            {
                distinationArray[i, j] = sourceArray[i, j];
            }

        }
        return distinationArray;
    }
    //
    private void DestroyPanels()
    {
       //PataMaterial pata= pataList[0,0].GetComponent<PataMaterial>();
        if (pataList[0, 0] != null)
        {
            for (int j = 0; j < pataList.GetLength(0); j++)
            {
                for (int i = 0; i < pataList.GetLength(0); i++)
                {
                    Destroy(pataList[i, j].gameObject);
                }
            }
        }
    
    }
    public void ClickCreate()
    {
       
        DestroyPanels();
        SetBoard(width, max_color);
       // InitPanel();
        CreateMondai();
    }
    [SerializeField]
    private HintViewer hint; 
    public void ClickHint()
    {
        if (HintVectors.Length <= 0) return;
        int index = UnityEngine.Random.Range(0, tekazu);
        hint.HintView(HintVectors[index]);
    }
}
