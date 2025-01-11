using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class pywriter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PythonRunner.RunFile("Assets/importdata.py");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
