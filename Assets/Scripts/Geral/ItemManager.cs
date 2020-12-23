using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private int[] amount;

    [SerializeField]
    private ItemUI[] itemUIs;

    private int free = 0;

    private void Start()
    {
        int size = System.Enum.GetValues(typeof(Itens)).Length;
        amount = new int[size];
        ItemGround[] grounds = null;
        for (int i = 0; i < amount.Length; i++)
        {
            amount[i] = PlayerPrefs.GetInt(((Itens)i).ToString(), 0);

            for (int j = 0; j < grounds.Length; j++)
            {
                if (grounds[j].GetItemType() == (Itens)i)
                {
                    //
                }
            }
        }
    }

    public void SetItem(ItemGround item)
    {
        if (free < itemUIs.Length)
        {
            itemUIs[free].SetupImage(item.GetSprite());
            amount[(int)item.GetItemType()]++;
            PlayerPrefs.SetInt(item.GetItemType().ToString(),
                amount[(int)item.GetItemType()]);
            free += 1;
            Debug.Log(item.GetItemType().ToString());
        }
        else
        {
            Debug.Log("Full");
        }
    }
}
