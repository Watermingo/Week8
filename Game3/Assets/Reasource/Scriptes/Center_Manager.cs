using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Center_Manager : MonoBehaviour
{
    public int my_point, enemy_point;
    public Text my_point_ui, enemy_point_ui;
    public GameObject Gameover;
    void Start()
    {
        
    }

   
    void Update()
    {
        my_point_ui.text = "Your Points:\n"+ my_point;
        enemy_point_ui.text = "Enemy's Points:\n" + enemy_point;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (my_point > 20 || enemy_point > 20)
        {
            Gameover.SetActive(true);
        }
    }
    public void Scene_Load(int index)
    {
        Application.LoadLevel(0);
    }
   
}
