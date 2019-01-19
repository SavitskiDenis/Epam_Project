using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SpecialInsulator.Common.Checker;

namespace SpecialInsulator.BLL.Implementations
{
    public class DetentionPlaceService : IDetentionPlaceService
    {
        IDetentionPlaceRepository data;

        public DetentionPlaceService(IDetentionPlaceRepository data)
        {
            this.data = data;
        }

        public bool AddDetentionPlace(DetentionPlace place)
        {
            if(Checker.CheckedForNull(place) && data.AddDetentionPlace(place))
            {
                return true;
            }
            return false;
            
        }

        public bool DeleteDetentionPlaceById(int? Id)
        {
            if(Checker.CheckedForNull(Id) && data.DeleteDetentionPlaceById(int.Parse(Id.ToString())))
            {
                return true;
            }
            return false;
        }

        public List<DetentionPlace> GetAllDetentionPlaces()
        {
            return data.GetAllDetentionPlaces();
        }

        public DetentionPlace GetDetentionPlaceById(int? Id)
        {
            if(Checker.CheckedForNull(Id))
            {
                return data.GetDetentionPlaceById(int.Parse(Id.ToString()));
            }
            else
            {
                return null;
            }
            
        }

        public bool EditDetentionPlace(DetentionPlace department)
        {
            if(Checker.CheckedForNull(department) && data.EditDetentionPlace(department))
            {
                return true;
            }
            return true;
        }

        public List<DetentionPlace> GetAllDetentionPlacesAndSwap(int? Id)
        {
            List<DetentionPlace> places = data.GetAllDetentionPlaces();

            int index = places.IndexOf(places.Where(item => item.Id == Id).FirstOrDefault());
            if(index > 0)
            {
                DetentionPlace myPlace = places[index];
                places[index] = places[0];
                places[0] = myPlace;

            }

            return places;
        }

        public bool IsNewPlace(string address)
        {
            List<DetentionPlace> places = GetAllDetentionPlaces();

            foreach(var item in places)
            {
                if(item.Address.ToLower() == address.ToLower())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
