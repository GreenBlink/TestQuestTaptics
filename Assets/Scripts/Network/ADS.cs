using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEditor.PackageManager.Requests;

public class ADS : MonoBehaviour
{
    void Start()
    {
        Advertisement.Initialize("ca-app-pub-8031020776871928~6802399658");    
    }

    public void Show()
    {
        Advertisement.Show("ca-app-pub-3940256099942544~3347511713");
    }
}
