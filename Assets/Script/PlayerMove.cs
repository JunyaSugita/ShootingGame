using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�J�������猩����ʍ����̍��W������ϐ�
    Vector3 LeftBotton;
    //�J�������猩����ʉE��̍��W������ϐ�
    Vector3 RightTop;
    //�q�I�u�W�F�N�g
    private float Left, Right, Top, Bottom;

    //�̗�
    private int playerHp;

    //�e�L�X�g
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
        //�J�����ƃv���C���[�̋����𑪂�
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        //�X�N���[����ʍ���
        LeftBotton = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));

        //�X�N���[����ʉE��
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        //�q�I�u�W�F�N�g�̐��������[�v����
        foreach (Transform child in gameObject.transform)
        {
            //�q�I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�Ȃ�
            if (child.localPosition.x >= Right)
            {
                //�q�I�u�W�F�N�g�̃��[�J��X���W���E�[�̕ϐ��ɑ��
                Right = child.transform.localPosition.x;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԍ��̈ʒu�Ȃ�
            if (child.localPosition.x <= Left)
            {
                //�q�I�u�W�F�N�g�̃��[�J��X���W�����[�̕ϐ��ɑ��
                Left = child.transform.localPosition.x;

            }
            //�q�I�u�W�F�N�g�̒��ň�ԏ�̈ʒu�Ȃ�
            if (child.localPosition.z >= Top)
            {
                //�q�I�u�W�F�N�g�̃��[�J��Z���W�����[�̕ϐ��ɑ��
                Top = child.transform.localPosition.z;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԉ��̈ʒu�Ȃ�
            if (child.localPosition.z <= Bottom)
            {
                //�q�I�u�W�F�N�g�̃��[�J��Z���W�����[�̕ϐ��ɑ��
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
