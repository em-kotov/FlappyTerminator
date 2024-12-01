using UnityEngine;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _starCountText;

    public void DisplayStarCount(int count)
    {
        _starCountText.text = count.ToString();
    }
}
