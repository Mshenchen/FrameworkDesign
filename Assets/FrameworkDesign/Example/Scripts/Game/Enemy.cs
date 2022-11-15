using UnityEngine;

// 写命名空间是个好习惯
namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        /// <summary>
        /// 点击自己则销毁
        /// </summary>
        private void OnMouseDown()
        {
            Destroy(gameObject);

            new KillEnemyCommand().Execute();
        }
    }
}

