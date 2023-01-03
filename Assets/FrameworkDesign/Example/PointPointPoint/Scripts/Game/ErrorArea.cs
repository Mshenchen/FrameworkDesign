using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QFramework.Example
{
    public class ErrorArea : MonoBehaviour, IController
    {

        private void OnMouseDown()
        {
            this.SendCommand<MissCommand>();
        }
        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }



    }
}


