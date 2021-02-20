using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    private static object _lock = new object();

    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    int numberOfObjFound = FindObjectsOfType(typeof(T)).Length;
                    if (numberOfObjFound > 1 || _instance == null)
                    {
                        if (_instance == null)
                        {
                            Debug.LogError("[SceneSingleton] An instance of " + typeof(T) +
                                    " does not exist on the scene ");
                        }
                        else
                        {
                            Debug.LogError("[SceneSingleton] There are more than one instance of  "
                                                        + typeof(T) + " on the scene! It should be just one!");
                        }
                    }
                    else
                    {
                        Debug.Log("[SceneSingleton] Using this particular created: " +
                            _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        }
    }
}
