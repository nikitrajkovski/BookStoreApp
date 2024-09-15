using Domain.Partner;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class PartnerPublisherService : IPartnerPublisherService
    {
        private readonly IPartnerRepository<Publisher> _publisherRepository;

        public PartnerPublisherService(IPartnerRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public void CreateNewPublisher(Publisher publisher)
        {
            _publisherRepository.Insert(publisher);
        }

        public void DeletePublisher(Guid id)
        {
            var publisher = _publisherRepository.Get(id);
            _publisherRepository.Delete(publisher);
        }

        public List<Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAll().ToList();
        }

        public Publisher GetDetailsForPublisher(Guid? id)
        {
            return _publisherRepository.Get(id);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            _publisherRepository.Update(publisher);
        }
    }
}
