﻿using UnityEngine;
using UnityEngine.UI;

public class DisplayGeneratorRate : MonoBehaviour
{
    public Generator generator = null;

    public enum GeneratorRateType { Current, Next }
    public GeneratorRateType currentOrNext = GeneratorRateType.Current;

    public Text textDisplayUI = null;

    public string prefix = "";
    public string separator = "/";
    public string suffix = "";

    public int maximumDecimalPlaces = 2;

    // Use this for initialization
    void Start()
    {
        if (textDisplayUI == null)
        {
            textDisplayUI = gameObject.GetComponent<Text>();
            if (textDisplayUI == null)
                Debug.LogWarning("DisplayUpgradeRate requires a Text script be on the same gameobject, or that you provice a link to a Text object. Disabling." );
        }

        if (generator == null)
        {
            generator = gameObject.GetComponent<Generator>();
            if(generator == null)
                Debug.LogWarning("DisplayUpgradeRate requires a Generator script be on the same gameobject, or that you provice a link to a Generator object. Disabling.");

        }//if

        enabled = (textDisplayUI != null && generator != null);
    }

    private string _str = "";
    // Update is called once per frame
    void Update()
    {
        _str = "{0}{1:N"+ maximumDecimalPlaces + "}{2}{3:N" + maximumDecimalPlaces + "}{4}";
        textDisplayUI.text = string.Format(_str, 
            prefix, 
            generator.TotalAmountPerClick((currentOrNext == GeneratorRateType.Current) ? generator.currentLevel : generator.currentLevel + 1),
            separator,
            generator.tickDurationInSeconds,
            suffix);
    }
}
