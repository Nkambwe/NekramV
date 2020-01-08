/*Interface: IAttachedObject
 * Description: Interfaces is used to identify collection objects
 *              that are not attatched to any parent object. For example 
 *              an items without a category, files without clients.
 *              This usually happens when the parent object is deleted form 
 *              the database and the children are not deleted.
 * Usage: Interface is implemented by owned objects
 * Created On:  January 8 2020
 */

namespace Nekram.Models {

    public interface IOwned<T> {
        T Owner { get; set; }
    }
}
