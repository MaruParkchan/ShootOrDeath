using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonControl : MonoBehaviour 
{
    [SerializeField] private KeyCode buyItemButton;
    [SerializeField] private Text[] itemText;
    [SerializeField] private int buyAmmo;
    [SerializeField] private int limitAmmo;
    [SerializeField] private int priceItem;
    [SerializeField] private Weapon weapon;
    [SerializeField] private int weaponNumber;
    private Player player;

    private Image image;
    [SerializeField] private Color[] color = new Color[2];

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        image = GetComponent<Image>();
        UpdateText();
    }

    void Update ()
    {
        UpdateText();
        ChangeImageColor();
        
        if(Input.GetKeyDown(buyItemButton))
        {
            BuyItem();
        }

    }

    public void UpdateText()
    {
        itemText[0].text = "" + weapon.IsCurrentAmmo;
        itemText[1].text = "" + weapon.IsMaxAmmo;
        itemText[2].text = "" + priceItem;
    }

    public void BuyItem()
    {
        WeaponChange();
        if (DataController.money >= priceItem && weapon.IsMaxAmmo < limitAmmo && weapon.IsMaxAmmo < weapon.LimitAmmoMax)
        {
            Debug.Log("아이템삼");
            weapon.BuyAmmo(buyAmmo);
            DataController.money -= priceItem;
        }
    }
    public void WeaponChange()
    {
        player.GunChange(weaponNumber);
    }

    private void ChangeImageColor()
    {
        if (DataController.money >= priceItem)
            image.color = color[0];
        else
            image.color = color[1];
    }
}
