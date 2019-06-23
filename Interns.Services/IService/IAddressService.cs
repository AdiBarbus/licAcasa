using System.Collections.Generic;
using Interns.Core.Data;

namespace Interns.Services.IService
{
    public interface IAddressService
    {
        IList<Address> GetAddresses();
        Address GetAddress(int id);
        void InsertAddress(Address address);
        void DeleteAddress(int id);
        void UpdateAddress(Address address);
    }
}