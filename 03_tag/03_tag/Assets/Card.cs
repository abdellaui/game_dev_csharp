using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Card")]
public class Card : ScriptableObject
{

    // Start is called before the first frame update
    [SerializeField] public Sprite spr;
    [SerializeField] public string title;
}
