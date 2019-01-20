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
        private IDetentionPlaceRepository placeRepository;

        public DetentionPlaceService(IDetentionPlaceRepository data)
        {
            this.placeRepository = data;
        }

        public bool AddDetentionPlace(DetentionPlace place)
        {
            if(Checker.CheckedForNull(place) && placeRepository.AddDetentionPlace(place))
            {
                return true;
            }
            return false;
            
        }

        public bool DeleteDetentionPlaceById(int? Id)
        {
            if(Checker.CheckedForNull(Id) && placeRepository.DeleteDetentionPlaceById(int.Parse(Id.ToString())))
            {
                return true;
            }
            return false;
        }

        public List<DetentionPlace> GetAllDetentionPlaces()
        {
            return placeRepository.GetAllDetentionPlaces();
        }

        public DetentionPlace GetDetentionPlaceById(int? Id)
        {
            if(Checker.CheckedForNull(Id))
            {
                return placeRepository.GetDetentionPlaceById(int.Parse(Id.ToString()));
            }
            else
            {
                return null;
            }
            
        }

        public bool EditDetentionPlace(DetentionPlace department)
        {
            if(Checker.CheckedForNull(department) && placeRepository.EditDetentionPlace(department))
            {
                return true;
            }
            return true;
        }

        public List<DetentionPlace> GetAllDetentionPlacesAndSwap(int? Id)
        {
            List<DetentionPlace> places = placeRepository.GetAllDetentionPlaces();

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

        public bool IsUsing(int? Id)
        {
            if(Id != null)
            {
                int id = int.Parse(Id.ToString());
                List<int> ids = placeRepository.GetUsingIds();
                if(ids != null)
                {
                    foreach(var item in ids)
                    {
                        if(item == id)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
