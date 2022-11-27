using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign 
{
    public interface IModel : IBelongToArchitecture
    {

        void Init();
    }
}

