using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PTA.Types
{
    /// <summary>
    /// Represents a list that provides notifications when items get added, removed, or when the whole list is refreshed. Provides methods to search, sort, and manipulate lists.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class ObservableList<T> : List<T>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        /// <summary>
        /// Notifies clients that a property value has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies listeners of dynamic changes, such as when an item is added and removed or the whole list is cleared.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;



        /// <summary>
        /// Initializes a new instance of a <see cref="ObservableList{T}"/>
        /// </summary>
        public ObservableList()
        {

        }

        /// <summary>
        /// Initializes a new instance of a <see cref="ObservableList{T}"/>.
        /// </summary>
        /// <param name="items">An array that is converted to <see cref="ObservableList{T}"/></param>
        public ObservableList(T[] items)
        {
            var itemsCount = items.Count();

            for (int i = 0; i < itemsCount; i++)
            {
                base.Add(items[i]);
            }

            NotifyCollectionChanged();
        }



        /// <summary>
        /// Adds an object to the end of the <see cref="ObservableList{T}"/>
        /// </summary>
        /// <param name="item">The object to be added to the end of the <see cref="ObservableList{T}"/>. The value can be null for reference types.</param>
        public new void Add(T item)
        {
            base.Add(item);
            NotifyCollectionChanged();
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="ObservableList{T}"/>.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="ObservableList{T}"/>. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public new void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);
            NotifyCollectionChanged();
        }

        /// <summary>
        /// Removes all elements from the <see cref="ObservableList{T}"/>.
        /// </summary>
        public new void Clear()
        {
            base.Clear();
            NotifyCollectionChanged();
        }

        /// <summary>
        /// Inserts an element into the <see cref="ObservableList{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        public new void Insert(int index, T item)
        {
            base.Insert(index, item);
            NotifyCollectionChanged();
        }

        /// <summary>
        /// Inserts the elements of a collection into the <see cref="ObservableList{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the <see cref="ObservableList{T}"/>. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public new void InsertRange(int index, IEnumerable<T> collection)
        {
            base.InsertRange(index, collection);
            NotifyCollectionChanged();
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="ObservableList{T}"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="ObservableList{T}"/>. The value can be null for reference types.</param>
        public new void Remove(T item)
        {
            base.Remove(item);
            NotifyCollectionChanged();
        }

        /// <summary>
        /// Removes all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the elements to remove.</param>
        public new void RemoveAll(Predicate<T> match)
        {
            base.RemoveAll(match);
            NotifyCollectionChanged();
        }

        /// <summary>
        /// Removes the element at the specified index of the <see cref="ObservableList{T}"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            NotifyPropertyChanged();
        }

        /// <summary>
        /// Removes a range of elements from the <see cref="ObservableList{T}"/>.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public new void RemoveRange(int index, int count)
        {
            base.RemoveRange(index, count);
            NotifyCollectionChanged();
        }

        /// <summary>
        /// Moves an element on specified index one index backward (index--).
        /// </summary>
        /// <param name="index">Index of the element.</param>
        public void MoveUp(int index)
        {
            if (index > 0)
            {
                var element = base[index];
                base.RemoveAt(index);
                base.Insert(index - 1, element);
                NotifyCollectionChanged();
            }
        }

        /// <summary>
        /// Finds element and moves it one position backward.
        /// </summary>
        /// <param name="match"></param>
        public void MoveUp(Predicate<T> match)
        {
            var index = base.FindIndex(match);
            MoveUp(index);
        }

        /// <summary>
        /// Moves an element on specified index one index forward (index++).
        /// </summary>
        /// <param name="index">Index of the element.</param>
        public void MoveDown(int index)
        {
            if (index < base.Count - 1)
            {
                var element = base[index];
                base.RemoveAt(index);
                base.Insert(index + 1, element);
                NotifyCollectionChanged();
            }
        }

        /// <summary>
        /// Finds an element and moves it one position forward.
        /// </summary>
        /// <param name="match"></param>
        public void MoveDown(Predicate<T> match)
        {
            var index = base.FindIndex(match);
            MoveDown(index);
        }

        /// <summary>
        /// Notifies clients that value of a given property has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property that has changed.</param>
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Notifies listeners of dynamic changes, such as when an item is added and removed or the whole list is cleared.
        /// </summary>
        public void NotifyCollectionChanged()
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
