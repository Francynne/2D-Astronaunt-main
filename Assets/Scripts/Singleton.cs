using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>: MonoBehaviour

    where T : Component
{
    static Singleton<T> instance;
    protected static object syncLock = new object();

    protected virtual void Awake()
    {
        bool destroyMe = true;

        if (instance == null)
        {
            //Lock no permite una segunda instancia
            lock (syncLock)
            {
                if (instance == null)
                {
                    destroyMe = false;
                    instance = this;
                    DontDestroyOnLoad(gameObject);
                }
            }
        }

        if (destroyMe)
        {
            Destroy(gameObject);
            return;
        }
    }

    public static T Instance
    {
        get { return instance as T; }
    }
}
