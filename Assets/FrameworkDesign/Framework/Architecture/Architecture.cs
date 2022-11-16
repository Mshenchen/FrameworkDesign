using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{
    public interface IArchitecture
    {
        T GetUtility<T>() where T : class;
    }
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        private static T mArchitecture;
        static void MakeSureArchitecture()
        {
            if(mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();
            }
        }
        protected abstract void Init();
        protected IOCContainer mContainer = new IOCContainer();
        public static T Get<T>() where T: class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }
        public void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }
        public void RegisterModel<T>(T model) where T : IBelongToArchitecture
        {
            model.Architecture = this;
            mContainer.Register<T>(model);
        } 
        public T GetUtility<T>() where T : class
        {
            return mContainer.Get<T>();
        }
    }
}

