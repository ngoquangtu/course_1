using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleFactory : ICharacterFactory
{
    public Character CreateCharacter()
    {
        return new RectanglePlayer(10.0f);
    }
}
