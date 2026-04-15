using UnityEngine;

public class BeeSpriteHandler : MonoBehaviour
{
    [SerializeField] private Sprite SpeedHatT1;
    [SerializeField] private Sprite SpeedHatT2;
    [SerializeField] private Sprite SpeedHatT3;
    
    [SerializeField] private Sprite MoneyHatT1;
    [SerializeField] private Sprite MoneyHatT2;
    [SerializeField] private Sprite MoneyHatT3;

    [SerializeField] private Sprite LocatorSpriteT1;
    [SerializeField] private Sprite LocatorSpriteT2;
    [SerializeField] private Sprite LocatorSpriteT3;

    [SerializeField] private SpriteRenderer HatSprite;
    private SpriteRenderer beeSprite;

    private void Start()
    {
        beeSprite = gameObject.GetComponent<SpriteRenderer>();
        SetBeeHat();
    }

    private void SetBeeColor(Color beeColor)
    {
        beeSprite.color = beeColor;
    }

    private void SetBeeHat()
    {
        HatSprite.color = Color.white;
        switch (ConstantData.hatType)
        {
            case HatType.Speed:

                switch (ConstantData.hatTeir)
                {
                    case 1:
                        HatSprite.sprite = SpeedHatT1;
                        break;
                    case 2:
                        HatSprite.sprite = SpeedHatT2;
                        break;
                    case 3:
                        HatSprite.sprite = SpeedHatT3;
                        break;
                }
                break;
            case HatType.Money:

                switch (ConstantData.hatTeir)
                {
                    case 1:
                        HatSprite.sprite = MoneyHatT1;
                        break;             
                    case 2:                
                        HatSprite.sprite = MoneyHatT2;
                        break;             
                    case 3:                
                        HatSprite.sprite = MoneyHatT3;
                        break;
                }
                break;
            case HatType.Detection:

                switch (ConstantData.hatTeir)
                {
                    case 1:
                        HatSprite.sprite = LocatorSpriteT1;
                        break;
                    case 2:
                        HatSprite.sprite = LocatorSpriteT2;
                        break;
                    case 3:
                        HatSprite.sprite = LocatorSpriteT3;
                        break;
                }
                break;
            default:
                HatSprite.color = Color.clear;
                break;
        }
    }
}
