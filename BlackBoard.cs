using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BlackBoard : MonoBehaviour
{
    private static BlackBoard _instance;

    public static BlackBoard instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load<BlackBoard>("BlackBoard"));
            }
            return _instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
