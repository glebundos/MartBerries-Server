﻿using MartBerries_Server.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Commands
{
    public class UpdateOrderSubmittedMoneyCommand : IRequest<Order>
    {
        public Guid Id { get; set; }

        public decimal SubmittedMoney { get; set; }
    }
}
