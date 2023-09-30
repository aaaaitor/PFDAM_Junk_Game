using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    [SerializeField]
    GameObject panelPausa;

    public void PauseGame()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }
}
