using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class ItemPanel : MonoBehaviour
    {
        public TextMeshPro _nameLabel;
        public TextMeshPro _itemNameText;
        public TextMeshPro _descriptionLabel;
        public TextMeshPro _itemDescription;
        public TextMeshPro _goldCostLabel;
        public TextMeshPro _itemGoldCost;

        private Item _item;

        public void SetAppear(bool active)
        {
            gameObject.SetActive(true);
            //_itemNameText.text = _item.
        }
    }
}
