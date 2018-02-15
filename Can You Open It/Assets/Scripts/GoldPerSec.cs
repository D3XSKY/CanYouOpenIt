using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPerSec : MonoBehaviour {

    public UnityEngine.UI.Text gpsDisplay;
    public Click click;
    public ItemManager[] items;

    void Start()
    {
        StartCoroutine(AutoTick());
    }

    void Update()
    {
        gpsDisplay.text = GetGoldPerSec () + " gold/sec";
    }

    public float GetGoldPerSec()
    {
        float tick = 0;
        foreach (ItemManager item in items)
        {
            tick += item.count * item.tickValue;
        }
        return tick;
    }

    public void AutoGoldPerSec()
    {
        click.gold += GetGoldPerSec () / 10;
    }
    IEnumerator AutoTick()
    {
        while (true)
        {
            AutoGoldPerSec();
            yield return new WaitForSeconds(0.10f);

        }
    }
}
