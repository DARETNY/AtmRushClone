using System;
using System.Collections.Generic;

namespace AtmRushClone.Scripts.Manager.Locater
{
    public static class ServiceLocater
    {
        private static readonly Dictionary<Type, ILocater> ServiceLocator = new Dictionary<Type, ILocater>();

        public static T GetManager<T>() where T : class, ILocater
        {
            if (ServiceLocator.ContainsKey(typeof(T)))
                return ServiceLocator[typeof(T)] as T;
            return null;
        }

        public static T Register<T>(T instance) where T : class, ILocater
        {
            ServiceLocator.Add(typeof(T), instance);
            return instance;
        }


        #region Getmanagers

        //todo: add all member of  managers here

        #endregion
    }
}