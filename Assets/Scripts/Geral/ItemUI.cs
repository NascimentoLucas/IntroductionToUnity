using UnityEngine;
using UnityEngine.UI;



public class ItemUI : MonoBehaviour
{
    [SerializeField]
    private Image image;

    public void SetupImage(Sprite sprite)
    {
        image.sprite = sprite;

    }
}
