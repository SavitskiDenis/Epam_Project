using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.Text;

namespace Special_Insulator.Advertising
{
    
    public class Service1 : IService1
    {
        public Dictionary<Url[], string[]> GetImages()
        {
            Dictionary<Url[], string[]> context = new Dictionary<Url[], string[]>
            {
                [new Url[] { new Url("https://avatars.mds.yandex.net/get-direct/364654/Hv43fCnvcwFUS9K622akjg/y300"), new Url("https://an.yandex.ru/count/6woC4b_bD6y503a2CM9_F5m00000EEwO7a02I09Wl0Xe172KdglI1u01qeVx7eW1nwkI-JYG0UY4ZBWnc06kWuoqCg01x8ICk36e0VI0ZBGok07-_uNt6i010jW1x9wX5U01qhkV5UW1UFW1lhtUlW680WUW0kBDaHUv0eQRPkWOxc7Ly0Bp_eUN3FW2We20W82G6O03sUN4aGo80upervu6c0EuzWAW0mYe0mgm0mIm106u1Fy1w0IT3lW4qvqAY0NJdGgG1UJG2g05nuy3g0Nxp0Am1VlC0hW5-za2m0MxW0p81T260z05-ym2u0LPy0K1c0Qqh9ySe0Qy0gW6l0B91YUWn5uYY7PGqGPrb2b7oDLuDza60000i8i0002G1ogf1_rjd45lnqR-i0U0W90aq0S2u0U62l47y5RTNYKInUo020BG2BgAX870a802u0ZnviWBW0e1mGe00000003mFzWA0k0AW8bw-0g0jHY82mwg2n21Q9Mw_Mq00Fn6lXvgVmK0m0k0emN82u3Kam7P2_rjd45lnqR-w0lJdGhm2mQ83Bwzthu1w0mRc0tGfjG1u0q2YGu00000000mF90Em8Gzc0wdm9BsfOIYkr2W3i24FR0E0Q4F00000000y3-e3_tRmPZKxR6Z_W7P3qesz2j1L-m_u0y1W12NWESHa12niO2ekUlMtYUQ40aH00000000y3_840Ju4F___________m604Vp__________m684G6G4G80?stat-id=7&test-tag=110501010878977&format-type=76&banner-test-tags=eyI2NjM1NDg3NTQwIjoiMTEwNTAwOTE4NjI0MjU2In0%3D&") }] =  new string[] { "Научитесь зарабатывать на рекламе", "Зарабатывайте на рекламе в соц сетях! Регистрируйтесь и получите pdf-руководство." } ,
                [new Url[] { new Url("https://avatars.mds.yandex.net/get-direct/1548818/TSqU8tZetcFakyvSz2swGQ/y300"), new Url("https://an.yandex.ru/count/54ND_qBG6ou503e2CQ-0F5m00000EEwO7a02I09Wl0Xe173AtApH2e01W9A1YRlWmQA10OW1YC_R-pYG0UZqmxanc07YpO6tCg01ei33kJ6e0U3DWRSok06MjE7t6i010jW1eep95k01pjVt1UW1g07u0Th2thu1Y082e0BusA8NkGA6csRe6EvXrV02f9BXgmBu0eA0W820a1c00-7qhuK5Y0FbjCWsc0E9WWAW0mIe0mIm0mIu1Fy1w0JF9VW4uhq7Y0NYlGUG1U742A05cgG2g0N0ym6m1S3p0RW5wPK2m0MFwmN81Vcz0T05l_C1u0Kvy0K1c0Q0qApp3g06l0Ae1hm2oGOdeCHU8eXsKD46TPGfHyZLU3VP1W000B2B0000a0SggGVzRKG3nHP7_h07W82G9D070k07XWhn1ut699VRl51VW0W2q0YwYe21m9200k08lApH2u0A0S4A9r92V_Pczp_O2WBW2e29UlWAWBKOY0i4gWiGkhq_GFrj001RjvCoQdy50C0BWAC5o0k0r9C1sGlzRKG3nHP7_kWBuhq7y0i6Y0pQmjw-0UWC6vWDmx7L0U0D0eaE00000000i3wG3i24FPWEfy2IzgM4ehjGe0x0X3sm3W6X3m0000000F0_g0_zs-72hTZ5e_u1sGy00000003mF-0F0O0GXjFr4f0GiR60gBdhrjudcX094G0000000F0_-13___________y1W17y__________y1Y141a142?stat-id=2&test-tag=110501010868225&format-type=2&banner-test-tags=eyI2NjM2OTkzODQ0IjoiMTEwNTAwOTE4NjI0MjU2In0%3D&") }] = new string[] { "Делаем хорошие сайты", "Мы знаем, как делать крутые сайты. Создаем, продвигаем, сопровождаем." },
            };

            
            return context;
        }
    }
}
