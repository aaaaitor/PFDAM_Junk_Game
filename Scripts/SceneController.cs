using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneChange(string nombre)
    {
        // Carga la escena especificada
        SceneManager.LoadScene(nombre);
    }
}
