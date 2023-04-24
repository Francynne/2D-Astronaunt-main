using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectibleController1 : LevelManager
{
    int end1 = 0;
    int part = 3;

    [SerializeField]
    TextMeshProUGUI partsText;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Door"))
        {
            AudioManager.Instance.PlaySFX("ParteNave");
            Destroy(other.gameObject);
            part++;
            partsText.text = "Partes: " + part;

        }

        if (other.gameObject.CompareTag("Machinne"))
        {
            AudioManager.Instance.PlaySFX("ParteNave");
            Destroy(other.gameObject);
            part++;
            partsText.text = "Partes: " + part;

        }

        if (other.gameObject.CompareTag("Windows"))
        {
            AudioManager.Instance.PlaySFX("ParteNave");
            Destroy(other.gameObject);
            part++;
            partsText.text = "Partes: " + part;

        }

        if (other.gameObject.CompareTag("End1"))
        {
            if (part >= 6)
            {
                Destroy(other.gameObject);
                end1++;
                AudioManager.Instance.PlaySFX("Gane");
                GetScene("EndGame");
            }
        }
    }
}
