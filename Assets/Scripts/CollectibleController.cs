using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectibleController : LevelManager
{
    int end = 0;
    int keys = 0;

    [SerializeField]
    TextMeshProUGUI partsText;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Chair"))
        {
            AudioManager.Instance.PlaySFX("ParteNave");
            Destroy(other.gameObject);
            keys++;
            partsText.text = "Partes: " + keys;

        }

        if (other.gameObject.CompareTag("Computer"))
        {
            AudioManager.Instance.PlaySFX("ParteNave");
            Destroy(other.gameObject);
            keys++;
            partsText.text = "Partes: " + keys;

        }

        if (other.gameObject.CompareTag("Control"))
        {
            AudioManager.Instance.PlaySFX("ParteNave");
            Destroy(other.gameObject);
            keys++;
            partsText.text = "Partes: " + keys;

        }


        if (other.gameObject.CompareTag("End"))
        {       
            if (keys >= 3)
            {
                Destroy(other.gameObject);
                end++;
                GetScene("Level2");
            }
        }

    }
}
