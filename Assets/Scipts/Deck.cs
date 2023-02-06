using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Deck", order = 1)]
public class Deck : ScriptableObject
{
    public Card[] deck;
}