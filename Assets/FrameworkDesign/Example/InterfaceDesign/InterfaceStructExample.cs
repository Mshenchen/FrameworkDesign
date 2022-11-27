using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example 
{
    public class InterfaceStructExample : MonoBehaviour
    {
        public interface ICustomScript 
        {
            void Start();
            void Update();
            void Destroy();
        }
        public abstract class CustomScript : ICustomScript
        {
            void ICustomScript.Destroy()
            {
                OnDestory();
            }

            void ICustomScript.Start()
            {
                OnStart();
            }

            void ICustomScript.Update()
            {
                OnUpdate();
            }
            protected abstract void OnStart();
            protected abstract void OnUpdate();
            protected abstract void OnDestory();
        }
        public class MyScript : CustomScript
        {
            protected override void OnDestory()
            {
                Debug.Log("On Destory");
            }

            protected override void OnStart()
            {
                Debug.Log("On Start");
            }

            protected override void OnUpdate()
            {
                Debug.Log("On Update");
            }
        }
        private void Start()
        {
            //һ��ײ����
            ICustomScript myScript = new MyScript();
            myScript.Start();
            myScript.Update();
            myScript.Destroy();
        }
    }

}
