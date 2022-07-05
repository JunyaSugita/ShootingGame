using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwerdShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;

    //弾のゲームオブジェクトのプレハブを入れる
    public GameObject bullet;

    //打ち出す間隔
    public float time = 1;

    //最初に打ち出すまでの時間
    public float delayTime = 1;

    //現在のタイマー時間
    float nowtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //タイマーを初期化
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //もしプレイヤーの情報が無ければ
        if(player == null)
        {
            //プロジェクトのplayerを探して情報を取得
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //タイマーを減らす
        nowtime -= Time.deltaTime;

        //もしタイマーが0になったら
        if(nowtime <= 0)
        {
            //弾を生成
            CreateShotObject(-transform.localEulerAngles.y);
            nowtime = time;
        }
    }

    private void CreateShotObject(float axis)
    {
        var direction = player.transform.position - transform.position;

        //ベクトルyを初期化
        direction.y = 0;

        //向きを取得
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        //弾を生成
        GameObject bulletClone =
        Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);

        //弾を打ち出す角度を変更する
        bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}
