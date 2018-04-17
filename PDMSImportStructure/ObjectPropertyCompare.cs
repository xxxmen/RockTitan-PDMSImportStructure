using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace SortableBindingList
{
    class ObjectPropertyCompare<T> : System.Collections.Generic.IComparer<T>
    {
        private PropertyDescriptor property;
        private ListSortDirection direction;

        public ObjectPropertyCompare(PropertyDescriptor property, ListSortDirection direction)
        {
            this.property = property;
            this.direction = direction;
        }

        #region IComparer<T>

        /// <summary>
        /// 比較方法
        /// </summary>
        /// <param name="x">相對屬性x</param>
        /// <param name="y">相對屬性y</param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            object xValue = x.GetType().GetProperty(property.Name).GetValue(x, null);
            object yValue = y.GetType().GetProperty(property.Name).GetValue(y, null);

            int returnValue;

            if (xValue is IComparable)
            {
                returnValue = ((IComparable)xValue).CompareTo(yValue);
            }
            else if (null == xValue && null != yValue)
            {
                returnValue = -1;
            }
            else if (null != xValue && null == yValue)
            {
                returnValue = 1;
            }
            else if (null == xValue && null == yValue)
            {
                returnValue = 0;
            }
            else if (xValue.Equals(yValue))
            {
                returnValue = 0;
            }
            else
            {
                returnValue = xValue.ToString().CompareTo(yValue.ToString());
            }

            if (direction == ListSortDirection.Ascending)
            {
                return returnValue;
            }
            else
            {
                return returnValue * -1;
            }
        }

        public bool Equals(T xWord, T yWord)
        {
            return xWord.Equals(yWord);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}
