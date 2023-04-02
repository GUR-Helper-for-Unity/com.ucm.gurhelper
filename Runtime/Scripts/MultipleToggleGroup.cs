using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Este script se conectará posteriormente con el que analice los resultados, para recoger el array de toggles y comprobar qué indices están On
/// </summary>
public class MultipleToggleGroup : MonoBehaviour
{
    [SerializeField]
    public List<Toggle> toggleArray;
}
