﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Partner
{
    public class BookInOrder : BaseEntity
    {
        public Guid? BookId { get; set; }
        public Book? Book { get; set; }
        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }
        public int? Quantity { get; set; }
    }
}
