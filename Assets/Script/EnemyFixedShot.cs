using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    //�v���C���[
    private GameObject player;

    //�e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;

    //���őł��o���e�̐�
    public int bulletWayNum = 3;

    //�ł��o���e�̊Ԋu
    public float bulletWaySpace = 30;

    //�ł��o���e�̊p�x����
    public int bulletWayAxis = 0;

    //�ł��o���Ԋu
    public float time = 1;

    //�ŏ��Ɍ��܂ł̎���
    public float delayTime = 1;

    //���݃^�C�}�[����
    float nowtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[������
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //�����v���C���[�̏�񂪓����Ė������
        if (player == null)
        {
            //�v���W�F�N�g��player��T���ď����擾
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //�^�C�}�[�����炷
        nowtime -= Time.deltaTime;

        //�����^�C�}�[��0�ȉ��Ȃ�
        if (nowtime <= 0)
        {
            //�p�x�����p�ϐ�
            float bulletWaySpaceSplit = 0;

            //���Ŕ��˂���e�����������[�v����
            for (int i = 0; i < bulletWayNum; i++)
            {
                CreateShotObject(
                    bulletWaySpace - bulletWaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y
                    );

                //�p�x����
                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }
            //�^�C�}�[������
            nowtime = time;
        }

    }
    private void CreateShotObject(float axis)
    {
        //�e�𐶐�
        GameObject bulletClone =
        Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBullet�̃Q�b�g�R���|�[�l���g��ϐ��Ƃ��ĕۑ�
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        //�e��ł��o�����I�u�W�F�N�g�̏���n��
        bulletObject.SetCharacterObject(gameObject);

        //�e��ł��o���p�x
        bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));
    }

}
