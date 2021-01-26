using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public class SetComplexityAtStart : MonoBehaviour
    {
        public Complexity DefaultComplexity = Complexity.Normal;
        public string LastComplexityKey = "LastComplexity";

        private void Start()
        {
            Complexity complexity;

            if (PlayerPrefs.HasKey(LastComplexityKey))
                complexity = (Complexity)PlayerPrefs.GetInt(LastComplexityKey);
            else
                complexity = DefaultComplexity;

            EventBus.Instance.PostEvent(new ComplexityChangedEvent(complexity));

            Destroy(gameObject);
        }
    }
}
