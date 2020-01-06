
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Nekram.Infrastructure {
    /// <summary>
    /// Base class for all value objects
    /// </summary>
    /// <typeparam name="T">The type of this value object</typeparam>
    public abstract class ValueObject<T> : IEquatable<T>, IValidatableObject where T : ValueObject<T> {
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">
        /// An object to compare with this object.
        /// </param>
        public bool Equals(T other) {
            if ((object)other == null) {
                return false;
            }

            if (ReferenceEquals(this, other)) {
                return true;
            }

            //compare all public properties
            var publicProperties = GetType().GetProperties();

            return !publicProperties.Any()
                   || publicProperties.All(p => CheckValue(p, other));
        }

        private bool CheckValue(PropertyInfo p, T other) {
            var first = p.GetValue(this, null);
            var second = p.GetValue(other, null);
            if (first == null || second == null)
                return false;

            if (first is T) {
                //check not self-references...
                return ReferenceEquals(first, second);
            }

            return first.Equals(second);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// True if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        public override bool Equals(object obj) {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = obj as ValueObject<T>;

            return item != null && Equals((T)item);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object" />.
        /// </returns>
        public override int GetHashCode() {
            var hashCode = 31;
            var changeMultiplier = false;
            const int index = 1;

            //compare all public properties
            var publicProperties = GetType().GetProperties();

            if (publicProperties.Any()) {
                foreach (var item in publicProperties) {
                    var value = item.GetValue(this, null);

                    if (value != null) {
                        hashCode = hashCode * ((changeMultiplier) ? 59 : 114) + value.GetHashCode();
                        changeMultiplier = !changeMultiplier;
                    } else {
                        hashCode = hashCode ^ (index * 13);//only for support {"a",null,null,"a"} <> {null,"a","a",null}
                    }
                }
            }
            return hashCode;
        }

        /// <summary>
        /// Override the equality comparer.
        /// </summary>
        /// <param name="thisObject">The first object to compare.</param>
        /// <param name="thatObject">The second object to compare.</param>
        /// <returns>True when the two objects are equal; false otherwise.</returns>
        public static bool operator ==(ValueObject<T> thisObject, ValueObject<T> thatObject) {
            return Equals(thisObject, null) ?
                (Equals(thatObject, null)) :
                thisObject.Equals(thatObject);
        }

        /// <summary>
        /// Override the not equals comparer.
        /// </summary>
        /// <param name="thisObject">The first object to compare.</param>
        /// <param name="thatObject">The second object to compare.</param>
        /// <returns>True when the two objects are not equal; false otherwise.</returns>
        public static bool operator !=(ValueObject<T> thisObject, ValueObject<T> thatObject) {
            return !(thisObject == thatObject);
        }

        /// <summary>
        /// Determines whether this object is valid or not.
        /// </summary>
        /// <param name="validationContext">Describes the context in which a validation check is performed.</param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);

        /// <summary>
        /// Determines whether this object is valid or not.
        /// </summary>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public IEnumerable<ValidationResult> Validate() {
            var validationErrors = new List<ValidationResult>();
            var ctx = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, ctx, validationErrors, true);
            return validationErrors;
        }
    }
}
