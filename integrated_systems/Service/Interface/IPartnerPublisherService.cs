﻿using Domain.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPartnerPublisherService
    {
        List<Publisher> GetAllPublishers();
        Publisher GetDetailsForPublisher(Guid? id);
        void CreateNewPublisher(Publisher publisher);
        void DeletePublisher(Guid id);
        void UpdatePublisher(Publisher publisher);
    }
}