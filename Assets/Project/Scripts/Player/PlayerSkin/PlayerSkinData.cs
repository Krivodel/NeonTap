using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = "New Player Skin", menuName = EditorConfig.MAIN_MENU + "Player Skin")]
    public class PlayerSkinData : ScriptableObject
    {
        public Sprite Sprite;
        public pint Price = 10;
    }
}
