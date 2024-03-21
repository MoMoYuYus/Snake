using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [AddComponentMenu("Game/GameManager")]

    public Button button_restart;
    public Button button_backmenu;
    public Text txt_gameover;
    public Button button_continuegame;
    public Button button_backmenu2;
    public Text txt_pausegame;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject uicanvas = GameObject.Find("GamingMenu");
        foreach(Transform t in uicanvas.transform.GetComponentsInChildren<Transform>())
        {
            if (t.name.CompareTo("GameOver") == 0)
            {
                txt_gameover = t.GetComponent<Text>();
                txt_gameover.gameObject.SetActive(false);
            }else if(t.name.CompareTo("RestartGame") == 0)
            {
                button_restart = t.GetComponent<Button>();
                button_restart.onClick.AddListener(delegate ()
                {
                    //��ȡ��ǰ�ؿ�
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                });
                button_restart.gameObject.SetActive(false);  //��Ϸ�������ذ�ť
            }else if(t.name.CompareTo("BackMenu") == 0)
            {
                button_backmenu = t.GetComponent<Button>();
                button_backmenu.onClick.AddListener(delegate ()
                {
                    //���ز˵�����
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                });
                button_backmenu.gameObject.SetActive(false);  //��Ϸ�������ذ�ť
            }
        }

        GameObject pausecanvas = GameObject.Find("PauseMenu");
        foreach (Transform t in pausecanvas.transform.GetComponentsInChildren<Transform>())
        {
            if (t.name.CompareTo("PauseGame") == 0)
            {
                txt_pausegame = t.GetComponent<Text>();
                txt_pausegame.gameObject.SetActive(false);
            }
            else if (t.name.CompareTo("ContinueGame") == 0)
            {
                button_continuegame = t.GetComponent<Button>();
                button_continuegame.onClick.AddListener(delegate ()
                {
                    //������ǰ�ؿ�
                    if(isPaused)
                    {
                        txt_pausegame.gameObject.SetActive(false);
                        button_continuegame.gameObject.SetActive(false);
                        button_backmenu2.gameObject.SetActive(false);
                        ResumeGame();   //���ü�����Ϸ����
                    }
                });
                button_continuegame.gameObject.SetActive(false);  //��Ϸ�������ذ�ť
            }
            else if (t.name.CompareTo("BackMenu") == 0)
            {
                button_backmenu2 = t.GetComponent<Button>();
                button_backmenu2.onClick.AddListener(delegate ()
                {
                    //���ز˵�����                    
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                    ResumeGame();
                });
                button_backmenu2.gameObject.SetActive(false);  //��Ϸ�������ذ�ť
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //����ESCʱ��Ϸ��ͣ
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {               
                txt_pausegame.gameObject.SetActive(false);
                button_continuegame.gameObject.SetActive(false);
                button_backmenu2.gameObject.SetActive(false);
                ResumeGame();
            }
            else
            {
                PauseGame();
                txt_pausegame.gameObject.SetActive(true);
                button_continuegame.gameObject.SetActive(true);
                button_backmenu2.gameObject.SetActive(true);
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
}
