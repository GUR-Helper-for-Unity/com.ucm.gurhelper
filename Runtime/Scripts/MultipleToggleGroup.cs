using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Este script se conectar� posteriormente con el que analice los resultados, para recoger el array de toggles y comprobar qu� indices est�n On
/// </summary>
public class MultipleToggleGroup : MonoBehaviour
{
    [SerializeField]
    public List<Toggle> toggleArray;
}
