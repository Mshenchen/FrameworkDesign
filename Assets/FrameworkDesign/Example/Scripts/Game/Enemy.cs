using UnityEngine;

// д�����ռ��Ǹ���ϰ��
namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        /// <summary>
        /// ����Լ�������
        /// </summary>
        private void OnMouseDown()
        {
            Destroy(gameObject);

            new KillEnemyCommand().Execute();
        }
    }
}

