using UnityEngine;

namespace FrameworkDesign.Example
{
    public class UI : MonoBehaviour
    {
        void Start()
        {
            GamePassEvent.Register(OnGamePass);
        }

        private void OnGamePass()
        {
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
            Debug.Log(98643);
        }

        private void OnDestroy()
        {
            GamePassEvent.UnRegister(OnGamePass);
        }
    }
}
