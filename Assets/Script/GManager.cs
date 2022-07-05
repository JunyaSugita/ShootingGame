using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    private GameObject[] enemy;

    public GameObject panel;
    public GameObject panel2;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        panel2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemy.Length == 0)
        {
            panel.SetActive(true);
            panel2.SetActive(true);
            //�^�O�������I�u�W�F�N�g���擾
            GameObject[] enemyBulletObjects =
            GameObject.FindGameObjectsWithTag("EnemyBullet");

            //��Ŏ擾�����S�ẴI�u�W�F�N�g������
            for (int i = 0; i < enemyBulletObjects.Length; i++)
            {
                Destroy(enemyBulletObjects[i].gameObject);
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneReset();
        }
    }

    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

}
