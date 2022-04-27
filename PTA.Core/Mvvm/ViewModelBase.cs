using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PTA.Core.Mvvm
{
    public abstract class ViewModelBase : BindableBase, IDestructible
    {
        private readonly Dictionary<string, object> properties = new Dictionary<string, object>();


        protected ViewModelBase()
        {

        }

        public virtual void Destroy()
        {

        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        protected T Get<T>([CallerMemberName] string propertyName = null)
        {
            if (properties.TryGetValue(propertyName, out object value))
                return value == null ? default : (T)value;
            return default;
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="value">Value of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        protected void Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(value, Get<T>(propertyName)))
                return;
            properties[propertyName] = value;
            RaisePropertyChanged(propertyName);
        }
    }
}