using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraficSettings : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int quality;

    void Start()
    {
        quality = PlayerPrefs.GetInt("numeroDeCalidad", 6);
        dropdown.value = quality;
        AjustQuality();
    }
    public void AjustQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad",dropdown.value);
        quality = dropdown.value;
    }
}
