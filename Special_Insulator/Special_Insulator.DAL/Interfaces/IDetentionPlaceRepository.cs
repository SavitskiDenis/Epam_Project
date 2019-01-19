using SpecialInsulator.Common.Entity;
using System.Collections.Generic;


namespace SpecialInsulator.DAL.Interfaces
{
    public interface IDetentionPlaceRepository
    {
        bool AddDetentionPlace(DetentionPlace place);

        List<DetentionPlace> GetAllDetentionPlaces();

        DetentionPlace GetDetentionPlaceById(int Id);

        bool DeleteDetentionPlaceById(int Id);

        bool EditDetentionPlace(DetentionPlace place);
    }
}
