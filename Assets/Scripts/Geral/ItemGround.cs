using UnityEngine;
using System.Collections;

public class ItemGround : MonoBehaviour
{
    [SerializeField]
    private Itens itemType;

    [SerializeField]
    private Sprite sprite;

    public Sprite GetSprite()
    {
        return sprite;
    }

    public Itens GetItemType()
    {
        return itemType;
    }
}
