﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.MailServiceInterfaces
{
    public interface IMailServiceRepository
    {
        void SendReservationApprovalEmail(string toEmail, string name);
    }
}
