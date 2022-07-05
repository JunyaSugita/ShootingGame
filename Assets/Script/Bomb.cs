using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //����������p�[�e�B�N��
    public GameObject particle;

    //�e�L�X�g
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    //�{���̐�
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
            //�^�O�������I�u�W�F�N�g���擾
            GameObject[] enemyBulletObjects =
            GameObject.FindGameObjectsWithTag("EnemyBullet");

            //��Ŏ擾�����S�ẴI�u�W�F�N�g������
            for(int i = 0; i < enemyBulletObjects.Length; i++)
            {
                Destroy(enemyBulletObjects[i].gameObject);
            }

            //�p�[�e�B�N�����������I�u�W�F�N�g�𐶐�
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
