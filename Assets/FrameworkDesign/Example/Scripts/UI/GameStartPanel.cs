using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour
    {
        /// <summary>
        /// Enemy �ĸ��ڵ�
        /// </summary>
        public GameObject Enemies;

        void Start()
        {
            transform.Find("BtnGameStart").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    gameObject.SetActive(false);

                    // �����¼�
                    new StartGameCommand().Execute();
                });
        }
    }
}

