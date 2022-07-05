using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //発生させるパーティクル
    public GameObject particle;

    //テキスト
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    //ボムの数
    int bombNum;

    // Start is called before the first frame update
    void Start()
    {
        bombNum = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && bombNum >= 1)
        {
            //タグが同じオブジェクトを取得
            GameObject[] enemyBulletObjects =
            GameObject.FindGameObjectsWithTag("EnemyBullet");

            //上で取得した全てのオブジェクトを消滅
            for(int i = 0; i < enemyBulletObjects.Length; i++)
            {
                Destroy(enemyBulletObjects[i].gameObject);
            }

            //パーティクルを持ったオブジェクトを生成
            Instantiate(particle, Vector3.zero, Quaternion.identity);

            bombNum = bombNum - 1;
        }

        if (bombNum <= 2)
        {
            panel3.SetActive(false);
        }
        if (bombNum <= 1)
        {
            panel2.SetActive(false);
        }
        if (bombNum <= 0)
        {
            panel1.SetActive(false);
        }
    }
}
