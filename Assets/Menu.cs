using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    /// <summary>
    /// ���˵�
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��ʼ��Ϸ
    public void StartGame()
    {
        //LoadScene���س����±�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //�˳���Ϸ
    public void ExitGame()
    {
        Application.Quit();
    }
}
