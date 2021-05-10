using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WeaponScript : MonoBehaviour
{
    [Header("Which slots?")]
    public bool hasStockSlot;
    public bool hasMagSlot;
    public bool hasSightSlot;
    public bool hasBarrelSlot;
    public bool hasGripSlot;

    [Header("Final Weapon Statistics!")]
    public float finalFireRate;
    public float finalAimDownSiteSpeed;
    public float finalHorizontalRecoil;
    public float finalVerticalRecoil;
    public float finalReloadSpeed;
    public float finalBulletVelocity;
    public float finalBulletDrop;
    public float finalWeight;

    public Transform[] attachmentSlots;
}
