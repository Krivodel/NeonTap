using UnityEngine;
using System.Collections;
#if UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace Krivodeling.ShareSystem
{
    public class Sharing : MonoBehaviour
    {
        public static Sharing Instance { get; private set; }

        private Transform _transform;
        private CanvasGroup _canvasGroup;

        public float Speed = 2f;

#if UNITY_IOS
		[DllImport ("__Internal")]
		private static extern void shareVia (string app, string message, string url, string param);
#endif

        public void ShareVia(string app, string message, string param = "")
        {
#if UNITY_ANDROID
            message = string.Format("{0} {1}", message, ShareData.Instance.Url);

            using (var plugin = new AndroidJavaClass("com.mycompany.sharing.Plugin"))
            {
                plugin.CallStatic("shareVia", app, message);
            }
#elif UNITY_IOS
			shareVia(app, message, ShareData.Instance.Url, param);
#endif
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Share - Canvas");
            GameObject obj = Instantiate(prefab);

            DontDestroyOnLoad(obj);

            obj.hideFlags = HideFlags.HideInHierarchy;

            Instance = obj.GetComponentInChildren<Sharing>();

            Instance.HideInstant();
        }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            StopAllCoroutines();
            StartCoroutine(ShowCoroutine());
        }

        public void ShowInstant()
        {
            Vector3 targetPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f));

            _transform.position = targetPos;
        }

        private IEnumerator ShowCoroutine()
        {
            Vector3 targetPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f));
            float screenHeight = Screen.height;

            _canvasGroup.blocksRaycasts = false;

            while (_transform.position != targetPos)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, targetPos, Speed * screenHeight * Time.deltaTime);

                yield return null;
            }

            _canvasGroup.blocksRaycasts = true;
        }

        public void Hide()
        {
            StopAllCoroutines();
            StartCoroutine(HideCoroutine());
        }

        public void HideInstant()
        {
            Vector3 targetPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, -0.5f, 0f));

            _transform.position = targetPos;
        }

        private IEnumerator HideCoroutine()
        {
            Vector3 targetPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, -0.5f, 0f));
            float screenHeight = Screen.height;

            _canvasGroup.blocksRaycasts = false;

            while (_transform.position != targetPos)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, targetPos, Speed * screenHeight * Time.deltaTime);

                yield return null;
            }
        }
    }
}
