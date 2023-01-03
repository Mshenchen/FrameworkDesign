using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example
{
    public class IOCExample : MonoBehaviour
    {
        private void Start()
        {
            var container = new IOCContainer();
            container.Register<IBluetoothManager>(new BluetoothManager());
            var bluetoothManager = container.Get<IBluetoothManager>();
            bluetoothManager.Connect();
        }
        public interface IBluetoothManager
        {
            void Connect();
        }
        public class BluetoothManager:IBluetoothManager
        {
            public void Connect()
            {
                Debug.Log("¿∂—¿¡¥Ω”≥…π¶");
            }
        }
    }
}

