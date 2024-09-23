using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bug Data", menuName = "ScriptableObjects/Bug Data", order = 1)]
public class BugData : ScriptableObject
{
    [SerializeField] string bugName;
    [SerializeField] GameObject bugModel;
}
