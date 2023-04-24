using UnityEngine;
using TMPro;
using System;

public class LivesController : LevelManager
{
    [SerializeField]
    TextMeshProUGUI livesText;

    [SerializeField]
    public int vidas = 3;
    public static int counter;
    static bool enter = false;

    void Start()
    {
        if (getLastSceneName() == "Welcome")
        {
            counter = 0;
        }

        livesText.text = "x " + vidas;
        if (counter > 0)
        {
            livesText.text = "x " + (vidas - counter);
        }

    }

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        enter = !enter;
        if (collision.gameObject.CompareTag("Water") && enter)
        {
            RestarLives();
        }
    }

    public void RestarLives()
    {
        counter++;

        if ((vidas - counter) > 0)
        {
           GetScene("Alert");
        }
        else
        {
            GetScene("GameOver");
            vidas = 3;
            counter = 0;
        }

        livesText.text = "x " + (vidas - counter);

    }
    public int getLives()
    {
        return vidas - counter;
    }
}
