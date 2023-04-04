using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName ="BulletType", order =1)]
public class AmmonationType : ScriptableObject
{
    public enum BulletType { Walther_P38, MP_40, Thompson };
    //public BulletType bulletType = BulletType.Walther_P38;

}
