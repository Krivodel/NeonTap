using UnityEngine;
using Krivodeling.ShareSystem;

namespace Project
{
    public class SetShareMessage
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Awake()
        {
            ShareData.Instance.SetMessage(ShareData.Instance.Message, RecordInfo.Instance.LastRecord);
        }
    }
}
