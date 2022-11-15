using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour
    {
        /// <summary>
        /// Enemy 的父节点
        /// </summary>
        public GameObject Enemies;

        void Start()
        {
            transform.Find("BtnGameStart").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    gameObject.SetActive(false);

                    // 触发事件
                    new StartGameCommand().Execute();
                });
        }
    }
}

