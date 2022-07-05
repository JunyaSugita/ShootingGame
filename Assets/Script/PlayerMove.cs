using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //カメラから見た画面左下の座標を入れる変数
    Vector3 LeftBotton;
    //カメラから見た画面右上の座標を入れる変数
    Vector3 RightTop;
    //子オブジェクト
    private float Left, Right, Top, Bottom;

    //体力
    private int playerHp;

    //テキスト
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;

    // Start is called before the first frame update
    void Start()
    {
        //カメラとプレイヤーの距離を測る
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        //スクリーン画面左下
        LeftBotton = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));

        //スクリーン画面右上
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        //子オブジェクトの数だけループ処理
        foreach (Transform child in gameObject.transform)
        {
            //子オブジェクトの中で一番右の位置なら
            if (child.localPosition.x >= Right)
            {
                //子オブジェクトのローカルX座標を右端の変数に代入
                Right = child.transform.localPosition.x;
            }
            //子オブジェクトの中で一番左の位置なら
            if (child.localPosition.x <= Left)
            {
                //子オブジェクトのローカルX座標を左端の変数に代入
                Left = child.transform.localPosition.x;

            }
            //子オブジェクトの中で一番上の位置なら
            if (child.localPosition.z >= Top)
            {
                //子オブジェクトのローカルZ座標を左端の変数に代入
                Top = child.transform.localPosition.z;
            }
            //子オブジェクトの中で一番下の位置なら
            if (child.localPosition.z <= Bottom)
            {
                //子オブジェクトのローカルZ座標を左端の変数に代入
                Bottom = child.transform.localPosition.z;
            }
        }

        playerHp = 5;
        panel6.SetActive(false);
        panel7.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float speed = 0.3f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.z += speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.z -= speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.x -= speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.x += speed;
        }
        transform.position = new Vector3(
            Mathf.Clamp(pos.x, LeftBotton.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBotton.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top)
            );
        if(playerHp <= 4)
        {
            panel5.SetActive(false);
        }
        if (playerHp <= 3)
        {
            panel4.SetActive(false);
        }
        if (playerHp <= 2)
        {
            panel3.SetActive(false);
        }
        if (playerHp <= 1)
        {
            panel2.SetActive(false);
        }
        if (playerHp <= 0)
        {
            panel1.SetActive(false);
            panel6.SetActive(true);
            panel7.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    public void PlayerDamege()
    {
        playerHp = playerHp - 1;
    }
}
