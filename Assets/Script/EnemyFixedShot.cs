using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;

    //弾のゲームオブジェクトを入れる
    public GameObject bullet;

    //一回で打ち出す弾の数
    public int bulletWayNum = 3;

    //打ち出す弾の間隔
    public float bulletWaySpace = 30;

    //打ち出す弾の角度調整
    public int bulletWayAxis = 0;

    //打ち出す間隔
    public float time = 1;

    //最初に撃つまでの時間
    public float delayTime = 1;

    //現在タイマー時間
    float nowtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //タイマー初期化
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //もしプレイヤーの情報が入って無ければ
        if (player == null)
        {
            //プロジェクトのplayerを探して情報を取得
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //タイマーを減らす
        nowtime -= Time.deltaTime;

        //もしタイマーが0以下なら
        if (nowtime <= 0)
        {
            //角度調整用変数
            float bulletWaySpaceSplit = 0;

            //一回で発射する弾数分だけループする
            for (int i = 0; i < bulletWayNum; i++)
            {
                CreateShotObject(
                    bulletWaySpace - bulletWaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y
                    );

                //角度調整
                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }
            //タイマー初期化
            nowtime = time;
        }

    }
    private void CreateShotObject(float axis)
    {
        //弾を生成
        GameObject bulletClone =
        Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);

        //弾を打ち出す角度
        bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));
    }

}
