using UnityEngine;
using System;

namespace Project
{
    [Serializable]
    public struct LearningSettings
    {
        public bool FirstStartCompleted;
        public bool Shield;
        public bool Invert;

        public string GetString()
        {
            return JsonUtility.ToJson(this);
        }

        public void SetFromString(string value)
        {
            this = JsonUtility.FromJson<LearningSettings>(value);
        }
    }
}
