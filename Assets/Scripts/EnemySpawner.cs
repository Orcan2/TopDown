using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public int enemyNum;
    public GameObject enemy, spwnPoint,GOmenu,WinMessage;


    // Update is called once per frame
    void Update()
    {
        if (enemyNum < 5)
        {
            Instantiate(enemy, spwnPoint.transform.position, Quaternion.identity);
            enemyNum++;
        }
        else if (enemyNum <= 0) { WinMessage.SetActive(true); }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GOmenu.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
