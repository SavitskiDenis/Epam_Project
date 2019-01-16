using System;
using System.Collections.Generic;
using System.Security.Policy;
using SpecialInsulator.Common.Entity;

namespace Special_Insulator.WCF
{

    public class AdvertisingService : IAdvertisingWCFService
    {
        public List<Advertising> GetAdversiting()
        {
            return new List<Advertising> {
                new Advertising {Image = new Url("https://avatars.mds.yandex.net/get-direct/364654/Hv43fCnvcwFUS9K622akjg/y300"),
                                Title = "Научитесь зарабатывать на рекламе",
                                Context = "Зарабатывайте на рекламе в соц сетях! Регистрируйтесь и получите pdf-руководство.",
                                Address = new Url("http://cpa-4biz.com")},
                new Advertising {Image= new Url("https://avatars.mds.yandex.net/get-direct/1548818/TSqU8tZetcFakyvSz2swGQ/y300"),
                                Title = "Делаем хорошие сайты",
                                Context = "Мы знаем, как делать крутые сайты. Создаем, продвигаем, сопровождаем.",
                                Address = new Url("https://electron.agency/index.html")}
            };
        }
    }
}
