using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject panelMuerte;

    [SerializeField]
    GameObject panelMejora;

    public void ToggleDeathPanel()
    {
        panelMuerte.SetActive(!panelMuerte.activeSelf);
    }

    public void ToggleUpgradePanel()
    {
        panelMejora.SetActive(!panelMejora.activeSelf);
    }

}
