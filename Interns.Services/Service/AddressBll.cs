//using System.Collections.Generic;
//using InternsDataAccessLayer.Entities;
//using InternsDataAccessLayer.Repository;

//namespace InternsBusiness.Business
//{
//    public class AddressBll : IAddressBll
//    {
//        private readonly IAddressRepository repository;

//        public AddressBll(IAddressRepository repo)
//        {
//            repository = repo;
//        }

//        public IList<Address> GetAllAddresses()
//        {
//            return repository.GetAll();
//        }

//        public Address GetAddressById(int id)
//        {
//            return repository.GetById(id);
//        }
//        public void AddAddress(Address address)
//        {
//            if (address != null)
//            {
//                repository.Insert(address);
//                Save();
//            }
//        }

//        public void DeleteAddress(int id)
//        {
//            repository.Delete(id);
//            Save();
//        }

//        public void EditAddress(Address address)
//        {
//            repository.Update(address);
//            Save();
//        }

//        public void Save()
//        {
//            repository.Save();
//        }
//    }
//}
