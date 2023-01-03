using System.Security.Cryptography.X509Certificates;
using UnityEngine;

// 测试下
namespace QFramework.Example
{
    public class Enemy : MonoBehaviour, IController
    {

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Interface;
        }
        private void Update()
        {

        }
        private void Awake()
        {

        }

        /// <summary>
        /// ����Լ�������
        /// </summary>
        private void OnMouseDown()
        {
            gameObject.SetActive(false);
            this.SendCommand<KillEnemyCommand>();
        }
    }
}

