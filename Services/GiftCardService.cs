﻿using BookingApp.Domain.Model;
using BookingApp.Repository;
using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Domain.RepositoryInterfaces;

namespace BookingApp.Services
{
    public class GiftCardService
    {
        public IGiftCardRepository GiftCardRepository { get; set; }

        public GiftCardService(IGiftCardRepository giftCardRepository)
        {
            GiftCardRepository = giftCardRepository;
        }

        public GiftCard Save(GiftCard giftCard)
        {
            return GiftCardRepository.Save(giftCard);
        }

        public List<GiftCard> GetAll()
        {
            return GiftCardRepository.GetAll();
        }
    }
}
