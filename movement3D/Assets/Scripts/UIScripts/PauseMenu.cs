using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public soundManager soundManager;
    [SerializeField] GameObject menuPausa;
    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }
    public void Reanudar()
    {
        soundManager.Instance.Play(9);
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }
    public void Reiniciar()
    {
        soundManager.Instance.Play(9);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Abandonar()
    {
        soundManager.Instance.Play(9);
        Time.timeScale = 1f;
        SceneManager.LoadScene("PrincipalMenu");
    }
}

